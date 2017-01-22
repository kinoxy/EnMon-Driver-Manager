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
    public partial class frm_GetDatabaseConnectionProperties : Form
    {
        public frm_GetDatabaseConnectionProperties()
        {
            InitializeComponent();
            cbx_DatabaseType.Items.Add("MySQL");
        }

        public frm_GetDatabaseConnectionProperties(string databaseType, string databaseName, string serverAddress, string userName, string password) : this()
        {
            cbx_DatabaseType.SelectedText = databaseType;
            txt_DatabaseName.Text = databaseName;
            txt_ServerAddress.Text = serverAddress;
            txt_DatabaseUserName.Text = userName;
            txt_DatabaseUserPassword.Text = password;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (VerifyInputsAtFormControls())
            {
                OnFormSubmitted();
            }
        }

        private void OnFormSubmitted()
        {
            frm_GetDatabaseConnectionPropertiesEventArgs args = new frm_GetDatabaseConnectionPropertiesEventArgs()
            {
                DataBaseType = cbx_DatabaseType.SelectedItem.ToString(),
                ServerAddress = txt_ServerAddress.Text,
                DatabaseName = txt_DatabaseName.Text,
                UserName = txt_DatabaseUserName.Text,
                Password = txt_DatabaseUserPassword.Text
            };

            if(FormSubmitted != null)
            {
                FormSubmitted(this, args);
            }
        }

        private bool VerifyInputsAtFormControls()
        {
            // Kullanıcı veri girerken text'ten sonra boşluk bıraktıysa bu boşluklar silinir.
            TrimAllInputFields();

            if (cbx_DatabaseType.SelectedItem == null)
            {
                MessageBox.Show("Veritabanı tipi bilgisi boş bırakılamaz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_DatabaseType.Focus();
                return false;
            }
            if (txt_ServerAddress.Text == string.Empty)
            {
                MessageBox.Show("Server adres bilgisi boş bırakılamaz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ServerAddress.Focus();
                return false;
            }
            if (txt_DatabaseName == null)
            {
                MessageBox.Show("Veritabanı Adı bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DatabaseName.Focus();
                return false;
            }
            if (txt_DatabaseUserName.Text ==  string.Empty)
            {
                MessageBox.Show("Veritabanı kullanıcı bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DatabaseUserName.Focus();
                return false;
            }
            if (txt_DatabaseUserPassword.Text == string.Empty)
            {
                MessageBox.Show("Veritabanı kullanıcı şifre bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DatabaseUserPassword.Focus();
                return false;
            }
            if (txt_DatabaseUserPasswordConfirmation.Text == string.Empty)
            {
                MessageBox.Show("Veritabanı kullanıcı şifre tekrar bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DatabaseUserPasswordConfirmation.Focus();
                return false;
            }
            if(txt_DatabaseUserPassword.Text != txt_DatabaseUserPasswordConfirmation.Text)
            {
                MessageBox.Show("Girilen şifreler aynı değil. Şifre bilgilerini kontrol ediniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_DatabaseUserPassword.Focus();
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

        public frm_GetDatabaseConnectionPropertiesEventHandler FormSubmitted;
        private string databaseType;
        private string databaseName;
        private string serverAddress;
        private string userName;
        private string password;
    }

    public class frm_GetDatabaseConnectionPropertiesEventArgs : EventArgs
    {

        public string DataBaseType { get; internal set; }

        public string ServerAddress { get; internal set; }

        public string DatabaseName { get; internal set; }

        public string UserName{ get; internal set; }

        public string Password { get; internal set; }
    }

    public delegate void frm_GetDatabaseConnectionPropertiesEventHandler(object source, frm_GetDatabaseConnectionPropertiesEventArgs e);
}
