using EnMon_Driver_Manager.Models;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace EnMon_Driver_Manager.Modbus
{
    public class ModbusTCP : AbstractDriver
    {
        #region Private Properties

        private List<string> ipAddresses;
        private List<string> connectedIpAdress;
        private List<string> notConnectedIpAdresses;
        public static List<ModbusServer> modbusServers;
        private static List<PollingTimer> timers;
        private static Dictionary<string, bool> connectionStatus;
        private static Dictionary<string, ModbusIpMaster> modbusMasters;
        private Dictionary<string, Timer> timers1;

        //private List<ModbusIpMaster> modbusMasters;

        #endregion Private Properties

        #region Constructors

        public ModbusTCP(List<string> _ipAddresses)
        {
            // TODO: ipaddress yerine driver dosyasının adı verilebilir. Ya da ModbusCommSettings diye bir model olusturularak tüm ayarlar buraya atanıp burdan okunabilir.
            ipAddresses = _ipAddresses;
            portNumber = 502;
            modbusServers = new List<ModbusServer>();
            foreach (string _ipAddress in _ipAddresses)
            {
                ModbusServer _modbusClient = new ModbusServer(_ipAddress, portNumber);
                modbusServers.Add(_modbusClient);
            }
            Log.Instance.Trace("Modbus driver olusturuldu.");
        }

        public ModbusTCP(List<string> _ipAddresses, int _portNumber)
        {
            ipAddresses = _ipAddresses;
            portNumber = _portNumber;
            Log.Instance.Trace("Modbus driver olusturuldu.");
        }

        public ModbusTCP(string _ipAddress, int _portnumber)
        {
            if (modbusServers == null)
            {
                modbusServers = new List<ModbusServer>();
            }

            ModbusServer _modbusServer = new ModbusServer(_ipAddress, _portnumber);
            modbusServers.Add(_modbusServer);
            Log.Instance.Trace("Modbus driver olusturuldu.");
        }

        public ModbusTCP(string _ipAddress)
        {
            if (modbusServers == null)
            {
                modbusServers = new List<ModbusServer>();
            }
            ModbusServer _modbusClient = new ModbusServer(_ipAddress);
            modbusServers.Add(_modbusClient);
            Log.Instance.Trace("Modbus driver olusturuldu.");
        }

        #endregion Constructors

        public int PortNumber
        {
            get { return portNumber; }
            set { portNumber = value; }
        }

        #region Private Methods

        /// <summary>
        /// Herhangi bir ağ bağlantısı olup olmadığını kontrol eder.
        /// </summary>
        /// <returns></returns>
        private bool IsNetworkAvaliable()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        /// <summary>
        /// Devices listesinde yer alan deviceları kontrol ederek tekil IP listesini çıkarır.
        /// </summary>
        private void GetIpListFromDevices()
        {
            
            ipAddresses = new List<string>();
            ipAddresses = Devices.Select(d => d.IpAddress).Distinct().ToList();
        }

        /// <summary>
        /// Verilen ip adresindeki modbus server cihazına baglanır.
        /// </summary>
        /// <param name="_ipAddress"></param>
        /// <param name="pls"></param>
        private static void /*bool /*ModbusIpMaster*/ ConnectToModbusServer(string _ipAddress, ParallelLoopState pls)
        {
            Log.Instance.Trace("ConnectToModbusServerAsync methodu {0} için cagrıldı", _ipAddress);

            bool status = false;
            try
            {
                // Server ile TCP baglantısı olusturuluyor
                TcpClient tcpClient = new TcpClient();
                IAsyncResult asyncResult = tcpClient.BeginConnect(_ipAddress, portNumber, null, null);
                asyncResult.AsyncWaitHandle.WaitOne(3000, true); // 3 saniye içerisinde bağlantının kurulması bekleniyor.
                // 3 saniye  içerisinde baglantı cevap vermezse
                if (!asyncResult.IsCompleted)
                {
                    tcpClient.Close();
                    // TODO: Baglantı kurulamazsa database'de device ile ilgili "Communication Not Ok" diye bir bilgi tutulmalı.
                    Log.Instance.Error("Driver baglantı hatası: {0} ip adresi ile bağlantı kurulamadı", _ipAddress);
                    status = false;
                }
                else
                {
                    // TCP baglantısı kurulduktan sonra _ipAddress için modbus baglantısı olusturuluyor ve daha sonra erişebilmek için dictionary'e atılıyor.
                    ModbusIpMaster master = ModbusIpMaster.CreateIp(tcpClient);
                    master.Transport.Retries = retryNumber;
                    master.Transport.ReadTimeout = readTimeOut;
                    if (modbusMasters.ContainsKey(_ipAddress))
                    {
                        modbusMasters[_ipAddress] = master;
                    }
                    else
                    {
                        modbusMasters.Add(_ipAddress, master); 
                    }
                    // Ipadresi için daha önce timer olusturulmamışsa sinyalleri okumak icin timer olusturuluyor.
                    if(_ipAddress != (from t in timers where t.hostAddress == _ipAddress select t.hostAddress).First())
                    {
                        PollingTimer timer = new PollingTimer(pollingTime);
                        timer.hostAddress = _ipAddress;
                        timer.Elapsed += ReadValuesFromServer;
                        timer.AutoReset = true;
                        timer.Enabled = true;
                    }
                    

                    // TODO: Baglantı kuruldugunda database'de device ile ilgili "Communication Ok" diye bir bilgi tutulmalı. Database, driver manager ile bir baglantısı yoksa otomatik olarak bu sutunu "Communication Not OK" e cevirmeli.
                    Log.Instance.Info("{0} ip adresi ile bağlantı kuruldu", _ipAddress);
                    status = true;
                }
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("Driver baglantı hatası: " + e.Message);
                status = false;
            }
            finally
            {
                if (connectionStatus.ContainsKey(_ipAddress))
                {
                    connectionStatus[_ipAddress] = status;
                }
                else
                {
                    connectionStatus.Add(_ipAddress, status);
                }
            }
        }

        private static void ReadValuesFromServer(Object source, ElapsedEventArgs e)
        {
            PollingTimer timer = (PollingTimer)source;
            timer.Enabled = false;
            try
            {
                if(connectionStatus[timer.hostAddress])
                {
                    var _serverDevices = from k in devices where k.IpAddress == timer.hostAddress select k;
                    ModbusIpMaster master = modbusMasters[timer.hostAddress];

                    // TODO: Degerleri okumaya basla
                }
                else
                {

                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion Private Methods

        #region Public Override Methods
        /// <summary>
        /// Devices listesinde yer alan tüm device'ların haberleşme protokol ayarları kontrol edilir. Haberleşme protokolu ModbusTCP seçilmeyen device'lar listeden çıkartılır.
        /// </summary>
        public override void VerifyProtocolofDevices()
        {
            foreach (Device device in Devices)
            {
                if (device.ProtocolID != Device.Protocol.ModbusTCP)
                {
                    Log.Instance.Warn("Yanlış protokol seçimi hatası: {0} adlı device'ın haberleşme protokolu ModbusTCP seçilmediği için bu device listeden çıkartılıyor.", device.Name);
                    Devices.Remove(device);
                }
            }
        }

        public override void Connect()
        {
            VerifyProtocolofDevices();

            GetIpListFromDevices();

            modbusMasters = new Dictionary<string, ModbusIpMaster>();
            connectionStatus = new Dictionary<string, bool>();
            connectedIpAdress = new List<string>();
            notConnectedIpAdresses = new List<string>();

            if (IsNetworkAvaliable())
            {
                ParallelLoopResult _loopResult = Parallel.ForEach(ipAddresses, ConnectToModbusServer);
            }
            else
            {
                Log.Instance.Error("Driver baglantı hatası: Aktif bir network bağlantısı bulunmamaktadır.");
            }
        }

        #endregion Public Override Methods
    }
}