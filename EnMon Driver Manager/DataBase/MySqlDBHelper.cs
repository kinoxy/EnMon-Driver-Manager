using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Threading;

namespace EnMon_Driver_Manager.DataBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="EnMon_Driver_Manager.DataBase.DBHelper" />
    public class MySqlDBHelper : DBHelper
    {
        #region Private Properties
        
        private static MySqlConnection conn { get; set; }
        
        #endregion

        #region Constructors
                
        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlDBHelper"/> class.
        /// </summary>
        public MySqlDBHelper () : base()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(ConnectionString);
            }
 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlDBHelper"/> class.
        /// </summary>
        /// <param name="_serverAddres">The server addres.</param>
        /// <param name="_databaseName">Name of the database.</param>
        /// <param name="_username">The username.</param>
        /// <param name="_password">The password.</param>
        public MySqlDBHelper (string _serverAddres, string _databaseName, string _username, string _password) : this()
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
                MySqlConnection connection = new MySqlConnection(MySqlDBHelper.ConnectionString);
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
        /// Gets the station devices list.
        /// </summary>
        /// <param name="_stationName">Name of the station.</param>
        /// <returns></returns>
        public override List<Device> GetStationDevices(string _stationName)
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
                    MySqlCommand a = new MySqlCommand(query, conn);
                    
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

        public override Station GetStationInfoByName(string _stationName)
        {
            Log.Instance.Trace("DBHelper.{0} methodu {1} için çağrıldı", MethodBase.GetCurrentMethod().Name, _stationName);
            Station _station = null;
            if (OpenConnection())
            {

                string query = String.Format("CALL getStationInfoByName('{0}')", _stationName);

                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                {
                    if(reader.HasRows)
                    {

                        while(reader.Read())
                        {
                            _station = new Station();
                            _station.ID = reader.GetUInt16("station_id");
                            _station.Name = _stationName;
                        }
                    }
                    else
                    {
                        Log.Instance.Trace("DBHelper.{0}", MethodBase.GetCurrentMethod().Name);
                        Log.Instance.Warn("{0} adlı bir station kaydı bulunamadı", _stationName);
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
        public override List<BinarySignal> GetDeviceBinarySignalsInfo(ushort _deviceID)
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
        public override List<BinarySignal> GetDeviceBinarySignalsValue(ushort _deviceID)
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
        public override List<AnalogSignal> GetDeviceAnalogSignalsInfo(ushort _deviceID)
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
        public override List<AnalogSignal> GetDeviceAnalogSignalsValue(ushort _deviceID)
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

        #endregion

        #region Protected Methods

        /// <summary>
        /// Checks and opens the databse connection if it is not already opened.
        /// </summary>
        /// <returns></returns>
        protected override bool OpenConnection()
        {
            if (conn == null)
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

                if (conn.State == System.Data.ConnectionState.Open)
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
        protected override bool CloseConnection()
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                    Log.Instance.Info("Database baglantısı kesildi.");
                }

                if (conn.State == System.Data.ConnectionState.Closed)
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
        /// Gets all devices list.
        /// </summary>
        /// <param name="List`1">The list`1.</param>
        /// <returns></returns>
        protected override List<Device> GetAllDevicesList()
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
        /// Executes the non query.
        /// </summary>
        /// <param name="_query">The query.</param>
        protected override void ExecuteNonQuery(string _query)
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

        /// <summary>
        /// Sets the binary signal value.
        /// </summary>
        /// <param name="_signalID">The signal identifier.</param>
        /// <param name="_signalValue">if set to <c>true</c> [signal value].</param>
        /// <param name="_datetime">The datetime.</param>
        /// <returns></returns>
        protected override bool SetBinarySignalValue(uint _signalID, bool _signalValue, string _datetime)
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

        /// <summary>
        /// Sets the analog signal value.
        /// </summary>
        /// <param name="_signalID">The signal identifier.</param>
        /// <param name="_signalValue">The signal value.</param>
        /// <param name="_datetime">The datetime.</param>
        /// <returns></returns>
        protected override bool SetAnalogSignalValue(uint _signalID, int _signalValue, string _datetime)
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
        #endregion
    }
}

