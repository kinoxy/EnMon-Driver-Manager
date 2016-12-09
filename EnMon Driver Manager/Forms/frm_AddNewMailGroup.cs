using EnMon_Driver_Manager.Models;
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
    public partial class frm_AddNewMailGroup : Form
    {
        #region Private Properties

        private uint ID;
        #endregion

        #region Constructors

        public frm_AddNewMailGroup()
        {
            InitializeComponent();
        }

        public frm_AddNewMailGroup(uint ID)
        {
            InitializeComponent();

            this.ID = ID;
        }

        #endregion

        #region Events

        #endregion

        #region Public Methods

        #endregion

        #region Public Methods

        public event AddEmailGroup addEmailGroup;

        #endregion

        #region Private Methods

        private void OnAddEmailGroup(MailGroup _mailGroup)
        {
            frm_AddNewMailGroupArgs args = new frm_AddNewMailGroupArgs();
            args.mailgroup = _mailGroup;
            if(addEmailGroup != null)
            {
                addEmailGroup(this, args);
            }
            this.Close();
        }

        #endregion


        private void btn_OK_Click(object sender, EventArgs e)
        {
           
            
            if(VerifyFormInputs())
            {
                MailGroup mailGroup = GetValuesFromFormControls();
                if (mailGroup != null)
                {
                    OnAddEmailGroup(mailGroup);
                }

            }
            
            
        }

        private bool VerifyFormInputs()
        {
            TrimAllInputFields();
            uint ID;
            if(!(uint.TryParse(txt_MailGroupID.Text, out ID)))
            {
                MessageBox.Show("Geçerli bir ID numarası giriniz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txt_MailGroupName.Text == string.Empty)
            {
                MessageBox.Show("E-Posta Grup Adı bilgisi için geçerli bir isim giriniz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void TrimAllInputFields()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Text.Trim();
                }
            }
        }

        private MailGroup GetValuesFromFormControls()
        {
            MailGroup mailGroup = new MailGroup();
            mailGroup.ID = uint.Parse((txt_MailGroupID.Text));
            mailGroup.Name = txt_MailGroupName.Text;
            return mailGroup;
        }

        private void frm_AddNewMailGroup_Load(object sender, EventArgs e)
        {
            txt_MailGroupID.Text = ID.ToString();
            txt_MailGroupID.Enabled = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public delegate void AddEmailGroup(object source, frm_AddNewMailGroupArgs args);

    public class frm_AddNewMailGroupArgs : EventArgs
    {
        public MailGroup mailgroup;
    }
}
