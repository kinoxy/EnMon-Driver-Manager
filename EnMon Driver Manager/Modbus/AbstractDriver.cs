using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Modbus
{
    abstract class AbstractDriver
    {
        #region Private Variables
        private List<BinarySignal> binarySignals;
        private List<AnalogSignal> analogSignals;
        private List<Device> devices;
        #endregion

        #region Public Methodlar
        public List<BinarySignal> BinarySignals
        {
            get { return binarySignals; }
            set { binarySignals = value; }
        }

        public List<AnalogSignal> AnalogSignals
        {
            get { return analogSignals; }
            set { analogSignals = value; }
        }

        public List<Device> Devices
        {
            get { return devices; }
            set { devices = value; }
        }

        public void GetSignalListForDriverDevices()
        {
            DBHelper db_connection = new DBHelper();
            foreach (Device _device in Devices)
            {
                _device.BinarySignals = db_connection.GetDeviceBinarySignalsInfo(_device.ID);
                _device.AnalogSignals = db_connection.GetDeviceAnalogSignalsInfo(_device.ID);
            }


        }

        /// <summary>
        /// Driver'da tanımlı tüm device'ların database'de kayıtlı sinyallerinin database'deki son güncel degerlerini alır.
        /// </summary>
        public void GetLastValuesFromDatabase()
        {
            // Yeni bir database baglantı nesnesi olusturuluyor
            DBHelper db_connection = new DBHelper();
            // Her device için donguye giriliyor
            foreach (Device device in Devices)
            {
                // Database'den currentValue bilgisi ile donen liste gecici olarak olusturulan List<BinarySignal>'e atanıyor.
                List<BinarySignal> _binarySignals = new List<BinarySignal>();
                _binarySignals = db_connection.GetDeviceBinarySignalsValue(device.ID);

                if(_binarySignals != null)
                {
                    foreach( BinarySignal signal in device.BinarySignals)
                    {
                        signal.CurrentValue = _binarySignals.First(s => s.Name == signal.Name).CurrentValue; 
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
                         signal.CurrentValue = _analogSignals.First(s => s.Name == signal.Name).CurrentValue; 
                    }
                }
                else
                {
                    Log.Instance.Error("{0} (ID No:{1}) device'ı için database'den son degerler okunamadı", device.Name, device.ID);
                }
            }
        }

        public void UpdateBinaryValuesAtDatabase(List<BinarySignal> _binarySignals)
        {
            DBHelper db_connection = new DBHelper();
            db_connection.Connect();
            foreach(BinarySignal signal in _binarySignals)
            {
                db_connection.SetBinarySignalValue(signal.DeviceID, signal.CurrentValue);
            }
            db_connection.Disconnect();
        }

        #endregion

        #region Private Methods

        #endregion

        #region Abstract Methods
        /// <summary>
        /// Device'tan istenilen sinyalin degerini okur
        /// </summary>
        /// <returns></returns>
        abstract public void ReadValueFromDevice();
        abstract public void WriteAnalogValuesToDatabase(List<AnalogSignal> _analogValues);
        abstract public void WriteValueToDevice();

        /// <summary>
        /// Devices listesindeki tüm cihazların dogru protokol ile haberleşip haberleşmediğini kontrol eder.
        /// Protokolü yanlış seçilmiş device varsa onu driver'in devices listesinden çıkartır ve o device ile baglantı kurmaz.
        /// </summary>
        abstract public void VerifyProtocolofDevices();

    }
    #region eskiyapılanlar

    //    public interface IDriverBuilder
    //    {
    //        Driver driver();


    //        private List<Station> stations;

    //        public abstract void GetBinarySignalList()
    //        {

    //        }
    //        public abstract void GetAnalogSignalList();

    //    }

    //    public class ModbusTCP : IDriverBuilder
    //    {
    //        private Driver driver;

    //        public ModbusTCP()
    //        {
    //            driver = new Driver(Driver.driverType.ModbusTCP);
    //        }

    //    }

    //    public class ModbusRTU : IDriverBuilder
    //    {

    //    }

    //    public class Driver
    //    {
    //        public static enum driverType
    //        {
    //            ModbusRTU,
    //            ModbusTCP,
    //            ModbusASCII
    //        };

    //        public Driver(enum _driverType)
    //        {
    //        }
    //    }

    #endregion

}
