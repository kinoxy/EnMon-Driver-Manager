using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Drivers.Mail;
using EnMon_Driver_Manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager
{
    public partial class frm_EmailAlarms : Form
    {
        private AbstractDBHelper DBHelper_EmailAlarms { get; set; }

        private MailClient mailClient { get; set; }
        private DataTable dt_MailGroups { get; set; }

        private frm_AddNewOrUpdateMailAlarm frm_addNewOrUpdateMailAlarm { get; set; }

        public frm_EmailAlarms()
        {
            InitializeComponent();

        }

        private void InitializeDBConnection()
        {
            if (File.Exists(Constants.DatabaseConfigFileLocation))
            {
                DBHelper_EmailAlarms = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            }
            else
            {
                DBHelper_EmailAlarms = null;
            }
        }

        private void frm_EmailSettings_Load(object sender, EventArgs e)
        {
            Task t1 = Task.Factory.StartNew(() => InitializeDBConnection());
            t1.Wait();
            dt_MailGroups = new DataTable();
            LoadMailAlarmsToGridView();
        }

        private List<User> GetUsersForSelectedGroup(List<User> users, uint _groupID)
        {
            return users.Where((u) => u.MailGroupID == _groupID).ToList();
        }

        private DataRow[] GetMailAddressesForSelectedGroup(DataTable _allMailAddresses, string _groupName)
        {
            uint mailGroupID;
            // Combobox için daha önceden veri cekildiyse
            if (dt_MailGroups.Rows.Count > 0)
            {
                // Combobox'ta seçilen mail grubu isminin id'sini al
                mailGroupID = (from d in dt_MailGroups.AsEnumerable() where d["group_name"].ToString() == _groupName select d.Field<uint>("group_id")).First();

                // ID bulunursa
                if (mailGroupID > 0)
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

        private void btn_AddNewAlarm_Click(object sender, EventArgs e)
        {
            frm_addNewOrUpdateMailAlarm = new frm_AddNewOrUpdateMailAlarm();
            frm_addNewOrUpdateMailAlarm.AddNewAlarmButtonClicked += tab_EmailSettings_AddNewAlarmButtonClicked;
            frm_addNewOrUpdateMailAlarm.ShowDialog();
        }

        private void tab_EmailSettings_AddNewAlarmButtonClicked(object source, MailAlarmEventArgs args)
        {
            if (!DBHelper_EmailAlarms.AddNewMailAlarm(args.alarmMail))
            {
                MessageBox.Show("Yeni alarm database'e eklenemedi", Constants.MessageBoxHeader);
            }
            else
            {
                LoadMailAlarmsToGridView();
                frm_addNewOrUpdateMailAlarm.Close();
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_EmailAlarms.LoadMailAlarmsToGridView()'
        public void LoadMailAlarmsToGridView()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_EmailAlarms.LoadMailAlarmsToGridView()'
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DBHelper_EmailAlarms.GetAllAlarmMailsAsDataTable();
                dt.Columns["name"].ColumnName = "Alarm Adı";
                dt.Columns["email_subject"].ColumnName = "E-Mail Konu";
                dt.Columns["email_text"].ColumnName = "Mesaj";
                dt.Columns["logic_text"].ColumnName = "Alarm Lojiği";
                dt.Columns["group_name"].ColumnName = "E-Posta Grubu";
                dgv_MailAlarms.DataSource = dt;
                dgv_MailAlarms.Columns["id"].Visible = false;
                dgv_MailAlarms.Columns["is_active"].Visible = false;
                dgv_MailAlarms.Columns["status"].Visible = false;
                dgv_MailAlarms.Columns["email_group_id"].Visible = false;
            }
            catch (Exception ex)
            {
                if (dgv_MailAlarms.DataSource == null)
                {
                    MessageBox.Show("Mail Alarmları okunamadı", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Log.Instance.Error("Mail alarmları okunamadı => {0}", ex.Message);
            }
        }

        private void dgv_MailAlarms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AlarmMail am = new AlarmMail();
            am.ID = uint.Parse(dgv_MailAlarms.SelectedRows[0].Cells["id"].Value.ToString());
            am.Name = dgv_MailAlarms.SelectedRows[0].Cells["Alarm Adı"].Value.ToString();
            am.EMailSubject = dgv_MailAlarms.SelectedRows[0].Cells["E-Mail Konu"].Value.ToString();
            am.EmailText = dgv_MailAlarms.SelectedRows[0].Cells["Mesaj"].Value.ToString();
            am.LogicText = dgv_MailAlarms.SelectedRows[0].Cells["Alarm Lojiği"].Value.ToString();
            am.MailGroupName = dgv_MailAlarms.SelectedRows[0].Cells["E-Posta Grubu"].Value.ToString();

            frm_addNewOrUpdateMailAlarm = new frm_AddNewOrUpdateMailAlarm(am);
            frm_addNewOrUpdateMailAlarm.UpdateExistingAlarmButtonClicked += tab_EmailSettings_UpdateExistingAlarmButtonClicked;
            frm_addNewOrUpdateMailAlarm.ShowDialog();
        }

        private void tab_EmailSettings_UpdateExistingAlarmButtonClicked(object source, MailAlarmEventArgs args)
        {
            try
            {
                if (!DBHelper_EmailAlarms.UpdateExistingMailAlarm(args.alarmMail.ID, args.alarmMail.Name, args.alarmMail.LogicText, args.alarmMail.MailGroupID, args.alarmMail.EMailSubject, args.alarmMail.EmailText))
                {
                    MessageBox.Show("Yeni alarm database'e  eklenemedi", Constants.MessageBoxHeader);
                }
                else
                {
                    LoadMailAlarmsToGridView();
                    frm_addNewOrUpdateMailAlarm.Close();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0} isimli alarm güncellenemedi => {1}", args.alarmMail.Name, ex.Message);
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_EmailAlarms.MailClientSettingsUpdateRequested'
        public EmailSettingsEventHandler MailClientSettingsUpdateRequested;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_EmailAlarms.MailClientSettingsUpdateRequested'

        private void btn_NewGroup_Click(object sender, EventArgs e)
        {
        }

        private void btn_DeleteAlarm_Click(object sender, EventArgs e)
        {
            if(dgv_MailAlarms.SelectedRows == null)
            {
                MessageBox.Show("Silmek için bir alarm seçiniz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DialogResult result = MessageBox.Show("Seçili alarm silinecektir. Devam etme istiyor musunuz?", Constants.MessageBoxHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(result == DialogResult.Yes)
            {
                string id = dgv_MailAlarms.SelectedRows[0].Cells["id"].Value.ToString();
                try
                {
                    if (!DBHelper_EmailAlarms.DeleteMailAlarm(id))
                    {
                        MessageBox.Show("Alarm database'den silinemedi.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        LoadMailAlarmsToGridView();
                    }
                }
                catch (Exception)
                {
                    Log.Instance.Error("Mail Alarm silerken hata : {0} isimli alarm silinemedi => ", dgv_MailAlarms.SelectedRows[0].Cells["Alarm Adı"].ToString());
                    throw;
                }
            }
        }
    }
}