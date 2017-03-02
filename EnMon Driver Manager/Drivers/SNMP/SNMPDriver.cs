using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Timers;
using System.Reflection;
using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Drivers.Abstract;
using EnMon_Driver_Manager.Models.Signals.SNMP;
using IniParser;
using IniParser.Model;

namespace EnMon_Driver_Manager.Drivers.SNMP
{
    public class SNMPDriver : AbstractDriver, ITCPDriver
    {

        #region Public Properties
        public int PollingTime { get; set; }



        public byte MaxRegisterInOnePoll { get; set; }

        public List<SNMPAnalogSignal> AnalogSignals { get; set; }

        public List<SNMPBinarySignal> BinarySignals { get; set; }

        public int PortNumber { get; set; }

        public List<string> ipAddresses { get; set; }

        public List<SNMPDevice> Devices { get; set; }

        #endregion

        #region Private Properties

        private ParallelLoopResult loopResult { get; set; }
    
        #endregion

        #region Constructors
        public SNMPDriver() : base()
        {

        }

        public SNMPDriver(string _configFile) : base(_configFile)
        {
            GetStationDevicesAndSignalsInfo();
        }
        #endregion

        #region Private Methods

        private void Communicate()
        {
            loopResult = Parallel.ForEach(ipAddresses, ConnectToSNMPAgents);

            // Belli aralıklarla web scadadan komut gönderilip gönderilmediği kontrol etmek için timer oluşturuluyor.
            InitializeTimerForCheckingActiveCommandsAtDatabase();
        }

        private void ConnectToSNMPAgents(string _ipAddress, ParallelLoopState pls)
        {
            Log.Instance.Trace("{1}: {2} methodu {0} ip adresi için cagrıldı", _ipAddress, this.GetType().Name, MethodBase.GetCurrentMethod().Name);

            try
            {
                // Verilen IP adresi icin SNMPClient olusturuluyor
                SNMPClient _snmpClient = new SNMPClient(_ipAddress, ReadTimeOut, RetryNumber, PollingTime);

                // SNMPClient'ın haberleşeceği cihazlar SNMPClient instance'in Devices property'sine ekleniyor.
                _snmpClient.Devices = (from d in Devices where d.IpAddress == _ipAddress select d).ToList();

                // Sinyal okumayı hızlandırmak için tüm sinyaller liste SNMP adreslerine göre sıralanıyor.
                foreach (SNMPDevice d in _snmpClient.Devices)
                {
                    if (d.BinarySignals.Count > 0)
                    {
                        d.BinarySignals = d.BinarySignals.OrderBy(b => b.Address).ToList();
                    }
                    if (d.AnalogSignals.Count > 0)
                    {
                        d.AnalogSignals = d.AnalogSignals.OrderBy(a => a.Address).ToList();
                    }
                    if (d.CommandSignals.Count > 0)
                    {
                        d.CommandSignals = d.CommandSignals.OrderBy(c => c.Address).ToList();
                    }
                }

                // Eventler ayarlanıyor
                _snmpClient.ConnectedToServer += ConnectedToServer;
                _snmpClient.DisconnectedFromServer += DisconnectedFromServer;
                _snmpClient.AnyBinarySignalValueChanged += AnyBinarySignalValueChanged;
                _snmpClient.AnyAnalogSignalValueChanged += AnyAnalogSignalValueChanged;
                _snmpClient.DeviceConnectionStateChanged += DeviceConnectionStateChanged;
                TCPClients.Add(_snmpClient);

                _snmpClient.Connect();
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0}: Driver baglantı hatası => {1}", this.GetType().Name, e.ToString());
            }
        }
        #endregion

        #region Public Override Methods
        public override void SetDriverAllDevicesDisconnected()
        {
            throw new NotImplementedException();
        }

        public override void StartCommunication()
        {
            Log.Instance.Trace("{0}: {1} methodu çağrıldı", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            try
            {
                Communicate();
                //TODO: Database'in değil de driverın kendi bufferı olması daha işlevsel olabilir.
                DBHelper.WriteValuesAtBufferToDatabase();
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0}: Driver baglantı hatası => {1} ", this.GetType().Name, e.Message);
            }
        }

        protected override void SendCommand(DataRow dr)
        {
            SNMPDevice _device;
            SNMPCommandSignal _command;

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
                DataTable dt_activeCommands = DBHelper.GetDriverActiveCommands(communicationProtocol.Name);

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

        protected override void SetDefaultCommunicationParameters()
        {
            ReadTimeOut = 1000;
            RetryNumber = 1;
            PollingTime = 30000;
            PortNumber = 161;

        }

        protected override void InitializeDriver()
        {
            ipAddresses = GetIpAddressListFromDevices();

            if (ipAddresses != null)
            {
                // if (ipAddresses.Count>0)
                {
                    TCPClients = new List<AbstractTCPClient>();
                    Log.Instance.Trace("{0}: SNMP driver olusturuldu.", this.GetType().Name);
                    IsError = false;
                }
            }
            else
            {
                Log.Instance.Error("{0} Hata: SNMP Server cihazlar için Ip adresi bulunamadı. Driver olusturulamıyor...", this.GetType().Name);
                IsError = true;
            }
        }

        private List<string> GetIpAddressListFromDevices()
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

        protected override void GetCommunicationParametersFromConfigFile(string _configFileLocation)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(_configFileLocation, Encoding.UTF8);
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

                    default:
                        break;
                }
            }
        }

        protected override void GetStationDevicesAndSignalsInfo()
        {
            Devices = new List<SNMPDevice>();
            if (Stations.Count > 0)
            {
                foreach (Station s in Stations)
                {

                    List<SNMPDevice> _stationDevices = DBHelper.GetStationDevices<SNMPDevice>(s);

                    if (_stationDevices.Count > 0)
                    {
                        // Her device için device'a ait sinyaller veritabanından çekilir
                        foreach (SNMPDevice d in _stationDevices)
                        {
                            d.BinarySignals = DBHelper.GetDeviceBinarySignalsInfo<SNMPBinarySignal>(d);
                            d.AnalogSignals = DBHelper.GetDeviceAnalogSignalsInfo<SNMPAnalogSignal>(d);
                            d.CommandSignals = DBHelper.GetDeviceCommandSignalsInfo<SNMPCommandSignal>(d);
                        }

                        s.SNMPDevices = _stationDevices;
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

        public void DeviceConnectionStateChanged(object source, TCPClientEventArgs e)
        {
            DBHelper.UpdateDeviceConnectedState(e.Device.ID, e.Device.Connected);
        }

        public void AnyAnalogSignalValueChanged(object sender, TCPClientEventArgs e)
        {
            DBHelper.AddAnalogSignalValueToDataBaseWriteBuffer(e.AnalogSignals);
        }

        public void AnyBinarySignalValueChanged(object sender, TCPClientEventArgs e)
        {
            DBHelper.AddBinarySignalValueToDataBaseWriteBuffer(e.BinarySignals);
        }

        public void DisconnectedFromServer(object sender, TCPClientEventArgs e)
        {
            SetDevicesAsDisconnected(e.Devices);
        }

        public void ConnectedToServer(object sender, TCPClientEventArgs e)
        {
            Log.Instance.Trace("{0}: {1} baglantı kuruldu", MethodBase.GetCurrentMethod().Name, e.ipAddress);
        }

        public override void SetAllDevicesDisconnected()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Protected Override Methods


        #endregion
    }
}
