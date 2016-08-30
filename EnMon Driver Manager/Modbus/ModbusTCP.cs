using EnMon_Driver_Manager.Models;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Modbus
{
    internal class ModbusTCP : AbstractDriver
    {
        #region Private Properties

        private List<string> ipAddresses;
        private int portNumber;
        private int retryNumber;
        private int readTimeOut;
        private List<string> connectedIpAdress;
        private List<string> notConnectedIpAdresses;
        private Dictionary<string, bool> connectionStatus;
        private Dictionary<string, ModbusIpMaster> modbusMasters;
        private List<Timer> timers;
        private Thread thread_Connect;
        private Dictionary<string, Thread> connectionThreads;

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



        #region Private Methods

        /// <summary>
        /// Herhangi bir ağ bağlantısı olup olmadığını kontrol eder.
        /// </summary>
        /// <returns></returns>
        private bool IsNetworkAvaliable()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        private /*bool /*ModbusIpMaster*/ async Task<bool> ConnectToModbusServerAsync(string _ipAddress)
        {
            Log.Instance.Trace("ConnectToModbusServerAsync methodu {0} için cagrıldı", _ipAddress);
            try
            {
                TcpClient tcpClient = new TcpClient();
                IAsyncResult asyncResult = tcpClient.BeginConnect(_ipAddress, portNumber, null, null);
                asyncResult.AsyncWaitHandle.WaitOne(3000, true); // 3 saniye içerisinde bağlantının kurulması bekleniyor.
                // 3 saniye  içerisinde baglantı cevap vermezse
                if (!asyncResult.IsCompleted)
                {
                    tcpClient.Close();
                    // TODO: Baglantı kurulamazsa database'de device ile ilgili "Communication Not Ok" diye bir bilgi tutulmalı.
                    Log.Instance.Error("Driver baglantı hatası: {0} ip adresi ile bağlantı kurulamadı", _ipAddress);
                    return false;
                }
                else
                {
                    // _ipAddress için modbus baglantısı olusturuluyor.
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

                    // TODO: Baglantı kuruldugunda database'de device ile ilgili "Communication Ok" diye bir bilgi tutulmalı. Database, driver manager ile bir baglantısı yoksa otomatik olarak bu sutunu "Communication Not OK" e cevirmeli.
                    Log.Instance.Info("{0} ip adresi ile bağlantı kuruldu", _ipAddress);
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("Driver baglantı hatası: " + e.Message);
                return false;
            }
        }

        #endregion Private Methods

        #region Public Override Methods

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

        public override async void Connect()
        {
            // Devices listesinde yer alan tüm device'ların haberleşme protokol ayarları kontrol ediliyor. Haberleşme protokolu ModbusTCP seçilmeyen device'lar listeden çıkartılıyor.
            VerifyProtocolofDevices();

            modbusMasters = new Dictionary<string, ModbusIpMaster>();
            connectionStatus = new Dictionary<string, bool>();
            connectedIpAdress = new List<string>();
            notConnectedIpAdresses = new List<string>();

            if (IsNetworkAvaliable())
            {
                // Devices listesinden tekil IP adresler alınıyor
                ipAddresses = new List<string>();
                ipAddresses = Devices.Select(d => d.IpAddress).Distinct().ToList();

                // Her ip adresi için bağlantı kuruluyor.
                foreach (string _ipAddress in ipAddresses)
                {
                    if (!connectionStatus.ContainsKey(_ipAddress))
                    {
                        connectionStatus.Add(_ipAddress, false);
                    }

                    connectionStatus[_ipAddress] = await ConnectToModbusServerAsync(_ipAddress);
                    // Baglantı kurulamaz ise null doner

                    //ModbusIpMaster master = ConnectToModbusServer(_ipAddress);
                    //if (master != null)
                    //{
                    //    modbusMasters.Add(_ipAddress, master);
                    //}
                    //else
                    //{
                    //    notConnectedIpAdresses.Add(_ipAddress);
                    //}
                }
            }
        }

        #endregion Public Override Methods
    }
}