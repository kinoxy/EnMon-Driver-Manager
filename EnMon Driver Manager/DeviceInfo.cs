using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager
{
    public partial class DeviceInfo : UserControl
    {
        private Color fontcolor;
        private Color userbackgroundcolor;
        public Color FontColor
        {
            get
            {
                return fontcolor;
            }

            set
            {
                lbl_DeviceName.ForeColor = value;
                lbl_StationName.ForeColor = value;
                lbl_SlaveId.ForeColor = value;
            }
        }

        public Color UserControlBackColor
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
        public ushort DeviceId { get; set; }
        public DeviceInfo()
        {
            InitializeComponent();
        }

        public event DeviceEventHandler SwitchButtonStateChanged;

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

    public delegate void DeviceEventHandler(object source, DeviceInfoEventArgs args);

    public class DeviceInfoEventArgs : EventArgs
    {
        public bool state { get; internal set; }
    }
}
