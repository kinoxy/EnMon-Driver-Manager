using EnMon_Driver_Manager.Modbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager
{
    public partial class frm_Devices : Form
    {
        private AbstractDriver driver;
        public frm_Devices()
        {
            InitializeComponent();
        }

        public void addDeviceInfo(AbstractDriver _driver)
        {
            int index = 0;
            driver = _driver;
            if (_driver.Devices.Count>0)
            {
                foreach (Device d in _driver.Devices)
                {
                    DeviceInfo deviceInfo = new DeviceInfo();
                    deviceInfo.lbl_StationName.Text = _driver.Stations.Where(s => s.ID == d.StationID).First().Name;
                    deviceInfo.lbl_DeviceName.Text = d.Name;
                    deviceInfo.lbl_SlaveId.Text = d.SlaveID.ToString();
                    deviceInfo.switchButton_DeviceIsActive.SetState(d.isActive);
                    if (!d.Connected)
                    {
                        deviceInfo.pictureBox_ConnectionStatus.Image = Properties.Resources.red;
                    }
                    deviceInfo.DeviceId = d.ID;
                    //deviceInfo.switchButton_DeviceIsActive.Click += this.DeviceInfo_SwitchButtonStateChanged;
                    // deviceInfo.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Top|AnchorStyles.Right);
                    deviceInfo.Location = new Point(0, 0);
                    deviceInfo.Name = "deviceInfo" + index.ToString();
                    deviceInfo.Size = new Size(402, 40);
                    deviceInfo.Dock = DockStyle.Top;
                    deviceInfo.FontColor = Color.FromArgb(153, 147, 145);
                    deviceInfo.BackColor = Color.FromArgb(42, 45, 55);
                    deviceInfo.SwitchButtonStateChanged += DeviceInfo_SwitchButtonStateChanged;
                    
                    this.Controls.Add(deviceInfo);
                }

                timer_Loop2Seconds.Enabled = true;
            }
        }

        private void DeviceInfo_SwitchButtonStateChanged(object sender, EventArgs e)
        {
            
            DeviceInfo _deviceInfo = (DeviceInfo)sender;
            OnStateChanged(_deviceInfo.DeviceId, _deviceInfo.switchButton_DeviceIsActive.GetState());
        }

        public frm_DevicesEventHandler StateChanged;

        private void OnStateChanged(ushort _deviceID, bool _state)
        {
            frm_DevicesEventArgs args = new frm_DevicesEventArgs();
            args.state = _state;
            args.deviceId = _deviceID;
            if(StateChanged != null)
            {
                StateChanged(this, args);
            }
        }

        private void CheckConnectionStatusOfDevices(object sender, EventArgs e)
        {
            foreach(Control c in Controls)
            {
                if(c is DeviceInfo)
                {
                    if(driver.Devices.Where(d => d.ID == (c as DeviceInfo).DeviceId).First().Connected)
                    {
                        (c as DeviceInfo).pictureBox_ConnectionStatus.Image = Properties.Resources.green;
                    }
                    else
                    {
                        (c as DeviceInfo).pictureBox_ConnectionStatus.Image = Properties.Resources.red;
                    }
                }
            }
        }
    }
    public delegate void frm_DevicesEventHandler(object source, frm_DevicesEventArgs args);
    public class frm_DevicesEventArgs : EventArgs
    {
        public bool state { get; internal set; }
        public ushort deviceId { get; internal set; }
    }
}
