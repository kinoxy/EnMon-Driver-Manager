using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

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
        #endregion

        #region Public Tanımlamalar
        /// <summary>
        /// Connection string
        /// </summary>
        public static String ConnectionString
        {
            get { return String.Format("Server={0};Database={1};Uid={2};Pwd={3};", str_serverAddress, str_databaseName, str_userName, str_password); }
        }

        public bool Connect()
        {
            try
            {
                conn.Open();
                Log.Instance.Info("Database'e baglanıldı");
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Fatal("Database baglantısı kurulamadı: {0}", ex.Message);
                return false;
            }
        }

        public bool Disconnect()
        {
            try
            {
                conn.Close();
                Log.Instance.Info("Database'e baglantısı kesildi.");
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Fatal("Database baglantısı kesilirken hata olustu: {0}", ex.Message);
                return false;
            }
        }
    

        #endregion

        #region Constructors
        /// <summary>
        /// Default ayarlar ile database'e baglanır
        /// </summary>
        public DBHelper ()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(ConnectionString);
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_serverAddres">Server hostname ya da ip addresi</param>
        /// <param name="_databaseName">Serverda baglanılacak olan database adı</param>
        /// <param name="_username">Kullanıcı adı</param>
        /// <param name="_password">Kullanıcı şifresi</param>
        public DBHelper (string _serverAddres, string _databaseName, string _username, string _password)
        {
            str_serverAddress = _serverAddres;
            str_databaseName = _databaseName;
            str_userName = _username;
            str_password = _password;

            if (conn == null)
            {
                conn = new MySqlConnection(ConnectionString);
            }
        }

        #endregion

        #region Methods
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
        /// Database'de "devices" tablosunda yer alan tum device'ların device_id, name, station_id, protocol_id, ip_address ve slave_id bilgilerini getirir.
        /// </summary>
        /// <returns></returns>
        public List<Device> GetDeviceList()
        {
            Log.Instance.Trace("GetDeviceList fonksiyonu cagrıldı");

            string query = "CALL getAllDevicesInfo()";

            List<Device> _deviceList = new List<Device>();
            Device _device;

            try
            {
                if (conn != null)
                {

                    if (Connect())
                    {
                        using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    _device = new Device();
                                    _device.ID = reader.GetInt32(0);
                                    _device.Name = reader.GetString(1);
                                    _device.StationID = reader.GetInt32(2);

                                    int protocolID = reader.GetInt32(3);
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

                                    _device.IpAddress = reader.GetString(4);
                                    _device.SlaveID = reader.GetInt32(5);

                                    _deviceList.Add(_device);
                                }
                            }
                            else
                            {
                                Log.Instance.Error("Database'den deger donmedi");
                            }
                        } 
                    }
                    Disconnect();

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
        /// Database'de binary_signals" tablosunda yer alan binary_signals verilerinden girilen device_id'ye filtreleyerek 
        /// signal_id, name, identification, is_event, is_alarm ve is_reversed bilgilerini döndürür.
        /// </summary>
        /// <param name="_deviceID">Device'ın database'de kayıtlı id'si</param>
        /// <returns></returns>
        public List<BinarySignal> GetDeviceBinarySignalsInfo(int _deviceID)
        {
            Log.Instance.Trace("GetDeviceBinarySignalsInfo fonksiyonu cagrıldı");

            string query = String.Format("CALL getDeviceBinarySignalsInfo({0})", _deviceID.ToString());

            List<BinarySignal> _binarySignalList = new List<BinarySignal>();
            BinarySignal _binarySignal;
            
            try
            {
                if (conn != null)
                {
                    if (Connect())
                    {
                        Log.Instance.Trace("Binary sinyal bilgileri databaseden okunuyor");
                        using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    _binarySignal = new BinarySignal();
                                    _binarySignal.ID = reader.GetInt32(0);
                                    _binarySignal.Name = reader.GetString(1);
                                    _binarySignal.Identification = reader.GetString(2);
                                    _binarySignal.Address = reader.GetInt32(3);
                                    _binarySignal.IsEvent = reader.GetBoolean(4);
                                    _binarySignal.IsAlarm = reader.GetBoolean(5);
                                    _binarySignal.IsReversed = reader.GetBoolean(6);
                                    _binarySignal.DeviceID = _deviceID;

                                    _binarySignalList.Add(_binarySignal);
                                }
                            }
                            else
                            {
                                Log.Instance.Error("Database'den deger donmedi");
                            }
                        } 
                    }

                    Disconnect();

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

        public List<BinarySignal> GetDeviceBinarySignalsValue(int _deviceID)
        {
            Log.Instance.Trace("GetDeviceBinarySignalsValue fonksiyonu cagrıldı");

            string query = String.Format("CALL getDeviceBinarySignalsValue({0})", _deviceID.ToString());

            List<BinarySignal> _binarySignalList = new List<BinarySignal>();

            try
            {

                if (conn != null)
                {
                    if (Connect())
                    {
                        Log.Instance.Trace("Database'de kayıtlı binary sinyal son deger bilgileri databaseden okunuyor");
                        using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    BinarySignal _binarySignal = new BinarySignal();

                                    _binarySignal.ID = reader.GetInt32(0);
                                    _binarySignal.Name = reader.GetString(1);
                                    _binarySignal.CurrentValue = reader.GetBoolean(2);
                                    _binarySignal.DeviceID = _deviceID;

                                    _binarySignalList.Add(_binarySignal);
                                }
                            }
                            else
                            {
                                Log.Instance.Error("Database'den deger donmedi");
                            }
                        } 
                    }

                    Disconnect();
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

            return _binarySignalList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_signalID">signalID</param>
        /// <param name="_signalValue">signal Value</param>
        /// <returns></returns>
        public bool SetBinarySignalValue(int _signalID, bool _signalValue)
        {
            Log.Instance.Trace("SetBinarySignalValue fonksiyonu çağrıldı");

            string query = String.Format("Call setBinarySignalValue({0},{1}", _signalID, _signalValue);
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                {
                    bool _returnValue = false;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _returnValue = reader.GetBoolean(0);
                            if(!_returnValue)
                            {
                                Log.Instance.Error("Database Hatası: (setBinarySignalValue({ 0},{ 1}) stored procedure çağrılırken bir hata oluştu)",_signalID, _signalValue );
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
                Log.Instance.Fatal("Database Hatası (setBinarySignalValue stored procedure çağrılırken bir hata olustu): {0}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Database'de "analog_signals" tablosunda yer alan analog_signals verilerinden girilen device_id'ye filtreleyerek 
        /// signal_id, name, identification, is_event, is_alarm ve is_reversed bilgilerini döndürür.
        /// </summary>
        /// <param name="_deviceID">Device'ın database'de kayıtlı id'si</param>
        /// <returns></returns>
        public List<AnalogSignal> GetDeviceAnalogSignalsInfo(int _deviceID)
        {
            Log.Instance.Trace("GetDeviceAnalogSignalsInfo fonksiyonu cagrıldı");

            string query = String.Format("CALL getDeviceAnalogSignalsInfo({0})", _deviceID.ToString());

            List<AnalogSignal> _analogSignalList = new List<AnalogSignal>();
            AnalogSignal _analogSignal;

            try
            {

                if (conn != null)
                {


                    if (Connect())
                    {
                        Log.Instance.Trace("Analog sinyal bilgileri databaseden okunuyor");
                        using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    _analogSignal = new AnalogSignal();
                                    _analogSignal.ID = reader.GetInt32(0);
                                    _analogSignal.Name = reader.GetString(1);
                                    _analogSignal.Identification = reader.GetString(2);
                                    _analogSignal.Address = reader.GetInt32(3);
                                    _analogSignal.DatatypeID = reader.GetInt32(4);
                                    _analogSignal.ScaleValue = reader.GetInt32(5);
                                    _analogSignal.MaxValue = reader.GetInt32(6);
                                    _analogSignal.MinValue = reader.GetInt32(7);
                                    _analogSignal.IsAlarm = reader.GetBoolean(8);
                                    _analogSignal.IsEvent = reader.GetBoolean(9);
                                    _analogSignal.DeviceID = _deviceID;

                                    _analogSignalList.Add(_analogSignal);
                                }
                            }
                        } 
                    }

                    Disconnect();
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

        public List<AnalogSignal> GetDeviceAnalogSignalsValue(int _deviceID)
        {
            Log.Instance.Trace("GetDeviceAnalogSignalsValue fonksiyonu cagrıldı");

            string query = String.Format("CALL getDeviceAnalogSignalsValue({0})", _deviceID.ToString());

            List<AnalogSignal> _analogSignalList = new List<AnalogSignal>();

            try
            {
                if (conn != null)
                {

                    if (Connect())
                    {
                        Log.Instance.Trace("Database'de kayıtlı analog sinyallerin son deger bilgileri databaseden okunuyor");
                        using (MySqlDataReader reader = MySqlHelper.ExecuteReader(conn, query))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    AnalogSignal _analogSignal = new AnalogSignal();

                                    _analogSignal.ID = reader.GetInt32(0);
                                    _analogSignal.Name = reader.GetString(1);
                                    _analogSignal.CurrentValue = reader.GetInt32(2);
                                    _analogSignal.DeviceID = _deviceID;

                                    _analogSignalList.Add(_analogSignal);
                                }
                            }
                        } 
                    }

                    Disconnect();
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

        public bool SetAnalogSignalValue(int _signalID, int _signalValue)
        {
            Log.Instance.Trace("SetAnalogSignalValue fonksiyonu çağrıldı");

            string query = String.Format("Call setAnalogSignalValue({0},{1}", _signalID, _signalValue);
            try
            {
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
                                Log.Instance.Error("Database Hatası: (setAnalogSignalValue({0},{1}) stored procedure çağrılırken bir hata oluştu)",_signalID, _signalValue );
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

