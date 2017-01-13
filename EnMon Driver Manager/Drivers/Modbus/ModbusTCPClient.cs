using EnMon_Driver_Manager.Models.Devices;
using Modbus;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection;
using EnMon_Driver_Manager.Models.Signals;
using EnMon_Driver_Manager.Models.Signals.Modbus;

namespace EnMon_Driver_Manager.Drivers
{
    public class ModbusTCPClient : AbstractTCPClient
    {
        #region Public Properties

        public byte MaxRegisterInOnePoll { get; set; }

        public ModbusIpMaster master { get; set; }

        public new List<ModbusTCPDevice> Devices { get; set; }

        #endregion Public Properties

        #region Private Properties

        private int indexOfCurrentAnalogSignal;

        private int indexOfCurrentBinarySignal;

        #endregion Private Properties

        #region Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="_ipAddress"></param>
        /// <param name="_readTimeOut"></param>
        /// <param name="_retryNumber"></param>
        /// <param name="_pollingtime"></param>
        /// <param name="_maxregisterinonepoll"></param>
        public ModbusTCPClient(string _ipAddress, int _readTimeOut, int _retryNumber, double _pollingtime, byte _maxregisterinonepoll) : base(_ipAddress, _readTimeOut, _retryNumber, _pollingtime)
        {
            MaxRegisterInOnePoll = _maxregisterinonepoll;
        }

        #endregion Constructors

        #region Public Methods

        #endregion Public Methods

        #region Private Methods

        private void LogModbusErrorMessage(Exception ex)
        {
            string _message = ex.Message;
            int _functionCode;
            string _exceptionCode;

            _message = _message.Remove(0, _message.IndexOf("\r\n") + 17);
            _functionCode = Convert.ToInt16(_message.Remove(_message.IndexOf("\r\n")));

            _exceptionCode = _message.Remove(_message.IndexOf("-"));
            switch (_exceptionCode.Trim())
            {
                case "1":
                    // Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                    Log.Instance.Error("{0}: {1} IP adresinde modbus haberleşme hatası => Illegal function", this.GetType().Name, ipAddress);
                    break;

                case "2":
                    // Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                    Log.Instance.Error("{0}: {1} IP adresinde modbus haberleşme hatası => Illegal data address", this.GetType().Name, ipAddress);
                    break;

                case "3":
                    // Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                    Log.Instance.Error("{0}: {1} IP adresinde modbus haberleşme hatası => Illegal data value", this.GetType().Name, ipAddress);
                    break;

                case "4":
                    // Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                    Log.Instance.Error("{0}: {1} IP adresinde modbus haberleşme hatası => Slave device failure", this.GetType().Name, ipAddress);
                    break;

                default:
                    //Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                    Log.Instance.Error("{0}: {1} IP adresinde modbus haberleşme hatası => Unknown Error", this.GetType().Name, ipAddress);
                    break;
            }
        }

        private void WriteValueMultipleRegisters(Device _d, ModbusCommandSignal _commandSignal)
        {
            //throw new NotImplementedException();
        }

        private void WriteMultipleCoils(Device _d, ModbusCommandSignal _commandSignal)
        {
            //throw new NotImplementedException();
        }

        private void WriteSingleRegister(Device _d, ModbusCommandSignal _commandSignal)
        {
            ModbusTCPDevice d = Devices.Where(device => device.ID == _d.ID).First();
            ushort value = 0;
            try
            {
                switch (_commandSignal.commandType)
                {
                    case ModbusCommandSignal.CommandType.Binary:
                        int bit = (_commandSignal.CommandValue) > 0 ? 1 : 0;
                        value = (ushort)(bit << _commandSignal.BitNumber);
                        master.WriteSingleRegister(d.SlaveID, _commandSignal.Address, value);
                        break;

                    case ModbusCommandSignal.CommandType.Analog:
                        value = (ushort)_commandSignal.CommandValue;
                        break;

                    default:
                        break;
                }

                master.WriteSingleRegister(d.SlaveID, _commandSignal.Address, value);
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: {1} adlı sinyale {2} değeri yazılamadı => {3}", this.GetType().Name, _commandSignal.Identification, _commandSignal.CommandValue, ex.Message);
            }
        }

        private void WriteSingleCoil(Device _d, ModbusCommandSignal _commandSignal)
        {
            ModbusTCPDevice d = Devices.Where((device) => device.ID == _d.ID).First();
            try
            {
                bool value = _commandSignal.CommandValue > 0 ? false : true;
                master.WriteSingleCoil(d.SlaveID, _commandSignal.Address, value);
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: {1} adlı sinyale {2} değeri yazılamadı => {3}", this.GetType().Name, _commandSignal.Identification, _commandSignal.CommandValue, ex.Message);
            }
        }

        /// <summary>
        /// Totals the word count.
        /// </summary>
        /// <param name="_signalList">The signal list.</param>
        /// <returns></returns>
        private ushort TotalWordCount(List<ModbusAnalogSignal> _signalList)
        {
            ushort _numberOfWords = 0;
            if (_signalList.Count > 0)
            {
                foreach (ModbusAnalogSignal _signal in _signalList)
                {
                    _numberOfWords += _signal.WordCount;
                }
            }
            return _numberOfWords;
        }

        /// <summary>
        /// Totals the word count.
        /// </summary>
        /// <param name="_signalList">The signal list.</param>
        /// <param name="_numberOfFirstSignal">The number of first signal.</param>
        /// <param name="_totalSignalCount">The total signal count.</param>
        /// <returns>"TotalWordCount"</returns>
        private ushort TotalWordCount(List<ModbusAnalogSignal> _signalList, int _numberOfFirstSignal, int _totalSignalCount)
        {
            ushort _numberOfWords = 0;
            for (int i = _numberOfFirstSignal; i < _numberOfFirstSignal + _totalSignalCount; i++)
            {
                _numberOfWords += _signalList[i].WordCount;
            }
            return _numberOfWords;
        }

        /// <summary>
        /// Reads the analog values.
        /// </summary>
        /// <param name="d">The d.</param>
        private void ReadAnalogValues(ModbusTCPDevice d)
        {
            if (d.AnalogSignals != null)
            {
                //Device(d) AnalogSignal listesi boş değilse okuma işlemi başlatılır
                if (d.AnalogSignals.Count > 0)
                {
                    int _totalWordCount = 0;
                    _totalWordCount = d.AnalogSignals[indexOfCurrentAnalogSignal].WordCount;

                    // Not: BinarySignal listesindeki tüm sinyaller "startCommunication" methodunda modbus adreslerine göre sıralanmıştı.

                    try
                    {
                        for (int index = indexOfCurrentAnalogSignal + 1; index < d.AnalogSignals.Count; index++)
                        {
                            bool isSameFunctionCode = ((d.AnalogSignals[index - 1].FunctionCode == 3 || d.AnalogSignals[index - 1].FunctionCode == 4) & (d.AnalogSignals[index - 1].FunctionCode == d.AnalogSignals[index].FunctionCode));
                            bool isModbusAddressSequential = d.AnalogSignals[index - 1].Address == d.AnalogSignals[index].Address - d.AnalogSignals[index].WordCount;
                            // AnalogSignals listesindeki signal[index-1] ve signal[index]'in function code'ları aynı ve singnal[i] ile signal[i-1]'in modbus adreslerinde istenen ardışıklık olduğu sürece for düngüsü devam eder.
                            // Logiclerden herhangi biri false donerse okuma işlemi başlatılır.
                            if (!(isSameFunctionCode & isModbusAddressSequential & (_totalWordCount + d.AnalogSignals[index].WordCount <= MaxRegisterInOnePoll)))
                            {
                                d.AnalogSignals = ReadAnalogSignalsValuesFromModbusDevice(d, indexOfCurrentAnalogSignal, index - indexOfCurrentAnalogSignal);
                                // Okume gerceklestiyse haberlesme var demektir. Aksi taktirde ReadAnalogSignalsValuesFromModbusDevice methodu exception gönderecekti.
                                if (d.Connected == false & !isDismiss)
                                {
                                    SetDeviceConnectionStatus(d, ConnectionStatus.Connected);
                                }
                                indexOfCurrentAnalogSignal = index;
                                _totalWordCount = 0;
                            }
                            else
                            {
                                _totalWordCount += d.AnalogSignals[index].WordCount;
                            }
                        }

                        // Son for döngüsünden sonra degeri okunmamış sinyal varsa bu sinyaller için okuma işlemi for döngüşü bittikten sonra gerçeklenir.
                        if (indexOfCurrentAnalogSignal != d.AnalogSignals.Count)
                        {
                            d.AnalogSignals = ReadAnalogSignalsValuesFromModbusDevice(d, indexOfCurrentAnalogSignal, d.AnalogSignals.Count - indexOfCurrentAnalogSignal);
                            if (d.Connected == false & !isDismiss)
                            {
                                SetDeviceConnectionStatus(d, ConnectionStatus.Connected);
                            }
                        }
                        // Tüm analog sinyallerin okuma işlemi bitti. Bir sonraki okuma işlemi için indexOfCurrentBinarySignal bilgisi sıfırlanır.
                        indexOfCurrentAnalogSignal = 0;
                    }
                    catch (Exception e)
                    {
                        if (d.Connected)
                        {
                            Log.Instance.Error("{0}: {1} nolu device haberleşme hatası ", this.GetType().Name, d.ID);
                            d.Connected = false;
                            SetDeviceConnectionStatus(d, ConnectionStatus.Disconnected);
                            //throw;
                        }
                        if (e.Source.Equals("System"))
                        {
                            // System tarafından gönderilen exception mesajı sinyal okuyamama ile ilgili bir exception değilse bu exceptionu üst methoda gönderir
                            if (e.HResult != -2146232800)
                            {
                                throw;
                            }
                        }
                        if (e.Source.Equals("NModbus4"))
                        {
                            if (e.HResult == -2146232800)
                            {
                                Log.Instance.Debug("{0}: {1}-{2} adlı cihaza yeniden baglantı kurulacak => {3}", this.GetType().Name, d.ID, d.Name, e.Message);
                                Connect();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Reads the binary values.
        /// </summary>
        /// <param name="d">The d.</param>
        private void ReadBinaryValues(ModbusTCPDevice d)
        {
            if (d.BinarySignals != null)
            {
                //Device(d) BinarySignal listesi boş değilse okuma işlemi başlatılır
                if (d.BinarySignals.Count > 0)
                {
                    int _totalWordCount = 0;
                    _totalWordCount = d.BinarySignals[indexOfCurrentBinarySignal].WordCount;

                    // Not: BinarySignal listesindeki tüm sinyaller "startCommunication" methodunda modbus adreslerine göre sıralanmıştı.

                    try
                    {
                        // BinarySignals listesinde birden fazla sinyal varsa ardışık okuma yapabilmek için for dongusu ile diger sinyallerin function code'ları ve modbus adreslerindeki ardışıklık kontrol edilir.
                        // Modbus adreslerinde ardışıklık yer alan sinyaller aynı request içerisinde okunur.
                        for (int index = indexOfCurrentBinarySignal + 1; index < d.BinarySignals.Count; index++)
                        {
                            // Şimdiki sinyal ile bir sonraki okunacak sinyalin function codeları aynı mı?
                            bool isSameFunctionCode = ((d.BinarySignals[index - 1].FunctionCode == 1 || d.BinarySignals[index - 1].FunctionCode == 2 || d.BinarySignals[index - 1].FunctionCode == 3) & (d.BinarySignals[index - 1].FunctionCode == d.BinarySignals[index].FunctionCode));
                            // Şimdiki sinyal ile bir sonraki sinyal'in function codelarına göre modbus adreslerinde devamlılık var mı?
                            bool isModbusAddressSequential = ((d.BinarySignals[index - 1].FunctionCode == 1 || d.BinarySignals[index - 1].FunctionCode == 2 & (d.BinarySignals[index - 1].Address == d.BinarySignals[index].Address - 1))
                                                          || ((d.BinarySignals[index - 1].FunctionCode == 3) & (d.BinarySignals[index - 1].Address == d.BinarySignals[index].Address)));
                            // Toplam okunacak register sayısı maxregisterinonepoll'dan büyük olmamalı
                            bool MaxRegisterInOnePollSatisfied = ((d.BinarySignals[index].FunctionCode == 1 || d.BinarySignals[index].FunctionCode == 2) & (_totalWordCount + d.BinarySignals[index].WordCount <= MaxRegisterInOnePoll)) || (d.BinarySignals[index].FunctionCode == 3);

                            // BinarySignals listesindeki signal[index-1] ve signal[index]'in function code'ları aynı ve singnal[i] ile signal[i-1]'in modbus adreslerinde istenen ardışıklık olduğu sürece for düngüsü devam eder.
                            // Logiclerden herhangi biri false donerse okuma işlemi başlatılır.
                            if (!(isSameFunctionCode & isModbusAddressSequential & MaxRegisterInOnePollSatisfied))
                            {
                                d.BinarySignals = ReadBinarySignalsValuesFromModbusDevice(d, indexOfCurrentBinarySignal, index - indexOfCurrentBinarySignal);

                                if (d.Connected == false & !isDismiss)
                                {
                                    SetDeviceConnectionStatus(d, ConnectionStatus.Connected);
                                }

                                indexOfCurrentBinarySignal = index;
                                _totalWordCount = 0;
                            }
                            // Okuma işlemi için sinyaller kontrol edilmeye devam ediyorsa totalWordCount bilgisi hesaplanır.
                            else
                            {
                                if (d.BinarySignals[index].FunctionCode != 3)
                                {
                                    _totalWordCount += d.BinarySignals[index].WordCount;
                                }
                                else
                                {
                                    _totalWordCount = d.BinarySignals[index].WordCount;
                                }
                            }
                        }

                        // Son for döngüsünden sonra degeri okunmamış sinyal kaldıysa bu sinyal için okuma işlemi for döngüsü bittikten sonra gerçeklenir.
                        if (indexOfCurrentBinarySignal != d.BinarySignals.Count)
                        {
                            d.BinarySignals = ReadBinarySignalsValuesFromModbusDevice(d, indexOfCurrentBinarySignal, d.BinarySignals.Count - indexOfCurrentBinarySignal);

                            if (d.Connected == false & !isDismiss)
                            {
                                SetDeviceConnectionStatus(d, ConnectionStatus.Connected);
                            }
                        }

                        // Tüm binary sinyallerin okuma işlemi bitti. Bir sonraki okuma işlemi için indexOfCurrentBinarySignal bilgisi sıfırlanır.
                        indexOfCurrentBinarySignal = 0;
                    }
                    catch (InvalidModbusRequestException)
                    {
                        Log.Instance.Error("Yakalandın : )");
                    }
                    catch (Exception e)
                    {
                        {
                            if (d.Connected)
                            {
                                Log.Instance.Error("{0}: {1} nolu device haberleşme hatası ", this.GetType().Name, d.ID);
                                SetDeviceConnectionStatus(d, ConnectionStatus.Disconnected);

                                //throw;
                            }
                            if (e.Source.Equals("System"))
                            {
                                // System tarafından gönderilen exception mesajı sinyal okuyamama ile ilgili bir exception değilse bu exceptionu üst methoda gönderir
                                if (e.HResult != -2146232800)
                                {
                                    throw;
                                }
                            }
                            if (e.Source.Equals("NModbus4"))
                            {
                                if (e.HResult == -2146232800)
                                {
                                    Log.Instance.Debug("{0}: {1}-{2} adlı cihaza yeniden baglantı kurulacak => {3}", this.GetType().Name, d.ID, d.Name, e.Message);
                                    Connect();
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Analog sinyalleri okur.
        /// </summary>
        /// <param name="_device">Device</param>
        /// <param name="_numberOfFirstSignal">The number of first signal.</param>
        /// <param name="_totalSignalCount">Okunacak toplam sinyal sayısı</param>
        /// <returns></returns>
        /// <exception cref="Exception">ModbusServer Hata: Yanlış tanımlanan adres veya Function Code bulundu</exception>
        private List<ModbusAnalogSignal> ReadAnalogSignalsValuesFromModbusDevice(ModbusTCPDevice _device, int _numberOfFirstSignal, int _totalSignalCount)
        {
            List<AnalogSignal> _valueChangedAnalogSignals = new List<AnalogSignal>();
            ModbusAnalogSignal _firstSignal = _device.AnalogSignals[_numberOfFirstSignal];
            ushort[] words = { };
            ushort wordCount = TotalWordCount(_device.AnalogSignals, _numberOfFirstSignal, _totalSignalCount);
            // Function Code'un 3 ve ya 4 olduğunda yapılan işlemler
            if (_firstSignal.FunctionCode == 3 || _firstSignal.FunctionCode == 4)
            {
                try
                {
                    switch (_firstSignal.FunctionCode)
                    {
                        case 3:
                            words = master.ReadHoldingRegisters(_device.SlaveID, _firstSignal.Address, wordCount);
                            break;

                        case 4:
                            words = master.ReadInputRegisters(_device.SlaveID, _firstSignal.Address, wordCount);
                            break;

                        default:
                            break;
                    }

                    // Okunan degerler ile eski degerler karsılastırılıyor. Sinyalin degeri değişmiş ise sinyal OnBinarySignalsValueCanged
                    // eventine gonderilmek üzere bufferValueChangedSignals listesine ekleniyor.
                    ushort currentWordNumber = 0;
                    for (int k = 0; k < _totalSignalCount; k++)
                    {
                        int currentSignalNo = _numberOfFirstSignal + k;
                        switch (_device.AnalogSignals[currentSignalNo].WordCount)
                        {
                            // Sinyal 16 bitlik bir analog sinyal ise;
                            case 1:

                                if (_device.AnalogSignals[currentSignalNo].CurrentValue != words[currentWordNumber])
                                {
                                    _device.AnalogSignals[currentSignalNo].CurrentValue = words[currentWordNumber];
                                    _device.AnalogSignals[currentSignalNo].TimeTag = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    _valueChangedAnalogSignals.Add(_device.AnalogSignals[currentSignalNo]);
                                }
                                currentWordNumber++;
                                break;

                            // Sinyal 32 bitlik bir analog sinyal ise;
                            case 2:
                                UInt32 _valueFromDevice = Convert.ToUInt32(words[currentWordNumber]) + Convert.ToUInt32(words[currentWordNumber + 1]) * 65536;
                                if (_device.AnalogSignals[currentSignalNo].CurrentValue != _valueFromDevice)
                                {
                                    _device.AnalogSignals[currentSignalNo].CurrentValue = _valueFromDevice;
                                    _device.AnalogSignals[currentSignalNo].TimeTag = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    _valueChangedAnalogSignals.Add(_device.AnalogSignals[currentSignalNo]);
                                }
                                currentWordNumber += 2;
                                break;

                            default:
                                Log.Instance.Error("ModbusTCPMaster Hata: Sinyal içerisinde beklenmedik word sayısı");
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    if (e.Source.Equals("System"))
                    {
                        // System tarafından gönderilen exception mesajı sinyal okuyamama ile ilgili bir exception değilse bu exceptionu üst methoda gönderir
                        if (e.HResult != -2146232800)
                        {
                            throw e;
                        }
                    }

                    //
                    if (_device.Connected)
                    {
                        Log.Instance.Error("{0}: {1}-{2} adlı device haberleşme hatası => {3} ", this.GetType().Name, _device.ID, _device.Name, e.Message);
                        _device.Connected = false;
                        OnDeviceConnectionStateChanged(_device);
                        throw e;
                    }
                }
            }
            // Function Code tanımsız oldugunda yaplan işlemler
            else
            {
                Log.Instance.Error("{0} Hata: Yanlış tanımlanan adres veya geçersiz function Code bulundu", this.GetType().Name);
            }
            // Okuma işlemi bittiğinde bufferValueChangedSignals listesine sinyal eklenmişse event çağrılır.
            if (_valueChangedAnalogSignals.Count > 0)
            {
                
                OnAnyAnalogSignalValueChanged(_valueChangedAnalogSignals);
            }

            return _device.AnalogSignals;
        }

        /// <summary>
        /// Reads the binary signals.
        /// </summary>
        /// <param name="_device">The device.</param>
        /// <param name="_numberOfFirstSignal">The number of first signal.</param>
        /// <param name="_totalSignalCount">The total signal count.</param>
        /// <returns></returns>
        /// <exception cref="Exception">ModbusServer Hata: Yanlış tanımlanan adres veya Function Code bulundu</exception>
        private List<ModbusBinarySignal> ReadBinarySignalsValuesFromModbusDevice(ModbusTCPDevice _device, int _numberOfFirstSignal, int _totalSignalCount)
        {
            List<BinarySignal> _valueChangedBinarySignals = new List<BinarySignal>();
            ModbusBinarySignal _firstSignal = _device.BinarySignals[_numberOfFirstSignal];
            bool[] values = { };
            //ushort wordCount = TotalWordCount(_device.BinarySignals, _numberOfFirstSignal, _totalSignalCount);

            // Function Code'un 1 ve ya 2 olduğunda yapılan işlemler
            try
            {
                if (_firstSignal.FunctionCode == 1 || _firstSignal.FunctionCode == 2)
                {
                    switch (_firstSignal.FunctionCode)
                    {
                        case 1:
                            values = master.ReadCoils(_device.SlaveID, _firstSignal.Address, Convert.ToUInt16(_totalSignalCount));
                            break;

                        case 2:
                            values = master.ReadInputs(_device.SlaveID, _firstSignal.Address, Convert.ToUInt16(_totalSignalCount));
                            break;

                        default:
                            throw new Exception("ModbusTCPMaster Hata: Beklenmedik function code... ");
                    }

                    // Okunan degerler ile  eski degerler karsılastırılıyor. Sinyalin degeri değişmiş ise sinyal OnBinarySignalsValueCanged
                    // eventine gonderilmek üzere _valueChangedSignals listesine ekleniyor.
                    for (int k = 0; k < values.Length; k++)
                    {
                        int currentSignalNo = _numberOfFirstSignal + k;

                        if (_device.BinarySignals[currentSignalNo].IsReversed)
                        {
                            values[k] = !values[k];
                        }

                        if (_device.BinarySignals[currentSignalNo].CurrentValue != values[k])
                        {
                            _device.BinarySignals[currentSignalNo].CurrentValue = values[k];
                            _device.BinarySignals[currentSignalNo].TimeTag = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            _valueChangedBinarySignals.Add(_device.BinarySignals[currentSignalNo]);
                        }
                    }
                }

                // Function Code 3 olduğunda yapılan işlemler
                else if (_firstSignal.FunctionCode == 3)
                {
                    ushort numberOfPoints = 0;
                    // Okunacak toplam register sayısı alınır.
                    // Bit okuma varsa max bit_number sayısından toplam okunacak register sayısı alınıyor
                    if (_device.BinarySignals[_numberOfFirstSignal].comparisonType == ModbusBinarySignal.ComparisonType.bit)
                    {
                        numberOfPoints = Convert.ToUInt16(_device.BinarySignals[_numberOfFirstSignal + _totalSignalCount - 1].ComparisonBitNumber / 16 + 1);
                    }
                    // Value okuma varsa word_count sayısından toplam okunacak register sayısı alınıyor
                    else
                    {
                        numberOfPoints = Convert.ToUInt16(_device.BinarySignals[_numberOfFirstSignal].WordCount);
                    }

                    if (numberOfPoints > 0)
                    {
                        ushort[] register = master.ReadHoldingRegisters(_device.SlaveID, _firstSignal.Address, numberOfPoints);

                        for (int k = 0; k < _totalSignalCount; k++)
                        {
                            bool value;
                            int currentSignalNo = _numberOfFirstSignal + k;

                            // bit okuma yapılacaksa;
                            if (_device.BinarySignals[currentSignalNo].comparisonType == ModbusBinarySignal.ComparisonType.bit)
                            {
                                // Okunacak bitin kaçıncı registerda oldugu hesaplanıyor.
                                int _wordNumber = _device.BinarySignals[currentSignalNo].ComparisonBitNumber / 16;

                                // Okunacak bit ilk registerda yer alıyorsa direk okuma işlemi yapılır.
                                if (_wordNumber == 0)
                                {
                                    value = (register[_wordNumber] & (1 << _device.BinarySignals[currentSignalNo].ComparisonBitNumber)) > 0;
                                }
                                // Okunacak bit ilkregisterda yyer almıyorsa okunacak bitin register içerisinde kaçıncı sırada  oldugu hesaplanır ve okuma işlemi yapılır.
                                else
                                {
                                    int bitNumber = (_device.BinarySignals[currentSignalNo].ComparisonBitNumber) - 16 * _wordNumber;
                                    value = (register[_wordNumber] & (1 << bitNumber)) > 0;
                                }
                            }
                            // value okuma yapılacaksa;
                            else
                            {
                                // Okunan register dizisi unsigned sayıya cevriliyor.
                                double readValue = 0;
                                for (int i = 0; i < register.Length; i++)
                                {
                                    readValue += register[i] * Math.Pow(256, i);
                                }

                                if (readValue == _device.BinarySignals[currentSignalNo].ComparisonValue)
                                {
                                    value = true;
                                }
                                else
                                {
                                    value = false;
                                }
                            }

                            if (_device.BinarySignals[currentSignalNo].IsReversed)
                            {
                                value = !value;
                            }

                            if (_device.BinarySignals[currentSignalNo].CurrentValue != value)
                            {
                                _device.BinarySignals[currentSignalNo].CurrentValue = value;
                                _device.BinarySignals[currentSignalNo].TimeTag = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                _valueChangedBinarySignals.Add(_device.BinarySignals[currentSignalNo]);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (e.Source.Equals("System"))
                {
                    // System tarafından gönderilen exception mesajı sinyal okuyamama ile ilgili bir exception değilse bu exceptionu üst methoda gönderir
                    if (e.HResult != -2146232800)
                    {
                        throw e;
                    }
                }

                //
                if (_device.Connected)
                {
                    Log.Instance.Error("{0}: {1}-{2} adlı device haberleşme hatası => {3} ", this.GetType().Name, _device.ID, _device.Name, e.Message);
                    _device.Connected = false;
                    OnDeviceConnectionStateChanged(_device);
                    throw e;
                }
            }

            // Function Code tanımsız oldugunda yaplan işlemler
            if (!(_firstSignal.FunctionCode == 1 || _firstSignal.FunctionCode == 2 || _firstSignal.FunctionCode == 3))
            {
                Log.Instance.Error("{0} Hata: Yanlış tanımlanan adres veya geçersiz function Code bulundu", this.GetType().Name);
            }

            // Okuma işlemi bittiğinde _valueChangedSignals listesine sinyal eklenmişse bu sinyallerin database buffera eklenmesi için event çağrılır.
            if (_valueChangedBinarySignals.Count > 0)
            {
                OnAnyBinarySignalValueChanged(_valueChangedBinarySignals);
                _valueChangedBinarySignals.Clear();
            }

            values = null;

            return _device.BinarySignals;
        }

        /// <summary>
        /// Compares the binary values.
        /// </summary>
        /// <param name="_deviceSignalList">The device signal list.</param>
        /// <param name="_readValuesSignalList">The read values signal list.</param>
        /// <param name="_readvalues">The readvalues.</param>
        /// <param name="_startAddress">The start address.</param>
        /// <returns></returns>
        private List<ModbusBinarySignal> CompareBinaryValues(ref List<ModbusBinarySignal> _deviceSignalList, List<ModbusBinarySignal> _readValuesSignalList, bool[] _readvalues, int _startAddress)
        {
            List<ModbusBinarySignal> returnSignalList = new List<ModbusBinarySignal>();

            for (int k = 0; k < _readValuesSignalList.Count; k++)
            {
                if (_readValuesSignalList[k].CurrentValue != _readvalues[k])
                {
                    _deviceSignalList[_startAddress - _readValuesSignalList.Count + k].CurrentValue = _readvalues[k];
                    _deviceSignalList[_startAddress - _readValuesSignalList.Count + k].TimeTag = DateTime.Now.ToString();
                    returnSignalList.Add(_deviceSignalList[_startAddress - k]);
                }
            }
            return returnSignalList;
        }

        /// <summary>
        /// Compares the binary values.
        /// </summary>
        /// <param name="_deviceSignalList">The device signal list.</param>
        /// <param name="_readValuesSignalList">The read values signal list.</param>
        /// <param name="_registers">The registers.</param>
        /// <param name="_startAddress">The start address.</param>
        /// <returns></returns>
        private List<ModbusBinarySignal> CompareBinaryValues(ref List<ModbusBinarySignal> _deviceSignalList, List<ModbusBinarySignal> _readValuesSignalList, ushort[] _registers, int _startAddress)
        {
            List<ModbusBinarySignal> returnSignalList = new List<ModbusBinarySignal>();

            for (int k = 0; k < _readValuesSignalList.Count; k++)
            {
                int _byteNumber = _readValuesSignalList[k].ComparisonBitNumber % 15;
                if (_readValuesSignalList[k].CurrentValue != (_registers[_byteNumber] & (1 << _readValuesSignalList[k].ComparisonBitNumber)) > 0)
                {
                    _deviceSignalList[_startAddress - _readValuesSignalList.Count + k].CurrentValue = (_registers[_byteNumber] & (1 << _readValuesSignalList[k].ComparisonBitNumber)) > 0;
                    _deviceSignalList[_startAddress - _readValuesSignalList.Count + k].TimeTag = DateTime.Now.ToString();
                    returnSignalList.Add(_deviceSignalList[_startAddress - _readValuesSignalList.Count + k]);
                }
            }

            return returnSignalList;
        }

        #endregion Private Methods

        #region Public Override Methods
        public override void ReadValues() 
        { 
            try
            {
                for (int i = indexOfCurrentDevice; i < Devices.Count; i++)
                {
                    indexOfCurrentDevice = i;
                    if (Devices[indexOfCurrentDevice].isActive)
                    {
                        ReadBinaryValues(Devices[indexOfCurrentDevice]);
                        ReadAnalogValues(Devices[indexOfCurrentDevice]);
                    }
                }
                // Bir modbus çevrimi sonucunda tüm cihazlar ile haberleşme tamamlandı.
                indexOfCurrentDevice = 0;
            }
            catch (HttpListenerException ex)
            {
                Log.Instance.Error("HttpListenerException " + ex.Message);
            }
            catch (NetworkInformationException ex)
            {
                Log.Instance.Error("NetworkInformationException " + ex.Message);
            }
            catch (SocketException ex)
            {
                Log.Instance.Error("SocketException " + ex.Message);
            }
            catch (WebSocketException ex)
            {
                Log.Instance.Error("WebSocketException " + ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("System"))
                {
                    dtDisconnected = DateTime.Now;
                    IsConnected = false;
                    Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                    Log.Instance.Error("{0}: {1} => {2}", this.GetType().Name, ipAddress, ex.Message);
                    //OnDisconnectedFromServer();
                }

                if (ex.Source.Equals("nModbus4"))
                {
                    LogModbusErrorMessage(ex);
                }
            }
        }

        public override bool WriteValue(Device d, CommandSignal c)
        {
            ModbusTCPDevice _d = Devices.Where(device => device.ID == d.ID).FirstOrDefault();
            ModbusCommandSignal _commandSignal = _d.CommandSignals.Where(command => command.ID == c.ID).FirstOrDefault();

            if (_d.Connected && _d.isActive)
            {
                switch (_commandSignal.FunctionCode)
                {
                    case 5:
                        WriteSingleCoil(_d, _commandSignal);
                        return true;

                    case 6:
                        WriteSingleRegister(_d, _commandSignal);
                        return true;

                    case 15:
                        WriteMultipleCoils(_d, _commandSignal);
                        return true;

                    case 16:
                        WriteValueMultipleRegisters(_d, _commandSignal);
                        return true;

                    default:
                        Log.Instance.Error("Yanlış function code : {0} sinyaline değer yazılamadı", _commandSignal.Identification);
                        return false;
                }
            }
            else
            {
                Log.Instance.Warn("{0}: {1} adlı komut cihaz ile haberleşme olmadığı için gönderilemedi", this.GetType().Name, _commandSignal.Identification);
                return false;
            }
        }

        #endregion

        #region Protected Override Methods

        protected override void OrderSignalsByAddress()
        {
            if(Devices.Count>0)
            {
                foreach (ModbusTCPDevice d in Devices)
                {
                    if (d.BinarySignals.Count > 0)
                    {
                        d.BinarySignals = d.BinarySignals.OrderBy(b => b.Address).ThenBy(b => b.ComparisonBitNumber).ToList();
                    }
                    if (d.AnalogSignals.Count > 0)
                    {
                        d.AnalogSignals = d.AnalogSignals.OrderBy(a => a.Address).ToList();
                    }
                }
            }
                
            
        }

        protected override void InitializeDefaultCommunicationSettings()
        {
            PortNumber = 502;
            readTimeOut = 1000;
            retryNumber = 1;
            pollingTime = 1000.0;
            MaxRegisterInOnePoll = 16;
        }

        protected override void InitializeClientProperties()
        {
            IsConnected = false;

            clientDisconnectionCounter = 0;

            indexOfCurrentDevice = 0;

            indexOfCurrentAnalogSignal = 0;

            indexOfCurrentAnalogSignal = 0;

            isDismiss = false;

            MaxRegisterInOnePoll = 16;
        }

        protected override void DoProtocolSpecificWorksWhenCommunicationEstablished()
        {
            if (master != null)
            {
                master.Dispose();
            }
            // TCP baglantısı kurulduktan sonra IpAddress için modbus baglantısı olusturuluyor
            master = ModbusIpMaster.CreateIp(client);
            master.Transport.Retries = retryNumber;
            master.Transport.ReadTimeout = readTimeOut;
        }

        protected override bool AnyActiveDeviceAvaliable()
        {
            return Devices.Exists((d) => d.isActive == true);
        }

        #endregion Protected Override Methods

    }
}