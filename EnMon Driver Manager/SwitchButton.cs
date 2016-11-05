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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton'
    public partial class SwitchButton : UserControl
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton'
    {
        private bool state;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton.SwitchButton()'
        public SwitchButton()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton.SwitchButton()'
        {
            InitializeComponent();
            state = false;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton.pictureBox1_MouseClick(object, MouseEventArgs)'
        public void pictureBox1_MouseClick(object sender, MouseEventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton.pictureBox1_MouseClick(object, MouseEventArgs)'
        {
            if(state != true)
            {
                pictureBox1.Image = Properties.Resources.switchbutton_on;
                state = true;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.switchbutton_off___Kopya;
                state = false;
            }
            OnClick();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton.Click'
        public event SwitchButtonEventHandler Click;
#pragma warning disable CS0108 // 'SwitchButton.Click' hides inherited member 'Control.Click'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton.Click'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton.OnClick()'
        public void OnClick()
#pragma warning restore CS0108 // 'SwitchButton.Click' hides inherited member 'Control.Click'. Use the new keyword if hiding was intended.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton.OnClick()'
        {
            if(Click!= null)
            {
                Click(this, EventArgs.Empty);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton.SetState(bool)'
        public void SetState(bool _state)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton.SetState(bool)'
        {
            if(_state)
            {
                pictureBox1.Image = Properties.Resources.switchbutton_on;
                state = true;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.switchbutton_off___Kopya;
                state = false;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton.GetState()'
        public bool GetState()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SwitchButton.GetState()'
        {
            return state;
        }      
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SwitchButtonEventHandler'
    public delegate void SwitchButtonEventHandler(object source, EventArgs e);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SwitchButtonEventHandler'
}
