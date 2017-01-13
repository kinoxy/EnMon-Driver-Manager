using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnMon_Driver_Manager
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo'
    public partial class DeviceInfo : UserControl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo'
    {
#pragma warning disable CS0649 // Field 'DeviceInfo.fontcolor' is never assigned to, and will always have its default value
        private Color fontcolor;
#pragma warning restore CS0649 // Field 'DeviceInfo.fontcolor' is never assigned to, and will always have its default value
        private bool connectionStatus;
#pragma warning disable CS0649 // Field 'DeviceInfo.userbackgroundcolor' is never assigned to, and will always have its default value
        private Color userbackgroundcolor;
#pragma warning restore CS0649 // Field 'DeviceInfo.userbackgroundcolor' is never assigned to, and will always have its default value

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo.FontColor'
        public Color FontColor
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo.FontColor'
        {
            get
            {
                return fontcolor;
            }

            set
            {
                lbl_DeviceName.ForeColor = value;
                lbl_StationName.ForeColor = value;
                lbl_ID.ForeColor = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo.isConnected'
        public bool isConnected
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo.isConnected'
        {
            get
            {
                return connectionStatus;
            }

            set
            {
                if(value)
                {
                    pictureBox_ConnectionStatus.Image = Properties.Resources.green;
                }
                else
                {
                    pictureBox_ConnectionStatus.Image = Properties.Resources.red;
                }

                connectionStatus = value;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo.UserControlBackColor'
        public Color UserControlBackColor
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo.UserControlBackColor'
        {
            get
            {
                return userbackgroundcolor;
            }
            set
            {
                BackColor = value;
            }

        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo.DeviceId'
        public ushort DeviceId { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo.DeviceId'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo.DeviceInfo()'
        public DeviceInfo()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo.DeviceInfo()'
        {
            InitializeComponent();
            connectionStatus = false;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo.SwitchButtonStateChanged'
        public event DeviceEventHandler SwitchButtonStateChanged;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfo.SwitchButtonStateChanged'

        private void OnSwitchButtonStateChanged(bool _state)
        {
            DeviceInfoEventArgs args = new DeviceInfoEventArgs();
            args.state = _state;
            if(SwitchButtonStateChanged != null)
            {
                SwitchButtonStateChanged(this, args);
            }
        }

        private void SwitchButton_DeviceIsActive_Click(object sender, EventArgs e)
        {
            OnSwitchButtonStateChanged(switchButton_DeviceIsActive.GetState());
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeviceEventHandler'
    public delegate void DeviceEventHandler(object source, DeviceInfoEventArgs args);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeviceEventHandler'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfoEventArgs'
    public class DeviceInfoEventArgs : EventArgs
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfoEventArgs'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfoEventArgs.state'
        public bool state { get; internal set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeviceInfoEventArgs.state'
    }
}
