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
    public partial class SwitchButton : UserControl
    {
        private bool state;
        public SwitchButton()
        {
            InitializeComponent();
            state = false;
        }

        public void pictureBox1_MouseClick(object sender, MouseEventArgs e)
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

        public event SwitchButtonEventHandler Click;

        public void OnClick()
        {
            if(Click!= null)
            {
                Click(this, EventArgs.Empty);
            }
        }

        public void SetState(bool _state)
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

        public bool GetState()
        {
            return state;
        }      
    }

    public delegate void SwitchButtonEventHandler(object source, EventArgs e);
}
