using EnMon_Driver_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EnMon_Driver_Manager.DataBase;
using IniParser;
using IniParser.Model;
using System.Text;

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
        private List<ModbusTCPMaster> modbusTCPMasters { get; set; }

        /// <summary>
        /// Gets or sets the loop result.
        /// </summary>
        /// <value>
        /// The loop result.
        /// </value>
        private ParallelLoopResult loopResult { get; set; }

        private int portNumber;

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

        #endregion

        #region Constructors        

        /// <summary>
        /// Initializes a new instance of the <see cref="ModbusTCP"/> class.
        /// </summary>
        /// <param name="_configFile">The configuration file.</param>
        public ModbusTCP(string _configFile, AbstractDBHelper _dbHelper) : base(_configFile, _dbHelper) { }

        #endregion Constructors  

        #region Private Methods

        /// <summary>
        /// Gets the ip list from devices.
        /// </summary>
        private void GetIpAddressesFromDevices()
        {
            Log.Instance.Trace("{0}: {1} methodu çağrıldı", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            ipAddresses = new List<string>();
            ipAddresses = Devices.Select(d => d.IpAddress).Distinct().ToList();
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
                ModbusTCPMaster _modbusTCPmaster = new ModbusTCPMaster(_ipAddress, ReadTimeOut, RetryNumber, PollingTime, MaxRegisterInOnePoll);

                // modbusTCPMaster'ın aynı ip adresi üzerinden haberleşeceği cihazlar ekleniyor.
                _modbusTCPmaster.Devices = (from d in Devices where d.IpAddress == _ipAddress select d).ToList();

                // Sinyal okumayı hızlandırmak için tüm sinyaller liste içerisinde modbus adreslerine göre sıralanıyor.
                foreach (Device d in _modbusTCPmaster.Devices)
                {
                    if (d.BinarySignals.Count > 0)
                    {
                        d.BinarySignals = d.BinarySignals.OrderBy(b => b.Address).ThenBy(b => b.BitNumber).ToList();
                    }
                    if (d.AnalogSignals.Count > 0)
                    {
                        d.AnalogSignals = d.AnalogSignals.OrderBy(a => a.Address).ToList();
                    }

                }

                // Eventler ayarlanıyor
                _modbusTCPmaster.ConnectedToServer += _modbusServer_ConnectedToServer;
                _modbusTCPmaster.DisconnectedFromServer += _modbusServer_DisconnectedFromServer;
                _modbusTCPmaster.AnyBinarySignalValueChanged += _modbusServer_AnyBinarySignalValueChanged;
                _modbusTCPmaster.AnyAnalogSignalValueChanged += _modbusServer_AnyAnalogSignalValueChanged;
                _modbusTCPmaster.DeviceConnectionStateChanged += _modbusTCPmaster_DeviceConnectionStateChanged;
                modbusTCPMasters.Add(_modbusTCPmaster);

                _modbusTCPmaster.Connect();
                
                if(_modbusTCPmaster.IsConnected)
                {
                    _modbusTCPmaster.ReadValues();
                }

            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0}: Driver baglantı hatası => {1}", this.GetType().Name, e.ToString());
            }
        }

        private void _modbusTCPmaster_DeviceConnectionStateChanged(object source, ModbusEventArgs e)
        {
            dbHelper.UpdateDeviceConnectedState(e.Device.ID, e.Device.Connected);
        }

        /// <summary>
        /// Handles the AnyAnalogSignalValueChanged event of the _modbusServer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private static void _modbusServer_AnyAnalogSignalValueChanged(object sender, ModbusEventArgs e)
        {
            dbHelper.AddAnalogSignalsToDataBaseWriteBuffer(e.AnalogSignals);
        }

        private static void _modbusServer_AnyBinarySignalValueChanged(object sender, ModbusEventArgs e)
        {
            dbHelper.AddBinarySignalsToDataBaseWriteBuffer(e.BinarySignals);
        }

        private static void _modbusServer_DisconnectedFromServer(object sender, ModbusEventArgs e)
        {
            foreach (Device d in e.Devices)
            {
                if (d.Connected == true)
                {
                    d.Connected = false;
                    dbHelper.UpdateDeviceConnectedState(d.ID, d.Connected);
                }
            }
            //Log.Instance.Error("{0} ile bağlantı koptu", e.ipAddress);
            //throw new NotImplementedException();
        }

        private static void _modbusServer_ConnectedToServer(object sender, ModbusEventArgs e)
        {
            Log.Instance.Trace("{0}: {1} baglantı kuruldu", MethodBase.GetCurrentMethod().Name, e.ipAddress );
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

        }

        /// <summary>
        /// Initializes the driver.
        /// </summary>
        protected override void InitializeDriver()
        {
            GetIpAddressesFromDevices();

            if(ipAddresses!=null)
            {
                if (ipAddresses.Count>0)
                {
                    modbusTCPMasters = new List<ModbusTCPMaster>();
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

        protected override void GetCommunicationParametersFromConfigFile(string _configFile)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(_configFile, Encoding.UTF8);
            var _parameters = data["Communication Parameters"];

            foreach( KeyData kd in _parameters)
            {
                switch(kd.KeyName.Trim())
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

        #endregion Public Override Methods
    }
}