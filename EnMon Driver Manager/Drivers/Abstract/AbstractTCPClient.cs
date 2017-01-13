using EnMon_Driver_Manager.Models;
using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Models.Signals;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection;
using System.Timers;

namespace EnMon_Driver_Manager.Drivers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'IDriverMaster'

    public abstract class AbstractTCPClient
    {

        #region Public Properties

        public PollingTimer pollingTimer { get; set; }

        public List<Device> Devices { get; set; }

        public string ipAddress { get; set; }

        public int PortNumber { get; set; }

        public bool IsConnected { get; set; }

        public TcpClient client { get; set; }

        #endregion Public Properties

        #region Protected Properties

        protected enum ConnectionStatus
        {
            Connected,
            Disconnected
        }

        protected double pollingTime { get; set; }

        protected int readTimeOut { get; set; }

        protected int retryNumber { get; set; }

        protected DateTime dtNow { get; set; }

        protected DateTime dtDisconnected { get; set; }

        protected bool isAnyActiveDeviceAvaliable { get; set; }

        protected bool isDismiss { get; set; }

        protected int clientDisconnectionCounter { get; set; }

        protected int indexOfCurrentDevice { get; set; }

        #endregion Protected Properties

        #region Constructors

        public AbstractTCPClient()
        {
            InitializeDefaultCommunicationSettings();

            InitializeClientProperties();

            Devices = new List<Device>();
        }

        public AbstractTCPClient(string _ipAddress) : this()
        {
            ipAddress = _ipAddress;
        }

        public AbstractTCPClient(string _ipAddress, int _portNumber) : this(_ipAddress)
        {
            PortNumber = _portNumber;
        }

        public AbstractTCPClient(string _ipAddress, int _readTimeOut, int _retryNumber, double _pollingtime) : this(_ipAddress)
        {
            readTimeOut = _readTimeOut;
            retryNumber = _retryNumber;
            pollingTime = _pollingtime;
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// Occurs when [any binary signal value changed].
        /// </summary>
        public event TCPClientEventHandler AnyBinarySignalValueChanged;

        /// <summary>
        /// Occurs when [any analog signal value changed].
        /// </summary>
        public event TCPClientEventHandler AnyAnalogSignalValueChanged;

        /// <summary>
        /// Occurs when [cannot connect to device].
        /// </summary>
        public event TCPClientEventHandler DisconnectedFromServer;

        /// <summary>
        /// Occurs when [communication established].
        /// </summary>
        public event TCPClientEventHandler ConnectedToServer;

        /// <summary>
        /// Occurs when [device connection state changed].
        /// </summary>
        public event TCPClientEventHandler DeviceConnectionStateChanged;


        protected void OnAnyBinarySignalValueChanged(List<BinarySignal> _valueChangedSignals)
        {
            Log.Instance.Trace("{1}: {2} methodu {0} ip adresi için cagrıldı", ipAddress, this.GetType().Name, MethodBase.GetCurrentMethod().Name);

            TCPClientEventArgs args = new TCPClientEventArgs();
            args.BinarySignals = _valueChangedSignals;

            AnyBinarySignalValueChanged?.Invoke(this, args);
        }

        protected void OnAnyAnalogSignalValueChanged(List<AnalogSignal> _valueChangedSignals)
        {
            Log.Instance.Trace("{1}: {2} methodu {0} ip adresi için cagrıldı", ipAddress, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            TCPClientEventArgs ms = new TCPClientEventArgs();
            ms.AnalogSignals = _valueChangedSignals;

            if (AnyAnalogSignalValueChanged != null)
            {
                AnyAnalogSignalValueChanged(this, ms);
            }
        }

        protected void OnDisconnectedFromServer(List<Device> _devices)
        {
            Log.Instance.Trace("{1}: {2} methodu {0} ip adresi için cagrıldı", ipAddress, this.GetType().Name, MethodBase.GetCurrentMethod().Name);

            Log.Instance.Error("{0}: Driver baglantı hatası => {1} ip adresi ile bağlantı problemi", this.GetType().Name, ipAddress);
            foreach (Device d in Devices)
            {
                d.Connected = false;
            }

            dtDisconnected = DateTime.Now;
            TCPClientEventArgs ms = new TCPClientEventArgs();
            ms.Devices = _devices;
            if (DisconnectedFromServer != null)
            {
                DisconnectedFromServer(this, ms);
            }
        }

        protected void OnConnectedToServer()
        {
            Log.Instance.Trace("{1}: {2} methodu {0} ip adresi için cagrıldı", ipAddress, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            if (Devices == null)
            {
                throw new Exception(string.Format("{0} Hata: Device bulunamadı", this.GetType().Name));
            }
            else
            {
                OrderSignalsByAddress();
            }
            if (ConnectedToServer != null)
            {
                TCPClientEventArgs ms = new TCPClientEventArgs();
                ms.ipAddress = ipAddress;
                ConnectedToServer(this, ms);
            }
        }

        protected void OnDeviceConnectionStateChanged(Device _device)
        {
            if (DeviceConnectionStateChanged != null)
            {
                TCPClientEventArgs ms = new TCPClientEventArgs();
                ms.Device = _device;
                DeviceConnectionStateChanged(this, ms);
            }
        }

        #endregion Events

        #region Public Methods

        public void Connect()
        {
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

                // Baglantı kurulduysa
                else
                {
                    IsConnected = true;
                    Log.Instance.Info("{0}: {1} ip adresi ile bağlantı kuruldu", this.GetType().Name, ipAddress);
                    DoProtocolSpecificWorksWhenCommunicationEstablished();
                    OnConnectedToServer();
                }
            }
            catch (Exception e)
            {
                IsConnected = false;
                clientDisconnectionCounter++;
                OnDisconnectedFromServer(Devices);
                Log.Instance.Error("{0}: {1} IP adresli cihaz ile haberleşme hatası => {2}", this.GetType().Name, ipAddress, e.Message);
            }
            finally
            {
                if (pollingTimer == null & !isDismiss)
                {
                    InitializePollingTimer();
                }
            }
        }

        public void Dismiss()
        {
            // Tekrar sorgu yapılmaması için timer durduruluyor.
            isDismiss = true;
            if (pollingTimer != null)
            {
                pollingTimer.Stop();
            }

            OnDisconnectedFromServer(Devices);
        }


        #endregion Public Methods

        #region Protected Methods

        protected void SetDeviceConnectionStatus(Device _device, ConnectionStatus _connectionStatus)
        {
            switch (_connectionStatus)
            {
                case ConnectionStatus.Connected:
                    _device.Connected = true;
                    OnDeviceConnectionStateChanged(_device);
                    break;

                case ConnectionStatus.Disconnected:
                    _device.Connected = false;
                    OnDeviceConnectionStateChanged(_device);
                    break;
            }
        }

        protected bool IsNetworkAvaliable()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        #endregion Protected Methods

        #region Private Methods

        private void InitializePollingTimer()
        {
            pollingTimer = new PollingTimer(pollingTime);
            pollingTimer.hostAddress = ipAddress;
            pollingTimer.Elapsed += PollingTimer_Elapsed;
            pollingTimer.AutoReset = true;
            pollingTimer.Enabled = true;
            pollingTimer.Start();
        }

        /// <summary>
        /// Handles the Elapsed event of the PollingTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void PollingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            pollingTimer.Enabled = false;

            // DriverTCPClient'in bağlanacağı cihazlardan en az 1'i aktif ise
            if (AnyActiveDeviceAvaliable())
            {
                // ve DriverTCPClient'in TCP bağlantısı varsa okuma işlemi başlatılır.
                if (IsConnected)
                {
                    ReadValues();    
                }

                // TCP bağlantısı yoksa tekrardan bağlantı kurmayı dener.
                else
                {
                    {
                        dtNow = DateTime.Now;
                        if ((dtNow - dtDisconnected) > TimeSpan.FromSeconds(10))
                        {
                            Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                            Log.Instance.Info("{0}: {1} ip adresine tekrardan bağlanılıyor...", this.GetType().Name, ipAddress);
                            Connect();
                        }
                    }
                }
            }

            if (pollingTimer != null & !isDismiss)
            {
                pollingTimer.Enabled = true;
            }
        }




        #endregion Private Methods

        #region Public Abstract Methods

        public abstract void ReadValues();

        public abstract bool WriteValue(Device d, CommandSignal c);

        #endregion Public Abstract Methods

        #region Protected Abstract Methods

        protected abstract void OrderSignalsByAddress();

        protected abstract void InitializeDefaultCommunicationSettings();

        protected abstract void InitializeClientProperties();

        protected abstract void DoProtocolSpecificWorksWhenCommunicationEstablished();

        protected abstract bool AnyActiveDeviceAvaliable();


        #endregion Protected Abstract Methods

    }
}