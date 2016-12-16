using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Drivers;
using EnMon_Driver_Manager.Drivers.Abstract;
using EnMon_Driver_Manager.Models;
using EnMon_Driver_Manager.Models.Device;
using IniParser;
using IniParser.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EnMon_Driver_Manager.Modbus
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="EnMon_Driver_Manager.Modbus.AbstractModbusDriver" />
    public class ModbusTCP : AbstractModbusDriver, ITCPDriver, IEnumerable
    {
        #region Private Properties
        private ParallelLoopResult loopResult { get; set; }
        #endregion Private Properties

        #region Public Properties

        public int PortNumber { get; set; }

        public List<string> ipAddresses { get; set; }

        public new List<ModbusTCPDevice> Devices { get; set; }

        public new List<ModbusTCPClient> TCPClients { get; set; }

        #endregion Public Properties

        #region Constructors
        public ModbusTCP() : base()
        {
            communicationProtocol = new CommunicationProtocol() { Name = "ModbusTCP" };
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModbusTCP"/> class.
        /// </summary>
        /// <param name="_configFile">The configuration file.</param>
        public ModbusTCP(string _configFile) : base(_configFile)
        {

        }

        #endregion Constructors

        #region Events

        public void DeviceConnectionStateChanged(object source, TCPClientEventArgs e)
        {
            DBHelper.UpdateDeviceConnectedState(e.Device.ID, e.Device.Connected);
        }

        /// <summary>
        /// Handles the AnyAnalogSignalValueChanged event of the _modbusServer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void AnyAnalogSignalValueChanged(object sender, TCPClientEventArgs e)
        {
            DBHelper.AddAnalogSignalsToDataBaseWriteBuffer(e.AnalogSignals);
        }

        public void AnyBinarySignalValueChanged(object sender, TCPClientEventArgs e)
        {
            DBHelper.AddBinarySignalsToDataBaseWriteBuffer(e.BinarySignals);
        }

        public void DisconnectedFromServer(object sender, TCPClientEventArgs e)
        {
            SetDevicesAsDisconnected(e.Devices);
        }

        public void ConnectedToServer(object sender, TCPClientEventArgs e)
        {
            Log.Instance.Trace("{0}: {1} baglantı kuruldu", MethodBase.GetCurrentMethod().Name, e.ipAddress);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the ip list from devices.
        /// </summary>
        protected List<string> GetIpAddressListFromDevices()
        {
            Log.Instance.Trace("{0}: {1} methodu çağrıldı", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            List<string> _ipAddresses = new List<string>();
            try
            {
                _ipAddresses = Devices.Select(d => d.IpAddress).Distinct().ToList();
                return _ipAddresses;
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }

        /// <summary>
        /// Connects to modbus servers.
        /// </summary>
        /// <param name="_ipAddress">The ip address.</param>
        /// <param name="pls">The PLS.</param>
        private void ConnectToModbusServer(string _ipAddress, ParallelLoopState pls)
        {
            Log.Instance.Trace("{1}: {2} methodu {0} ip adresi için cagrıldı", _ipAddress, this.GetType().Name, MethodBase.GetCurrentMethod().Name);

            try
            {
                // Verilen IP adresi icin modbusTCPMaster olusturuluyor
                ModbusTCPClient _modbusTCPClient = new ModbusTCPClient(_ipAddress, ReadTimeOut, RetryNumber, PollingTime, MaxRegisterInOnePoll);

                // modbusTCPClient'ın haberleşeceği cihazlar modbusTCPCLient instance'in Devices property'sine ekleniyor.
                _modbusTCPClient.Devices = (from d in Devices where d.IpAddress == _ipAddress select d).ToList();

                // Sinyal okumayı hızlandırmak için tüm sinyaller liste modbus adreslerine göre sıralanıyor.
                foreach (ModbusTCPDevice d in _modbusTCPClient.Devices)
                {
                    if (d.BinarySignals.Count > 0)
                    {
                        d.BinarySignals = d.BinarySignals.OrderBy(b => b.Address).ThenBy(b => b.ComparisonBitNumber).ToList();
                    }
                    if (d.AnalogSignals.Count > 0)
                    {
                        d.AnalogSignals = d.AnalogSignals.OrderBy(a => a.Address).ToList();
                    }
                    if (d.CommandSignals.Count > 0)
                    {
                        d.CommandSignals = d.CommandSignals.OrderBy(a => a.Address).ToList();
                    }
                }

                // Eventler ayarlanıyor
                _modbusTCPClient.ConnectedToServer += ConnectedToServer;
                _modbusTCPClient.DisconnectedFromServer += DisconnectedFromServer;
                _modbusTCPClient.AnyBinarySignalValueChanged += AnyBinarySignalValueChanged;
                _modbusTCPClient.AnyAnalogSignalValueChanged += AnyAnalogSignalValueChanged;
                _modbusTCPClient.DeviceConnectionStateChanged += DeviceConnectionStateChanged;
                TCPClients.Add(_modbusTCPClient);

                _modbusTCPClient.Connect();
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0}: Driver baglantı hatası => {1}", this.GetType().Name, e.ToString());
            }
        }
        
        #endregion Private Methods

        #region Protected Override Methods

        /// <summary>
        /// Devices listesindeki tüm cihazların dogru protokol ile haberleşip haberleşmediğini kontrol eder.
        /// Protokolü farklı device varsa onu driver'in devices listesinden çıkartır ve o device ile baglantı kurmaz.
        /// </summary>


        /// <summary>
        /// Connects this instance.
        /// </summary>
        protected override void Communicate()
        {
            loopResult = Parallel.ForEach(ipAddresses, ConnectToModbusServer);

            // Belli aralıklarla web scadadan komut gönderilip gönderilmediği kontrol etmek için timer oluşturuluyor.
            InitializeTimerForCheckingActiveCommandsAtDatabase();
        }

        /// <summary>
        /// Initializes the driver.
        /// </summary>
        protected override void InitializeDriver()
        {
            ipAddresses = GetIpAddressListFromDevices();

            if (ipAddresses != null)
            {
                // if (ipAddresses.Count>0)
                {
                    TCPClients = new List<ModbusTCPClient>();
                    Log.Instance.Trace("{0}: Modbus driver olusturuldu.", this.GetType().Name);
                    IsError = false;
                }
            }
            else
            {
                Log.Instance.Error("{0} Hata: ModbusTCP Server cihazları için Ip adres bilgisi bulunamadı. Driver olusturulamıyor...", this.GetType().Name);
                IsError = true;
            }
        }

        protected override void GetCommunicationParametersFromConfigFile(string _configFile)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(_configFile, Encoding.UTF8);
            var _parameters = data["Communication Parameters"];

            foreach (KeyData kd in _parameters)
            {
                switch (kd.KeyName.Trim())
                {
                    case "ReadTimeOut":
                        ReadTimeOut = Convert.ToInt32(kd.Value.Trim());
                        break;

                    case "RetryNumber":
                        RetryNumber = Convert.ToInt32(kd.Value.Trim());
                        break;

                    case "PollingTime":
                        PollingTime = Convert.ToInt32(kd.Value.Trim());
                        break;

                    case "PortNumber":
                        PortNumber = Convert.ToInt32(kd.Value.Trim());
                        break;

                    case "MaxRegisterInOnePoll":
                        MaxRegisterInOnePoll = Convert.ToByte(kd.Value.Trim());
                        break;

                    default:
                        break;
                }
            }
        }

        protected override void SetDefaultCommunicationParameters()
        {
            ReadTimeOut = 1000;
            RetryNumber = 1;
            PollingTime = 1000;
            PortNumber = 502;
            MaxRegisterInOnePoll = 16;
        }

        protected override void GetStationDevicesAndSignalsInfo()
        {
            Devices = new List<ModbusTCPDevice>();
            if (Stations.Count > 0)
            {
                foreach (Station s in Stations)
                {
                    //TODO: Verifyprotocolofdevices methodu kullanmak yerine cihazlar database'den protokolune göre çekilebilir
                    List<ModbusTCPDevice> _stationDevices = DBHelper.GetStationModbusTCPDevices(s);


                    // Haberleşme protokolü farklı olan device'lar bu driver ile haberleşemeyeceği için listeden çıkartılıyor
                    _stationDevices = VerifyProtocolofDevices(_stationDevices, communicationProtocol.Name);

                    if (_stationDevices.Count > 0)
                    {
                        // Her device için device'a ait sinyaller veritabanından çekilir
                        foreach (ModbusTCPDevice d in _stationDevices)
                        {
                            d.BinarySignals = DBHelper.GetModbusDeviceSignalsInfo<ModbusBinarySignal>(d);
                            d.AnalogSignals = DBHelper.GetModbusDeviceSignalsInfo<ModbusAnalogSignal>(d);
                            d.CommandSignals = DBHelper.GetModbusDeviceSignalsInfo<ModbusCommandSignal>(d);
                        }

                        s.ModbusTCPDevices = _stationDevices;
                        Devices.AddRange(_stationDevices);
                    }
                    else
                    {
                        Log.Instance.Info("{0}: {1} adlı istasyon için kayıtlı cihaz bulunamadı", this.GetType().Name, s.Name);
                    }
                }

                if (Devices.Count > 0)
                {
                    InitializeDriver();
                }

                else
                {
                    Log.Instance.Error("{0} Hata: İstasyonlar altında kayıtlı cihaz bulunamadı. Driver başlatılamıyor...", this.GetType().Name);
                    IsError = true;
                }
            }
            else
            {
                Log.Instance.Error("{0} Hata: Config dosyasında geçerli istasyon adı bulunamadı. Driver başlatılamıyor...", this.GetType().Name);
                IsError = true;
            }
        }

        public override void SetDriverAllDevicesDisconnected()
        {
            CommunicationProtocol _protocol = new CommunicationProtocol() { ID = 0, Name = "ModbusTCP" };
            DBHelper.SetDriverDevicesDisconnected(_protocol);
        }

        protected override void SendCommand(DataRow dr)
        {
            ModbusTCPDevice _device;
            ModbusCommandSignal _command;

            // Komutun gideceği cihaz bulunur.
            _device = Devices.Where((d) => d.CommandSignals.Exists((c) => c.ID == dr.Field<uint>("command_signal_id"))).FirstOrDefault();

            if (_device != null)
            {
                // Komut sinyalinin bilgileri alınır.
                _command = _device.CommandSignals.Where((c) => c.ID == dr.Field<uint>("command_signal_id")).First();
                _command.CommandValue = dr.Field<float>("value");
                try
                {
                    if (_command != null)
                    {
                        // komut gönderilecek device'in hangi TCPClient üzerinden haberleştiği bulunur ve komut gönderilir.
                        AbstractTCPClient TCPClient = TCPClients.Where((m) => m.Devices.Exists((d) => d.ID == _device.ID)).First();

                        if (TCPClient.WriteValue(_device, _command))
                        {
                            DBHelper.DeleteActiveCommandFromDatabase(dr.Field<uint>("command_signal_id"));
                        }

                    }
                }
                catch (Exception ex)
                {
                    Log.Instance.Error("{0} adlı cihaza {1} komutu gönderirirken hata => {2}", _device.Name, _command.Name, ex.Message);
                }
            }
        }

        protected override void CycleForCommands_Elapsed(object sender, ElapsedEventArgs e)
        {
            {
                cycleForCommands.Stop();

                // Veritabanından active_commands tablosu okunuyor.
                DataTable dt_activeCommands = DBHelper.GetDriverActiveCommands("ModbusTCP");

                // active_commands tablosundan veri donduyse web scadadan komut gelmiş demektir.
                if (dt_activeCommands != null)
                {
                    if (dt_activeCommands.Rows.Count > 0)
                    {
                        // Veritabanından gelen her komut için ayrı işlem yapılır.
                        foreach (DataRow dr in dt_activeCommands.Rows)
                        {
                            SendCommand(dr);
                        }
                    }
                }

                cycleForCommands.Start();
            }
        }

        public IEnumerator GetEnumerator()
        {
            if (TCPClients != null)
            {
                foreach (ModbusTCPClient client in TCPClients)

                {
                    yield return client;
                }
            }
        }

        public override void SetAllDevicesDisconnected()
        {
            DBHelper.SetDriverDevicesDisconnected(communicationProtocol);
        }


        #endregion Protected Override Methods
    }
}