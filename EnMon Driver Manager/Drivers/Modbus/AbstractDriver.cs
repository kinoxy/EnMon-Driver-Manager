using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using EnMon_Driver_Manager.DataBase;
using System.Text;

namespace EnMon_Driver_Manager.Modbus
{
    /// <summary>
    ///
    /// </summary>
    public abstract class AbstractDriver
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the analog signals.
        /// </summary>
        /// <value>
        /// The analog signals.
        /// </value>
        public List<AnalogSignal> AnalogSignals { get; set; }

        /// <summary>
        /// Gets or sets the binary signals.
        /// </summary>
        /// <value>
        /// The binary signals.
        /// </value>
        public List<BinarySignal> BinarySignals { get; set; }

        /// <summary>
        /// Gets or sets the devices.
        /// </summary>
        /// <value>
        /// The devices.
        /// </value>
        public List<Device> Devices { get; set; }

        /// <summary>
        /// Gets or sets the stations.
        /// </summary>
        /// <value>
        /// The stations.
        /// </value>
        public List<Station> Stations { get; set; }

        /// <summary>
        /// Gets or sets the polling time.
        /// </summary>
        /// <value>
        /// The polling time.
        /// </value>
        public int PollingTime
        {
            get { return pollingTime; }
            protected set { pollingTime = value; }
        }

        /// <summary>
        /// Gets or sets the read time out.
        /// </summary>
        /// <value>
        /// The read time out.
        /// </value>
        public int ReadTimeOut
        {
            get { return readTimeOut; }
            protected set { readTimeOut = value; }
        }

        /// <summary>
        /// Gets or sets the retry number.
        /// </summary>
        /// <value>
        /// The retry number.
        /// </value>
        public int RetryNumber
        {
            get { return retryNumber; }
            protected set { retryNumber = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is error; otherwise, <c>false</c>.
        /// </value>
        public bool IsError { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether [maximum register in one pool].
        /// </summary>
        /// <value>
        /// <c>true</c> if [maximum register in one pool]; otherwise, <c>false</c>.
        /// </value>
        public byte MaxRegisterInOnePoll
        {
            get { return maxRegisterInOnePoll; }
            protected set { maxRegisterInOnePoll = value; }
        }
        /// <summary>
        /// Gets or sets the database helper.
        /// </summary>
        /// <value>
        /// The database helper.
        /// </value>
        protected static AbstractDBHelper dbHelper { get; set; }

        #endregion Public Properties

        #region Private Properties

        private static int pollingTime;
        private static int readTimeOut;
        private static int retryNumber;
        private static byte maxRegisterInOnePoll;

        private List<AnalogSignal> analogSignals;
        private List<BinarySignal> binarySignals;
        private Thread thread_ReadAnalogValues;
        private Thread thread_ReadBinaryValues;



        /// <summary>
        /// Gets or sets the database helper.
        /// </summary>
        /// <value>
        /// The database helper.
        /// </value>
        //protected static MySqlDBHelper dbhelper { get; set; }

        #endregion Private Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractDriver"/> class.
        /// </summary>
        public AbstractDriver() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractDriver"/> class.
        /// </summary>
        /// <param name="_configFile">The configuration file.</param>
        /// <param name="_dbHelper">The database helper.</param>
        public AbstractDriver(string _configFile, AbstractDBHelper _dbHelper)
        {
            dbHelper = _dbHelper;
            Devices = new List<Device>();
            Stations = new List<Station>();

            //Default haberleşme ayarları
            SetDefaultCommunicationParameters();
            // Config dosyasından haberleşme ayarları ve istasyon isimleri çekiliyor
            ReadDriverConfigFile(_configFile);

            if (Stations.Count > 0)
            {
                foreach (Station s in Stations)
                {
                    List<Device> _stationDevices = dbHelper.GetStationDevices(s.Name);
 
                    _stationDevices = VerifyProtocolofDevices(_stationDevices);

                    if (_stationDevices.Count > 0)
                    {
                        foreach (Device d in _stationDevices)
                        {
                            d.BinarySignals = dbHelper.GetDeviceBinarySignalsInfo(d.ID);
                            d.AnalogSignals = dbHelper.GetDeviceAnalogSignalsInfo(d.ID);
                        }
                        s.Devices = _stationDevices;
                        Devices.AddRange(_stationDevices);
                    }
                    else
                    {
                        Log.Instance.Info("{0} adlı station için device bulunamadı", s.Name);
                    }
                }
                if (Devices.Count > 0)
                {
                    InitializeDriver();
                }

                else
                {
                    Log.Instance.Error("{0} Hata: İstasyonlar altında kayıtlı modbus cihazı bulunamadı. Driver başlatılamıyor...", this.GetType().Name);
                    IsError = true;
                }
            }
            else
            {
                Log.Instance.Error("{0} Hata: ModbusDriverConfig.ini dosyasında geçerli istasyon adı bulunamadı. Driver başlatılamıyor...", this.GetType().Name);
                IsError = true;
            }
            
        }
        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Gets the signal list for driver devices.
        /// </summary>
        //public void GetSignalListOfDriverDevices()
        //{
        //    Log.Instance.Trace("GetSignalListForDriverDevices fonksiyonu cagrıldı");

        //    MySqlDBHelper db_connection = new MySqlDBHelper();
        //    foreach (Device _device in Devices)
        //    {
        //        _device.BinarySignals = db_connection.GetDeviceBinarySignalsInfo(_device.ID);
        //        _device.AnalogSignals = db_connection.GetDeviceAnalogSignalsInfo(_device.ID);
        //    }
        //}

        /// <summary>
        /// Starts the communication.
        /// </summary>
        public void StartCommunication()
        {
            Log.Instance.Trace("{0}: {1} methodu çağrıldı", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            try
            {
                ConnectToModbusDevices();
                //TODO: Database'in değil de driverın kendi bufferı olması daha mantıklı.
                dbHelper.WriteValuesAtBufferToDatabase();
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0}: Driver baglantı hatası => ", this.GetType().Name, e.Message);
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Driver'da tanımlı tüm device'ların database'de kayıtlı sinyallerinin database'deki son güncel degerlerini alır.
        /// </summary>
        private void GetLatestValuesFromDatabase()
        {
            Log.Instance.Trace("GetLastValuesFromDatabase fonksiyonu cagrıldı");

            // Yeni bir database baglantı nesnesi olusturuluyor
            MySqlDBHelper db_connection = new MySqlDBHelper();

            // Her device için donguye giriliyor
            foreach (Device device in Devices)
            {
                // Database'den currentValue bilgisi ile donen liste gecici olarak olusturulan List<BinarySignal>'e atanıyor.
                List<BinarySignal> _binarySignals = new List<BinarySignal>();
                _binarySignals = db_connection.GetDeviceBinarySignalsValue(device.ID);

                if (_binarySignals != null)
                {
                    foreach (BinarySignal signal in device.BinarySignals)
                    {
                        signal.CurrentValue = _binarySignals.First(s => s.ID == signal.ID).CurrentValue;
                        signal.TimeTag = _binarySignals.First(s => s.ID == signal.ID).TimeTag;
                    }
                }
                else
                {
                    Log.Instance.Error("{0} (ID No:{1}) device'ı için database'den son degerler okunamadı", device.Name, device.ID);
                }

                // Database'den currentValue bilgisi ile donen liste gecici olarak olusturulan List<AnalogSignal>'e atanıyor.
                List<AnalogSignal> _analogSignals = new List<AnalogSignal>();
                _analogSignals = db_connection.GetDeviceAnalogSignalsValue(device.ID);

                if (_analogSignals != null)
                {
                    foreach (AnalogSignal signal in device.AnalogSignals)
                    {
                        signal.CurrentValue = _analogSignals.First(s => s.ID == signal.ID).CurrentValue;
                    }
                }
                else
                {
                    Log.Instance.Error("{0} (ID No:{1}) device'ı için database'den son degerler okunamadı", device.Name, device.ID);
                }
            }
        }

        /// <summary>
        /// Verifies the station names and returns Station informations from database for given station names.
        /// </summary>
        /// <param name="_stationNames">The station names.</param>
        /// <returns></returns>
        private List<Station> VerifyStationNames(List<string> _stationNames)
        {
            List<Station> _stations = new List<Station>();
            foreach (string s in _stationNames)
            {
                Station _station = null;
                _station = dbHelper.GetStationInfoByName(s);
                if(_station != null)
                {
                    _stations.Add(_station);
                }  
            }
            return _stations;
        }

        /// <summary>
        /// Gets the station names from configuration file.
        /// </summary>
        /// <param name="_configFile">The configuration file.</param>
        /// <returns></returns>
        private List<string> GetStationNamesFromConfigFile(string _configFile)
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

        /// <summary>
        /// Reads the configuration file.
        /// </summary>
        /// <param name="_configFile">The configuration file.</param>
        private void ReadDriverConfigFile(string _configFile)
        {

            GetCommunicationParametersFromConfigFile(_configFile);

            // Config dosyasından station isimleri okunuyor
            List<string> _stationNames = GetStationNamesFromConfigFile(_configFile);

            // Config dosyasındaki station isimleri database'de yer alan station isimleri ile karşılaştırılıyor. Database'de kayıtlı olmayan isimler siliniyor.
            Stations = VerifyStationNames(_stationNames);
        }

        #endregion Private Methods

        #region Protected Abstract Methods

        /// <summary>
        /// Device'tan istenilen sinyalin degerini okur
        /// </summary>
        /// <returns></returns>
        //abstract public void ReadBinaryValuesFromDevice();

        /// <summary>
        /// Reads the analog values from device.
        /// </summary>
        //abstract public void ReadAnalogValuesfromDevice();

        /// <summary>
        /// Writes the value to device.
        /// </summary>
        //abstract public void WriteValueToDevice();

        /// <summary>
        /// Connects this instance.
        /// </summary>
        protected abstract void ConnectToModbusDevices();

        /// <summary>
        /// Initializes the driver.
        /// </summary>
        protected abstract void InitializeDriver();

        /// <summary>
        /// Devices listesindeki tüm cihazların dogru protokol ile haberleşip haberleşmediğini kontrol eder.
        /// Protokolü yanlış seçilmiş device varsa onu driver'in devices listesinden çıkartır ve o device ile baglantı kurmaz.
        /// </summary>
        protected abstract List<Device> VerifyProtocolofDevices(List<Device> _devices);

        /// <summary>
        /// Gets the communication parameters from configuration file.
        /// </summary>
        /// <param name="_configFile">The configuration file.</param>
        protected abstract void GetCommunicationParametersFromConfigFile(string _configFile);

        //
        protected abstract void SetDefaultCommunicationParameters();
        #endregion Abstract Methods
    }
}