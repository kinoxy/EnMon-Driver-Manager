using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection;
using System.Timers;

namespace EnMon_Driver_Manager.Models
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void ModbusEventHandler(object source, ModbusEventArgs e);

    /// <summary>
    ///
    /// </summary>
    public class ModbusTCPClient : IDriverMaster
    {
        #region Public Properties

        /// <summary>
        /// The polling timer
        /// </summary>
        public PollingTimer pollingTimer { get; set; }

        /// <summary>
        /// Gets or sets the devices.
        /// </summary>
        /// <value>
        /// The devices.
        /// </value>
        public List<Device> Devices { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is connected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        public bool IsConnected { get; set; }

        /// <summary>
        /// Gets or sets the maximum register in one poll.
        /// </summary>
        /// <value>
        /// The maximum register in one poll.
        /// </value>
        public byte MaxRegisterInOnePoll { get; set; }

        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>
        /// The ip address.
        /// </value>
        public string ipAddress { get; set; }

        /// <summary>
        /// Gets or sets the port number.
        /// </summary>
        /// <value>
        /// The port number.
        /// </value>
        public int PortNumber { get; set; }

        #endregion Public Properties

        #region Private Properties

        private bool isAnyActiveDeviceAvaliable { get; set; }

        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        private TcpClient client { get; set; }

        /// <summary>
        /// Gets or sets the master.
        /// </summary>
        /// <value>
        /// The master.
        /// </value>
        private ModbusIpMaster master { get; set; }

        /// <summary>
        /// Gets or sets the polling time.
        /// </summary>
        /// <value>
        /// The polling time.
        /// </value>
        private double pollingTime { get; set; }

        /// <summary>
        /// Gets or sets the read time out.
        /// </summary>
        /// <value>
        /// The read time out.
        /// </value>
        private int readTimeOut { get; set; }

        /// <summary>
        /// Gets or sets the retry number.
        /// </summary>
        /// <value>
        /// The retry number.
        /// </value>
        private int retryNumber { get; set; }

        private DateTime dtNow { get; set; }

        private DateTime dtDisconnected { get; set; }

        #endregion Private Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ModbusTCPClient" /> class.
        /// </summary>
        /// <param name="_ipAddress">The ip address.</param>
        public ModbusTCPClient(string _ipAddress)
        {
            ipAddress = _ipAddress;
            PortNumber = 502;
            IsConnected = false;
            readTimeOut = 1000;
            retryNumber = 1;
            pollingTime = 1000.0;
            MaxRegisterInOnePoll = 16;
        }

#pragma warning disable CS1573 // Parameter '_maxregisterinonepoll' has no matching param tag in the XML comment for 'ModbusTCPClient.ModbusTCPClient(string, int, int, double, byte)' (but other parameters do)
        /// <summary>
        /// Initializes a new instance of the <see cref="ModbusTCPClient"/> class.
        /// </summary>
        /// <param name="_ipAddress">The ip address.</param>
        /// <param name="_readTimeOut">The read time out.</param>
        /// <param name="_retryNumber">The retry number.</param>
        /// <param name="_pollingtime">The pollingtime.</param>
        public ModbusTCPClient(string _ipAddress, int _readTimeOut, int _retryNumber, double _pollingtime, byte _maxregisterinonepoll) : this(_ipAddress)
#pragma warning restore CS1573 // Parameter '_maxregisterinonepoll' has no matching param tag in the XML comment for 'ModbusTCPClient.ModbusTCPClient(string, int, int, double, byte)' (but other parameters do)
        {
            readTimeOut = _readTimeOut;
            retryNumber = _retryNumber;
            pollingTime = _pollingtime;
            MaxRegisterInOnePoll = _maxregisterinonepoll;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModbusTCPClient" /> class.
        /// </summary>
        /// <param name="_ipAddress">The ip address.</param>
        /// <param name="_portNumber">The port number.</param>
        public ModbusTCPClient(string _ipAddress, int _portNumber) : this(_ipAddress)
        {
            PortNumber = _portNumber;
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// Occurs when [any binary signal value changed].
        /// </summary>
        public event ModbusEventHandler AnyBinarySignalValueChanged;

        /// <summary>
        /// Occurs when [any analog signal value changed].
        /// </summary>
        public event ModbusEventHandler AnyAnalogSignalValueChanged;

        /// <summary>
        /// Occurs when [cannot connect to device].
        /// </summary>
        public event ModbusEventHandler DisconnectedFromServer;

        /// <summary>
        /// Occurs when [communication established].
        /// </summary>
        public event ModbusEventHandler ConnectedToServer;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModbusTCPClient.DeviceConnectionStateChanged'
        public event ModbusEventHandler DeviceConnectionStateChanged;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModbusTCPClient.DeviceConnectionStateChanged'

        /// <summary>
        /// Called when [any binary signal value changed].
        /// </summary>
        /// <param name="_valueChangedSignals">Value changed signals.</param>
        private void OnAnyBinarySignalValueChanged(List<BinarySignal> _valueChangedSignals)
        {
            Log.Instance.Trace("{1}: {2} methodu {0} ip adresi için cagrıldı", ipAddress, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            ModbusEventArgs ms = new ModbusEventArgs();
            ms.BinarySignals = _valueChangedSignals;

            if (AnyBinarySignalValueChanged != null)
            {
                AnyBinarySignalValueChanged(this, ms);
            }
        }

        /// <summary>
        /// Called when [any analog signal value changed].
        /// </summary>
        /// <param name="_valueChangedSignals">Value changed signals.</param>
        private void OnAnyAnalogSignalValueChanged(List<AnalogSignal> _valueChangedSignals)
        {
            Log.Instance.Trace("{1}: {2} methodu {0} ip adresi için cagrıldı", ipAddress, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            ModbusEventArgs ms = new ModbusEventArgs();
            ms.AnalogSignals = _valueChangedSignals;

            if (AnyAnalogSignalValueChanged != null)
            {
                AnyAnalogSignalValueChanged(this, ms);
            }
        }

        /// <summary>
        /// Called when [disconnect from server].
        /// </summary>
        private void OnDisconnectedFromServer(List<Device> _devices)
        {
            Log.Instance.Trace("{1}: {2} methodu {0} ip adresi için cagrıldı", ipAddress, this.GetType().Name, MethodBase.GetCurrentMethod().Name);

            Log.Instance.Error("{0}: Driver baglantı hatası => {1} ip adresi ile bağlantı problemi", this.GetType().Name, ipAddress);
            foreach (Device d in Devices)
            {
                d.Connected = false;
            }

            dtDisconnected = DateTime.Now;
            ModbusEventArgs ms = new ModbusEventArgs();
            ms.Devices = _devices;
            if (DisconnectedFromServer != null)
            {
                DisconnectedFromServer(this, ms);
            }
        }

        /// <summary>
        /// Called when [connected to server].
        /// </summary>
        /// <exception cref="Exception">ModbusServer Hata: Device bulunamadı</exception>
        private void OnConnectedToServer()
        {
            Log.Instance.Trace("{1}: {2} methodu {0} ip adresi için cagrıldı", ipAddress, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            if (Devices == null)
            {
                throw new Exception("ModbusServer Hata: Device bulunamadı");
            }
            else
            {
                foreach (Device d in Devices)
                {
                    if (d.BinarySignals.Count > 0)
                    {
                        d.BinarySignals = d.BinarySignals.OrderBy(b => b.Address).ThenBy(b => b.BitNumber).ToList();
                    }
                    if (d.AnalogSignals.Count > 0)
                    {
                        d.AnalogSignals = d.AnalogSignals.OrderBy(a => a.Address).ToList();
                    }
                }
            }
            if (ConnectedToServer != null)
            {
                ModbusEventArgs ms = new ModbusEventArgs();
                ms.ipAddress = ipAddress;
                ConnectedToServer(this, ms);
            }
        }

        private void OnDeviceConnectionStateChanged(Device _device)
        {
            if (DeviceConnectionStateChanged != null)
            {
                ModbusEventArgs ms = new ModbusEventArgs();
                ms.Device = _device;
                DeviceConnectionStateChanged(this, ms);
            }
        }

        #endregion Events

        #region Public Methods

        /// <summary>
        /// Connects to modbus server.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Connect()
        {
            if (master != null)
            {
                master.Dispose();
            }
            if (client != null)
            {
                client.Close();
            }
            client = new TcpClient();
            try
            {
                // Server ile TCP baglantısı olusturuluyor

                IAsyncResult asyncResult = client.BeginConnect(ipAddress, PortNumber, null, null);
                // readTimeOut süresi kadar saniye içerisinde bağlantının kurulması bekleniyor.
                asyncResult.AsyncWaitHandle.WaitOne(readTimeOut, true); 
                // readTimeOut süresi sonunda TCP baglantısı kurulamazsa
                if (!asyncResult.IsCompleted)
                {
                    client.Close();
                    IsConnected = false;
                    OnDisconnectedFromServer(Devices);
                }
                // Baglantı kuruldugunda
                else
                {
                    // TCP baglantısı kurulduktan sonra IpAddress için modbus baglantısı olusturuluyor
                    master = ModbusIpMaster.CreateIp(client);
                }
            }
            catch (Exception e)
            {
                IsConnected = false;
                OnDisconnectedFromServer(Devices);
                Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                Log.Instance.Fatal("ModbusTCP ({0}) => {1}", ipAddress, e.InnerException);
            }
            finally
            {
                if ((client.Client != null & master != null))
                {
                    if (client.Connected)
                    {
                        master.Transport.Retries = retryNumber;
                        master.Transport.ReadTimeout = readTimeOut;
                        IsConnected = true;
                        Log.Instance.Info("{0} ip adresi ile bağlantı kuruldu", ipAddress);
                        OnConnectedToServer();
                    }
                    else
                    {
                        IsConnected = false;
                    }
                }

                if (pollingTimer == null)
                {
                    InitializePollingTimer();
                }

            }
        }

        /// <summary>
        /// Reads the values from modbus server.
        /// </summary>
        public void ReadValues()
        {
            // ModbusServer için daha önce timer olusturulmamışsa sinyalleri okumak icin timer olusturuluyor. 
            

            try
            {
                if (IsConnected)
                {
                    ReadBinaryValues();
                    ReadAnalogValues();
                }
                else
                {
                    dtNow = DateTime.Now;
                    if ((dtNow - dtDisconnected) > TimeSpan.FromSeconds(10))
                    {
                        // Ip adresi altındaki cihazlardan herhangi birinin isActive bitinin true olup olmadığına bakılıyor.
                        // isActive biti true olan cihaz yoksa bağlantı kurulmuyor.

                        if (isAnyActiveDeviceAvaliable)
                        {
                            Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                            Log.Instance.Info("{0}: {1} ip adresine tekrardan bağlanılıyor...", this.GetType().Name, ipAddress);
                            Connect();
                        }
                    }
                }
            }
            catch (HttpListenerException ex)
            {
                Log.Instance.Error("HttpListenerException " + ex.Message );
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
                    Log.Instance.Error("ModbusServer Hata: {0} => {1}", ipAddress, ex.Message);
                    //OnDisconnectedFromServer();
                }

                if (ex.Source.Equals("nModbusPC"))
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
                            Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                            Log.Instance.Error("ModbusServer Hata: {0} => {1} => Illegal function", ipAddress, _exceptionCode.Trim());
                            break;

                        case "2":
                            Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                            Log.Instance.Error("ModbusServer Hata: {0} => {1} => Illegal data address", ipAddress, _exceptionCode.Trim());
                            break;

                        case "3":
                            Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                            Log.Instance.Error("ModbusServer Hata: {0} => {1} => Illegal data value", ipAddress, _exceptionCode.Trim());
                            break;

                        case "4":
                            Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                            Log.Instance.Error("ModbusServer Hata: {0} => {1} => Slave device failure", ipAddress, _exceptionCode.Trim());
                            break;

                        default:
                            Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                            Log.Instance.Error("ModbusServer Hata: {0} => {1} => Unknown Error", ipAddress, _exceptionCode.Trim());
                            break;
                    }
                }
            }
        }

        private void InitializePollingTimer()
        {
            pollingTimer = new PollingTimer(pollingTime);
            pollingTimer.hostAddress = ipAddress;
            pollingTimer.Elapsed += PollingTimer_Elapsed;
            pollingTimer.AutoReset = true;
            pollingTimer.Enabled = true;
            pollingTimer.Start();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ModbusTCPClient.WriteValue(Device, CommandSignal)'
        public void WriteValue(Device _d, CommandSignal _commandSignal)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ModbusTCPClient.WriteValue(Device, CommandSignal)'
        {
            if (_d.Connected && _d.isActive)
            {
                switch (_commandSignal.FunctionCode)
                {
                    case 5:
                        WriteSingleCoil(_d, _commandSignal);
                        break;
                    case 6:
                        WriteSingleRegister(_d, _commandSignal);
                        break;
                    case 15:
                        WriteMultipleCoils(_d, _commandSignal);
                        break;
                    case 16:
                        WriteValueMultipleRegisters(_d, _commandSignal);
                        break;
                    default:
                        Log.Instance.Error("Yanlış function code : {0} sinyaline değer yazılamadı", _commandSignal.Identification);
                        break;
                } 
            }
            else
            {
                Log.Instance.Warn("{0}: {1} adlı komut cihaz ile haberleşme olmadığı için gönderilemedi", this.GetType().Name, _commandSignal.Identification);
            }
            
        }

        private void WriteValueMultipleRegisters(Device _d, CommandSignal _commandSignal)
        {
            //throw new NotImplementedException();
        }

        private void WriteMultipleCoils(Device _d, CommandSignal _commandSignal)
        {
            //throw new NotImplementedException();
        }

        private void WriteSingleRegister(Device _d, CommandSignal _commandSignal)
        {
            ushort value = 0;
            try
            {
                switch(_commandSignal.commandType)
                {
                    case CommandSignal.CommandType.Binary:
                        int bit = (_commandSignal.CommandValue) > 0 ? 0 : 1;
                        value = (ushort)(bit << _commandSignal.BitNumber);
                        master.WriteSingleRegister(_d.SlaveID, _commandSignal.Address, value);
                        break;
                    case CommandSignal.CommandType.Analog:
                        value = (ushort)_commandSignal.CommandValue;
                        break;
                    default:
                        break;
                }

                master.WriteSingleRegister(_d.SlaveID, _commandSignal.Address, value);


            }
            catch (Exception)
            {
                Log.Instance.Error("{0} adlı sinyale {1} değeri yazılamadı", _commandSignal.Identification, _commandSignal);
            }
        }

        private void WriteSingleCoil(Device _d, CommandSignal _commandSignal)
        {

            try
            {
                bool value = _commandSignal.CommandValue > 0 ? false : true;
                master.WriteSingleCoil(_d.SlaveID, _commandSignal.Address, value);

            }
            catch (Exception)
            {
                Log.Instance.Error("{0} adlı sinyale {1} değeri yazılamadı", _commandSignal.Identification, _commandSignal);
            }
        }


        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Handles the Elapsed event of the PollingTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void PollingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            pollingTimer.Enabled = false;
            isAnyActiveDeviceAvaliable = Devices.Exists((d) => d.isActive == true);
            if (isAnyActiveDeviceAvaliable)
            {
                ReadValues();
            }
            pollingTimer.Enabled = true;
        }

        /// <summary>
        /// Totals the word count.
        /// </summary>
        /// <param name="_signalList">The signal list.</param>
        /// <returns></returns>
        private ushort TotalWordCount(List<AnalogSignal> _signalList)
        {
            ushort _numberOfWords = 0;
            if (_signalList.Count > 0)
            {
                foreach (AnalogSignal _signal in _signalList)
                {
                    _numberOfWords += _signal.WordCount;
                }
            }
            return _numberOfWords;
        }

#pragma warning disable CS1573 // Parameter '_totalSignalCount' has no matching param tag in the XML comment for 'ModbusTCPClient.TotalWordCount(List<AnalogSignal>, int, int)' (but other parameters do)

#pragma warning disable CS1572 // XML comment has a param tag for '_numberOfLastSignal', but there is no parameter by that name
        /// <summary>
        /// Totals the word count.
        /// </summary>
        /// <param name="_signalList">The signal list.</param>
        /// <param name="_numberOfFirstSignal">The number of first signal.</param>
        /// <param name="_numberOfLastSignal">The number of last signal.</param>
        /// <returns></returns>
        private ushort TotalWordCount(List<AnalogSignal> _signalList, int _numberOfFirstSignal, int _totalSignalCount)
#pragma warning restore CS1573 // Parameter '_totalSignalCount' has no matching param tag in the XML comment for 'ModbusTCPClient.TotalWordCount(List<AnalogSignal>, int, int)' (but other parameters do)
        {
#pragma warning restore CS1572 // XML comment has a param tag for '_numberOfLastSignal', but there is no parameter by that name
            ushort _numberOfWords = 0;
            for (int i = _numberOfFirstSignal; i < _numberOfFirstSignal + _totalSignalCount; i++)
            {
                _numberOfWords += _signalList[i].WordCount;
            }
            return _numberOfWords;
        }

#pragma warning disable CS1572 // XML comment has a param tag for 'source', but there is no parameter by that name

#pragma warning disable CS1572 // XML comment has a param tag for 'e', but there is no parameter by that name
        /// <summary>
        /// Reads the analog values from server.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs" /> instance containing the event data.</param>
        private void ReadAnalogValues()
        {
            // ModbusTCPMaster'da yer alan her device için okuma işlemi başlatılır.
            foreach (Device d in Devices)
            {
                if (d.isActive)
                {
                    try
                    {
                        if (d.AnalogSignals != null)
                        {
                            //Device(d) AnalogSignals listesi boş değilse okuma işlemi başlatılır
                            if (d.AnalogSignals.Count > 0)
                            {
                                // Note: AnalogSignal listesindeki tüm sinyaller "OnConnectedToServer" methodunda modbus adreslerine göre sıralanmıştır.

                                int _queueIndexOfFirstSignalWillBeRead = 0;
                                int _totalWordCount = 0;
                                _totalWordCount += d.AnalogSignals[0].WordCount;
                                // AnalogSignals listesinde birden fazla sinyal varsa ardışık okuma yapabilmek için for dongusu ile diger sinyallerin function code'ları ve modbus adreslerindeki ardışıklık kontrol edilir.
                                // Modbus adreslerinde ardışıklık yer alan sinyaller aynı request içerisinde okunur.
                                for (int index = 1; index < d.AnalogSignals.Count; index++)
                                {
                                    bool isSameFunctionCode = ((d.AnalogSignals[index - 1].FunctionCode == 3 || d.AnalogSignals[index - 1].FunctionCode == 4) & (d.AnalogSignals[index - 1].FunctionCode == d.AnalogSignals[index].FunctionCode));
                                    bool isModbusAddressSequential = d.AnalogSignals[index - 1].Address == d.AnalogSignals[index].Address - d.AnalogSignals[index].WordCount;
                                    // AnalogSignals listesindeki signal[index-1] ve signal[index]'in function code'ları aynı ve singnal[i] ile signal[i-1]'in modbus adreslerinde istenen ardışıklık olduğu sürece for düngüsü devam eder.
                                    // Logiclerden herhangi biri false donerse okuma işlemi başlatılır.
                                    if (!(isSameFunctionCode & isModbusAddressSequential & (_totalWordCount + d.AnalogSignals[index].WordCount <= MaxRegisterInOnePoll)))
                                    {
                                        d.AnalogSignals = ReadAnalogSignalsValuesFromModbusDevice(d, _queueIndexOfFirstSignalWillBeRead, index - _queueIndexOfFirstSignalWillBeRead);
                                        // Okume gerceklestiyse haberlesme var demektir. Aksi taktirde ReadAnalogSignalsValuesFromModbusDevice methodu exception gönderecekti.
                                        if (d.Connected == false)
                                        {
                                            d.Connected = true;
                                            OnDeviceConnectionStateChanged(d);
                                        }
                                        _queueIndexOfFirstSignalWillBeRead = index;
                                        _totalWordCount = 0;
                                    }
                                    else
                                    {
                                        _totalWordCount += d.AnalogSignals[index].WordCount;
                                    }
                                }

                                // Son for döngüsünden sonra degeri okunmamış sinyal varsa bu sinyaller için okuma işlemi for döngüşü bittikten sonra gerçeklenir.
                                if (_queueIndexOfFirstSignalWillBeRead != d.AnalogSignals.Count)
                                {
                                    d.AnalogSignals = ReadAnalogSignalsValuesFromModbusDevice(d, _queueIndexOfFirstSignalWillBeRead, d.AnalogSignals.Count - _queueIndexOfFirstSignalWillBeRead);
                                    if (d.Connected == false)
                                    {
                                        d.Connected = true;
                                        OnDeviceConnectionStateChanged(d);
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
                                throw;
                            }
                        }

                        //
                        if (d.Connected)
                        {
                            Log.Instance.Error("{0}: {1} nolu device haberleşme hatası ", this.GetType().Name, d.ID);
                            d.Connected = false;
                            OnDeviceConnectionStateChanged(d);
                            //throw;
                        }
                    }
                }
            }
        }

#pragma warning disable CS1572 // XML comment has a param tag for 'source', but there is no parameter by that name

#pragma warning disable CS1572 // XML comment has a param tag for 'e', but there is no parameter by that name
        /// <summary>
        /// Reads the binary values from server.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="Exception">
        /// ModbusServer Hata: Yanlış tanımlanan adres veya Function Code bulundu
        /// or
        /// ModbusServer Hata: Yanlış tanımlanan adres veya Function Code bulundu
        /// </exception>
        private void ReadBinaryValues()
#pragma warning restore CS1572 // XML comment has a param tag for 'e', but there is no parameter by that name
#pragma warning restore CS1572 // XML comment has a param tag for 'source', but there is no parameter by that name
        {
            // ModbusTCPMaster'da yer alan her device için okuma işlemi başlatılır.
            foreach (Device d in Devices)
            {
                if (d.isActive)
                {
                    try
                    {
                        if (d.BinarySignals != null)
                        {
                            //Device(d) BinarySignal listesi boş değilse okuma işlemi başlatılır
                            if (d.BinarySignals.Count > 0)
                            {
                                int _queueIndexOfFirstSignalWillBeRead = 0;
                                int _totalWordCount = 0;
                                _totalWordCount = d.BinarySignals[0].WordCount;
                                // Not: BinarySignal listesindeki tüm sinyaller "startCommunication" methodunda modbus adreslerine göre sıralanmıştı.

                                // BinarySignals listesinde birden fazla sinyal varsa ardışık okuma yapabilmek için for dongusu ile diger sinyallerin function code'ları ve modbus adreslerindeki ardışıklık kontrol edilir.
                                // Modbus adreslerinde ardışıklık yer alan sinyaller aynı request içerisinde okunur.
                                for (int index = 1; index < d.BinarySignals.Count; index++)
                                {
                                    bool isSameFunctionCode = ((d.BinarySignals[index - 1].FunctionCode == 1 || d.BinarySignals[index - 1].FunctionCode == 2 || d.BinarySignals[index - 1].FunctionCode == 3) & (d.BinarySignals[index - 1].FunctionCode == d.BinarySignals[index].FunctionCode));
                                    bool isModbusAddressSequential = ((d.BinarySignals[index - 1].FunctionCode == 1 || d.BinarySignals[index - 1].FunctionCode == 2 & (d.BinarySignals[index - 1].Address == d.BinarySignals[index].Address - 1))
                                                                  || ((d.BinarySignals[index - 1].FunctionCode == 3) & (d.BinarySignals[index - 1].Address == d.BinarySignals[index].Address)));
                                    bool MaxRegisterInOnePollSatisfied = ((d.BinarySignals[index].FunctionCode == 1 || d.BinarySignals[index].FunctionCode == 2) & (_totalWordCount + d.BinarySignals[index].WordCount <= MaxRegisterInOnePoll)) || (d.BinarySignals[index].FunctionCode == 3);

                                    // AnalogSignals listesindeki signal[index-1] ve signal[index]'in function code'ları aynı ve singnal[i] ile signal[i-1]'in modbus adreslerinde istenen ardışıklık olduğu sürece for düngüsü devam eder.
                                    // Logiclerden herhangi biri false donerse okuma işlemi başlatılır.
                                    if (!(isSameFunctionCode & isModbusAddressSequential & MaxRegisterInOnePollSatisfied))
                                    {
                                        d.BinarySignals = ReadBinarySignalsValuesFromModbusDevice(d, _queueIndexOfFirstSignalWillBeRead, index - _queueIndexOfFirstSignalWillBeRead);
                                        if (d.Connected == false)
                                        {
                                            d.Connected = true;
                                            OnDeviceConnectionStateChanged(d);
                                        }
                                        _queueIndexOfFirstSignalWillBeRead = index;
                                        _totalWordCount = 0;
                                    }
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

                                // Son for döngüsünden sonra degeri okunmamış sinyal varsa bu sinyaller için okuma işlemi for döngüşü bittikten sonra gerçeklenir.
                                if (_queueIndexOfFirstSignalWillBeRead != d.BinarySignals.Count)
                                {
                                    d.BinarySignals = ReadBinarySignalsValuesFromModbusDevice(d, _queueIndexOfFirstSignalWillBeRead, d.BinarySignals.Count - _queueIndexOfFirstSignalWillBeRead);
                                    if (d.Connected == false)
                                    {
                                        d.Connected = true;
                                        OnDeviceConnectionStateChanged(d);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        if (e.Source.Equals("System"))
                        {
                            // System tarafından gönderilen exception mesajı sinyal okuyamam ile ilgili bir exception değilse bu exceptionu üst methoda gönderir
                            if (e.HResult != -2146232800)
                            {
                                throw;
                            }
                        }

                        //
                        if (d.Connected)
                        {
                            Log.Instance.Error("{0}: {1} nolu device haberleşme hatası ", this.GetType().Name, d.ID);
                            d.Connected = false;
                            OnDeviceConnectionStateChanged(d);
                            //throw;
                        }

                        //throw;
                    }
                }
            }
        }

        //private void ReadCommands()
        //{
        //    // ModbusTCPMaster'da yer alan her device için okuma işlemi başlatılır.
        //    foreach (Device d in Devices)
        //    {
        //        if (d.isActive)
        //        {
        //            try
        //            {
        //                if (d.CommandSignals != null)
        //                {
        //                    //Device(d) CommandSignals listesi boş değilse database'den ilgili device için aktif komut olup olmadığı kontrol edilir
        //                    if (d.CommandSignals.Count > 0)
        //                    {
        //                        DataTable dt = new DataTable();
        //                        dt = db
        //                    }
        //                }
        //            }
        //            catch
        //            {
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Analog sinyalleri okur.
        /// </summary>
        /// <param name="_device">Device</param>
        /// <param name="_numberOfFirstSignal">The number of first signal.</param>
        /// <param name="_totalSignalCount">Okunacak toplam sinyal sayısı</param>
        /// <returns></returns>
        /// <exception cref="Exception">ModbusServer Hata: Yanlış tanımlanan adres veya Function Code bulundu</exception>
        private List<AnalogSignal> ReadAnalogSignalsValuesFromModbusDevice(Device _device, int _numberOfFirstSignal, int _totalSignalCount)
        {
            List<AnalogSignal> _valueChangedSignals = new List<AnalogSignal>();
            AnalogSignal _firstSignal = _device.AnalogSignals[_numberOfFirstSignal];
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
                                    _valueChangedSignals.Add(_device.AnalogSignals[currentSignalNo]);
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
                                    _valueChangedSignals.Add(_device.AnalogSignals[currentSignalNo]);
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
                            throw;
                        }
                    }

                    //
                    if (_device.Connected)
                    {
                        Log.Instance.Error("{0}: {1} nolu device haberleşme hatası ", this.GetType().Name, _device.ID);
                        _device.Connected = false;
                        OnDeviceConnectionStateChanged(_device);
                        throw;
                    }
                }
            }
            // Function Code tanımsız oldugunda yaplan işlemler
            else
            {
                Log.Instance.Error("{0} Hata: Yanlış tanımlanan adres veya geçersiz function Code bulundu", this.GetType().Name);
            }

            // Okuma işlemi bittiğinde bufferValueChangedSignals listesine sinyal eklenmişse event çağrılır.
            if (_valueChangedSignals.Count > 0)
            {
                OnAnyAnalogSignalValueChanged(_valueChangedSignals);
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
        private List<BinarySignal> ReadBinarySignalsValuesFromModbusDevice(Device _device, int _numberOfFirstSignal, int _totalSignalCount)
        {
            List<BinarySignal> _valueChangedSignals = new List<BinarySignal>();
            BinarySignal _firstSignal = _device.BinarySignals[_numberOfFirstSignal];
            bool[] values = { };
            //ushort wordCount = TotalWordCount(_device.BinarySignals, _numberOfFirstSignal, _totalSignalCount);

            // Function Code'un 1 ve ya 2 olduğunda yapılan işlemler
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
#pragma warning disable CS0162 // Unreachable code detected
                        break;
#pragma warning restore CS0162 // Unreachable code detected
                }
                //if ((_firstSignal.FunctionCode == 1))
                //{
                //    values = master.ReadCoils(_device.SlaveID, _firstSignal.Address, Convert.ToUInt16(_totalSignalCount));
                //}
                //else if (_firstSignal.FunctionCode == 2)
                //{
                //    values = master.ReadInputs(_device.SlaveID, _firstSignal.Address, Convert.ToUInt16(_totalSignalCount));
                //}

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
                        _valueChangedSignals.Add(_device.BinarySignals[currentSignalNo]);
                    }
                }
            }

            // Function Code 3 olduğunda yapılan işlemler
            else if (_firstSignal.FunctionCode == 3)
            {
                ushort numberOfPoints = Convert.ToUInt16(_device.BinarySignals[_numberOfFirstSignal + _totalSignalCount - 1].BitNumber / 15 + 1);
                ushort[] register = master.ReadHoldingRegisters(_device.SlaveID, _firstSignal.Address, numberOfPoints);

                for (int k = 0; k < _totalSignalCount; k++)
                {
                    int currentSignalNo = _numberOfFirstSignal + k;
                    int _wordNumber = _device.BinarySignals[currentSignalNo].BitNumber / 15;
                    bool value = (register[_wordNumber] & (1 << _device.BinarySignals[currentSignalNo].BitNumber)) > 0;

                    if (_device.BinarySignals[currentSignalNo].IsReversed)
                    {
                        value = !value;
                    }

                    if (_device.BinarySignals[currentSignalNo].CurrentValue != value)
                    {
                        _device.BinarySignals[currentSignalNo].CurrentValue = value;
                        _device.BinarySignals[currentSignalNo].TimeTag = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        _valueChangedSignals.Add(_device.BinarySignals[currentSignalNo]);
                    }
                }
            }

            // Function Code tanımsız oldugunda yaplan işlemler
            else
            {
                Log.Instance.Error("{0} Hata: Yanlış tanımlanan adres veya geçersiz function Code bulundu", this.GetType().Name);
            }

            // Okuma işlemi bittiğinde _valueChangedSignals listesine sinyal eklenmişse event çağrılır.
            if (_valueChangedSignals.Count > 0)
            {
                OnAnyBinarySignalValueChanged(_valueChangedSignals);
                _valueChangedSignals.Clear();
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
        private List<BinarySignal> CompareBinaryValues(ref List<BinarySignal> _deviceSignalList, List<BinarySignal> _readValuesSignalList, bool[] _readvalues, int _startAddress)
        {
            List<BinarySignal> returnSignalList = new List<BinarySignal>();

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
        private List<BinarySignal> CompareBinaryValues(ref List<BinarySignal> _deviceSignalList, List<BinarySignal> _readValuesSignalList, ushort[] _registers, int _startAddress)
        {
            List<BinarySignal> returnSignalList = new List<BinarySignal>();

            for (int k = 0; k < _readValuesSignalList.Count; k++)
            {
                int _byteNumber = _readValuesSignalList[k].BitNumber % 15;
                if (_readValuesSignalList[k].CurrentValue != (_registers[_byteNumber] & (1 << _readValuesSignalList[k].BitNumber)) > 0)
                {
                    _deviceSignalList[_startAddress - _readValuesSignalList.Count + k].CurrentValue = (_registers[_byteNumber] & (1 << _readValuesSignalList[k].BitNumber)) > 0;
                    _deviceSignalList[_startAddress - _readValuesSignalList.Count + k].TimeTag = DateTime.Now.ToString();
                    returnSignalList.Add(_deviceSignalList[_startAddress - _readValuesSignalList.Count + k]);
                }
            }

            return returnSignalList;
        }

        /// <summary>
        /// Determines whether [is network avaliable].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is network avaliable]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsNetworkAvaliable()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        #endregion Private Methods
    }

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ModbusEventArgs : EventArgs
    {
        /// <summary>
        /// The analog signals
        /// </summary>
        public List<AnalogSignal> AnalogSignals { get; internal set; }

        /// <summary>
        /// Gets or sets the binary signals.
        /// </summary>
        /// <value>
        /// The binary signals.
        /// </value>
        public List<BinarySignal> BinarySignals { get; internal set; }

        public string ipAddress { get; internal set; }

        public List<Device> Devices { get; internal set; }

        public Device Device { get; internal set; }
    }
}