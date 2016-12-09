using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Forms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void txt_ModbusTCPConfigFileLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch(treeView1.SelectedNode.Name)
            {
                case "Node_EmailGroups":
                    Load_frm_MailGroups();
                    break;
                default:
                    break;
            }
        }

        private void Load_frm_MailGroups()
        {
            frm_Email frm_email = new frm_Email();
            frm_email.FormBorderStyle = FormBorderStyle.None;
            frm_email.Dock = DockStyle.Fill;
            frm_email.TopLevel = false;
            frm_email.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_email);
            frm_email.Visible = true;
        }
    }
}
