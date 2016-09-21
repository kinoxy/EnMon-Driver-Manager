using EnMon_Driver_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EnMon_Driver_Manager.DataBase;

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
        public ModbusTCP(string _configFile) : base(_configFile) { }


        /// <summary>
        /// Initializes a new instance of the <see cref="ModbusTCP"/> class.
        /// </summary>
        /// <param name="_ipAddresses">The ip addresses.</param>
        public ModbusTCP(List<string> _ipAddresses) : base()
        {
            ipAddresses = _ipAddresses;
            portNumber = 502;
            modbusTCPMasters = new List<Models.ModbusTCPMaster>();
            dbhelper = new MySqlDBHelper();
            Log.Instance.Trace("{0}: Modbus driver olusturuldu.", this.GetType().Name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModbusTCP"/> class.
        /// </summary>
        /// <param name="_ipAddresses">The ip addresses.</param>
        /// <param name="_portNumber">The port number.</param>
        public ModbusTCP(List<string> _ipAddresses, int _portNumber) : this(_ipAddresses)
        {
            portNumber = _portNumber;

        }

        #endregion Constructors  

        #region Private Methods

        /// <summary>
        /// Gets the ip list from devices.
        /// </summary>
        private void GetIpListFromDevices()
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
                ModbusTCPMaster _modbusTCPmaster = new ModbusTCPMaster(_ipAddress);
                // modbusTCPMaster'ın aynı ip adresi üzerinden haberleşeceği cihazlar ekleniyor.
                _modbusTCPmaster.Devices = (from d in Devices where d.IpAddress == _ipAddress select d).ToList();
                
                // Eventler ayarlanıyor
                _modbusTCPmaster.ConnectedToServer += _modbusServer_ConnectedToServer;
                _modbusTCPmaster.DisconnectedFromServer += _modbusServer_DisconnectedFromServer;
                _modbusTCPmaster.AnyBinarySignalValueChanged += _modbusServer_AnyBinarySignalValueChanged;
                _modbusTCPmaster.AnyAnalogSignalValueChanged += _modbusServer_AnyAnalogSignalValueChanged;
                modbusTCPMasters.Add(_modbusTCPmaster);
                _modbusTCPmaster.Connect();
                if(_modbusTCPmaster.IsConnected)
                {
                    _modbusTCPmaster.ReadValuesFromModbusServer();
                }

            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0}: Driver baglantı hatası => {1}", this.GetType().Name, e.ToString());
            }
        }

        /// <summary>
        /// Handles the AnyAnalogSignalValueChanged event of the _modbusServer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private static void _modbusServer_AnyAnalogSignalValueChanged(object sender, ModbusServerEventArgs e)
        {
            dbhelper.AddAnalogSignalsToDataBaseWriteBuffer(e.AnalogSignals);
        }

        private static void _modbusServer_AnyBinarySignalValueChanged(object sender, ModbusServerEventArgs e)
        {
            dbhelper.AddBinarySignalsToDataBaseWriteBuffer(e.BinarySignals);
        }

        private static void _modbusServer_DisconnectedFromServer(object sender, ModbusServerEventArgs e)
        {
            foreach (Device d in e.Devices)
            {
                if (d.Connected == true)
                {
                    d.Connected = false;
                    dbhelper.UpdateDeviceConnectedState(d.ID, d.Connected);
                }
            }
            //Log.Instance.Error("{0} ile bağlantı koptu", e.ipAddress);
            //throw new NotImplementedException();
        }

        private static void _modbusServer_ConnectedToServer(object sender, ModbusServerEventArgs e)
        {
            Log.Instance.Trace("{0}: {1} baglantı kuruldu", MethodBase.GetCurrentMethod().Name, e.ipAddress );
            //_modbusTCPmaster.ReadValuesFromModbusServer();
            //throw new NotImplementedException();
        }

        #endregion Private Methods

        #region Public Override Methods                
        
        /// <summary>
        /// Devices listesindeki tüm cihazların dogru protokol ile haberleşip haberleşmediğini kontrol eder.
        /// Protokolü yanlış seçilmiş device varsa onu driver'in devices listesinden çıkartır ve o device ile baglantı kurmaz.
        /// </summary>
        protected override void VerifyProtocolofDevices()
        {
            foreach (Device device in Devices)
            {
                if (device.ProtocolID != Device.Protocol.ModbusTCP)
                {
                    Log.Instance.Warn("Modbus Driver Uyarı: {0} adlı device'ın haberleşme protokolu ModbusTCP seçilmemiş Haberleşilecek cihazlar listesinden çıkartılıyor...", device.Name);
                    Devices.Remove(device);
                }
            }
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
            GetIpListFromDevices();

            if(ipAddresses!=null)
            {
                modbusTCPMasters = new List<Models.ModbusTCPMaster>();
                Log.Instance.Trace("{0}: Modbus driver olusturuldu.", this.GetType().Name );
            }
            else
            {
                Log.Instance.Error("{0} Hata: ModbusTCP Server cihazlar için Ip adresi bulunamadı", this.GetType().Name);
            }
        }

        #endregion Public Override Methods
    }
}