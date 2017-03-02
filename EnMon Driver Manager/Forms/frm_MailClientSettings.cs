using EnMon_Driver_Manager.Drivers.Mail;
using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Forms
{
    public partial class frm_MailClientSettings : Form
    {
        public string EMailAddressForTestMail;

        public frm_MailClientSettings()
        {
            InitializeComponent();
        }

        private void btn_SendTestMail_Click(object sender, EventArgs e)
        {
            EMailAddressForTestMail = "";
            frm_GetEmailAddress Frm_GetEmailAddress = new frm_GetEmailAddress();
            Frm_GetEmailAddress.frm_GetEmailAddress_Send += SendTestEMail;
            Frm_GetEmailAddress.ShowDialog();

        }

        private void ShowMailClientSettings()
        {
            if (File.Exists(Constants.MailClientConfigFileLocation))
            {
                string _mailServerName = string.Empty;
                string _mailServerPort = string.Empty;
                string _userName = string.Empty;
                string _password = string.Empty;

                var parser = new FileIniDataParser();

                IniData data = parser.ReadFile(Constants.MailClientConfigFileLocation, Encoding.UTF8);

                var _parameters = data["MailClient Parameters"];

                foreach (KeyData kd in _parameters)
                {
                    switch (kd.KeyName.Trim())
                    {
                        case "MailServerName":
                            txt_MailServerName.Text = kd.Value.Trim();
                            break;

                        case "MailServerPort":
                            txt_MailServerPort.Text = kd.Value.Trim();
                            break;

                        case "UserName":
                            txt_UserName.Text = kd.Value.Trim();
                            break;

                        case "Password":
                            txt_Password.Text = kd.Value.Trim();
                            break;
                        case "MailAddress":
                            txt_From.Text = kd.Value.Trim();
                            break;
                        case "EnableSSL":
                            cbx_UseSSL.Checked = kd.Value.Trim() == "TRUE" ? true : false;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("MailClient config dosyası okunamadı", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SendTestEMail(object source, frm_GetEmailAddressArgs args)
        {
            if (VerifyMailSettingInputsAreCorrect())
            {
                MailClient client = new MailClient(txt_MailServerName.Text, txt_MailServerPort.Text, txt_UserName.Text, txt_Password.Text, txt_From.Text, cbx_UseSSL.Checked);

                string message = @"Bu bir deneme mesajıdır.";

                List<string> _toWhoList = new List<string>();
                _toWhoList.Add(args.EMailAddress);

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    await client.SendMailAsync(_toWhoList, message);
                    MessageBox.Show("E-posta gönderimi başarılı", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Test E-postası gönderilemedi.\nAyrıntılı bilgi için log dosyasına bakınız.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Instance.Error("Mail Server'a baglanırken hata : {0}", ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }

        }

        private bool VerifyMailSettingInputsAreCorrect()
        {
            int portnumber = 0;
            if (txt_MailServerName.Text == null)
            {
                MessageBox.Show("Sunucu Adresi bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txt_MailServerPort.Text == null)
            {
                MessageBox.Show("Port Numarası bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!(int.TryParse(txt_MailServerPort.Text, out portnumber)))
            {
                MessageBox.Show("Geçerli bir port numarası giriniz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txt_UserName.Text == null || txt_UserName.Text == string.Empty)
            {
                MessageBox.Show("Kullanıcı Adı bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txt_Password.Text == null || txt_Password.Text == string.Empty)
            {
                MessageBox.Show("Şifre bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {

                //OnMailClientSettingsUpdateRequested(txt_MailServerName.Text, txt_MailServerPort.Text, txt_UserName.Text, txt_Password.Text);
                if (UpdateMailClientSettings(txt_MailServerName.Text, txt_MailServerPort.Text, txt_UserName.Text, txt_Password.Text, txt_From.Text, cbx_UseSSL.Checked))
                {
                    MessageBox.Show("Ayarlar başarılı bir şekilde güncellendi", Constants.MessageBoxHeader, MessageBoxButtons.OK);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ayarlar güncellenemedi. Ayrıntılı bilgi için log dosyasına bakınız", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.Error("E_Posta ayarları güncellenemedi => {0}", ex.Message);
            }
        }

        private bool UpdateMailClientSettings(string _mailServerName, string _mailServerPort, string _userName, string _password, string _fromMailAddress, bool _enableSSL)
        {
            try
            {
                if (File.Exists(Constants.MailClientConfigFileLocation))
                {
                    var parser = new FileIniDataParser();
                    IniData data = parser.ReadFile(Constants.MailClientConfigFileLocation);

                    data["MailClient Parameters"]["MailServerName"] = _mailServerName;
                    data["MailClient Parameters"]["MailServerPort"] = _mailServerPort;
                    data["MailClient Parameters"]["UserName"] = _userName;
                    data["MailClient Parameters"]["Password"] = _password;
                    data["MailClient Parameters"]["MailAddress"] = _fromMailAddress;
                    data["MailClient Parameters"]["EnableSLL"] = _enableSSL.ToString().ToUpper();
                    parser.WriteFile(Constants.MailClientConfigFileLocation, data);

                    return true;
                }
                else
                {

                    MessageBox.Show("E-Posta Konfigurasyon dosyası bulunamadı", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Instance.Warn("E-Posta ayarlarını guncellerken {0} dosya konumunda -eposta konfigurasyon dosyası bulunamadı", Constants.MailClientConfigFileLocation);
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frm_MailClientSettings_Load(object sender, EventArgs e)
        {
            ShowMailClientSettings();
        }
    }
}
