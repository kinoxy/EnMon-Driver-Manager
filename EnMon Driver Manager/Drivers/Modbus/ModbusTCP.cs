using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models;
using IniParser;
using IniParser.Model;
using System;
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
    /// <seealso cref="EnMon_Driver_Manager.Modbus.AbstractDriver" />
    public class ModbusTCP : AbstractDriver
    {
        #region Private Properties

        private List<string> ipAddresses { get; set; }

        /// <summary>
        /// Gets or sets the modbus TCP masters.
        /// </summary>
        /// <value>
        /// The modbus TCP masters.
        /// </value>
        public List<ModbusTCPClient> modbusTCPClients { get; set; }

        /// <summary>
        /// Gets or sets the loop result.
        /// </summary>
        /// <value>
        /// The loop result.
        /// </value>
        private ParallelLoopResult loopResult { get; set; }

        private int portNumber;

        private Timer cycleForCommands;

        #endregion Private Properties

        #region Public Properties

        /// <summary>
        /// Gets or sets the port number.
        /// </summary>
        /// <value>
        /// The port number.
        /// </value>
        ///
        public int PortNumber
        {
            get { return portNumber; }
            set { portNumber = value; }
        }

        #endregion Public Properties

        #region Constructors

#pragma warning disable CS1573 // Parameter '_dbHelper' has no matching param tag in the XML comment for 'ModbusTCP.ModbusTCP(string, AbstractDBHelper)' (but other parameters do)
        /// <summary>
        /// Initializes a new instance of the <see cref="ModbusTCP"/> class.
        /// </summary>
        /// <param name="_configFile">The configuration file.</param>
        public ModbusTCP(string _configFile, AbstractDBHelper _dbHelper) : base(_configFile, _dbHelper) { }
#pragma warning restore CS1573 // Parameter '_dbHelper' has no matching param tag in the XML comment for 'ModbusTCP.ModbusTCP(string, AbstractDBHelper)' (but other parameters do)

        #endregion Constructors

        #region Private Methods

        /// <summary>
        /// Gets the ip list from devices.
        /// </summary>
        private List<string> GetIpAddressesFromDevices()
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

                // modbusTCPMaster'ın aynı ip adresi üzerinden haberleşeceği cihazlar ekleniyor.
                _modbusTCPClient.Devices = (from d in Devices where d.IpAddress == _ipAddress select d).ToList();

                // Sinyal okumayı hızlandırmak için tüm sinyaller liste içerisinde modbus adreslerine göre sıralanıyor.
                foreach (Device d in _modbusTCPClient.Devices)
                {
                    if (d.BinarySignals.Count > 0)
                    {
                        d.BinarySignals = d.BinarySignals.OrderBy(b => b.Address).ThenBy(b => b.BitNumber).ToList();
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
                _modbusTCPClient.ConnectedToServer += _modbusServer_ConnectedToServer;
                _modbusTCPClient.DisconnectedFromServer += _modbusServer_DisconnectedFromServer;
                _modbusTCPClient.AnyBinarySignalValueChanged += _modbusServer_AnyBinarySignalValueChanged;
                _modbusTCPClient.AnyAnalogSignalValueChanged += _modbusServer_AnyAnalogSignalValueChanged;
                _modbusTCPClient.DeviceConnectionStateChanged += _modbusTCPmaster_DeviceConnectionStateChanged;
                modbusTCPClients.Add(_modbusTCPClient);

                _modbusTCPClient.Connect();
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0}: Driver baglantı hatası => {1}", this.GetType().Name, e.ToString());
            }
        }

        private void _modbusTCPmaster_DeviceConnectionStateChanged(object source, ModbusEventArgs e)
        {
            DBHelper_Driver.UpdateDeviceConnectedState(e.Device.ID, e.Device.Connected);
        }

        /// <summary>
        /// Handles the AnyAnalogSignalValueChanged event of the _modbusServer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private static void _modbusServer_AnyAnalogSignalValueChanged(object sender, ModbusEventArgs e)
        {
            DBHelper_Driver.AddAnalogSignalsToDataBaseWriteBuffer(e.AnalogSignals);
        }

        private static void _modbusServer_AnyBinarySignalValueChanged(object sender, ModbusEventArgs e)
        {
            DBHelper_Driver.AddBinarySignalsToDataBaseWriteBuffer(e.BinarySignals);
        }

        private static void _modbusServer_DisconnectedFromServer(object sender, ModbusEventArgs e)
        {
            foreach (Device d in e.Devices)
            {
                if (d.Connected == true)
                {
                    d.Connected = false;
                    DBHelper_Driver.UpdateDeviceConnectedState(d.ID, d.Connected);
                }
            }
            //Log.Instance.Error("{0} ile bağlantı koptu", e.ipAddress);
            //throw new NotImplementedException();
        }

        private static void _modbusServer_ConnectedToServer(object sender, ModbusEventArgs e)
        {
            Log.Instance.Trace("{0}: {1} baglantı kuruldu", MethodBase.GetCurrentMethod().Name, e.ipAddress);
            //_modbusTCPmaster.ReadValuesFromModbusServer();
            //throw new NotImplementedException();
        }

        #endregion Private Methods

        #region Protected Override Methods

        /// <summary>
        /// Devices listesindeki tüm cihazların dogru protokol ile haberleşip haberleşmediğini kontrol eder.
        /// Protokolü yanlış seçilmiş device varsa onu driver'in devices listesinden çıkartır ve o device ile baglantı kurmaz.
        /// </summary>
        protected override List<Device> VerifyProtocolofDevices(List<Device> _devices)
        {
            foreach (Device device in _devices)
            {
                if (device.ProtocolID != Device.Protocol.ModbusTCP)
                {
                    Log.Instance.Warn("Modbus Driver Uyarı: {0} adlı device'ın haberleşme protokolu ModbusTCP seçilmemiş Haberleşilecek cihazlar listesinden çıkartılıyor...", device.Name);
                    _devices.Remove(device);
                }
            }
            return _devices;
        }

        /// <summary>
        /// Connects this instance.
        /// </summary>
        protected override void ConnectToModbusDevices()
        {
            loopResult = Parallel.ForEach(ipAddresses, ConnectToModbusServer);

            InitializeTimerForCheckingActiveCommandsFromDatabase();
        }

        private void InitializeTimerForCheckingActiveCommandsFromDatabase()
        {
            cycleForCommands = new Timer(1000);
            cycleForCommands.Elapsed += CycleForCommands_Elapsed;
            cycleForCommands.Start();
        }

        private void CycleForCommands_Elapsed(object sender, ElapsedEventArgs e)
        {
            cycleForCommands.Stop();
            DataTable dt_activeCommands = DBHelper_Driver.GetActiveCommands();
            if (dt_activeCommands.Rows.Count > 0)
            {
                foreach (DataRow dr in dt_activeCommands.Rows)
                {
                    SendCommand(dr);
                }
            }
            cycleForCommands.Start();
        }

        private void SendCommand(DataRow dr)
        {
            Device _device;
            CommandSignal _command;
            _device = Devices.Where((d) => d.CommandSignals.Exists((c) => c.ID == dr.Field<uint>("command_signal_id"))).First();
            _command = _device.CommandSignals.Where((c) => c.ID == dr.Field<uint>("command_signal_id")).First();
            _command.CommandValue = dr.Field<float>("value");
            try
            {
                if (_command != null && _device != null)
                {
                    ModbusTCPClient modbusTCPClient = modbusTCPClients.Where((m) => m.Devices.Exists((d) => d.ID == _device.ID)).First();
                    modbusTCPClient.WriteValue(_device, _command);
                    DBHelper_Driver.DeleteActiveCommand(dr.Field<uint>("command_signal_id"));
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0} adlı cihaza {1} komutu gönderirirken hata  oluştu => {2}", _device.Name, _command.Name, ex.Message);
            }
        }

        /// <summary>
        /// Initializes the driver.
        /// </summary>
        protected override void InitializeDriver()
        {
            ipAddresses = GetIpAddressesFromDevices();

            if (ipAddresses != null)
            {
                // if (ipAddresses.Count>0)
                {
                    modbusTCPClients = new List<ModbusTCPClient>();
                    Log.Instance.Trace("{0}: Modbus driver olusturuldu.", this.GetType().Name);
                    IsError = false;
                }
            }
            else
            {
                Log.Instance.Error("{0} Hata: ModbusTCP Server cihazlar için Ip adresi bulunamadı. Driver olusturulamıyor...", this.GetType().Name);
                IsError = true;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModbusTCP.GetCommunicationParametersFromConfigFile(string)'
        protected override void GetCommunicationParametersFromConfigFile(string _configFile)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModbusTCP.GetCommunicationParametersFromConfigFile(string)'
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModbusTCP.SetDefaultCommunicationParameters()'
        protected override void SetDefaultCommunicationParameters()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModbusTCP.SetDefaultCommunicationParameters()'
        {
            ReadTimeOut = 1000;
            RetryNumber = 1;
            PollingTime = 1000;
            PortNumber = 502;
            MaxRegisterInOnePoll = 16;
        }

        #endregion Protected Override Methods
    }
}