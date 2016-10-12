using MailKit;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Drivers.Mail;
using IniParser;
using IniParser.Model;
using EnMon_Driver_Manager.Models;

namespace EnMon_Driver_Manager
{
    public partial class frm_EmailSettings : Form
    {
        private AbstractDBHelper DBHelper { get; set; }

        private MailClient mailClient { get; set; }
        private DataTable dt_MailGroups { get; set; }
        public frm_EmailSettings()
        {
            InitializeComponent();
            
        }

        private void InitializeDBConnection()
        {
            if(File.Exists(Constants.DatabaseConfigFileLocation))
            {
                DBHelper = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            }
            else
            {
                DBHelper = null;
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            SendMail("bu bir deneme mesajıdır");
        }

        private bool SendMail(string _message)
        {
            try
            {
                List<string> mailAddresses = new List<string>();
                mailAddresses.Add("umutn86@gmail.com");
                mailAddresses.Add("umut.kilic@utmotomasyon.com");

                using (mailClient = StaticHelper.InitializeMailClient(Constants.MailclientConfigFileLocation))
                {;
                    if (mailClient != null)
                    {
                        MimeEntity entity = new TextPart("plain") { Text = @_message };
                        mailClient.SendMail(mailAddresses, entity);
                        return true;
                    }
                    else
                    {
                        return false;
                    } 
                }
            }
            catch (ServiceNotConnectedException ex)
            {
                Log.Instance.Error("E-mail gonderilemedi. Ayarları kontrol ediniz => {0}", ex.Message);
                return false;
            }
            catch (ServiceNotAuthenticatedException ex)
            {
                Log.Instance.Error("E-mail gonderilemedi. Ayarları kontrol ediniz => {0}", ex.Message);
                return false;

            }
            catch (Exception ex)
            {
                Log.Instance.Error("E-mail gonderilemedi. Ayarları kontrol ediniz => {0}", ex.Message);
                return false;

            }


                    
        }

        private async void frm_EmailSettings_Load(object sender, EventArgs e)
        {
            Task t1 = Task.Factory.StartNew(() => InitializeDBConnection());

            //Task t2 = Task.Factory.StartNew(() => ShowMailClientSettings());
            ShowMailClientSettings();
            dt_MailGroups = new DataTable();
            await t1;
            

        }

        private void ShowMailClientSettings()
        {
            if (File.Exists(Constants.MailclientConfigFileLocation))
            {
                string _mailServerName = string.Empty;
                string _mailServerPort = string.Empty;
                string _userName = string.Empty;
                string _password = string.Empty;

                var parser = new FileIniDataParser();

                IniData data = parser.ReadFile(Constants.MailclientConfigFileLocation, Encoding.UTF8);

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

        private void chkBox_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBox_ShowPassword.CheckState == CheckState.Checked)
            {
                txt_Password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_Password.UseSystemPasswordChar = true;
            }
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
            catch(Exception ex)
            {
                MessageBox.Show("Database'den e-posta grup bilgileri çekilirken hata oluştu", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.Error("Database'den mail grup bilgileri çekilirken hata oluştu => {0} ", ex.Message);
            }
            
            
        }

        private void AddMailGroupsToComboBox()
        {
            List<MailGroup> mailGroups;
            mailGroups = DBHelper.GetMailGroups();
            if (mailGroups.Count > 1)
            {
                mailGroups.Remove(mailGroups.Where((mg) => mg.Name == "No Group").First());
                foreach (MailGroup mg in mailGroups)
                {
                    comboBox1.Items.Add(mg);
                }
            }
            else
            {
                Log.Instance.Info("Database'de mail grubu bulunamadı");
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cbBox = (ComboBox)sender;
            try
            {
                ShowGroupMails((MailGroup)cbBox.SelectedItem);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Database'den e-posta bilgileri çekilirken hata oluştu", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.Error("Database'den e-posta bilgileri çekilirken hata oluştu => {0} ", ex.Message);
            }
            
        }

        private void ShowGroupMails(MailGroup _mailGroup)
        {
            List<User> users = DBHelper.GetAllUsersMailInfo();
            List<User> _usersInGroup = GetUsersForSelectedGroup(users, _mailGroup.ID);
            if(_usersInGroup != null)
            {
                foreach (User u in _usersInGroup)
                {
                    lstBox_UsersAddedToGroup.Items.Add(u);
                }

                users.RemoveAll((u) => u.MailGroupID == _mailGroup.ID);
                foreach(User u in users)
                {
                    lstBox__UsersNotAddedToGroup.Items.Add(u);
                }
                
            }
        }

        private List<User> GetUsersForSelectedGroup(List<User> users, uint _groupID)
        {
            return users.Where((u) => u.MailGroupID == _groupID).ToList();
        }

        private DataRow[] GetMailAddressesForSelectedGroup(DataTable _allMailAddresses, string _groupName)
        {
            uint mailGroupID;
            // Combobox için daha önceden veri cekildiyse 
            if(dt_MailGroups.Rows.Count>0)
            {
                // Combobox'ta seçilen mail grubu isminin id'sini al
                 mailGroupID  = (from d in dt_MailGroups.AsEnumerable() where d["group_name"].ToString() == _groupName select d.Field<uint>("group_id")).First();

                // ID bulunursa
                if(mailGroupID > 0 )
                {
                    // ID'ye göre gruba kayıtlı mail adreslerini döndür
                    return (from dr in _allMailAddresses.AsEnumerable() where dr.Field<uint>("mail_group_id") == mailGroupID select dr).ToArray(); 
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

            
        }

        private void btn_AddSelectedUserToGroup_Click(object sender, EventArgs e)
        {
            if(lstBox__UsersNotAddedToGroup.SelectedItem !=  null)
            {
                User user = (User)lstBox__UsersNotAddedToGroup.SelectedItem;
                MoveUserToGroupListBox(user);
            }
            
        }

        private void MoveUserToGroupListBox(User _user)
        {
            lstBox__UsersNotAddedToGroup.Items.Remove(_user);
            lstBox_UsersAddedToGroup.Items.Add(_user);
        }

        private void RemoveUserFromGroupListBox(User _user)
        {
            lstBox__UsersNotAddedToGroup.Items.Add(_user);
            lstBox_UsersAddedToGroup.Items.Remove(_user);
        }

        private void btn_AddAllUsersToGroup_Click(object sender, EventArgs e)
        {
            if(lstBox__UsersNotAddedToGroup.Items.Count>0)
            {
                List<User> _users = lstBox__UsersNotAddedToGroup.Items.Cast<User>().ToList();
                foreach (User u in _users)
                {
                    MoveUserToGroupListBox(u);

                }
            }
        }

        private void btn_RemoveSelectedUserFromGroup_Click(object sender, EventArgs e)
        {
            if(lstBox_UsersAddedToGroup.SelectedItem != null)
            {
                RemoveUserFromGroupListBox((User)lstBox_UsersAddedToGroup.SelectedItem);
            }
            
        }

        private void btn_RemoveAllUsersFromGroup_Click(object sender, EventArgs e)
        {
            if(lstBox_UsersAddedToGroup.Items.Count>0)
            {
                List<User> _users = lstBox_UsersAddedToGroup.Items.Cast<User>().ToList();
                foreach (User u in _users)
                {
                    RemoveUserFromGroupListBox(u);
                }
            }
 
        }

        private void btn_ChangeGroupName_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
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
                if (DBHelper.UpdateGroupName((MailGroup)comboBox1.SelectedItem, newName))
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
            lstBox__UsersNotAddedToGroup.Items.Clear();
            comboBox1.Items.Clear();
            AddMailGroupsToComboBox();
        }

        private void btn_AddNewAlarm_Click(object sender, EventArgs e)
        {
            frm_AddMailAlarm frm_addMailAlarm = new frm_AddMailAlarm();
            frm_addMailAlarm.ShowDialog();
        }
    }
}
