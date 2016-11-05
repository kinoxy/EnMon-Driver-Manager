using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Modbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_Devices'
    public partial class frm_Devices : Form
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_Devices'
    {
#pragma warning restore CS0169 // The field 'frm_Devices._driver' is never used
        private AbstractDBHelper DBHelper_Devices;
        private List<Station> stations;
        private int index;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_Devices.frm_Devices()'
        public frm_Devices()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_Devices.frm_Devices()'
        {
            InitializeComponent();
            index = 0;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_Devices.timer'
        public Timer timer;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_Devices.timer'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_Devices.AddDevicesToForm()'
        public async void AddDevicesToForm()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_Devices.AddDevicesToForm()'
        {
            try
            {
                stations = DBHelper_Devices.GetAllStationsInfoWithDeviceInfo();

                
                if (stations.Count > 0)
                {
                    Task t1 = Task.Factory.StartNew(AddDeviceInfoControl);
                    await t1;

                    // 2sn de bir cihazların haberleşme durumunu kontrol etmek için timer çalıştırılır.
                    timer_Loop2Seconds.Start();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}.{1} => {2}", this.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                throw;
            }
        }

        private void AddDeviceInfoControl()
        {
            foreach (Station s in stations)
            {
                foreach (Device d in s.Devices)
                {
                    DeviceInfo deviceInfo = new DeviceInfo();
                    deviceInfo.lbl_StationName.Text = s.Name;
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
                    deviceInfo.FontColor = Color.WhiteSmoke;
                    deviceInfo.BackColor = Color.SteelBlue;
                    deviceInfo.SwitchButtonStateChanged += DeviceInfo_SwitchButtonStateChanged;
                    //control.Invoke((MethodInvoker)(() => control.Text = "new text"));
                    this.Invoke((MethodInvoker)(() => this.Controls.Add(deviceInfo))); //.Controls.Add(deviceInfo);
                } 
            }
        }

        private void DeviceInfo_SwitchButtonStateChanged(object sender, EventArgs e)
        {
            DeviceInfo _deviceInfo = (DeviceInfo)sender;
            OnStateChanged(_deviceInfo.DeviceId, _deviceInfo.switchButton_DeviceIsActive.GetState());
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_Devices.StateChanged'
        public frm_DevicesEventHandler StateChanged;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_Devices.StateChanged'

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

        private async void CheckConnectionStatusOfDevices(object sender, EventArgs e)
        {
            timer_Loop2Seconds.Stop();

            Task t1 = Task.Factory.StartNew(UpdateDeviceStatuses);
            await t1;
            
            timer_Loop2Seconds.Start();
        }

        private void UpdateDeviceStatuses()
        {
            try
            {
                stations = DBHelper_Devices.GetAllStationsInfoWithDeviceInfo();
                foreach (Control c in Controls)
                {
                    if (c is DeviceInfo)
                    {

                        if (stations.Where((s) => (s.Devices.Any((d) => d.ID == (c as DeviceInfo).DeviceId))).First().Devices.Find((d) => d.ID == (c as DeviceInfo).DeviceId).Connected)
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
            catch (Exception ex)
            {
                Log.Instance.Error("{0}.{1} => {2}", this.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                throw;
            }
        }

        private void frm_Devices_Load(object sender, EventArgs e)
        {
            DBHelper_Devices = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            AddDevicesToForm();
        }        
    }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_DevicesEventHandler'
    public delegate void frm_DevicesEventHandler(object source, frm_DevicesEventArgs args);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_DevicesEventHandler'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_DevicesEventArgs'
    public class frm_DevicesEventArgs : EventArgs
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_DevicesEventArgs'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_DevicesEventArgs.state'
        public bool state { get; internal set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_DevicesEventArgs.state'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_DevicesEventArgs.deviceId'
        public ushort deviceId { get; internal set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_DevicesEventArgs.deviceId'
    }
}
