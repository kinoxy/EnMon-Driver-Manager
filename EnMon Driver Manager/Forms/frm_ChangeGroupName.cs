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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_ChangeGroupName'
    public partial class frm_ChangeGroupName : MaterialForm
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_ChangeGroupName'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_ChangeGroupName.frm_ChangeGroupName()'
        public frm_ChangeGroupName()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_ChangeGroupName.frm_ChangeGroupName()'
        {
            InitializeComponent();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_ChangeGroupName.frm_ChangeGroupName(MailGroup)'
        public frm_ChangeGroupName(MailGroup _mailGroup)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_ChangeGroupName.frm_ChangeGroupName(MailGroup)'
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_ChangeGroupName.ClickedChangeGroupNameButton'
        public ChangeGroupNameEventHandler ClickedChangeGroupNameButton;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_ChangeGroupName.ClickedChangeGroupNameButton'

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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ChangeGroupNameEventArgs'
public class ChangeGroupNameEventArgs : EventArgs
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ChangeGroupNameEventArgs'
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ChangeGroupNameEventArgs.Name'
    public string Name { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ChangeGroupNameEventArgs.Name'

}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ChangeGroupNameEventHandler'
public delegate void ChangeGroupNameEventHandler(object source, ChangeGroupNameEventArgs e);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ChangeGroupNameEventHandler'