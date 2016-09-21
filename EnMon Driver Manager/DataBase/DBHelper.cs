using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.DataBase
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DBHelper
    {
        #region Public Properties        
        /// <summary>
        /// The string server address
        /// </summary>
        public static string str_serverAddress = "46.101.240.185";

        /// <summary>
        /// The string database name
        /// </summary>
        public static string str_databaseName = "utmdb";

        /// <summary>
        /// The string user name
        /// </summary>
        public static string str_userName = "root";

        /// <summary>
        /// The string password
        /// </summary>
        public static string str_password = "Qweasd123";

        /// <summary>
        /// Gets or sets the buffer binary signals.
        /// </summary>
        /// <value>
        /// The buffer binary signals.
        /// </value>
        public static Queue<BinarySignal> buffer_BinarySignals { get; protected set; }

        /// <summary>
        /// Gets or sets the buffer analog signals.
        /// </summary>
        /// <value>
        /// The buffer analog signals.
        /// </value>
        public static Queue<AnalogSignal> buffer_AnalogSignals { get; protected set; }

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
        public bool IsWriteEnabled { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHelper"/> class.
        /// </summary>
        public DBHelper()
        {
            buffer_BinarySignals = new Queue<BinarySignal>();
            buffer_AnalogSignals = new Queue<AnalogSignal>();
            IsWriteEnabled = true;
        }
        #endregion

        #region Protected Methods        
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

        /// <summary>
        /// Gets all devices list.
        /// </summary>
        /// <param name="List`1">The list`1.</param>
        /// <returns></returns>
        protected abstract List<Device> GetAllDevicesList();

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="_query">The query.</param>
        protected abstract void ExecuteNonQuery(string _query);

        /// <summary>
        /// Sets the binary signal value.
        /// </summary>
        /// <param name="_signalID">The signal identifier.</param>
        /// <param name="_signalValue">if set to <c>true</c> [signal value].</param>
        /// <param name="_datetime">The datetime.</param>
        /// <returns></returns>
        protected abstract bool SetBinarySignalValue(uint _signalID, bool _signalValue, string _datetime);

        /// <summary>
        /// Sets the analog signal value.
        /// </summary>
        /// <param name="_signalID">The signal identifier.</param>
        /// <param name="_signalValue">The signal value.</param>
        /// <param name="_datetime">The datetime.</param>
        /// <returns></returns>
        protected abstract bool SetAnalogSignalValue(uint _signalID, int _signalValue, string _datetime);

        #endregion

        #region Public  Methods

        /// <summary>
        /// Gets the device binary signals information.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <returns></returns>
        public abstract List<BinarySignal> GetDeviceBinarySignalsInfo(ushort _deviceID);

        /// <summary>
        /// Gets the device binary signals value.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <returns></returns>
        public abstract List<BinarySignal> GetDeviceBinarySignalsValue(ushort _deviceID);

        /// <summary>
        /// Gets the device analg signals information.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <returns></returns>
        public abstract List<AnalogSignal> GetDeviceAnalogSignalsInfo(ushort _deviceID);

        /// <summary>
        /// Gets the device analg signals value.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <returns></returns>
        public abstract List<AnalogSignal> GetDeviceAnalogSignalsValue(ushort _deviceID);

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
                            if (SetBinarySignalValue(_signal.ID, _signal.CurrentValue, _signal.TimeTag))
                            {
                                buffer_BinarySignals.Dequeue();
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

            Task writeAnalogValues = Task.Factory.StartNew(() =>
            {
                while (IsWriteEnabled)
                {
                    while (buffer_AnalogSignals.Count > 0)
                    {
                        try
                        {
                            AnalogSignal _signal = buffer_AnalogSignals.Peek();
                            if (SetAnalogSignalValue(_signal.ID, _signal.CurrentValue, _signal.TimeTag))
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
        public void UpdateDeviceActiveState(ushort _deviceID, bool _state)
        {
            Log.Instance.Trace("{0}.{1} methodu {2} nolu device için cagrıldı", "DBHelper", MethodBase.GetCurrentMethod().Name, _deviceID);
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
        /// Gets the station devices.
        /// </summary>
        /// <param name="_stationName">Name of the station.</param>
        /// <returns></returns>
        public abstract List<Device> GetStationDevices(string _stationName);

        /// <summary>
        /// Updates the state of the device connected.
        /// </summary>
        /// <param name="_deviceID">The device identifier.</param>
        /// <param name="_state">if set to <c>true</c> [state].</param>
        public void UpdateDeviceConnectedState(ushort _deviceID, bool _state)
        {
            Log.Instance.Trace("{0}.{1} methodu {2} nolu device için cagrıldı", "DBHelper", MethodBase.GetCurrentMethod().Name, _deviceID);
            string query = String.Format("CALL updateDeviceConnectedState({0},{1})", _deviceID.ToString(), _state.ToString());
            try
            {
                ExecuteNonQuery(query);
                if (_state)
                {
                    Log.Instance.Info("{0} nolu device haberleşme tekrardan kuruldu.", _deviceID);
                }
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0} hata: {1}", "DBHelper", e.Message);
            }
        }

        /// <summary>
        /// Gets the name of the station information by.
        /// </summary>
        /// <param name="_stationName">Name of the station.</param>
        /// <returns></returns>
        public abstract Station GetStationInfoByName(string _stationName);

        #endregion
    }
}
