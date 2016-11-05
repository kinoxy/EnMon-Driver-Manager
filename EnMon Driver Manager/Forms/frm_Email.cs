using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Drivers.Mail;
using EnMon_Driver_Manager.Models;
using IniParser;
using IniParser.Model;
using MimeKit;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace EnMon_Driver_Manager
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_Email'
    public partial class frm_Email : Form
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_Email'
    {
        private DataTable dt_MailGroups { get; set; } 

        private AbstractDBHelper DBHelper_EmailSettings;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_Email.frm_Email()'
        public frm_Email()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_Email.frm_Email()'
        {
            InitializeComponent();
        }

        private void btn_ChangeGroupName_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                using (frm_ChangeGroupName frm_changeGroupName = new frm_ChangeGroupName((MailGroup)comboBox1.SelectedItem))
                {
                    frm_changeGroupName.ClickedChangeGroupNameButton += frm_changeGroupName_ClickedChangeGroupName;
                    DialogResult result = frm_changeGroupName.ShowDialog();
                }
            }
        }

        private void frm_changeGroupName_ClickedChangeGroupName(object source, ChangeGroupNameEventArgs e)
        {
            try
            {
                string newName = e.Name;
                if (DBHelper_EmailSettings.UpdateGroupName((MailGroup)comboBox1.SelectedItem, newName))
                {
                    MessageBox.Show("Grup Adı değiştirildi", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Log.Instance.Info("{0} mail grubunun adı {1} olarak değiştirildi", ((MailGroup)comboBox1.SelectedItem).Name, e.Name);
                    RefreshMailGroupBox();
                }
                else
                {
                    MessageBox.Show("Grup Adı değiştirilemedi", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                Log.Instance.Error("Grup Adı değiştirilemedi: => {0}", ex.Message);
            }
        }

        private void RefreshMailGroupBox()
        {
            comboBox1.SelectedItem = null;
            lstBox_UsersAddedToGroup.Items.Clear();
            lstBox_UsersNotAddedToGroup.Items.Clear();
            comboBox1.Items.Clear();
            AddMailGroupsToComboBox();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                
                //OnMailClientSettingsUpdateRequested(txt_MailServerName.Text, txt_MailServerPort.Text, txt_UserName.Text, txt_Password.Text);
                if (UpdateMailClientSettings(txt_MailServerName.Text, txt_MailServerPort.Text, txt_UserName.Text, txt_Password.Text) & UpdateAlarmGroups() & AddMailGroupsToComboBox())
                    {
                    MessageBox.Show("Ayarlar başarılı bir şekilde güncellendi", Constants.MessageBoxHeader, MessageBoxButtons.OK);
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ayarlar güncellenemedi. Ayrıntılı bilgi için log dosyasına bakınız", Constants.MessageBoxHeader, MessageBoxButtons.OK,MessageBoxIcon.Error);
                Log.Instance.Error("E_Posta ayarları güncellenemedi => {0}", ex.Message);
            }
        }
        private void OnMailClientSettingsUpdateRequested(string _MailServerName, string _MailServerPort, string _UserName, string _Password)
        {
            EmailSettingsEventArgs args = new EmailSettingsEventArgs();

            args.MailServerName = _MailServerName;
            args.MailServerPort = _MailServerPort;
            args.Username = _UserName;
            args.Password = _Password;

            if (MailClientSettingsUpdateRequested != null)
            {
                MailClientSettingsUpdateRequested(this, args);
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_Email.MailClientSettingsUpdateRequested'
        public EmailSettingsEventHandler MailClientSettingsUpdateRequested;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_Email.MailClientSettingsUpdateRequested'


        private bool UpdateAlarmGroups()
        {
            try
            {
                MailGroup mg = (MailGroup)comboBox1.SelectedItem;
                foreach (var item in lstBox_UsersNotAddedToGroup.Items)
                {
                    DBHelper_EmailSettings.UpdateUserMailGroup(((User)item).ID, 1);
                }
                foreach (var item in lstBox_UsersAddedToGroup.Items)
                {
                    DBHelper_EmailSettings.UpdateUserMailGroup(((User)item).ID, mg.ID);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
 

        private bool UpdateMailClientSettings(string _mailServerName, string _mailServerPort, string _userName, string _password)
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
            catch (Exception)
            {

                throw;
            }

        }

        private void GetMailClientSettings(string _configFileLocation)
        {
            if (File.Exists(_configFileLocation))
            {
                var parser = new FileIniDataParser();

                IniData iniFile = parser.ReadFile(_configFileLocation);
                iniFile.Sections["MailClient Parameters"]["MailServerName"] = txt_MailServerName.Text;
                iniFile.Sections["MailClient Parameters"]["MailServerPort"] = txt_MailServerPort.Text;
                iniFile.Sections["MailClient Parameters"]["UserName"] = txt_UserName.Text;
                iniFile.Sections["MailClient Parameters"]["Password"] = txt_Password.Text;
                parser.WriteFile(_configFileLocation, iniFile, Encoding.Default);

            }
        }

        private void btn_NewGroup_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Items.Count == 0)
                {
                    AddMailGroupsToComboBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database'den e-posta grup bilgileri çekilirken hata oluştu", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.Error("Database'den mail grup bilgileri çekilirken hata oluştu => {0} ", ex.Message);
            }
        }

        private bool AddMailGroupsToComboBox()
        {
            List<MailGroup> mailGroups;
            try
            {
                
                mailGroups = DBHelper_EmailSettings.GetMailGroups();
                if (mailGroups.Count > 1)
                {
                    comboBox1.Items.Clear();
                    mailGroups.Remove(mailGroups.Where((mg) => mg.Name == "No Group").First());
                    foreach (MailGroup mg in mailGroups)
                    {
                        comboBox1.Items.Add(mg);
                    }
                    return true;
                }
                else
                {
                    Log.Instance.Info("Database'de kayıtlı mail grubu bulunamadı");
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void frm_Email_Load(object sender, EventArgs e)
        {
            Task t1 = Task.Factory.StartNew(() => DBHelper_EmailSettings = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation));

            //Task t2 = Task.Factory.StartNew(() => ShowMailClientSettings());
            ShowMailClientSettings();

            dt_MailGroups = new DataTable();
            await t1;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbBox = (ComboBox)sender;
            try
            {
                ShowGroupMailAddresses((MailGroup)cbBox.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database'den e-posta bilgileri çekilirken hata oluştu", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.Error("Database'den e-posta bilgileri çekilirken hata oluştu => {0} ", ex.Message);
            }
        }

        private void ShowGroupMailAddresses(MailGroup _mailGroup)
        {
            lstBox_UsersAddedToGroup.Items.Clear();
            lstBox_UsersNotAddedToGroup.Items.Clear();
            List<User> users = DBHelper_EmailSettings.GetAllUsersMailInfo();
            List<User> _usersInGroup = GetUsersForSelectedGroup(users, _mailGroup.ID);
            if (_usersInGroup != null)
            {
                foreach (User u in _usersInGroup)
                {
                    lstBox_UsersAddedToGroup.Items.Add(u);
                }

                users.RemoveAll((u) => u.MailGroupID == _mailGroup.ID);
                foreach (User u in users)
                {
                    lstBox_UsersNotAddedToGroup.Items.Add(u);
                }

            }

        }

        private List<User> GetUsersForSelectedGroup(List<User> users, uint _groupID)
        {
            return users.Where((u) => u.MailGroupID == _groupID).ToList();
        }

        private void btn_AddSelectedUserToGroup_Click(object sender, EventArgs e)
        {
            if (lstBox_UsersNotAddedToGroup.SelectedItem != null)
            {
                User user = (User)lstBox_UsersNotAddedToGroup.SelectedItem;
                MoveUserToGroupListBox(user);
            }
        }

        private void btn_AddAllUsersToGroup_Click(object sender, EventArgs e)
        {
            if (lstBox_UsersNotAddedToGroup.Items.Count > 0)
            {
                List<User> _users = lstBox_UsersNotAddedToGroup.Items.Cast<User>().ToList();
                foreach (User u in _users)
                {
                    MoveUserToGroupListBox(u);

                }
            }
        }

        private void btn_RemoveSelectedUserFromGroup_Click(object sender, EventArgs e)
        {
            if (lstBox_UsersAddedToGroup.SelectedItem != null)
            {
                RemoveUserFromGroupListBox((User)lstBox_UsersAddedToGroup.SelectedItem);
            }
        }

        private void btn_RemoveAllUsersFromGroup_Click(object sender, EventArgs e)
        {
            if (lstBox_UsersAddedToGroup.Items.Count > 0)
            {
                List<User> _users = lstBox_UsersAddedToGroup.Items.Cast<User>().ToList();
                foreach (User u in _users)
                {
                    RemoveUserFromGroupListBox(u);
                }
            }
        }

        private void MoveUserToGroupListBox(User _user)
        {
            lstBox_UsersNotAddedToGroup.Items.Remove(_user);
            lstBox_UsersAddedToGroup.Items.Add(_user);
        }

        private void RemoveUserFromGroupListBox(User _user)
        {
            lstBox_UsersNotAddedToGroup.Items.Add(_user);
            lstBox_UsersAddedToGroup.Items.Remove(_user);
        }

        private void chkBox_ShowPassword_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkBox_ShowPassword.CheckState == CheckState.Checked)
            {
                txt_Password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_Password.UseSystemPasswordChar = true;
            }
        }

        private void btn_DeleteGroup_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Bu mail grubu ve bu mail grubuna ait tüm alarmlar silininecektir. \nDevam etmek istiyor musunuz?", Constants.MessageBoxHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if(result == DialogResult.Yes)
                {
                    MailGroup mg = ((MailGroup)comboBox1.SelectedItem);
                    DBHelper_EmailSettings.DeleteMailGroup(mg);
                    comboBox1.SelectedItem = null;
                }
            }
        }

        private void btn_SendTestMail_Click(object sender, EventArgs e)
        {
            MailClient client = new MailClient();
            MimeEntity entity = new TextPart("plain") { Text = @"Bu bir deneme mesajıdır." };
            List<string> _toWhoList = new List<string>();
            _toWhoList.Add("umut.kilic@utmotomasyon.com");

            try
            {
                client.Connect(txt_MailServerName.Text, txt_MailServerPort.Text, txt_UserName.Text, txt_Password.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail Server'a baglanılamadı.\nAyarları kontrol ediniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK,MessageBoxIcon.Error);
                Log.Instance.Error("Mail Server'a baglanırken hata : {0}", ex.Message);
            }
            try
            {
                if(client.Client.IsConnected)
                {
                    client.SendMail(_toWhoList, entity);
                }
                else
                {
                    MessageBox.Show("Mail Server ile baglantı  kurulamadı", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Instance.Error("Mail Server ile bağlantı kurulamadığı için test e-postası gonderilemedi");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test E-postası gönderilemedi", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.Error("Mail Server'a baglanırken hata : {0}", ex.Message);
            }
        }

        private void btn_NewGroup_Click_1(object sender, EventArgs e)
        {

        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EmailSettingsEventArgs'
    public class EmailSettingsEventArgs : EventArgs
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EmailSettingsEventArgs'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EmailSettingsEventArgs.MailServerName'
        public string MailServerName { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EmailSettingsEventArgs.MailServerName'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EmailSettingsEventArgs.MailServerPort'
        public string MailServerPort { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EmailSettingsEventArgs.MailServerPort'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EmailSettingsEventArgs.Username'
        public string Username { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EmailSettingsEventArgs.Username'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EmailSettingsEventArgs.Password'
        public string Password { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EmailSettingsEventArgs.Password'


    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'EmailSettingsEventHandler'
    public delegate void EmailSettingsEventHandler(object source, EmailSettingsEventArgs args);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'EmailSettingsEventHandler'

}
