using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Threading;

namespace EnMon_Driver_Manager
{
    public class DBHelper
    {
        #region Private Tanımlamalar
        private static String str_serverAddress = "46.101.240.185";
        private static String str_databaseName = "utmdb";
        private static String str_userName = "root";
        private static String str_password = "Qweasd123";
        private static MySqlConnection conn;
        private static Queue<BinarySignal> buffer_BinarySignals;
        private static Queue<AnalogSignal> buffer_AnalogSignals;
        #endregion

        #region Public Methods

        /// <summary>
        /// Connection string
        /// </summary>
        public static String ConnectionString
        {
            get { return String.Format("Server={0};Database={1};Uid={2};Pwd={3};", str_serverAddress, str_databaseName, str_userName, str_password); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is database write enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is database write enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsWriteEnabled { get; set; }

        #endregion

        #region Constructors
                
        /// <summary>
        /// Initializes a new instance of the <see cref="DBHelper"/> class.
        /// </summary>
        public DBHelper ()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(ConnectionString);
            }

            buffer_BinarySignals = new Queue<BinarySignal>();
            buffer_AnalogSignals = new Queue<AnalogSignal>();
            IsWriteEnabled = true;
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHelper"/> class.
        /// </summary>
        /// <param name="_serverAddres">The server addres.</param>
        /// <param name="_databaseName">Name of the database.</param>
        /// <param name="_username">The username.</param>
        /// <param name="_password">The password.</param>
        public DBHelper (string _serverAddres, string _databaseName, string _username, string _password) : this()
        {
            str_serverAddress = _serverAddres;
            str_databaseName = _databaseName;
            str_userName = _username;
            str_password = _password;
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Databases the test connection.
        /// </summary>
        /// <returns></returns>
        public bool DatabaseTestConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(DBHelper.ConnectionString);
                connection.Open();
                Log.Instance.Info("Database'e baglanıldı.");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Database baglantı hatası: {0}",ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Gets the device list from database.
        /// </summary>
        /// <returns></returns>
        public List<Device> GetAllDevicesList()
        {
            Log.Instance.Trace("GetAllDeviceList fonksiyonu cagrıldı");

            string query = "CALL getAllDevicesInfo()";

            List<Device> _deviceList = new List<Device>();
            Device _device;

            try
            {
                if (conn != null)
                {

                    if (OpenConnection())
                    {
                        using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    _device = new Device();
                                    _device.ID = reader.GetUInt16("device_id");
                                    _device.Name = reader.GetString("name");
                                    _device.StationID = reader.GetUInt16("station_id");

                                    int protocolID = reader.GetByte(3);
                                    switch (protocolID)
                                    {
                                        case 0:
                                            _device.ProtocolID = Device.Protocol.ModbusRTU;
                                            break;
                                        case 1:
                                            _device.ProtocolID = Device.Protocol.ModbusTCP;
                                            break;
                                        case 2:
                                            _device.ProtocolID = Device.Protocol.ModbusASCII;
                                            break;
                                        default:
                                            break;
                                    }

                                    _device.IpAddress = reader.GetString("ip_address");
                                    _device.SlaveID = reader.GetByte("slave_id");
                                    _device.Connected = reader.GetBoolean("connected");
                                    _device.isActive = reader.GetBoolean("is_active");
                                    _deviceList.Add(_device);
                                }
                            }
                            else
                            {
                                Log.Instance.Error("Database'den deger donmedi");
                            }
                        } 
                    }
                    //CloseConnection();

                }
                else
                {
                    Log.Instance.Error("Database baglantı hatası: Aktif bir database baglantısı yok.");
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Database hatası: {0}", ex.Message);
                throw;
            }

            return _deviceList;
        }

        /// <summary>
        /// Gets the station devices list.
        /// </summary>
        /// <param name="_stationName">Name of the station.</param>
        /// <returns></returns>
        public List<Device> GetStationDevices(string _stationName)
        {
            Log.Instance.Trace("{0}: {1} methodu cagrıldı", this.GetType().Name, MethodBase.GetCurrentMethod().Name);

            string query = String.Format("CALL getStationDevicesInfo('{0}')", _stationName);

            List<Device> _deviceList = new List<Device>();
            Device _device;

            try
            {
                if (conn != null)
                {

                    if (OpenConnection())
                    {
                        using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    _device = new Device();
                                    _device.ID = reader.GetUInt16("device_id");
                                    _device.Name = reader.GetString("name");
                                    _device.StationID = reader.GetUInt16("station_id");

                                    int protocolID = reader.GetByte(3);
                                    switch (protocolID)
                                    {
                                        case 0:
                                            _device.ProtocolID = Device.Protocol.ModbusRTU;
                                            break;
                                        case 1:
                                            _device.ProtocolID = Device.Protocol.ModbusTCP;
                                            break;
                                        case 2:
                                            _device.ProtocolID = Device.Protocol.ModbusASCII;
                                            break;
                                        default:
                                            break;
                                    }

                                    _device.IpAddress = reader.GetString("ip_address");
                                    _device.SlaveID = reader.GetByte("slave_id");
                                    _device.isActive = reader.GetBoolean("is_active");
                                    _device.Connected = reader.GetBoolean("connected");

                                    _deviceList.Add(_device);
                                }
                            }
                            else
                            {
                                Log.Instance.Error("Database'den deger donmedi");
                            }
                        }
                    }

                    //CloseConnection();

                }
                else
                {
                    Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                    Log.Instance.Error("Database baglantı hatası: Aktif bir database baglantısı yok.");
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                Log.Instance.Fatal("Database hatası: {0}", ex.Message);
                //throw;
            }

            return _deviceList;
        }

        /// <summary>
        /// Updates the state of the device connected.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <param name="_state">if set to <c>true</c> [state].</param>
        public static void UpdateDeviceConnectedState(ushort _deviceID, bool _state)
        {
            Log.Instance.Trace("{0}.{1} methodu {2} nolu device için cagrıldı", "DBHelper", MethodBase.GetCurrentMethod().Name, _deviceID);
            string query = String.Format("CALL updateDeviceConnectedState({0},{1})", _deviceID.ToString(), _state.ToString());
            try
            {
                ExecuteNonQuery(query);
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0} hata: {1}", "DBHelper", e.Message);
            }
        }

        public static Station GetStationInfoByName(string s)
        {
            Log.Instance.Trace("DBHelper.{0} methodu {1} için çağrıldı", MethodBase.GetCurrentMethod().Name, s);
            Station _station = null;
            if (OpenConnection())
            {

                string query = String.Format("CALL getStationInfoByName('{0}')", s);

                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                {
                    if(reader.HasRows)
                    {

                        while(reader.Read())
                        {
                            _station = new Station();
                            _station.ID = reader.GetUInt16("station_id");
                            _station.Name = s;
                        }
                    }
                    else
                    {
                        Log.Instance.Trace("DBHelper.{0}", MethodBase.GetCurrentMethod().Name);
                        Log.Instance.Warn("{0} adlı bir station kaydı bulunamadı", s);
                    }
                }

                return _station;
            }
            else
            {
                Log.Instance.Debug("{0} methodu için database baglantısı olusturulamadı", MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        /// <summary>
        /// Database'de binary_signals" tablosunda yer alan binary_signals verilerinden girilen device_id'ye filtreleyerek 
        /// signal_id, name, identification, is_event, is_alarm ve is_reversed bilgilerini döndürür.
        /// </summary>
        /// <param name="_deviceID">Device'ın database'de kayıtlı id'si</param>
        /// <returns></returns>
        public List<BinarySignal> GetDeviceBinarySignalsInfo(ushort _deviceID)
        {
            Log.Instance.Trace("{0}: {1} methodu {2} userID numaralı device için cagrıldı", this.GetType().Name, MethodBase.GetCurrentMethod().Name, _deviceID.ToString());

            string query = String.Format("CALL getDeviceBinarySignalsInfo({0})", _deviceID.ToString());

            List<BinarySignal> _binarySignalList = new List<BinarySignal>();
            BinarySignal _binarySignal;
            
            try
            {
                if (conn != null)
                {
                    if (OpenConnection())
                    {
                        Log.Instance.Trace("{0}: {1} => Binary sinyal bilgileri databaseden okunuyor", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                        using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    _binarySignal = new BinarySignal();
                                    _binarySignal.ID = reader.GetUInt32("binary_signal_id");
                                    _binarySignal.Name = reader.GetString("name");
                                    _binarySignal.Identification = reader.GetString("identification");
                                    _binarySignal.Address = reader.GetUInt16("address");
                                    _binarySignal.FunctionCode = reader.GetByte("function_code");
                                    _binarySignal.BitNumber = reader.GetByte("bit_number");
                                    _binarySignal.IsEvent = reader.GetBoolean("is_event");
                                    _binarySignal.IsAlarm = reader.GetBoolean("is_alarm");
                                    _binarySignal.IsReversed = reader.GetBoolean("is_reversed");
                                    _binarySignal.DeviceID = _deviceID;

                                    _binarySignalList.Add(_binarySignal);
                                }
                            }
                            else
                            {
                                Log.Instance.Trace("{0}: {1} => Database'den deger donmedi", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                            }
                        } 
                    }

                    //CloseConnection();

                } 
                else
                {
                    Log.Instance.Error("Database baglantı hatası: Aktif bir database baglantısı yok.");
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Database hatası: {0}", ex.Message);
                throw;
            }

            return _binarySignalList;
        }

        /// <summary>
        /// Gets the device binary signals value.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <returns></returns>
        public List<BinarySignal> GetDeviceBinarySignalsValue(ushort _deviceID)
        {
            Log.Instance.Trace("{0}: {1} methodu {2} userID numaralı device için cagrıldı", this.GetType().Name, MethodBase.GetCurrentMethod().Name, _deviceID.ToString());

            string query = String.Format("CALL getDeviceBinarySignalsValue({0})", _deviceID.ToString());

            List<BinarySignal> _binarySignalList = new List<BinarySignal>();

            try
            {
                if (conn != null)
                {
                    if (OpenConnection())
                    {
                        Log.Instance.Trace("{0}: {1} => Analog sinyal bilgileri databaseden okunuyor", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                        using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    BinarySignal _binarySignal = new BinarySignal();

                                    _binarySignal.ID = reader.GetUInt32("binary_signal_id");
                                    _binarySignal.Name = reader.GetString("name");
                                    _binarySignal.CurrentValue = reader.GetBoolean("current_value");
                                    _binarySignal.TimeTag = reader.GetDateTime("ts_datetime").ToString(); ;
                                    _binarySignal.DeviceID = _deviceID;

                                    _binarySignalList.Add(_binarySignal);
                                }
                            }
                            else
                            {
                                Log.Instance.Trace("{0}: {1} => Database'den deger donmedi", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                            }
                        }

                        //CloseConnection();
                    }   
                }
                else
                {
                    Log.Instance.Error("Database hatası: Aktif bir database baglantısı yok.");
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Fatal("Database hatası: {0}", ex.Message);
            }

            return _binarySignalList;
        }
       
        /// <summary>
        /// Database'de "analog_signals" tablosunda yer alan analog_signals verilerinden girilen device_id'ye filtreleyerek 
        /// signal_id, name, identification, is_event, is_alarm ve is_reversed bilgilerini döndürür.
        /// </summary>
        /// <param name="_deviceID">Device'ın database'de kayıtlı id'si</param>
        /// <returns></returns>
        public List<AnalogSignal> GetDeviceAnalogSignalsInfo(ushort _deviceID)
        {
            Log.Instance.Trace("GetDeviceAnalogSignalsInfo fonksiyonu cagrıldı");

            string query = String.Format("CALL getDeviceAnalogSignalsInfo({0})", _deviceID.ToString());

            List<AnalogSignal> _analogSignalList = new List<AnalogSignal>();
            AnalogSignal _analogSignal;

            try
            {

                if (conn != null)
                {


                    if (OpenConnection())
                    {
                        Log.Instance.Trace("Analog sinyal bilgileri databaseden okunuyor");
                        using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    _analogSignal = new AnalogSignal();
                                    _analogSignal.ID = reader.GetUInt32("analog_signal_id");
                                    _analogSignal.Name = reader.GetString("name");
                                    _analogSignal.Identification = reader.GetString("identification");
                                    _analogSignal.Address = reader.GetUInt16("address");
                                    _analogSignal.FunctionCode = reader.GetByte("function_code");
                                    _analogSignal.WordCount = reader.GetByte("word_count");
                                    _analogSignal.DatatypeID = reader.GetByte("data_type_id");
                                    _analogSignal.ScaleValue = reader.GetFloat("scale_value");
                                    _analogSignal.MaxValue = reader.GetInt32("max_value");
                                    _analogSignal.MinValue = reader.GetInt32("min_value");
                                    _analogSignal.IsAlarm = reader.GetBoolean("is_alarm");
                                    _analogSignal.IsEvent = reader.GetBoolean("is_event");

                                    _analogSignal.DeviceID = _deviceID;

                                    _analogSignalList.Add(_analogSignal);
                                }
                            }
                        } 
                    }

                    //CloseConnection();
                }
                else
                {
                    Log.Instance.Error("Database baglantı hatası: Aktif bir database baglantısı yok.");
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Database hatası: {0}", ex.Message);
                throw;
            }

            return _analogSignalList;
        }

        /// <summary>
        /// Gets the device analog signals value.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <returns></returns>
        public List<AnalogSignal> GetDeviceAnalogSignalsValue(ushort _deviceID)
        {
            Log.Instance.Trace("GetDeviceAnalogSignalsValue fonksiyonu cagrıldı");

            string query = String.Format("CALL getDeviceAnalogSignalsValue({0})", _deviceID.ToString());

            List<AnalogSignal> _analogSignalList = new List<AnalogSignal>();

            try
            {
                if (conn != null)
                {

                    if (OpenConnection())
                    {
                        Log.Instance.Trace("Database'de kayıtlı analog sinyallerin son deger bilgileri databaseden okunuyor");
                        using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    AnalogSignal _analogSignal = new AnalogSignal();

                                    _analogSignal.ID = reader.GetUInt32("analog_signal_id");
                                    _analogSignal.Name = reader.GetString("name");
                                    _analogSignal.CurrentValue = reader.GetInt32("current_value");
                                    _analogSignal.DeviceID = _deviceID;

                                    _analogSignalList.Add(_analogSignal);
                                }
                            }
                        }
                    }

                    //CloseConnection();
                }
                else
                {
                    Log.Instance.Error("Database baglantı hatası: Aktif bir database baglantısı yok.");
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Fatal("Database hatası: {0}", ex.Message);
                throw;
            }

            return _analogSignalList;
        }

        /// <summary>
        /// Adds the binary signals to buffer.
        /// </summary>
        /// <param name="_signalList">The signal list.</param>
        public void AddBinarySignalsToBuffer(List<BinarySignal> _signalList)
        {
            foreach (BinarySignal _signal in _signalList)
            {
                buffer_BinarySignals.Enqueue(_signal);
            }
        }

        /// <summary>
        /// Adds the analog signals to buffer.
        /// </summary>
        /// <param name="_signalList">The signal list.</param>
        public void AddAnalogSignalsToBuffer(List<AnalogSignal> _signalList)
        {
            foreach (AnalogSignal _signal in _signalList)
            {
                buffer_AnalogSignals.Enqueue(_signal);
            }
        }
        
        /// <summary>
        /// Writes the values at buffer to database.
        /// </summary>
        public async void WriteValuesAtBufferToDatabase()
        {
            OpenConnection();
            Task writeBinaryValues = Task.Factory.StartNew(() =>
            {
                while (IsWriteEnabled)
                {
                    while (buffer_BinarySignals.Count > 0)
                    {
                         //;
                        try
                        {
                            BinarySignal _signal = buffer_BinarySignals.Peek();
                            if(SetBinarySignalValue(_signal.ID, _signal.CurrentValue, _signal.TimeTag))
                            {
                                buffer_BinarySignals.Dequeue();
                            }
                            
                        }
                        catch(Exception)
                        {
                            throw;
                        }
                        //Thread.Sleep(5);
                    }
                    Thread.Sleep(20);
                }
                
            });

            Task writeAnalogValues = Task.Factory.StartNew(() =>
            {
                while (IsWriteEnabled)
                {
                    while (buffer_AnalogSignals.Count > 0)
                    {
                        try
                        {
                            AnalogSignal _signal = buffer_AnalogSignals.Peek();
                            if(SetAnalogSignalValue(_signal.ID, _signal.CurrentValue, _signal.TimeTag))
                            {
                                buffer_AnalogSignals.Dequeue();
                            }
                            
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        //Thread.Sleep(5);
                    }
                    Thread.Sleep(20);
                }
                
            });

            await writeBinaryValues;
            await writeAnalogValues;
            //CloseConnection();
        }

        /// <summary>
        /// Updates the state of the device active.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <param name="_state">if set to <c>true</c> [state].</param>
        public static void UpdateDeviceActiveState(ushort _deviceID, bool _state)
        {
            Log.Instance.Trace("{0}.{1} methodu {2} nolu device için cagrıldı", "DBHelper", MethodBase.GetCurrentMethod().Name, _deviceID);
            string query = String.Format("CALL updateDeviceActiveState({0},{1})", _deviceID.ToString(), _state.ToString());
            try
            {
                ExecuteNonQuery(query);
            }
            catch(Exception e)
            {
                Log.Instance.Fatal("{0} hata: {1}", "DBHelper", e.Message);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Connects this instance.
        /// </summary>
        /// <returns></returns>
        public static bool OpenConnection()
        {
            if(conn == null)
            {
                conn = new MySqlConnection(ConnectionString);
            }

            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    Log.Instance.Info("Database'e baglanıldı");
                }

                if(conn.State == System.Data.ConnectionState.Open)
                { 
                    return true;
                }
                else
                {
                    return false;
                }                
            }
            catch (Exception ex)
            {
                Log.Instance.Fatal("Database baglantısı kurulamadı: {0}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        /// <returns></returns>
        public bool CloseConnection()
        {
            try
            {
                if(conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                    Log.Instance.Info("Database baglantısı kesildi.");
                }
                
                if(conn.State == System.Data.ConnectionState.Closed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Fatal("Database baglantısı kesilirken hata olustu: {0}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Sets the analog signal value.
        /// </summary>
        /// <param name="_signalID">The signal identifier.</param>
        /// <param name="_signalValue">The signal value.</param>
        /// <param name="_datetime">The datetime.</param>
        /// <returns></returns>
        private bool SetAnalogSignalValue(uint _signalID, int _signalValue, string _datetime)
        {
            Log.Instance.Trace("SetAnalogSignalValue fonksiyonu çağrıldı");

            string query = String.Format("Call setAnalogSignalValue({0},{1},'{2}')", _signalID, _signalValue, _datetime);
            try
            {
                OpenConnection();
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                {
                    bool _returnValue = false;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _returnValue = reader.GetBoolean(0);
                            if (!_returnValue)
                            {
                                Log.Instance.Error("Database Hatası: {0} sorgusu çağrılırken bir hata oluştu)", query);
                            }
                        }
                    }
                    else
                    {
                        Log.Instance.Error("Database'den deger donmedi");
                        _returnValue = false;
                    }
                    return _returnValue;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Fatal("Database Hatası (setAnalogSignalValue stored procedure çağrılırken bir hata olustu): {0}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Sets the binary signal value.
        /// </summary>
        /// <param name="_signalID">The signal identifier.</param>
        /// <param name="_signalValue">if set to <c>true</c> [signal value].</param>
        /// <param name="_datetime">The datetime.</param>
        /// <returns></returns>
        private bool SetBinarySignalValue(uint _signalID, bool _signalValue, string _datetime)
        {
            Log.Instance.Trace("SetBinarySignalValue fonksiyonu çağrıldı");

            string query = String.Format("Call setBinarySignalValue({0},{1},{2}", _signalID, _signalValue, _datetime);
            try
            {
                OpenConnection();
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                {
                    bool _returnValue = false;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _returnValue = reader.GetBoolean(0);
                            if (!_returnValue)
                            {
                                Log.Instance.Error("Database Hatası: (setBinarySignalValue({ 0},{ 1}) stored procedure çağrılırken bir hata oluştu)", _signalID, _signalValue);
                            }
                        }
                    }
                    else
                    {
                        Log.Instance.Error("Database'den deger donmedi");
                        _returnValue = false;
                    }
                    return _returnValue;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Fatal("Database Hatası: (setBinarySignalValue stored procedure çağrılırken bir hata olustu) {0}", ex.Message);
                return false;
            }
        }
        #endregion

        private static void ExecuteNonQuery(string _query)
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = _query;
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

