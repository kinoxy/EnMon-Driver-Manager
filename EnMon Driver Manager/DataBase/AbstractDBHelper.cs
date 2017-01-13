using EnMon_Driver_Manager.Extensions;
using EnMon_Driver_Manager.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EnMon_Driver_Manager.Models.ArchivePeriods;
using EnMon_Driver_Manager.Models.DataTypes;
using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Models.Signals;
using EnMon_Driver_Manager.Models.Signals.Modbus;
using EnMon_Driver_Manager.Models.StatusTexts;

namespace EnMon_Driver_Manager.DataBase
{
    /// <summary>
    ///
    /// </summary>
    public abstract class AbstractDBHelper
    {
        #region Public Properties

        /// <summary>
        /// The string server address
        /// </summary>
        protected static string str_serverAddress; //= "46.101.240.185";

        /// <summary>
        /// The string database name
        /// </summary>
        protected static string str_databaseName; //= "utmdb";

        /// <summary>
        /// The string user name
        /// </summary>
        protected static string str_userName; //= "root";

        /// <summary>
        /// The string password
        /// </summary>
        protected static string str_password; //= "Qweasd123";

        /// <summary>
        /// Gets or sets the buffer binary signals.
        /// </summary>
        /// <value>
        /// The buffer binary signals.
        /// </value>
        public static ConcurrentQueue<BinarySignal> buffer_BinarySignals { get; protected set; }

        /// <summary>
        /// Gets or sets the buffer analog signals.
        /// </summary>
        /// <value>
        /// The buffer analog signals.
        /// </value>
        public static ConcurrentQueue<AnalogSignal> buffer_AnalogSignals { get; protected set; }

        /// <summary>
        /// Connection string
        /// </summary>
        public static String ConnectionString
        {
            get { return String.Format("Server={0};Database={1};Uid={2};Pwd={3};charset=utf8", str_serverAddress, str_databaseName, str_userName, str_password); }
        }

        public List<StatusText> GetAllStatusTexts()
        {
            List<StatusText> statusTexts = new List<StatusText>();
            string query = "CALL getAllStatusTexts();";
            DataTable dt = new DataTable();
            try
            {
                dt = ExecuteQuery(query);
                foreach (DataRow dr in dt.Rows)
                {
                    StatusText statusText = new StatusText();
                    statusText.StatusID = dr.Field<uint>("status_id");
                    statusText.Name = dr.Field<string>("name");
                    statusTexts.Add(statusText);
                }
                return statusTexts;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Status bilgileri veritabanýndan çekilirken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                return statusTexts;
                throw;
            }
        }

        public string GetSignalValueByIdentification(string _identification)
        {
            string query = string.Format("CALL getSignalValueByIdentification('{0}')", _identification);
            DataTable dt = new DataTable();
            try
            {
                dt = ExecuteQuery(query);
                if (dt.HasRows())
                {
                    if (dt.Rows[0].ItemArray[0].ToString() == "")
                    {
                        return "0";
                    }
                    else
                    {
                        return dt.Rows[0].ItemArray[0].ToString();
                    }
                }
                else
                {
                    Log.Instance.Error("Sinyal deðeri database'den okunamadý");
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Sinyal deðeri database'den okunamadý => {0}", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is database write enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is database write enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsWriteEnabled { get; protected set; }

        public bool IsConnected { get; protected set; }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractDBHelper"/> class.
        /// </summary>
        public AbstractDBHelper()
        {
            buffer_BinarySignals = new ConcurrentQueue<BinarySignal>();
            buffer_AnalogSignals = new ConcurrentQueue<AnalogSignal>();
            IsWriteEnabled = true;
            //if (CheckDBConnection())
            //{
            //    IsConnected = true;
            //}
            //else
            //{
            //    if (IsConnected)
            //    {
            //        Log.Instance.Error("Database baglantýsý kurulamadý. Ayarlarý kontrol ediniz...");
            //        IsConnected = false;
            //    }
            //}
        }

        #endregion Constructors

        #region Protected Abstract Methods

        /// <summary>
        /// Checks and opens the databse connection if it is not already opened.
        /// </summary>
        /// <returns></returns>
        protected abstract bool OpenConnection();



        /// <summary>
        /// Closes the connection.
        /// </summary>
        /// <returns></returns>
        protected abstract bool CloseConnection();

        #endregion Protected Abstract Methods

        #region Public Abstract Methods

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="_query">The query.</param>
        public abstract int ExecuteNonQuery(string _query);

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="_query">The query.</param>
        /// <returns></returns>
        public abstract DataTable ExecuteQuery(string _query);

        /// <summary>
        /// Checks the database connection.
        /// </summary>
        /// <returns></returns>
        public abstract bool CheckDBConnection();

        #endregion Public Abstract Methods

        #region Protected Methods

        internal void AddAnalogSignalValueToDataBaseWriteBuffer(List<AnalogSignal> analogSignals)
        {
            throw new NotImplementedException();
        }

        internal void AddBinarySignalValueToDataBaseWriteBuffer(List<BinarySignal> binarySignals)
        {
            throw new NotImplementedException();
        }

        //public BinarySignal GetBinarySignalsInfoByIdentification(string _identification)
        //{
        //    //todo
        //    string query = string.Format("CALL getBinarySignalInfoByIdentification('{0}')", _identification);
        //    BinarySignal binarySignal = new BinarySignal();
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = ExecuteQuery(query);
        //        if (dt.HasRows())
        //        {
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                binarySignal.ID = dr.Field<uint>("binary_signal_id");
        //                binarySignal.Name = dr.Field<string>("name");
        //                binarySignal.Identification = _identification;
        //                binarySignal.Address = dr.Field<ushort>("address");
        //                binarySignal.FunctionCode = dr.Field<byte>("function_code");
        //                binarySignal.WordCount = dr.Field<byte>("word_count");
        //                binarySignal.ComparisonBitNumber = dr.Field<byte>("comparison_bit_number");
        //                binarySignal.ComparisonValue = dr.Field<int>("comparison_value");
        //                binarySignal.IsAlarm = dr.Field<bool>("is_alarm");
        //                binarySignal.IsEvent = dr.Field<bool>("is_event");
        //                binarySignal.StatusID = dr.Field<uint>("status_id");
        //                binarySignal.DeviceID = dr.Field<ushort>("device_id"); ;
        //                binarySignal.IsReversed = dr.Field<bool>("is_reversed");
        //                switch (dr.Field<string>("comparison_type"))
        //                {
        //                    case "bit":
        //                        binarySignal.comparisonType = BinarySignal.ComparisonType.bit;
        //                        break;

        //                    case "value":
        //                        binarySignal.comparisonType = BinarySignal.ComparisonType.value;
        //                        break;

        //                    default:
        //                        break;
        //                }
        //            }
        //        }
        //        return binarySignal;
        //    }
        //    catch (Exception ex)
        //    {
        //        Instance.Error("{0}: Binary sinyal bilgisi veritabanýndan okunamadý => {1}", this.GetType().Name, ex.Message);
        //        return null;
        //    }
        //}

        public List<T> GetDeviceSignalsInfo<T>(Device d) where T : Signal, new()
        {
            string type_T = typeof(T).ToString();
            string query;

            query = GetDeviceSignalsInfoQueryText(type_T, d.ID);
            
            T signal;
            List<T> signals = new List<T>();
            DataTable dt = new DataTable();
            try
            {
                dt = ExecuteQuery(query);
                if (dt.HasRows())
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        signal = new T();
                        signal.GetPropertyValuesFromDataRow(dr);
                        signals.Add(signal);
                    }
                }

                return signals;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: {1} adlý device için veritabananýndan {2} bilgileri okunurken hata oluþtu => {3}", this.GetType().Namespace, d.Name, type_T, ex.Message);
                return null;
            }
        }

        

        public List<T> GetStationDevices<T>(Station s) where T :  Device, new()
        {
            string query = GetStationDevicesQueryText(typeof(T), s);
            List<T> devices = new List<T>();
            DataTable dt = new DataTable();
            try
            {

                dt = ExecuteQuery(query);
                if (dt.HasRows())
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        T device = new T();
                        device.GetPropertyValuesFromDataRow(dr);
                        devices.Add(device);
                    }
                }
                return devices;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: {1} adlý istasyona ait cihaz bilgileri okunurken hata oluþtu => {2}", this.GetType().Name, s.Name, ex.Message);
                throw;
            }
        }

        protected bool SetAnalogSignalValue(uint _signalID, UInt32 _signalValue, string _datetime)
        {
            Log.Instance.Trace("{0} methodu çaðrýldý cagrýldý", MethodBase.GetCurrentMethod().Name);
            bool _returnValue = false;
            string query = String.Format("Call setAnalogSignalValue({0},{1},'{2}')", _signalID, _signalValue, _datetime);
            DataTable dt = new DataTable();
            try
            {
                dt = ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Fatal("Database Hatasý (setAnalogSignalValue stored procedure çaðrýlýrken bir hata olustu): {0}, {1}", ex.Message, query);
                return false;
            }

            return _returnValue;
        }

        /// <summary>
        /// Sets the binary signal value.
        /// </summary>
        /// <param name="_signalID">The signal identifier.</param>
        /// <param name="_signalValue">if set to <c>true</c> [signal value].</param>
        /// <param name="_datetime">The datetime.</param>
        /// <returns></returns>
        protected bool SetBinarySignalValue(uint _signalID, bool _signalValue, string _datetime)
        {
            Log.Instance.Trace("{0} methodu çaðrýldý cagrýldý", MethodBase.GetCurrentMethod().Name);
            bool _returnValue = false;
            string value = _signalValue == true ? "1" : "0";
            string query = String.Format("CALL setBinarySignalValue('{0}', {1},'{2}')", _signalID, value, _datetime);
            DataTable dt = new DataTable();
            try
            {
                dt = ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        _returnValue = (dr.Field<bool>("result"));
                        if (!_returnValue)
                        {
                            Log.Instance.Error("Database Hatasý: (setBinarySignalValue('{0}', {1}, '{2}') stored procedure çaðrýlýrken bir hata oluþtu)", _signalID, _signalValue, _datetime);
                        }
                    }
                }
                else
                {
                    Log.Instance.Error("Database'den deger donmedi");
                    _returnValue = false;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Fatal("Database Hatasý: setBinarySignalValue stored procedure çaðrýlýrken bir hata olustu => {0}", ex.Message);
                return false;
            }

            return _returnValue;
        }

        public void SetDriverDevicesDisconnected(CommunicationProtocol _communicationProtocol)
        {
            string query = $"CALL setDriverAllDevicesDisconnected({_communicationProtocol.ID})";
            try
            {
                ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Sürücü durdurulurken tüm cihazlarýn isConnected bilgisi deðiþtirilemedi =>{1}", this.GetType().Name, ex.Message);
            }
        }
        #endregion Protected Methods

        #region Public  Methods

        public bool AddNewModbusAnalogSignal(ModbusAnalogSignal analogSignal)
        {
            int hasMaxAlarm, hasMinAlarm, isArchive, displayAtStationPage, displayAtDetailPage;
            string query, max_value, min_value;
            try
            {
                // Bir kerede update edilecek satýr sayýsý 30k dolaylarýnda olursa database'in hata verme ihtimali var
                hasMaxAlarm = analogSignal.HasMaxAlarm.ToString().ToUpper() == "TRUE" ? 1 : 0;
                hasMinAlarm = analogSignal.HasMinAlarm.ToString().ToUpper() == "TRUE" ? 1 : 0;
                isArchive = analogSignal.IsArchive.ToString().ToUpper() == "TRUE" ? 1 : 0;
                max_value = analogSignal.MaxAlarmValue.ToString().Replace(",", ".");
                min_value = analogSignal.MinAlarmValue.ToString().Replace(",", ".");
                displayAtStationPage = analogSignal.DisplayAtStationDetailPage.ToString().ToUpper() == "TRUE" ? 1 : 0;
                displayAtDetailPage = analogSignal.DisplayAtDeviceDetailPage.ToString().ToUpper() == "TRUE" ? 1 : 0;

                query = $"CALL addNewModbusAnalogSignal('{analogSignal.ID}', '{analogSignal.deviceID}', '{analogSignal.Name}', '{analogSignal.Identification}', '{analogSignal.dataType.ID}','{analogSignal.Unit}','{analogSignal.ScaleValue}','{max_value}','{min_value}','{analogSignal.MaxAlarmStatusTextID}','{analogSignal.MinAlarmStatusTextID}','{hasMaxAlarm}','{hasMinAlarm}','{isArchive}','{analogSignal.archivePeriod.ID}', '{displayAtStationPage}', '{displayAtDetailPage}', {analogSignal.Address}','{analogSignal.FunctionCode}','{analogSignal.WordCount}')";
                return ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Veritabanýna yeni analog sinyal eklenirken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        public bool AddNewModbusBinarySignal(ModbusBinarySignal binarySignal)
        {
            string query = string.Empty;
            int isAlarm, isEvent, isReversed, displayAtStationPage, displayAtDetailPage;
            try
            {
                isAlarm = binarySignal.IsAlarm ? 1 : 0;
                isEvent = binarySignal.IsEvent ? 1 : 0;
                isReversed = binarySignal.IsReversed ? 1 : 0;
                displayAtStationPage = binarySignal.DisplayAtStationDetailPage.ToString().ToUpper() == "TRUE" ? 1 : 0;
                displayAtDetailPage = binarySignal.DisplayAtDeviceDetailPage.ToString().ToUpper() == "TRUE" ? 1 : 0;

                query =$"CALL addNewModbusBinarySignal('{binarySignal.ID}', '{binarySignal.deviceID}','{binarySignal.Name}', '{binarySignal.Identification}', '{binarySignal.StatusID}', '{isAlarm}', '{isEvent}', '{isReversed}', '{displayAtStationPage}', '{displayAtDetailPage}', '{binarySignal.Address}', '{binarySignal.FunctionCode}', '{binarySignal.WordCount}', '{binarySignal.ComparisonBitNumber}', '{binarySignal.ComparisonValue}', '{binarySignal.comparisonType}')";
                return ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Binary sinyal veritabanýna eklenirken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        public bool AddNewModbusCommandSignal(ModbusCommandSignal commandSignal)
        {
            string query = $"CALL addNewModbusCommand('{commandSignal.ID}','{commandSignal.deviceID}', '{commandSignal.Name}', '{commandSignal.Identification}', '{commandSignal.Address}', '{commandSignal.WordCount}', '{commandSignal.commandType}')";
            try
            {
                return ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Komut sinyali veritabanýna eklenirken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        public bool AddNewMailGroup(MailGroup mailgroup)
        {
            string query = $"INSERT INTO mail_groups(group_id, group_name) VALUES({mailgroup.ID},'{mailgroup.Name}');";
            try
            {
                return ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Yeni E-posta grubu oluþtururken hata => {1}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        public bool DeleteAnalogSignal(uint ID)
        {
            string query = $"CALL deleteAnalogSignalWithAllRecords('{ID}')";
            try
            {
                return ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: {1} ID numaralý sinyal veritabanýndan silinirken hata oluþtu => {2}", this.GetType().Name, ID, ex.Message);
                return false;
            }
        }

        public bool DeleteMailAlarm(string id)
        {
            string query = string.Format("DELETE FROM mail_alarms WHERE id = '{0}'", id);

            try
            {
                return ExecuteNonQuery(query) > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteMailGroup(MailGroup _mailGroup)
        {
            try
            {
                string query = string.Format("CALL deleteMailGroup('{0}')", _mailGroup.ID.ToString());
                return ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0} isimli mail grubu silinirken hata oluþtu => {1}", _mailGroup.Name, ex.Message);
                return false;
                throw;
            }
        }

        public T GetBinarySignalInfoByIdentification<T>(string signalIdentification) where T : BinarySignal, new()
        {
            string query;
            // Generic tipine göre sql sorgusu oluþturuluyor.
            switch (typeof(T).ToString())
            {
                case "ModbusBinarySignal":
                    query = $"CALL getModbusBinarySignalByIdentification('{signalIdentification}')";
                    break;
                case "SNMPBinarySignal":
                    query = $"CALL getSNMPBinarySignalByIdentification('{signalIdentification}')";
                    break;
                default:
                    Log.Instance.Error("{0}: Bilinmeyen sinyal tipi => {1}", this.GetType().Name, typeof(T).ToString());
                    return null;
            }

      
            DataTable dt;
            T binarySignal = new T();
            try
            {
                dt = ExecuteQuery(query);
                if (dt == null) return null;
                binarySignal.GetPropertyValuesFromDataRow(dt.Rows[0]);
                return binarySignal;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: {1} adlý sinyalin bilgileri veritanýndan okunurken hata oluþtu => {2}", this.GetType().Name, signalIdentification, ex.Message);
                return null;
            }

        }

        public uint GetNextAnalogSignalID()
        {
            string query = "CALL getNextAnalogSignalID()";
            try
            {
                DataTable dt = ExecuteQuery(query);
                if (dt.HasRows())
                {
                    return dt.Rows[0].Field<uint>("ID");
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Yeni analog sinyal için ID bilgisi alýnýrken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                return 0;
                throw;
            }
        }

        public T GetAnalogSignalsInfoByIdentification<T>(string _identification) where T :AnalogSignal, new()
        {
            string query;
            // Generic tipine göre sql sorgusu oluþturuluyor.
            switch (typeof(T).ToString())
            {
                case "ModbusAnalogSignal":
                    query = $"CALL getModbusAnalogSignalByIdentification('{_identification}')";
                    break;
                case "SNMPAnalogSignal":
                    query = $"CALL getSNMPAnalogSignalByIdentification('{_identification}')";
                    break;
                default:
                    Log.Instance.Error("{0}: Bilinmeyen sinyal tipi => {1}", this.GetType().Name, typeof(T).ToString());
                    return null;
            }

            T signal = new T();
            DataTable dt = new DataTable();
            try
            {
                dt = ExecuteQuery(query);
                if (dt.HasRows())
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        signal.GetPropertyValuesFromDataRow(dr);
                    }
                }
                return signal;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: {1} adlý sinyalin bilgileri veritanýndan okunurken hata oluþtu => {2}", this.GetType().Name, _identification, ex.Message);
                return null;
            }
        }

        public uint GetNextBinarySignalID()
        {
            string query = "CALL getNextBinarySignalID()";
            try
            {
                DataTable dt = ExecuteQuery(query);
                if (dt.HasRows())
                {
                    return dt.Rows[0].Field<uint>("ID");
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Yeni binary sinyal için ID bilgisi alýnýrken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                return 0;
                throw;
            }
        }

        public uint GetNextCommandSignalID()
        {
            string query = "CALL getNextCommandSignalID()";
            try
            {
                DataTable dt = ExecuteQuery(query);
                if (dt.HasRows())
                {
                    return dt.Rows[0].Field<uint>("ID");
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Yeni komut sinyali için ID bilgisi alýnýrken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                return 0;
                throw;
            }
        }

        public uint GetNextMailGroupID()
        {
            string query = "CALL GetNextMailGroupID()";
            try
            {
                DataTable dt = ExecuteQuery(query);
                if (dt.HasRows())
                {
                    return dt.Rows[0].Field<uint>("ID");
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Yeni e-posta grubu eklemek için ID bilgisi alýnýrken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                return 0;
                throw;
            }
        }

        /// <summary>
        /// Gets the used modbus slave address.
        /// </summary>
        /// <param name="_stationName">Name of the station.</param>
        /// <returns></returns>
        public List<int> GetUsedModbusSlaveAddresses(string _stationName)
        {
            List<int> usedModbusSlaveAddresses = new List<int>();
            try
            {
                string query = String.Format("CALL getUsedModbusSlaveAddresses('{0}')", _stationName);
                DataTable dt = new DataTable();
                dt = ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        usedModbusSlaveAddresses.Add(dr.Field<int>(0));
                    }
                }
                return usedModbusSlaveAddresses;
            }
            catch (Exception)
            {
                Log.Instance.Error("Database Hatasý: {0} istasyonu için mevcut slave adresler database'den okunamadý.", _stationName);
                return usedModbusSlaveAddresses;
            }
        }

        public bool UpdateModbusAnalogSignal(ModbusAnalogSignal analogSignal)
        {
            int HasMaxAlarm, HasMinAlarm, isEvent, isArchive, displayAtStationPage, displayAtDetailPage;
            string query;
            try
            {
                HasMaxAlarm = analogSignal.HasMaxAlarm.ToString().ToUpper() == "TRUE" ? 1 : 0;
                HasMinAlarm = analogSignal.HasMinAlarm.ToString().ToUpper() == "TRUE" ? 1 : 0;
                isArchive = analogSignal.IsArchive.ToString().ToUpper() == "TRUE" ? 1 : 0;
                string max_value = analogSignal.MaxAlarmValue.ToString().Replace(",", ".");
                string min_value = analogSignal.MinAlarmValue.ToString().Replace(",", ".");
                displayAtStationPage = analogSignal.DisplayAtStationDetailPage.ToString().ToUpper() == "TRUE" ? 1 : 0;
                displayAtDetailPage = analogSignal.DisplayAtDeviceDetailPage.ToString().ToUpper() == "TRUE" ? 1 : 0;

                query =
                    $"CALL updateModbusAnalogSignal('{analogSignal.ID}', '{analogSignal.deviceID}', '{analogSignal.Name}', '{analogSignal.Identification}', '{analogSignal.Identification}', '{analogSignal.Unit}', '{analogSignal.ScaleValue}', '{max_value}', '{min_value}', '{analogSignal.MaxAlarmStatusTextID}', '{analogSignal.MinAlarmStatusTextID}', '{HasMaxAlarm}', '{HasMinAlarm}', '{isArchive}', '{analogSignal.archivePeriod.ID}', '{displayAtStationPage}', '{displayAtDetailPage}', '{analogSignal.Address}', '{analogSignal.FunctionCode}', '{analogSignal.WordCount}')";
                return ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Modbus analog sinyali güncellenirken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        public bool UpdateModbusBinarySignal(ModbusBinarySignal binarySignal)
        {
            int IsAlarm, IsEvent, IsReversed, displayAtStationPage, displayAtDetailPage;
            string query;
            try
            {
                IsAlarm = binarySignal.IsAlarm.ToString().ToUpper() == "TRUE" ? 1 : 0;
                IsEvent = binarySignal.IsEvent.ToString().ToUpper() == "TRUE" ? 1 : 0;
                IsReversed = binarySignal.IsReversed.ToString().ToUpper() == "TRUE" ? 1 : 0;
                displayAtStationPage = binarySignal.DisplayAtStationDetailPage.ToString().ToUpper() == "TRUE" ? 1 : 0;
                displayAtDetailPage = binarySignal.DisplayAtDeviceDetailPage.ToString().ToUpper() == "TRUE" ? 1 : 0;

                query = $"CALL updateModbusBinarySignal('{binarySignal.ID}', '{binarySignal.deviceID}', '{binarySignal.Name}', '{binarySignal.Identification}', '{binarySignal.StatusID}',  '{IsAlarm}', '{IsEvent}', '{IsReversed}', '{displayAtStationPage}', '{displayAtDetailPage}', '{binarySignal.Address}', '{binarySignal.FunctionCode}', '{binarySignal.WordCount}', '{binarySignal.ComparisonBitNumber}', '{binarySignal.ComparisonValue}', '{binarySignal.comparisonType}')";
                return ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Modbus Binary sinyal güncellenirken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        public bool IsSignalAvalibale(string v)
        {
            string query = string.Format("CALL isSignalAvaliable('{0}');", v);
            if (ExecuteQuery(query).Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Gets the active commands.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDriverActiveCommands(string _protocolName)
        {
            DataTable dt = new DataTable();
            string query = $"CALL getDriverActiveCommands('{_protocolName}')";
            try
            {
                dt = ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: SCADA'dan gelen komutlarý okurken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                throw;
            }
            return dt;
        }

        public List<DataType> GetAllDataTypes()
        {
            {
                List<DataType> dataTypes = new List<DataType>();
                string query = "CALL getAllDataTypes();";
                DataTable dt = new DataTable();
                try
                {
                    dt = ExecuteQuery(query);
                    foreach (DataRow dr in dt.Rows)
                    {
                        DataType dataType = new DataType();
                        dataType.ID = dr.Field<byte>("data_type_id");
                        dataType.Name = dr.Field<string>("name");
                        dataTypes.Add(dataType);
                    }
                    return dataTypes;
                }
                catch (Exception ex)
                {
                    Log.Instance.Error("{0}: Data Tipi bilgileri veritabanýndan çekilirken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                    return dataTypes;
                    throw;
                }
            }
        }

        public List<ArchivePeriod> GetAllArchivePeriods()
        {
            {
                List<ArchivePeriod> archivePeriods = new List<ArchivePeriod>();
                string query = "CALL getAllArchivePeriods();";
                DataTable dt = new DataTable();
                try
                {
                    dt = ExecuteQuery(query);
                    foreach (DataRow dr in dt.Rows)
                    {
                        ArchivePeriod archivePeriod = new ArchivePeriod();
                        archivePeriod.ID = dr.Field<uint>("id");
                        archivePeriod.Description = dr.Field<string>("description");
                        archivePeriod.Period = dr.Field<uint>("period");
                        archivePeriods.Add(archivePeriod);
                    }
                    return archivePeriods;
                }
                catch (Exception ex)
                {
                    Log.Instance.Error("{0}: Arþivleme periyot bilgileri veritabanýndan çekilirken hata oluþtu => {1}", this.GetType().Name, ex.Message);
                    return archivePeriods;
                    throw;
                }
            }
        }
        public bool AddNewMailAlarm(AlarmMail _alarmMail)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractDBHelper.AddNewMailAlarm(AlarmMail)'
        {
            string query = string.Format("CALL addNewMailAlarm('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", _alarmMail.Name, _alarmMail.LogicText, _alarmMail.MailGroupID.ToString(), _alarmMail.EMailSubject, _alarmMail.EmailText, _alarmMail.Delaytime.ToString());
            bool result = false;
            if (ExecuteNonQuery(query) > 0)
            {
                result = true;
            }

            return result;
        }

        public void DeleteActiveCommandFromDatabase(uint _commandID)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractDBHelper.DeleteActiveCommand(uint)'
        {
            string query = string.Format("CALL deleteActiveCommand('{0}');", _commandID);
            try
            {
                ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: komut database'den silinemedi. => {1}", this.GetType().Name, ex.Message);
            }
        }

        /// <summary>
        /// Adds the station.
        /// </summary>
        /// <param name="_stationName">Name of the station.</param>
        /// <returns></returns>
        public bool AddStation(string _stationName)
        {
            string query = String.Format("Call addStation('{0}');", _stationName);
            int result = ExecuteNonQuery(query);

            return result > 0;
        }

        /// <summary>
        /// Gets all stations information with device information.
        /// </summary>
        /// <returns></returns>
        public List<Station> GetAllStationsInfoWithDeviceInfo()
        {
            Log.Instance.Trace("DBHelper.{0} methodu çaðrýldý", MethodBase.GetCurrentMethod().Name);
            List<Station> _stations = new List<Station>();
            try
            {
                string query = String.Format("CALL getAllStationsInfo();");
                DataTable dt = new DataTable();
                dt = ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Station _station = new Station(dr);

                        // Ýstasyona ait cihazlar okunuyor
                        _station.Devices = GetStationDevicesBasicInfo(_station.Name);

                        _stations.Add(_station);
                    }

                    return _stations;
                }
                else
                {
                    Log.Instance.Trace("DBHelper.{0}", MethodBase.GetCurrentMethod().Name);
                    Log.Instance.Warn("Database'de station kaydý bulunamadý");
                    return _stations;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Debug("{0}.{1} => {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return _stations;
            }
        }

        public DataTable GetAllAnalogSignalsInfoWithLastValues()

        {
            DataTable dt = new DataTable();
            try
            {
                if (OpenConnection())
                {
                    string query = "CALL getAllAnalogSignalsBasicInfoWithLastValues();";
                    dt = ExecuteQuery(query);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Analog sinyaller database'den okunamadý => {0}", ex.Message);
                return dt;
            }
        }

        public DataTable GetAllBinarySignalsInfoWithLastValues()
        {
            DataTable dt = new DataTable();
            try
            {
                if (OpenConnection())
                {
                    string query = "CALL getAllBinarySignalsBasicInfoWithLastValues();";
                    dt = ExecuteQuery(query);
                }
                return dt;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Binary sinyaller database'den okunamadý => {0}", ex.Message);
                return dt;
            }
        }

        public bool UpdateGroupName(MailGroup _mailGroup, string newName)

        {
            bool success = false;
            try
            {
                if (OpenConnection())
                {
                    string query = String.Format("Call updateGroupName({0},'{1}')", _mailGroup.ID, newName);
                    if (ExecuteNonQuery(query) == 1)
                    {
                        success = true;
                    }
                }

                return success;
            }
            catch (Exception)
            {
                return success;
                throw;
            }
        }

        /// <summary>
        /// Gets all alarm mails.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllAlarmMailsAsDataTable()
        {
            try
            {
                DataTable dt = new DataTable();
                if (OpenConnection())
                {
                    string query = "CALL getAllAlarmMails();";

                    dt = ExecuteQuery(query);
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AlarmMail> GetAllAlarmMails()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractDBHelper.GetAllAlarmMails()'
        {
            List<AlarmMail> alarmMails = new List<AlarmMail>();
            string query = "CALL getAllAlarmMails();";
            try
            {
                DataTable dt = new DataTable();
                if (OpenConnection())
                {
                    dt = ExecuteQuery(query);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            AlarmMail am = new AlarmMail();
                            am.EMailSubject = dr.Field<string>("email_subject");
                            am.EmailText = dr.Field<string>("email_text");
                            am.ID = dr.Field<uint>("id");
                            am.LogicText = dr.Field<string>("logic_text");
                            am.MailGroupID = dr.Field<uint>("email_group_id");
                            am.Name = dr.Field<string>("name");
                            am.isActive = dr.Field<bool>("is_active");
                            am.Status = dr.Field<bool>("status");
                            am.Delaytime = dr.Field<UInt32>("delay_time");
                            alarmMails.Add(am);
                        }
                    }
                }
                return alarmMails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CommunicationProtocol> GetAllProtocolsInfo()
        {
            Log.Instance.Trace("DBHelper.{0} methodu çaðrýldý", MethodBase.GetCurrentMethod().Name);
            List<CommunicationProtocol> protocols = new List<CommunicationProtocol>();
            try
            {
                string query = String.Format("CALL getAllProtocolsInfo();");
                DataTable dt = new DataTable();
                dt = ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CommunicationProtocol _protocol = new CommunicationProtocol(dr);
                        protocols.Add(_protocol);
                    }

                    return protocols;
                }
                else
                {
                    Log.Instance.Trace("DBHelper.{0}", MethodBase.GetCurrentMethod().Name);
                    Log.Instance.Warn("Database'de haberleþme protokolü kaydý bulunamadý");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Debug("{0}.{1} => {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return null;
            }
        }

        public List<User> GetMailRecipients(uint mailGroupID)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractDBHelper.GetMailRecipients(uint)'
        {
            try
            {
                List<User> users = new List<User>();
                string query = string.Format("CALL getMailRecipients('{0}')", mailGroupID.ToString());
                DataTable dt = ExecuteQuery(query);
                if (dt.HasRows())
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        User user = new User();
                        user.Name = dr.Field<string>("name");
                        user.Surname = dr.Field<string>("surname");
                        user.Email = dr.Field<string>("email");
                        users.Add(user);
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Database'den mail adresleri çekilemedi => {0}", ex.Message);
                throw ex;
            }
        }

        public bool UpdateMailAlarmStatus(AlarmMail alarm)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractDBHelper.UpdateMailAlarmStatus(AlarmMail)'
        {
            try
            {
                string status;
                if (alarm.Status == true)
                {
                    status = "1";
                }
                else
                {
                    status = "0";
                }
                string query = string.Format("CALL updateAlarmStatus('{0}', '{1}')", alarm.ID.ToString(), status);
                return ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0} isimli mail alarmýn durumu güncellenemedi => {1}", alarm.Name, ex.Message);
                return false;
            }
        }

        public bool UpdateUserMailGroup(uint _userID, uint _mailGroupID)
        {
            try
            {
                string query = string.Format("CALL updateUserMailGroup('{0}','{1}')", _userID, _mailGroupID);
                return ExecuteNonQuery(query) > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateExistingMailAlarm(uint id, string name, string logicText, uint mailGroupID, string eMailSubject, string emailText)
        {
            try
            {
                if (OpenConnection())
                {
                    string query = string.Format("CALL updateExistingMailAlarm('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", id, name, logicText, mailGroupID, eMailSubject, emailText);
                    int result = ExecuteNonQuery(query);
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                    throw new Exception("Database baðlantýsý kurulamadý");
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// Gets the name of the station information by.
        /// </summary>
        /// <param name="_stationName">Name of the station.</param>
        /// <returns></returns>
        public Station GetStationInfoByName(string _stationName)
        {
            Log.Instance.Trace("DBHelper.{0} methodu {1} için çaðrýldý", MethodBase.GetCurrentMethod().Name, _stationName);
            Station _station = null;
            try
            {
                string query = String.Format("CALL getStationInfoByName('{0}')", _stationName);
                DataTable dt = new DataTable();
                dt = ExecuteQuery(query);
                if (dt.Rows.Count > 0)
                {
                    _station = new Station();
                    _station.ID = dt.Rows[0].Field<ushort>("station_id");
                    _station.Name = _stationName;
                }
                else
                {
                    Log.Instance.Trace("DBHelper.{0}", MethodBase.GetCurrentMethod().Name);
                    Log.Instance.Warn("{0} adlý bir station kaydý bulunamadý", _stationName);
                }

                return _station;
            }
            catch (Exception ex)
            {
                Log.Instance.Debug("{0}.{1} => {2}", this.GetType().Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return null;
            }
        }

        public bool UpdateAnalogSignals(DataTable _dt)
        {
            int HasMaxAlarm, HasMinAlarm, isEvent, isArchive, isSummary, isGauge;
            List<string> Rows = new List<string>();
            try
            {
                // Bir kerede update edilecek satýr sayýsý 30k dolaylarýnda olursa database'in hata verme ihtimali var
                DataRow firstRow = _dt.Rows[0];
                HasMaxAlarm = firstRow["Max Alarm"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                HasMinAlarm = firstRow["Min Alarm"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                isArchive = firstRow["Archive"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                isSummary = firstRow["Device Page Shown"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                isGauge = firstRow["Detail Page Shown"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                StringBuilder query = new StringBuilder(string.Format("UPDATE analog_signals ass JOIN (SELECT '{0}' as _analog_signal_id, '{1}' as _device_id, '{2}' as _name, '{3}' as _identification, '{4}' as _address, '{5}' as _function_code, '{6}' as _word_count, '{7}' as _data_type_id, '{8}' as _unit, {9} as _scale_value, '{10}' as _max_value, '{11}' as _min_value, '{12}' as _max_status_id, '{13}' as _min_status_id, '{14}' as _has_max_alarm, '{15}' as _has_min_alarm, '{16}' as _is_archive, '{17}' as _archive_period_id, '{18}' as _is_summary, '{19}' as _is_gauge UNION ALL ",
                    MySqlHelper.EscapeString(firstRow["Analog Signal ID"].ToString()), MySqlHelper.EscapeString(firstRow["Device ID"].ToString()), MySqlHelper.EscapeString(firstRow["Name"].ToString()),
                                                        MySqlHelper.EscapeString(firstRow["Identification"].ToString()), MySqlHelper.EscapeString(firstRow["Address"].ToString()), MySqlHelper.EscapeString(firstRow["Function Code"].ToString()),
                                                        MySqlHelper.EscapeString(firstRow["Word Count"].ToString()), MySqlHelper.EscapeString(firstRow["Data Type ID"].ToString()), MySqlHelper.EscapeString(firstRow["Unit"].ToString()),
                                                        MySqlHelper.EscapeString(firstRow["Scale Value"].ToString()), MySqlHelper.EscapeString(firstRow["Max Value"].ToString().Replace(",",".")), MySqlHelper.EscapeString(firstRow["Min Value"].ToString().Replace(",", ".")),
                                                        MySqlHelper.EscapeString(firstRow["Max Alarm ID"].ToString()), MySqlHelper.EscapeString(firstRow["Min Alarm ID"].ToString()), MySqlHelper.EscapeString(HasMaxAlarm.ToString()), MySqlHelper.EscapeString(HasMinAlarm.ToString()),
                                                        MySqlHelper.EscapeString(isArchive.ToString()), MySqlHelper.EscapeString(firstRow["Archive Period ID"].ToString()), MySqlHelper.EscapeString(isSummary.ToString()), MySqlHelper.EscapeString(isGauge.ToString())));
                for (int i = 1; i < _dt.Rows.Count - 1; i++)
                {
                    DataRow innerRow = _dt.Rows[i];
                    HasMaxAlarm = innerRow["Max Alarm"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    HasMinAlarm = innerRow["Min Alarm"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    isArchive = innerRow["Archive"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    isSummary = innerRow["Device Page Shown"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    isGauge = innerRow["Detail Page Shown"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    query.Append(string.Format("SELECT '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}' UNION ALL ",
                                            MySqlHelper.EscapeString(innerRow["Analog Signal ID"].ToString()), MySqlHelper.EscapeString(innerRow["Device ID"].ToString()), MySqlHelper.EscapeString(innerRow["Name"].ToString()),
                                            MySqlHelper.EscapeString(innerRow["Identification"].ToString()), MySqlHelper.EscapeString(innerRow["Address"].ToString()), MySqlHelper.EscapeString(innerRow["Function Code"].ToString()),
                                            MySqlHelper.EscapeString(innerRow["Word Count"].ToString()), MySqlHelper.EscapeString(innerRow["Data Type ID"].ToString()), MySqlHelper.EscapeString(innerRow["Unit"].ToString()),
                                            MySqlHelper.EscapeString(innerRow["Scale Value"].ToString()), MySqlHelper.EscapeString(innerRow["Max Value"].ToString().Replace(",", ".")), MySqlHelper.EscapeString(innerRow["Min Value"].ToString().Replace(",", ".")),
                                            MySqlHelper.EscapeString(innerRow["Max Alarm ID"].ToString()), MySqlHelper.EscapeString(innerRow["Min Alarm ID"].ToString()), MySqlHelper.EscapeString(HasMaxAlarm.ToString()), MySqlHelper.EscapeString(HasMinAlarm.ToString()),
                                            MySqlHelper.EscapeString(isArchive.ToString()), MySqlHelper.EscapeString(innerRow["Archive Period ID"].ToString()), MySqlHelper.EscapeString(isSummary.ToString()), MySqlHelper.EscapeString(isGauge.ToString())));
                }
                DataRow lastRow = _dt.Rows[_dt.Rows.Count - 1];
                HasMaxAlarm = lastRow["Max Alarm"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                HasMinAlarm = lastRow["Min Alarm"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                isArchive = lastRow["Archive"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                isSummary = lastRow["Device Page Shown"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                isGauge = lastRow["Detail Page Shown"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                query.Append(string.Format("SELECT '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}')",
                                            MySqlHelper.EscapeString(lastRow["Analog Signal ID"].ToString()), MySqlHelper.EscapeString(lastRow["Device ID"].ToString()), MySqlHelper.EscapeString(lastRow["Name"].ToString()),
                                            MySqlHelper.EscapeString(lastRow["Identification"].ToString()), MySqlHelper.EscapeString(lastRow["Address"].ToString()), MySqlHelper.EscapeString(lastRow["Function Code"].ToString()),
                                            MySqlHelper.EscapeString(lastRow["Word Count"].ToString()), MySqlHelper.EscapeString(lastRow["Data Type ID"].ToString()), MySqlHelper.EscapeString(lastRow["Unit"].ToString()),
                                            MySqlHelper.EscapeString(lastRow["Scale Value"].ToString()), MySqlHelper.EscapeString(lastRow["Max Value"].ToString().Replace(",", ".")), MySqlHelper.EscapeString(lastRow["Min Value"].ToString().Replace(",", ".")),
                                            MySqlHelper.EscapeString(lastRow["Max Alarm ID"].ToString()), MySqlHelper.EscapeString(lastRow["Min Alarm ID"].ToString()), MySqlHelper.EscapeString(HasMaxAlarm.ToString()), MySqlHelper.EscapeString(HasMinAlarm.ToString()),
                                            MySqlHelper.EscapeString(isArchive.ToString()), MySqlHelper.EscapeString(lastRow["Archive Period ID"].ToString()), MySqlHelper.EscapeString(isSummary.ToString()), MySqlHelper.EscapeString(isGauge.ToString())));
                //                vals ON m.id = vals.id
                //SET col1 = _col1, col2 = _col2;
                query.Append(String.Format(" vals ON ass.analog_signal_id = vals._analog_signal_id SET device_id = _device_id, name = _name, identification = _identification, address = _address, function_code = _function_code, word_count = _word_count, data_type_id = _data_type_id, unit = _unit, scale_value = _scale_value, max_value = _max_value, min_value = _min_value, max_status_id = _max_status_id, min_status_id = _min_status_id, has_max_alarm = _has_max_alarm, has_min_alarm = _has_min_alarm, is_archive = _is_archive, archive_period_id = _archive_period_id, is_summary = _is_summary, is_gauge = _is_gauge;"));
                query = query.Replace("''", "NULL");
                return ExecuteNonQuery(query.ToString()) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Analog sinyaller update edilirken hata => {1}", this.GetType().Name, ex.Message);
                return false;
                throw;
            }
        }

        public bool UpdateBinarySignals(DataTable _dt)
        {
            int isAlarm, isEvent, isReverse, isMail;
            List<string> Rows = new List<string>();
            StringBuilder query = new StringBuilder();
            try
            {
                // Bir kerede update edilecek satýr sayýsý 30k dolaylarýnda olursa database'in hata verme ihtimali var
                DataRow firstRow = _dt.Rows[0];
                isAlarm = firstRow["Alarm"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                isEvent = firstRow["Event"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                isReverse = firstRow["Reverse"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                isMail = firstRow["Send Mail"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                query.Append(string.Format("UPDATE binary_signals ass JOIN (SELECT '{0}' as _binary_signal_id, '{1}' as _device_id, '{2}' as _name, '{3}' as _identification, '{4}' as _address, '{5}' as _function_code, '{6}' as _word_count, '{7}' as _bit_number, '{8}' as _is_alarm, '{9}' as _is_event, '{10}' as _is_reversed, '{11}' as _status_id, '{12}' as _send_mail, '{13}' as _mail_message UNION ALL ",
                                            MySqlHelper.EscapeString(firstRow["Binary Signal ID"].ToString()), MySqlHelper.EscapeString(firstRow["Device ID"].ToString()), MySqlHelper.EscapeString(firstRow["Name"].ToString()),
                                            MySqlHelper.EscapeString(firstRow["Identification"].ToString()), MySqlHelper.EscapeString(firstRow["Address"].ToString()), MySqlHelper.EscapeString(firstRow["Function Code"].ToString()),
                                            MySqlHelper.EscapeString(firstRow["Word Count"].ToString()), MySqlHelper.EscapeString(firstRow["Bit Number"].ToString()), MySqlHelper.EscapeString(isAlarm.ToString()),
                                            MySqlHelper.EscapeString(isEvent.ToString()), MySqlHelper.EscapeString(isReverse.ToString()), MySqlHelper.EscapeString(firstRow["Status ID"].ToString()), MySqlHelper.EscapeString(isMail.ToString()), MySqlHelper.EscapeString(firstRow["Mail Message"].ToString())));
                for (int i = 1; i < _dt.Rows.Count - 1; i++)
                {
                    DataRow innerRow = _dt.Rows[i];
                    isAlarm = innerRow["Alarm"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    isEvent = innerRow["Event"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    isReverse = innerRow["Reverse"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    isMail = innerRow["Send Mail"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    query.Append(string.Format("SELECT '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, '{10}', '{11}', '{12}', '{13}' UNION ALL ",
                                            MySqlHelper.EscapeString(innerRow["Binary Signal ID"].ToString()), MySqlHelper.EscapeString(innerRow["Device ID"].ToString()), MySqlHelper.EscapeString(innerRow["Name"].ToString()),
                                            MySqlHelper.EscapeString(innerRow["Identification"].ToString()), MySqlHelper.EscapeString(innerRow["Address"].ToString()), MySqlHelper.EscapeString(innerRow["Function Code"].ToString()),
                                            MySqlHelper.EscapeString(innerRow["Word Count"].ToString()), MySqlHelper.EscapeString(innerRow["Bit Number"].ToString()), MySqlHelper.EscapeString(isAlarm.ToString()),
                                            MySqlHelper.EscapeString(isEvent.ToString()), MySqlHelper.EscapeString(isReverse.ToString()), MySqlHelper.EscapeString(innerRow["Status ID"].ToString()), MySqlHelper.EscapeString(isMail.ToString()), MySqlHelper.EscapeString(innerRow["Mail Message"].ToString())));
                }
                DataRow lastRow = _dt.Rows[_dt.Rows.Count - 1];
                isAlarm = lastRow["Alarm"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                isEvent = lastRow["Event"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                isReverse = lastRow["Reverse"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                isMail = lastRow["Send Mail"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                query.Append(string.Format("SELECT '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, '{10}', '{11}', '{12}', '{13}') ",
                                            MySqlHelper.EscapeString(lastRow["Binary Signal ID"].ToString()), MySqlHelper.EscapeString(lastRow["Device ID"].ToString()), MySqlHelper.EscapeString(lastRow["Name"].ToString()),
                                            MySqlHelper.EscapeString(lastRow["Identification"].ToString()), MySqlHelper.EscapeString(lastRow["Address"].ToString()), MySqlHelper.EscapeString(lastRow["Function Code"].ToString()),
                                            MySqlHelper.EscapeString(lastRow["Word Count"].ToString()), MySqlHelper.EscapeString(lastRow["Bit Number"].ToString()), MySqlHelper.EscapeString(isAlarm.ToString()),
                                            MySqlHelper.EscapeString(isEvent.ToString()), MySqlHelper.EscapeString(isReverse.ToString()), MySqlHelper.EscapeString(lastRow["Status ID"].ToString()), MySqlHelper.EscapeString(isMail.ToString()), MySqlHelper.EscapeString(lastRow["Mail Message"].ToString())));
                //                vals ON m.id = vals.id
                //SET col1 = _col1, col2 = _col2;
                query.Append(String.Format("vals ON ass.binary_signal_id = vals._binary_signal_id SET binary_signal_id = _binary_signal_id, device_id = _device_id, name = _name, identification = _identification, address = _address, function_code = _function_code, word_count = _word_count, comparison_bit_number = _bit_number, is_alarm = _is_alarm, is_event = _is_event, is_reversed = _is_reversed, status_id = _status_id, send_mail = _send_mail, mail_message  = _mail_message;"));
                return ExecuteNonQuery(query.ToString()) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Binary sinyaller update edilirken hata => {1}", this.GetType().Name, ex.Message);
                return false;
                throw;
            }
        }

        public bool UpdateCommandSignals(DataTable _dt)
        {
            StringBuilder query = new StringBuilder();
            try
            {
                // Bir kerede update edilecek satýr sayýsý 30k dolaylarýnda olursa database'in hata verme ihtimali var
                DataRow firstRow = _dt.Rows[0];
                var isEvent = firstRow["Event"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                query.Append(string.Format("UPDATE command_signals ass JOIN (SELECT '{0}' as _command_signal_id, '{1}' as _device_id, '{2}' as _name, '{3}' as _identification, '{4}' as _address, '{5}' as _function_code, '{6}' as _word_count, '{7}' as _bit_number, '{8}' as _is_event, '{9}' as _status_id, '{10}' as _command_type UNION ALL ",
                                            MySqlHelper.EscapeString(firstRow["Command Signal ID"].ToString()), MySqlHelper.EscapeString(firstRow["Device ID"].ToString()), MySqlHelper.EscapeString(firstRow["Name"].ToString()),
                                            MySqlHelper.EscapeString(firstRow["Identification"].ToString()), MySqlHelper.EscapeString(firstRow["Address"].ToString()), MySqlHelper.EscapeString(firstRow["Function Code"].ToString()),
                                            MySqlHelper.EscapeString(firstRow["Word Count"].ToString()), MySqlHelper.EscapeString(firstRow["Bit Number"].ToString()), MySqlHelper.EscapeString(isEvent.ToString()),
                                            MySqlHelper.EscapeString(firstRow["Status ID"].ToString()), MySqlHelper.EscapeString(firstRow["Command Type"].ToString())));
                for (int i = 1; i < _dt.Rows.Count - 1; i++)
                {
                    DataRow innerRow = _dt.Rows[i];
                    isEvent = innerRow["Event"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    query.Append(string.Format("SELECT '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, '{10}' UNION ALL ",
                                            MySqlHelper.EscapeString(innerRow["Command Signal ID"].ToString()), MySqlHelper.EscapeString(innerRow["Device ID"].ToString()), MySqlHelper.EscapeString(innerRow["Name"].ToString()),
                                            MySqlHelper.EscapeString(innerRow["Identification"].ToString()), MySqlHelper.EscapeString(innerRow["Address"].ToString()), MySqlHelper.EscapeString(innerRow["Function Code"].ToString()),
                                            MySqlHelper.EscapeString(innerRow["Word Count"].ToString()), MySqlHelper.EscapeString(innerRow["Bit Number"].ToString()), MySqlHelper.EscapeString(isEvent.ToString()),
                                            MySqlHelper.EscapeString(innerRow["Status ID"].ToString()), MySqlHelper.EscapeString(innerRow["Command Type"].ToString())));
                }
                DataRow lastRow = _dt.Rows[_dt.Rows.Count - 1];

                isEvent = lastRow["Event"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                query.Append(string.Format("SELECT '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}, '{10}') ",
                                            MySqlHelper.EscapeString(lastRow["Command Signal ID"].ToString()), MySqlHelper.EscapeString(lastRow["Device ID"].ToString()), MySqlHelper.EscapeString(lastRow["Name"].ToString()),
                                            MySqlHelper.EscapeString(lastRow["Identification"].ToString()), MySqlHelper.EscapeString(lastRow["Address"].ToString()), MySqlHelper.EscapeString(lastRow["Function Code"].ToString()),
                                            MySqlHelper.EscapeString(lastRow["Word Count"].ToString()), MySqlHelper.EscapeString(lastRow["Bit Number"].ToString()), MySqlHelper.EscapeString(isEvent.ToString()),
                                            MySqlHelper.EscapeString(lastRow["Status ID"].ToString()), MySqlHelper.EscapeString(lastRow["Command Type"].ToString())));
                // vals ON m.id = vals.id
                //SET col1 = _col1, col2 = _col2;
                query.Append("vals ON ass.command_signal_id = vals._command_signal_id SET command_signal_id = _command_signal_id, device_id = _device_id, name = _name, identification = _identification, address = _address, function_code = _function_code, word_count = _word_count, bit_number = _bit_number, is_event = _is_event, status_id = _status_id, command_type = _command_type;");
                return ExecuteNonQuery(query.ToString()) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Komut sinyalleri update edilirken hata => {1}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        public bool AddModbusTCPDeviceToDatabase(string stationName, string deviceName, string ipAddress, string slaveID)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractDBHelper.AddModbusTCPDeviceToDatabase(string, string, string, string)'
        {
            Log.Instance.Trace("{0}: {1} methodu {2} adlý cihazý eklemek için cagrýldý", this.GetType().Name, MethodBase.GetCurrentMethod().Name, deviceName);

            try
            {
                string query = String.Format("CALL addModbusTCPDevice('{0}', '{1}', '{2}', '{3}');", stationName, deviceName, ipAddress, slaveID);
                return ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Database Hata: {0} adlý cihaz database'e eklenemedi => {1}", deviceName, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Gets the station devices.
        /// </summary>
        /// <param name="_stationName">Name of the station.</param>
        /// <returns></returns>
        public List<Device> GetStationDevicesBasicInfo(string _stationName)
        {
            Log.Instance.Trace("{0}: {1} methodu cagrýldý", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            List<Device> _deviceList = new List<Device>();
            Device _device;

            try
            {
                string query = String.Format("CALL getStationDevicesBasicInfo('{0}')", _stationName);
                DataTable dt = new DataTable();
                dt = ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        _device = new Device();
                        _device.GetPropertyValuesFromDataRow(dr);
                        _deviceList.Add(_device);
                    }
                }
                else
                {
                    Log.Instance.Warn("{0} adlý station için device bulunamadý", _stationName);
                }

                //CloseConnection();
            }
            catch (Exception ex)
            {
                Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                Log.Instance.Fatal("Database hatasý: {0}", ex.Message);
                //throw;
            }

            return _deviceList;
        }

        /// <summary>
        /// Gets the device binary signals information.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <returns></returns>
        
        //public List<BinarySignal> GetDeviceBinarySignalsInfo(ushort _deviceID)
        //{
        //    Instance.Trace("{0}: {1} methodu {2} ID numaralý device için cagrýldý", this.GetType().Name, MethodBase.GetCurrentMethod().Name, _deviceID.ToString());

        //    List<BinarySignal> _binarySignalList = new List<BinarySignal>();
        //    BinarySignal _binarySignal;
        //    string query = String.Format("CALL getDeviceBinarySignalsInfo({0})", _deviceID.ToString());
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = ExecuteQuery(query);

        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                _binarySignal = new BinarySignal();
        //                _binarySignal.ID = dr.Field<uint>("binary_signal_id");
        //                _binarySignal.Name = dr.Field<string>("name");
        //                _binarySignal.Identification = dr.Field<string>("identification");
        //                _binarySignal.Address = dr.Field<ushort>("address");
        //                _binarySignal.FunctionCode = dr.Field<byte>("function_code");
        //                _binarySignal.WordCount = dr.Field<byte>("word_count");
        //                _binarySignal.ComparisonBitNumber = dr.Field<byte>("comparison_bit_number");
        //                _binarySignal.IsEvent = dr.Field<bool>("is_event");
        //                _binarySignal.IsAlarm = dr.Field<bool>("is_alarm");
        //                _binarySignal.IsReversed = dr.Field<bool>("is_reversed");
        //                _binarySignal.DeviceID = _deviceID;
        //                _binarySignal.ComparisonValue = dr.Field<int>("comparison_value");
        //                _binarySignal.CurrentValue = dr.Field<bool>("current_value");
        //                switch (dr.Field<string>("comparison_type"))
        //                {
        //                    case "bit":
        //                        _binarySignal.comparisonType = BinarySignal.ComparisonType.bit;
        //                        break;

        //                    case "value":
        //                        _binarySignal.comparisonType = BinarySignal.ComparisonType.value;
        //                        break;

        //                    default:
        //                        break;
        //                }
        //                _binarySignalList.Add(_binarySignal);
        //            }
        //        }
        //        else
        //        {
        //            Instance.Info("{0} id numarasýna sahip device için kayýtlý binary sinyal bulunamadý.", _deviceID.ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Instance.Error("Database baglantý hatasý => {0} nolu cihaza ait binary sinyalleri database'den dogru bir þekilde okunamadý... {1}", _deviceID.ToString(), ex.Message);
        //        throw;
        //    }

        //    return _binarySignalList;
        //}

        /// <summary>
        /// Gets all binary signals identifier.
        /// </summary>
        /// <returns></returns>
        public List<uint> GetAllBinarySignalsID()
        {
            List<uint> allBinarySignalsID = new List<uint>();
            string query = String.Format("CALL getAllBinarySignalsID();");
            DataTable dt = new DataTable();
            try
            {
                dt = ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        allBinarySignalsID.Add(dr.Field<uint>(0));
                    }
                }
                return allBinarySignalsID;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Binary sinyallerin ID'leri database'den okunamadý => {1}", this.GetType().Name, ex.Message);
                return allBinarySignalsID;
            }
        }

        /// <summary>
        /// Gets all analog signals identifier.
        /// </summary>
        /// <returns></returns>
        public List<uint> GetAllAnalogSignalsID()
        {
            List<uint> allAnalogSignalsID = new List<uint>();
            string query = String.Format("CALL getAllAnalogSignalsID();");
            DataTable dt = new DataTable();
            try
            {
                dt = ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        allAnalogSignalsID.Add(dr.Field<uint>(0));
                    }
                }
                return allAnalogSignalsID;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Analog sinyallerin ID'leri database'den okunamadý => {1}", this.GetType().Name, ex.Message);
                return allAnalogSignalsID;
            }
        }

        public List<uint> GetAllCommandSignalsID()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractDBHelper.GetAllCommandSignalsID()'
        {
            List<uint> allCommandSignalsID = new List<uint>();
            string query = String.Format("CALL getAllCommandSignalsID();");
            DataTable dt = new DataTable();
            try
            {
                dt = ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        allCommandSignalsID.Add(dr.Field<uint>(0));
                    }
                }
                return allCommandSignalsID;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Komut sinyallerinin ID'leri database'den okunamadý => {1}", this.GetType().Name, ex.Message);
                return allCommandSignalsID;
            }
        }

        /// <summary>
        /// Gets the device binary signals value.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <returns></returns>
        public List<BinarySignal> GetDeviceBinarySignalsValue(ushort _deviceID)
        {
            Log.Instance.Trace("{0}: {1} methodu {2} ID numaralý device için cagrýldý", this.GetType().Name, MethodBase.GetCurrentMethod().Name, _deviceID.ToString());

            List<BinarySignal> _binarySignalList = new List<BinarySignal>();

            try
            {
                string query = String.Format("CALL getDeviceBinarySignalsValue({0})", _deviceID.ToString());
                DataTable dt = new DataTable();
                dt = ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BinarySignal _binarySignal = new BinarySignal();

                        _binarySignal.ID = dr.Field<uint>("binary_signal_id");
                        _binarySignal.Name = dr.Field<string>("name");
                        _binarySignal.CurrentValue = dr.Field<bool>("current_value");
                        _binarySignal.TimeTag = dr.Field<string>("ts_datetime").ToString(); ;
                        _binarySignal.deviceID = _deviceID;

                        _binarySignalList.Add(_binarySignal);
                    }
                }
                else
                {
                    Log.Instance.Warn("{0} id numarasýna sahip device için kayýtlý binary sinyallerin son degerleri databasede bulunamadý.", _deviceID.ToString());
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Database baglantý hatasý => {0} nolu cihaza ait binary sinyallerin degerleri database'den dogru bir þekilde okunamadý... {1}", _deviceID.ToString(), ex.Message);
                throw;
            }

            return _binarySignalList;
        }

        /// <summary>
        /// Gets the device analog signals information.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <returns></returns>
        public List<T> GetDeviceAnalogSignalsInfo<T>(ushort _deviceID) where T: Signal, new()
        {
            Log.Instance.Trace("{0}: {1} methodu {2} ID numaralý device için cagrýldý", this.GetType().Name, MethodBase.GetCurrentMethod().Name, _deviceID);

            List<T> _analogSignalList = new List<T>();
            T _analogSignal;
            string query;
            try
            {
                switch (typeof(T).ToString())
                {
                    case "ModbusAnalogSignal":
                        query = $"CALL getDeviceModbusAnalogSignalsInfo({_deviceID})";
                        break;
                    case "SNMPAnalogSignal":
                        query = $"CALL getDeviceSNMPAnalogSignalsInfo({_deviceID})";
                        break;
                    default:
                        Log.Instance.Error("{0} : {1} nolu device için analog sinyal okuma sýrasýnda tanýmlanmamýþ generic veri tipi", this.GetType().Name, _deviceID);
                        return null;
                }
                
                DataTable dt = new DataTable();
                dt = ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        _analogSignal = new T();
                        _analogSignal.GetPropertyValuesFromDataRow(dr);
                        _analogSignalList.Add(_analogSignal);
                    }
                }
                else
                {
                    Log.Instance.Warn("{0} id numarasýna sahip device için kayýtlý analog sinyal bulunamadý.", _deviceID);
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Database baglantý hatasý => {1} nolu cihaza ait analog sinyallerin verileri database'den dogru bir þekilde okunamadý... {2}", this.GetType().Name, _deviceID, ex.Message);
                throw;
            }

            return _analogSignalList;
        }



        /// <summary>
        /// Gets the device analg signals value.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <returns></returns>
        public List<AnalogSignal> GetDeviceAnalogSignalsValue(ushort _deviceID)
        {
            Log.Instance.Trace("{0}: {1} methodu {2} ID numaralý device için cagrýldý", this.GetType().Name, MethodBase.GetCurrentMethod().Name, _deviceID.ToString());

            List<AnalogSignal> _analogSignalList = new List<AnalogSignal>();

            try
            {
                string query = String.Format("CALL getDeviceAnalogSignalsValue({0})", _deviceID.ToString());
                DataTable dt = new DataTable();
                dt = ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        AnalogSignal _analogSignal = new AnalogSignal();

                        _analogSignal.ID = dr.Field<uint>("analog_signal_id");
                        _analogSignal.Name = dr.Field<string>("analog_signal_name");
                        _analogSignal.CurrentValue = dr.Field<uint>("current_value");
                        _analogSignal.deviceID = _deviceID;

                        _analogSignalList.Add(_analogSignal);
                    }
                }
                else
                {
                    Log.Instance.Warn("{0} id numarasýna sahip device için kayýtlý analog sinyallerin son degerleri databasede bulunamadý.", _deviceID.ToString());
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Database baglantý hatasý => {0} nolu cihaza ait analog sinyallerin deðerleri database'den dogru bir þekilde okunamadý... {1}", _deviceID.ToString(), ex.Message);
                throw;
            }

            return _analogSignalList;
        }

        /// <summary>
        /// Resets the table.
        /// </summary>
        /// <param name="_tableName">Name of the table.</param>
        public void ResetTable(string _tableName)
        {
            Log.Instance.Trace("{0}.{1} methodu cagrýldý", "DBHelper", MethodBase.GetCurrentMethod().Name);
            string query = String.Format("CALL resetTable('{0}');", _tableName);
            try
            {
                ExecuteNonQuery(query);
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0} hata: {1}", "DBHelper", e.Message);
            }
        }

        /// <summary>
        /// Adds the binary signals to buffer.
        /// </summary>
        /// <param name="_signalList">The signal list.</param>
        public void AddBinarySignalsToDataBaseWriteBuffer(List<BinarySignal> _signalList)
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
        public void AddAnalogSignalsToDataBaseWriteBuffer(List<AnalogSignal> _signalList)
        {
            foreach (AnalogSignal _signal in _signalList)
            {
                buffer_AnalogSignals.Enqueue(_signal);
            }
        }

        /// <summary>
        /// Writes the values at buffer to database.
        /// </summary>
        //public async void WriteValuesAtBufferToDatabase()
        //{
        //    OpenConnection();

        //    Task writeBinaryValues = Task.Factory.StartNew(() =>
        //    {
        //        while (IsWriteEnabled)
        //        {
        //            BinarySignal _signal = new BinarySignal();
        //            while (buffer_AnalogSignals.Count > 0)
        //            {
        //                try
        //                {
        //                    if (buffer_BinarySignals.TryPeek(out _signal))
        //                    {
        //                        if (SetBinarySignalValue(_signal.ID, _signal.CurrentValue, _signal.TimeTag))
        //                        {
        //                            buffer_BinarySignals.TryDequeue(out _signal);
        //                        }
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    Log.Instance.Error("Binary sinyal veritabanýna deðer yazma hatasý => {0}", ex.Message);
        //                    //throw;
        //                }
        //                Thread.Sleep(5);
        //            }
        //            Thread.Sleep(20);
        //        }
        //    });

        //    Task writeAnalogValues = Task.Factory.StartNew(() =>
        //    {
        //        while (IsWriteEnabled)
        //        {
        //            AnalogSignal _signal = new AnalogSignal();
        //            while (buffer_AnalogSignals.Count > 0)
        //            {
        //                try
        //                {
        //                    if (buffer_AnalogSignals.TryPeek(out _signal))
        //                    {
        //                        if (SetAnalogSignalValue(_signal.ID, _signal.CurrentValue, _signal.TimeTag))
        //                        {
        //                            buffer_AnalogSignals.TryDequeue(out _signal);
        //                        }
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    Log.Instance.Error("Analog sinyal veritabanýna deðer yazma hatasý => {0}", ex.Message);
        //                    //throw;
        //                }

        //                Thread.Sleep(5);
        //            }

        //            Thread.Sleep(20);
        //        }
        //    });

        //    await writeBinaryValues;
        //    await writeAnalogValues;
        //    //CloseConnection();
        //}

        public async void WriteValuesAtBufferToDatabase()
        {
            OpenConnection();

            Task t1 = Task.Factory.StartNew(writeBinaryValuesFromBufferToDatabase);
            Task t2 = Task.Factory.StartNew(WriteAnalogValuesFromBufferToDatabase);

            Task.WaitAll(t1, t2);

            //CloseConnection();
        }

        private void WriteAnalogValuesFromBufferToDatabase()
        {
            while (IsWriteEnabled)
            {
                // Bufferda veri varsa verilerin database'e yazýlmasý için iþlem baþlatýlýr
                while (buffer_AnalogSignals.Count > 0)
                {
                    try
                    {
                        // 50'lik paketler halinde yüklemek yerine bufferý bir kere de yazma
                        // deneniyor.
                        AnalogSignal _signal = new AnalogSignal();
                        if (buffer_AnalogSignals.Count>5)
                        {
                            List<AnalogSignal> signals = new List<AnalogSignal>();
                            signals = GetDataFromBuffer(buffer_AnalogSignals, buffer_AnalogSignals.Count);
                            if (!WriteMultipleAnalogValuesToDatabase(signals))
                            {
                                AddSignalsBackToQueee(signals, buffer_AnalogSignals);
                            } 
                        }
                        else if (buffer_AnalogSignals.TryPeek(out _signal))
                        {
                            if (SetAnalogSignalValue(_signal.ID, _signal.CurrentValue, _signal.TimeTag))
                            {
                                buffer_AnalogSignals.TryDequeue(out _signal);
                            }
                        }
                        


                    }
                    catch (Exception ex)
                    {
                        Log.Instance.Error("{0}: Analog sinyal veritabanýna deðer yazma hatasý => {1}", this.GetType().Name, ex.Message);
                        //throw;
                    }
                    Thread.Sleep(200);
                }
                Thread.Sleep(400);
            }
        }

        private bool WriteMultipleAnalogValuesToDatabase(List<AnalogSignal> signals)
        {
            int count = signals.Count;
            StringBuilder query = new StringBuilder(string.Format("UPDATE analog_signals ass JOIN(SELECT '{0}' as '_id', '{1}' as '_value', '{2}' as '_ts_datetime' UNION ALL ", signals[0].ID, signals[0].CurrentValue, signals[0].TimeTag));
            for (int i = 1; i < count - 2; i++)
            {
                query.Append(string.Format("SELECT '{0}','{1}','{2}' UNION ALL ", signals[i].ID, signals[i].CurrentValue, signals[i].TimeTag));
            }

            query.Append(string.Format("SELECT '{0}','{1}', '{2}') ", signals[count-1].ID, signals[count - 1].CurrentValue, signals[count - 1].TimeTag));
            query.Append(string.Format(" vals ON ass.analog_signal_id = vals._id SET current_value = _value, ts_datetime = _ts_datetime "));
            try
            {
                return ExecuteNonQuery(query.ToString()) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: AnalogSignals buffer'ýndaki veriler veritabanýna yazýlamadý. Veri sayýsý: {1} => {2}", this.GetType().Name, count, ex.Message);
                return false;
            }
        }

        private void writeBinaryValuesFromBufferToDatabase()
        {
            while (IsWriteEnabled)
            {
                // Bufferda veri varsa verilerin database'e yazýlmasý için iþlem baþlatýlýr
                while (buffer_BinarySignals.Count > 0)
                {
                    try
                    {
                        BinarySignal _signal = new BinarySignal();
                        // buffer'da 10 taneden fazla  veri varsa veriler 10'ar 10'ar yazýlýr.
                        if (buffer_BinarySignals.Count > 30)
                        {
                            List<BinarySignal> signals = new List<BinarySignal>();
                            signals = GetDataFromBuffer(buffer_BinarySignals, 30);
                            if (signals.Count == 30)
                            {
                                // Verileri veritabanýna yazarken hata olusursa veriler daha sonra tekrardan veritabanýna yazmak için buffera geri eklenir.
                                if (!WriteMultipleBinaryValuesToDatabase(signals))
                                {
                                    AddSignalsBackToQueee(signals, buffer_BinarySignals);
                                }
                            }

                        }
                        // buffer'da 10'dan az veri varsa veriler teker teker yazýlýr.
                        else if (buffer_BinarySignals.TryPeek(out _signal))
                        {
                            if (SetBinarySignalValue(_signal.ID, _signal.CurrentValue, _signal.TimeTag))
                            {
                                buffer_BinarySignals.TryDequeue(out _signal);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Instance.Error("{0}: Binary sinyal veritabanýna deðer yazma hatasý => {1}", this.GetType().Name, ex.Message);
                        //throw;
                    }
                    Thread.Sleep(200);
                }
                Thread.Sleep(400);
            }
        }

        private void AddSignalsBackToQueee<T>(List<T> signals, ConcurrentQueue<T> buffer)
        {
            foreach (T signal in signals)
            {
                buffer.Enqueue(signal);
            }
        }

        private bool WriteMultipleBinaryValuesToDatabase(List<BinarySignal> signals)
        {
            int count = signals.Count;
            string value = signals[0].CurrentValue == true ? "1" : "0";
            StringBuilder query = new StringBuilder(string.Format("UPDATE binary_signals ass JOIN(SELECT '{0}' as '_id', '{1}' as '_value', '{2}' as '_ts_datetime' UNION ALL ", signals[0].ID, value, signals[0].TimeTag));
            for (int i = 1; i < count - 2; i++)
            {
                value = signals[i].CurrentValue == true ? "1" : "0";
                query.Append(string.Format("SELECT '{0}','{1}','{2}' UNION ALL ", signals[i].ID, value, signals[i].TimeTag));
            }
            value = signals[9].CurrentValue == true ? "1" : "0";
            query.Append(string.Format("SELECT '{0}','{1}', '{2}') ", signals[count - 1].ID, value, signals[count - 1].TimeTag));
            query.Append(string.Format(" vals ON ass.binary_signal_id = vals._id SET current_value = _value, ts_datetime = _ts_datetime "));
            try
            {
                return ExecuteNonQuery(query.ToString()) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: BinarySignals buffer'ýndaki veriler veritabanýna yazýlamadý => {1}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        private List<T> GetDataFromBuffer<T>(ConcurrentQueue<T> buffer_Signals, int numberOfData) where T : new()
        {
            List<T> signals = new List<T>();
            for (int i = 0; i < numberOfData; i++)
            {
                T signal = new T();
                if(buffer_Signals.TryDequeue(out signal))
                {
                    signals.Add(signal);
                }
                
            }
            return signals;
        }

        /// <summary>
        /// Updates the state of the device active.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <param name="_state">if set to <c>true</c> [state].</param>
        public void UpdateDeviceActiveState(ushort _deviceID, bool _state)
        {
            Log.Instance.Trace("{0}.{1} methodu {2} nolu device için cagrýldý", "DBHelper", MethodBase.GetCurrentMethod().Name, _deviceID);
            string query = String.Format("CALL updateDeviceActiveState({0},{1})", _deviceID.ToString(), _state.ToString());
            try
            {
                ExecuteNonQuery(query);
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0} hata: {1}", "DBHelper", e.Message);
            }
        }

        /// <summary>
        /// Updates the state of the device connected.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <param name="_state">if set to <c>true</c> [state].</param>
        public void UpdateDeviceConnectedState(ushort _deviceID, bool _state)
        {
            Log.Instance.Trace("{0}.{1} methodu {2} nolu device için cagrýldý", "DBHelper", MethodBase.GetCurrentMethod().Name, _deviceID);
            string query = String.Format("CALL updateDeviceConnectedState({0},{1})", _deviceID.ToString(), _state.ToString());
            try
            {
                ExecuteNonQuery(query);
                if (_state)
                {
                    Log.Instance.Info("{0} nolu device haberleþmesi tekrardan saðlandý.", _deviceID);
                }
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0} hata: {1}", "DBHelper", e.Message);
            }
        }

        public bool AddAnalogSignalsToDataBase(DataTable _dt)
        {
            StringBuilder query = new StringBuilder();
            int HasMaxAlarm, HasMinAlarm, isArchive, isSummary, isGauge;
            List<string> Rows = new List<string>();
            try
            {
                
                query.Append("INSERT INTO analog_signals (analog_signal_id, device_id, name, identification, address, function_code, word_count, data_type_id,unit, scale_value, max_value, min_value, max_status_id, min_status_id, has_max_alarm, has_min_alarm, is_archive, archive_period_id, is_summary, is_gauge) VALUES ");
                foreach (DataRow dr in _dt.Rows)
                {
             
                    HasMaxAlarm = dr["Max Alarm"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    HasMinAlarm = dr["Min Alarm"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    isArchive = dr["Archive"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    isSummary = dr["Device Page Shown"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    isGauge = dr["Detail Page shown"].ToString().ToUpper() == "TRUE" ? 1 : 0;
                    Rows.Add(string.Format("('{0}', '{1}', '{2}', '{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}', '{17}', '{18}', '{19}')",
                        MySqlHelper.EscapeString(dr["Analog Signal ID"].ToString()), MySqlHelper.EscapeString(dr["Device ID"].ToString()), MySqlHelper.EscapeString(dr["Name"].ToString()), MySqlHelper.EscapeString(dr["Identification"].ToString()), MySqlHelper.EscapeString(dr["Address"].ToString()), MySqlHelper.EscapeString(dr["Function Code"].ToString()), MySqlHelper.EscapeString(dr["Word Count"].ToString()), MySqlHelper.EscapeString(dr["Data Type Id"].ToString()),
                        MySqlHelper.EscapeString(dr["Unit"].ToString()), MySqlHelper.EscapeString(dr["Scale Value"].ToString()), MySqlHelper.EscapeString(dr["Max Value"].ToString().Replace(",",".")), MySqlHelper.EscapeString(dr["Min Value"].ToString().Replace(",",".")), MySqlHelper.EscapeString(dr["Max Alarm ID"].ToString()), MySqlHelper.EscapeString(dr["Min Alarm ID"].ToString()), MySqlHelper.EscapeString(HasMaxAlarm.ToString()), MySqlHelper.EscapeString(HasMinAlarm.ToString()),
                        MySqlHelper.EscapeString(isArchive.ToString()), MySqlHelper.EscapeString(dr["Archive Period ID"].ToString()), MySqlHelper.EscapeString(isSummary.ToString()), MySqlHelper.EscapeString(isGauge.ToString())));
                }
                query.Append(string.Join(",", Rows));
                query.Append(";");
                return ExecuteNonQuery(query.ToString()) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Analog sinyaller database'e eklenemedi => {1}", this.GetType().Name, ex.Message);
                return false;
                throw;
            }
        }

        public bool AddBinarySignalsToDataBase(DataTable _dt)
        {
            string isAlarm, isEvent, isReverse;
            StringBuilder query = new StringBuilder();
            try
            {
                List<string> Rows = new List<string>();
                query.Append("INSERT INTO binary_signals (binary_signal_id, device_id, name, identification, address, function_code, word_count, comparison_bit_number, status_id, is_alarm, is_event,  is_reversed) VALUES ");
                foreach (DataRow dr in _dt.Rows)
                {
                    isAlarm = dr["Alarm"].ToString().ToUpper() == "TRUE" ? "1" : "0";
                    isEvent = dr["Event"].ToString().ToUpper() == "TRUE" ? "1" : "0";
                    isReverse = dr["Reverse"].ToString().ToUpper() == "TRUE" ? "1" : "0";

                    Rows.Add(string.Format("('{0}', '{1}', '{2}', '{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",
                        MySqlHelper.EscapeString(dr["Binary Signal ID"].ToString()), MySqlHelper.EscapeString(dr["Device ID"].ToString()), MySqlHelper.EscapeString(dr["Name"].ToString()), MySqlHelper.EscapeString(dr["Identification"].ToString()), MySqlHelper.EscapeString(dr["Address"].ToString()), MySqlHelper.EscapeString(dr["Function Code"].ToString()), MySqlHelper.EscapeString(dr["Word Count"].ToString()), MySqlHelper.EscapeString(dr["Bit Number"].ToString()),
                        MySqlHelper.EscapeString(dr["Status ID"].ToString()), MySqlHelper.EscapeString(isAlarm), MySqlHelper.EscapeString(isEvent), MySqlHelper.EscapeString(isReverse)));
                }
                query.Append(string.Join(",", Rows));
                query.Append(";");
                return ExecuteNonQuery(query.ToString()) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Binary sinyaller database'e eklenemedi => {1}", this.GetType().Name, ex.Message);
                return false;
                throw;
            }
        }

        public bool AddCommandSignalsToDataBase(DataTable _dt)
        {
            string isEvent;
            StringBuilder query = new StringBuilder();
            try
            {
                List<string> Rows = new List<string>();
                query.Append("INSERT INTO command_signals (command_signal_id, device_id, name, identification, address, function_code, word_count, bit_number, status_id, is_event, command_type) VALUES ");
                foreach (DataRow dr in _dt.Rows)
                {
                    isEvent = dr["Event"].ToString().ToUpper() == "TRUE" ? "1" : "0";

                    Rows.Add(string.Format("('{0}', '{1}', '{2}', '{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                        MySqlHelper.EscapeString(dr["Command Signal ID"].ToString()), MySqlHelper.EscapeString(dr["Device ID"].ToString()),
                        MySqlHelper.EscapeString(dr["Name"].ToString()), MySqlHelper.EscapeString(dr["Identification"].ToString()),
                        MySqlHelper.EscapeString(dr["Address"].ToString()), MySqlHelper.EscapeString(dr["Function Code"].ToString()),
                        MySqlHelper.EscapeString(dr["Word Count"].ToString()), MySqlHelper.EscapeString(dr["Bit Number"].ToString()),
                        MySqlHelper.EscapeString(dr["Status ID"].ToString()), MySqlHelper.EscapeString(isEvent),
                        MySqlHelper.EscapeString(dr["Command Type"].ToString())));
                }
                query.Append(string.Join(",", Rows));
                query.Append(";");
                return ExecuteNonQuery(query.ToString()) > 0;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Komut sinyalleri database'e eklenemedi => {0}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        public List<MailGroup> GetMailGroups()
        {
            try
            {
                List<MailGroup> mailGroups = new List<MailGroup>();
                string query = "CALL getMailGroups()";
                DataTable dt = new DataTable();
                if (OpenConnection())
                {
                    dt = ExecuteQuery(query);
                    if (dt.HasRows())
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            MailGroup mailGroup = new MailGroup();
                            mailGroup.ID = dr.Field<uint>("group_id");
                            mailGroup.Name = dr.Field<string>("group_name");
                            mailGroups.Add(mailGroup);
                        }
                    }
                }
                return mailGroups;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<User> GetAllUsersMailInfo()
        {
            try
            {
                List<User> users = new List<User>();
                string query = "CALL getAllUsersMailInfo();";
                if (OpenConnection())
                {
                    DataTable dt = new DataTable();
                    dt = ExecuteQuery(query);
                    if (dt.HasRows())
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            User user = new User();
                            user.ID = dr.Field<uint>("user_id");
                            user.Email = dr.Field<string>("email");
                            user.MailGroupID = dr.Field<uint>("mail_group_id");
                            users.Add(user);
                        }
                    }
                }

                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ArchivePeriod> GetArchivePeriods()
        {
            try
            {
                List<ArchivePeriod> _periods = new List<ArchivePeriod>();
                if (OpenConnection())
                {
                    string _query = "CALL getArchivePeriods();";
                    DataTable dt = new DataTable();
                    dt = ExecuteQuery(_query);
                    if (dt.HasRows())
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            ArchivePeriod _period = new ArchivePeriod();
                            // 1 nolu archive periodu arþivlenmeyecek sinyaller için. 1 nolu period dondurulmez.
                            if (dr.Field<uint>("id") != 1)
                            {
                                _period.ID = dr.Field<uint>("id");
                                _period.Period = dr.Field<uint>("period");
                                _period.Description = dr.Field<string>("description");
                                _periods.Add(_period);
                            }
                        }
                    }
                }
                return _periods;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveValuesToArchive(uint _periodID)
        {
            try
            {
                if (OpenConnection())
                {
                    string query = string.Format("CALL SaveAnalogValuesToArchive('{0}');", _periodID.ToString());
                    ExecuteNonQuery(query);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool HasAnyValuAtBuffers()
        {
            if (buffer_AnalogSignals.Count > 0 || buffer_BinarySignals.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Public  Methods

        #region Private Methods

        private string GetStationDevicesQueryText(Type type, Station s)
        {
            switch (type.ToString())
            {
                case ("EnMon_Driver_Manager.Models.Device.ModbusTCPDevice"):
                    return $"CALL GetStationModbusTCPDevicesInfo('{s.ID}')";
                case "EnMon_Driver_Manager.Models.Device.SNMPDevice":
                    return $"CALL GetStationSNMPDevicesInfo('{s.ID}')";
                default:
                    throw new Exception($"{this.GetType().Name}: Veritabanýndan device bilgileri okunurken tanýmlanmamýþ device tipi");
            }
        }

        private string GetDeviceSignalsInfoQueryText(string type_T, int device_id)
        {
            ;
            switch (type_T)
            {
                case "EnMon_Driver_Manager.Models.ModbusBinarySignal":
                    return string.Format("CALL getModbusDeviceBinarySignalsInfo('{0}')", device_id);
                case "EnMon_Driver_Manager.Models.ModbusAnalogSignal":
                    return string.Format("CALL getModbusDeviceAnalogSignalsInfo('{0}')", device_id);
                case "EnMon_Driver_Manager.Models.ModbusCommandSignal":
                    return string.Format("CALL getModbusCommandSignalsInfo('{0}')", device_id);
                case "EnMon_Driver_Manager.Models.SNMPBinarySignal":
                    return string.Format("CALL getSNMPDeviceBinarySignalsInfo('{0}')", device_id);
                case "EnMon_Driver_Manager.Models.SNMPAnalogSignal":
                    return string.Format("CALL getSNMPDeviceAnalogSignalsInfo('{0}')", device_id);
                case "EnMon_Driver_Manager.Models.SNMPCommandSignal":
                    return string.Format("CALL getSNMPCommandSignalsInfo('{0}')", device_id);
                default:
                    Log.Instance.Error("{0}: Tanýmlanmamýþ veri tipi => {1}", this.GetType().Namespace, type_T);
                    return null;
            }
        }

        #endregion
    }
}