using EnMon_Driver_Manager.Models;
using MaterialSkin.Controls;
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
    public partial class frm_ChangeGroupName : Form
    {
       public frm_ChangeGroupName()
        {
            InitializeComponent();
        }

        public frm_ChangeGroupName(MailGroup _mailGroup)
        {
            InitializeComponent();
            txtBox_OldName.Text = _mailGroup.Name;
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {

        }

        private void btn_ChangeGroupName_Click(object sender, EventArgs e)
        {
            if(txtbox_NewName.Text != null)
            {
                this.DialogResult = DialogResult.OK;
                OnClickedChangeGroupNameButton();
                this.Close();
            }
        }

        public ChangeGroupNameEventHandler ClickedChangeGroupNameButton;

        private void OnClickedChangeGroupNameButton()
        {
            ChangeGroupNameEventArgs args = new ChangeGroupNameEventArgs();
            args.Name = txtbox_NewName.Text;

            if (ClickedChangeGroupNameButton != null)
            {
                ClickedChangeGroupNameButton(this, args);
            }
        }
    }
}

public class ChangeGroupNameEventArgs : EventArgs
{
    public string Name { get; set; }

}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ChangeGroupNameEventHandler'
public delegate void ChangeGroupNameEventHandler(object source, ChangeGroupNameEventArgs e);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ChangeGroupNameEventHandler'