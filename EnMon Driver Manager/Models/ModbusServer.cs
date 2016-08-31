using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models
{
    delegate void ModbusServerEventHandler(object source, EventArgs e);
    public class ModbusServer
    {
        private string IpAddress { get; set; }
        public int PortNumber { get; set; }
        public bool IsConnected {get; set;}
        private int RetryNumber { get; set; }
        private int ReadTimeOut { get; set; }
        private int PollingTime { get; set; }
        private ModbusIpMaster master { get; set; }
        public List<Device> Devices { get; set; }
        public PollingTimer pollingTimer;
        public event EventHandler CannotConnectToDevice;
        public event EventHandler CommunicationEstablished;
        public event EventHandler BinaryValueRead;

        public ModbusServer(string _ipAddress, int _portNumber)
        {
            IpAddress = _ipAddress;
            PortNumber = _portNumber;
        }

        public ModbusServer(string _ipAddress)
        {
            IpAddress = _ipAddress;
            PortNumber = 502;
        }

        public TcpClient Client
        {
            get { return client; }
        }

        #region Events
        public void OnCannotConnectToServer()
        {
            if(CannotConnectToDevice != null)
            {
                CannotConnectToDevice(this, EventArgs.Empty);
            }
        }

        public void OnCommunicationStarted()
        {
            if (CommunicationEstablished != null)
            {
                CommunicationEstablished(this, EventArgs.Empty);
            }

            if (Devices != null)
            {
                Log.Instance.Error("ModbusServer üzerinde haberleşilecek cihaz bulunamadı.");
                throw new Exception("ModbusServer Hata: Device bulunamadı");
            }
            else
            {

                foreach (Device d in Devices)
                {
                    d.BinarySignals = d.BinarySignals.OrderBy(b => b.Address).ToList(); //(from b in d.BinarySignals orderby b.Address ascending select b).ToList();
                    d.AnalogSignals = d.AnalogSignals.OrderBy(a => a.Address).ToList();
                }

            }

            // ModbusServer için daha önce timer olusturulmamışsa sinyalleri okumak icin timer olusturuluyor.
            if (pollingTimer != null)
            {
                pollingTimer = new PollingTimer(PollingTime);
                pollingTimer.hostAddress = IpAddress;
                pollingTimer.Elapsed += ReadValuesFromServer;
                pollingTimer.AutoReset = true;
                pollingTimer.Enabled = true;
            }
        }

        public void OnBinaryValueRead()
        {
            if (BinaryValueRead != null)
            {
                BinaryValueRead(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Private Methods
        public void startCommunication(int _retryNumber, int _readTimeOut, int _pollingTime )
        {
            RetryNumber = _retryNumber;
            ReadTimeOut = _readTimeOut;
            PollingTime = _pollingTime;
            IsConnected = false;
            try
            {
                // Server ile TCP baglantısı olusturuluyor
                TcpClient tcpClient = new TcpClient();
                IAsyncResult asyncResult = tcpClient.BeginConnect(IpAddress, PortNumber, null, null);
                asyncResult.AsyncWaitHandle.WaitOne(3000, true); // 3 saniye içerisinde bağlantının kurulması bekleniyor.
                // 3 saniye içerisinde TCP baglantısı kurulamazsa
                if (!asyncResult.IsCompleted)
                {
                    tcpClient.Close();
                    OnCannotConnectToServer();
                    IsConnected = false;
                    throw new Exception(String.Format("Driver baglantı hatası: {0} ip adresi ile bağlantı kurulamadı", IpAddress));   
                }
                else
                {
                    // TCP baglantısı kurulduktan sonra _ipAddress için modbus baglantısı olusturuluyor
                    master = ModbusIpMaster.CreateIp(tcpClient);
                    master.Transport.Retries = RetryNumber;
                    master.Transport.ReadTimeout = ReadTimeOut;
                    IsConnected = true;
                    Log.Instance.Info("{0} ip adresi ile bağlantı kuruldu", IpAddress);
                    OnCommunicationStarted();
                }
            }
            catch (Exception e)
            {
                Log.Instance.Fatal("Driver baglantı hatası: " + e.Message);
                OnCannotConnectToServer();
                IsConnected = false;
            }
        }

        private void ReadValuesFromServer()
        {
            pollingTimer.Enabled = false;
            List<BinarySignal> buffer = new List<BinarySignal>();
            bool[] values = { };
            foreach (Device d in Devices)
            {
                buffer.Clear();
                buffer.Add(d.BinarySignals[0]);
                for (int i =1; i < d.BinarySignals.Count-1; i++)
                {
                    if(d.BinarySignals[i-1].Address == d.BinarySignals[i].Address-1)
                    {
                        buffer.Add(d.BinarySignals[i]);
                    }
                    else
                    {
                        if (buffer[0].Address.ToString().StartsWith("0"))
                        {
                            values = master.ReadCoils(Convert.ToByte(d.SlaveID), Convert.ToUInt16(buffer[0].Address), Convert.ToUInt16(buffer.Count));  
                        }
                        else if(buffer[0].Address.ToString().StartsWith("1"))
                        {
                            values = master.ReadInputs(Convert.ToByte(d.SlaveID), Convert.ToUInt16(buffer[0].Address), Convert.ToUInt16(buffer.Count));
                        }
                        else
                        {
                            buffer.Clear();
                            throw new Exception("ModbusServer Hata: Yanlış tanımlanan adres bulundu.");
                        }

                        for (int k = 0; k < values.Length; k++)
                        {
                            d.BinarySignals[i - k].CurrentValue = values[values.Length - k - 1];
                            d.BinarySignals[i - k].TimeTag = DateTime.Now.ToString();
                            // TODO: Database'e kayıt için buffer dondurulebilir.
                            OnBinaryValueRead();
                        }
                        buffer.Clear();
                        values = null;
                        buffer.Add(d.BinarySignals[i]);
                    }

                    if (buffer[0].Address.ToString().StartsWith("0"))
                    {
                        values = master.ReadCoils(Convert.ToByte(d.SlaveID), Convert.ToUInt16(buffer[0].Address), Convert.ToUInt16(buffer.Count));
                    }
                    else if (buffer[0].Address.ToString().StartsWith("1"))
                    {
                        values = master.ReadInputs(Convert.ToByte(d.SlaveID), Convert.ToUInt16(buffer[0].Address), Convert.ToUInt16(buffer.Count));
                    }
                    else
                    {
                        buffer.Clear();
                        throw new Exception("ModbusServer Hata: Yanlış tanımlanan adres bulundu.");
                    }

                    for (int k = 0; k < values.Length; k++)
                    {
                        d.BinarySignals[i - k].CurrentValue = values[values.Length - k - 1];
                        d.BinarySignals[i - k].TimeTag = DateTime.Now.ToString();
                        // TODO: Database'e kayıt için buffer dondurulebilir.
                        OnBinaryValueRead();
                    }
                }

            }
        } 
       
        #endregion
    }
}
