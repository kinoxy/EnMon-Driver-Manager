using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using EnMon_Driver_Manager.DataBase;
using System.Text;
using EnMon_Driver_Manager.Drivers;
using EnMon_Driver_Manager.Models.Device;

namespace EnMon_Driver_Manager.Modbus
{
    /// <summary>
    ///
    /// </summary>
    public abstract class AbstractModbusDriver : AbstractDriver
    {
        #region Public Properties

        public int PollingTime { get; set; }

        public int ReadTimeOut { get; set; }

        public int RetryNumber { get; set; }

        public byte MaxRegisterInOnePoll { get; set; }

        public List<ModbusAnalogSignal> AnalogSignals { get; set; }

        public List<ModbusBinarySignal> BinarySignals { get; set; }

        #endregion Public Properties

        #region Private Properties

        #endregion Private Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractModbusDriver"/> class.
        /// </summary>
        public AbstractModbusDriver()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_configFile"></param>
        public AbstractModbusDriver(string _configFile) : base (_configFile)
        {
            GetStationDevicesAndSignalsInfo();   
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Starts the communication.
        /// </summary>
        public override void StartCommunication()
       {
            Log.Instance.Trace("{0}: {1} methodu çağrıldı", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            try
            {

                Communicate();
                //TODO: Database'in değil de driverın kendi bufferı olması daha işlevsel olabilir.
                DBHelper.WriteValuesAtBufferToDatabase();
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("{0}: Driver baglantı hatası => {1} ", this.GetType().Name, e.Message);
            }
        }

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods

        #region Protected Abstract Methods

        /// <summary>
        /// Connects this instance.
        /// </summary>
        protected abstract void Communicate();

        #endregion
    }
}