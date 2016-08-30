using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Modbus
{
    abstract class AbstractDriver
    {
        #region Private Properties
        private List<BinarySignal> binarySignals;
        private List<AnalogSignal> analogSignals;
        private List<Device> devices;
        private Thread thread_ReadBinaryValues;
        private Thread thread_ReadAnalogValues;
        #endregion

        #region Public Methods
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
            Log.Instance.Trace("GetSignalListForDriverDevices fonksiyonu cagrıldı");

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
            Log.Instance.Trace("GetLastValuesFromDatabase fonksiyonu cagrıldı");

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
       
        /// <summary>
        /// Fonksiyonuna girilen BinarySignal listesindeki sinyallerin degerleri driverdaki sinyallerin degerleri ile karsılastırılıyor. 
        /// Guncellenmesi gereken deger varsa hem driver da hem de database de guncelleniyor.
        /// </summary>
        /// <param name="_binarySignals"></param>
        /// <param name="_deviceID"></param>
        public void UpdateValuesOfDeviceBinarySignals(List<BinarySignal> _binarySignals, int _deviceID)
        {
            Log.Instance.Trace("UpdateValuesOfDeviceBinarySignals fonksiyonu cagrıldı");

            DBHelper db_connection = new DBHelper();
            db_connection.Connect();
            foreach(BinarySignal signal in _binarySignals)
            {
                //Mevcut deger ile okunan deger farklı ise databasede ve driverda tutulan deger guncelleniyor.
                if (signal.CurrentValue != Devices.Where(d => d.ID == _deviceID).First().BinarySignals.Where(b => b.CurrentValue == signal.CurrentValue).First().CurrentValue)
                {
                    //Mevuct deger ile okunan deger farklı cıktıgı için yeni deger database'e gonderiliyor.
                    db_connection.SetBinarySignalValue(signal.DeviceID, signal.CurrentValue);
                    //Driver'da tutulan listede yer alan sinyalin degeri güncelleniyor.
                    Devices.Where(d => d.ID == _deviceID).First().BinarySignals.Where(b => b.CurrentValue == signal.CurrentValue).First().CurrentValue = signal.CurrentValue;
                }

            }
            db_connection.Disconnect();
        }

        /// <summary>
        /// Fonksiyonuna girilen AnalogSignal listesindeki sinyallerin degerleri driverdaki sinyallerin degerleri ile karsılastırılıyor. 
        /// Guncellenmesi gereken deger varsa hem driver da hem de database de guncelleniyor.
        /// </summary>
        /// <param name="_analogSignals"></param>
        /// <param name="_deviceID"></param>
        public void UpdateValuesOfDeviceAnalogSignals(List<AnalogSignal> _analogSignals, int _deviceID)
        {
            Log.Instance.Trace("UpdateValuesOfDeviceAnalogSignals fonksiyonu cagrıldı");

            DBHelper db_connection = new DBHelper();
            db_connection.Connect();
            foreach (AnalogSignal signal in _analogSignals)
            {
                //Mevcut deger ile okunan deger farklı ise databasede ve driverda tutulan deger guncelleniyor.
                if (signal.CurrentValue != Devices.Where(d => d.ID == _deviceID).First().AnalogSignals.Where(b => b.CurrentValue == signal.CurrentValue).First().CurrentValue)
                {
                    //Mevuct deger ile okunan deger farklı cıktıgı için yeni deger database'e gonderiliyor.
                    db_connection.SetAnalogSignalValue(signal.DeviceID, signal.CurrentValue);
                    //Driver'da tutulan listede yer alan sinyalin degeri güncelleniyor.
                    Devices.Where(d => d.ID == _deviceID).First().AnalogSignals.Where(b => b.CurrentValue == signal.CurrentValue).First().CurrentValue = signal.CurrentValue;
                }

            }
            db_connection.Disconnect();
        }

        public void StartCommunication()
        {
            Log.Instance.Trace("StartCommunication fonksiyonu cagrıldı");
            try
            {
                Connect();

                // TODO: burdan sonra iki tane async thread calıstırmak gerekli. birinci thread cihazlardan veri okurken, ikinci thread baglantısı kopmus cihazlara tekrardan baglanmaya calısacak. 

                thread_ReadBinaryValues = new Thread(ReadBinaryValuesFromDevices);
                thread_ReadAnalogValues = new Thread(ReadAnalogValuesfromDevices);

                thread_ReadBinaryValues.Start();
                thread_ReadAnalogValues.Start();

                
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("Driver baglantı hatası: " + e.Message);
            }

            
        }
        #endregion

        #region Private Methods

        #endregion

        #region Abstract Methods
        /// <summary>
        /// Device'tan istenilen sinyalin degerini okur
        /// </summary>
        /// <returns></returns>
        abstract public void ReadBinaryValuesFromDevices();
        abstract public void ReadAnalogValuesfromDevices();
        abstract public void WriteAnalogValuesToDatabase(List<AnalogSignal> _analogValues);
        abstract public void WriteValueToDevice();
        abstract public void Connect();
        
        /// <summary>
        /// Devices listesindeki tüm cihazların dogru protokol ile haberleşip haberleşmediğini kontrol eder.
        /// Protokolü yanlış seçilmiş device varsa onu driver'in devices listesinden çıkartır ve o device ile baglantı kurmaz.
        /// </summary>
        abstract public void VerifyProtocolofDevices();

        abstract public void ConnectToDisconnectedDevices();

        abstract public void ReadValuesFromConnectedDevices();

        #endregion

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
