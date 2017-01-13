using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models;
using EnMon_Driver_Manager.Models.Devices;
using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Timers;

namespace EnMon_Driver_Manager.Drivers
{
    public abstract class AbstractDriver
    {
        #region Public Properties

        public int ReadTimeOut { get; set; }

        public int RetryNumber { get; set; }

        public List<Station> Stations { get; set; }

        public static AbstractDBHelper DBHelper { get; set; }

        public List<AbstractTCPClient> TCPClients { get; set; }

        public bool IsError { get; protected set; }

        public CommunicationProtocol communicationProtocol { get; set; }

        #endregion Public Properties



        #region Private Properties

        protected Timer cycleForCommands;

        #endregion Private Properties

        #region Constructor

        public AbstractDriver()
        {
             switch(this.GetType().Name)
            {
                case "ModbusTCP":
                    communicationProtocol = new CommunicationProtocol() { Name = "ModbusTCP" };
                        break;
                case "SNMP":
                    communicationProtocol = new CommunicationProtocol() { Name = "SNMP" };
                    break;
                default:
                    break;
            }
        }

        public AbstractDriver(string _configFile) : this()
        {
            Stations = new List<Station>();

            //Default haberleşme ayarları
            SetDefaultCommunicationParameters();

            try
            {
                DBHelper = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
                if (DBHelper != null)
                {
                    // Config dosyasından haberleşme ayarları ve istasyon isimleri çekiliyor
                    ReadDriverConfigFile(_configFile);

                    // Station'lara ait device'lar ve device'lara ait sinyallar veritabanından okunur.
                    // Child sınıfta burayı ekle
                    GetStationDevicesAndSignalsInfo();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Beklenmedik bir hata nedeniyle sürücü oluşturulamadı. => {1}", this.GetType().Name, ex.Message);
                throw;
            }
            
        }

        #endregion Constructor

        #region Public Methods

        public void SetDevicesAsDisconnected<T>(List<T> _devices) where T : Device
        {
            foreach (Device d in _devices)
            {
                DBHelper.UpdateDeviceConnectedState(d.ID, false);
                d.Connected = false;
            }
        }

        public abstract void SetDriverAllDevicesDisconnected();


        #endregion Public Methods

        #region Protected Methods

        protected void InitializeTimerForCheckingActiveCommandsAtDatabase()
        {
            cycleForCommands = new Timer(1000);
            cycleForCommands.Elapsed += CycleForCommands_Elapsed;
            cycleForCommands.Start();
        }

        protected List<string> GetStationNamesFromConfigFile(string _configFile)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(_configFile, Encoding.UTF8);
            var _stations = data["Stations"];

            List<string> _stationNames = new List<string>();
            if (_stations != null)
            {
                foreach (KeyData kd in _stations)
                {
                    _stationNames.Add(kd.Value.Trim());
                }
            }

            return _stationNames;
        }

        protected List<Station> VerifyStationNames(List<string> _stationNames)
        {
            List<Station> _stations = new List<Station>();
            foreach (string s in _stationNames)
            {
                Station _station = null;
                _station = DBHelper.GetStationInfoByName(s);
                if (_station != null)
                {
                    _stations.Add(_station);
                }
            }
            return _stations;
        }

        protected void ReadDriverConfigFile(string _configFile)
        {
            GetCommunicationParametersFromConfigFile(_configFile);

            // Config dosyasından station isimleri okunuyor
            List<string> _stationNames = GetStationNamesFromConfigFile(_configFile);

            // Config dosyasındaki station isimleri database'de yer alan station isimleri ile karşılaştırılıyor. Database'de kayıtlı olmayan isimler siliniyor.
            Stations = VerifyStationNames(_stationNames);
        }

        protected List<T> VerifyProtocolofDevices<T>(List<T> _devices, string _protocolName) where T : Device
        {
            List<T> protocolDevices = new List<T>();
            foreach (T device in _devices)
            {
                if (device.communicationProtocol.Name == _protocolName)
                {
                    protocolDevices.Add(device);
                }
            }
            return protocolDevices;
        }
    
        #endregion Protected Methods

        #region Private Methods

        protected abstract void CycleForCommands_Elapsed(object sender, ElapsedEventArgs e);
        

        #endregion Private Methods

        #region Public Abstract Methods

        public abstract void StartCommunication();

        public abstract void SetAllDevicesDisconnected();

        #endregion Public Abstract Methods

        #region Protected Abstract Methods

        protected abstract void SetDefaultCommunicationParameters();

        protected abstract void InitializeDriver();

        protected abstract void SendCommand(DataRow dr);

        protected abstract void GetCommunicationParametersFromConfigFile(string _configFileLocation);

        protected abstract void GetStationDevicesAndSignalsInfo();

   
        #endregion Protected Abstract Methods
    }
}