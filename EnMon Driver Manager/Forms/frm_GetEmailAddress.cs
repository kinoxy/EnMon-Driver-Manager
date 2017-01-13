using System;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Forms
{
    public partial class frm_GetEmailAddress : Form
    {
        public frm_GetEmailAddress()
        {
            InitializeComponent();
        }

        public Send frm_GetEmailAddress_Send;
        private void btn_OK_Click(object sender, EventArgs e)
        {
            OnSend();
        }

        private void OnSend()
        {
            frm_GetEmailAddressArgs args = new frm_GetEmailAddressArgs();
            args.EMailAddress = textBox1.Text;
            if(frm_GetEmailAddress_Send != null)
            {
                frm_GetEmailAddress_Send(this, args);
            }
        }
    }

    public delegate void Send(object source, frm_GetEmailAddressArgs args);

    public class frm_GetEmailAddressArgs : EventArgs
    {
        public string EMailAddress;
    }
}
