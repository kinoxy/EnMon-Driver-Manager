using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models;
using ExpressionValidatorLib;
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_AddNewOrUpdateMailAlarm'
    public partial class frm_AddNewOrUpdateMailAlarm : Form, IDisposable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_AddNewOrUpdateMailAlarm'
    {
        private int cursorPos;
        private AbstractDBHelper DBHelper_AddNewOrUpdateExistingMailAlarm;
        private frm_SelectVariable frm_selectVariable;
        private AlarmMail alarmMail;
        private enum FormType
        {
            AddNewSignal,
            UpdateExistingSignal
        }

        private FormType formType;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_AddNewOrUpdateMailAlarm.frm_AddNewOrUpdateMailAlarm()'
        public frm_AddNewOrUpdateMailAlarm()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_AddNewOrUpdateMailAlarm.frm_AddNewOrUpdateMailAlarm()'
        {
            InitializeComponent();
            cursorPos = 0;
            txt_AlarmLogic.SelectionLength = 1;
            formType = FormType.AddNewSignal;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_AddNewOrUpdateMailAlarm.frm_AddNewOrUpdateMailAlarm(AlarmMail)'
        public frm_AddNewOrUpdateMailAlarm(AlarmMail _alarmMail)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_AddNewOrUpdateMailAlarm.frm_AddNewOrUpdateMailAlarm(AlarmMail)'
        {
            
            InitializeComponent();
            formType = FormType.UpdateExistingSignal;
            alarmMail = _alarmMail;
            cursorPos = 0;
            txt_AlarmLogic.SelectionLength = 1;
        }

        private void btn_AddOR_Click(object sender, EventArgs e)
        {
            txt_AlarmLogic.Text = txt_AlarmLogic.Text.Insert(txt_AlarmLogic.SelectionStart, "||");
        }

        private void btn_AddSignal_Click(object sender, EventArgs e)
        {
            if(frm_selectVariable == null)
            {
                frm_selectVariable = new frm_SelectVariable();
                frm_selectVariable.ClickedSignalAddButton += AddSignalNameToLogic;
                Point location = new Point(this.Location.X + this.Size.Width, this.Location.Y);
                frm_selectVariable.Location = location;
                frm_selectVariable.StartPosition = FormStartPosition.Manual;
                frm_selectVariable.Show();
                frm_selectVariable.TopMost = true;
            }
            else
            {
                frm_selectVariable.Visible = true;
            }
            
            setCursor();

        }

        private void AddSignalNameToLogic(object sender, frm_SelectVariableEventArgs args)
        {
            string name = string.Empty;
            if(args.analogSignal != null)
            {
                name = args.analogSignal.Identification;
            }
            else if(args.binarySignal !=null)
            {
                name = args.binarySignal.Identification;
            }
            txt_AlarmLogic.Text = txt_AlarmLogic.Text.Insert(txt_AlarmLogic.SelectionStart, string.Format("'{0}' ", name));
        }

        private void btn_AddAND_Click(object sender, EventArgs e)
        {
            txt_AlarmLogic.Text = txt_AlarmLogic.Text.Insert(txt_AlarmLogic.SelectionStart, "&");
            setCursor();
        }

        private void btn_AddLESS_Click(object sender, EventArgs e)
        {
            txt_AlarmLogic.Text = txt_AlarmLogic.Text.Insert(txt_AlarmLogic.SelectionStart, "< ");
            setCursor();
        }

        private void btn_AddGREATER_Click(object sender, EventArgs e)
        {
            txt_AlarmLogic.Text = txt_AlarmLogic.Text.Insert(txt_AlarmLogic.SelectionStart, "> ");
            setCursor();
        }

        private void btn_AddEQUAL_Click(object sender, EventArgs e)
        {
            txt_AlarmLogic.Text = txt_AlarmLogic.Text.Insert(txt_AlarmLogic.SelectionStart, "= ");
            setCursor();
        }

        private void btn_AddFirstParenthessis_Click(object sender, EventArgs e)
        {
            txt_AlarmLogic.Text = txt_AlarmLogic.Text.Insert(txt_AlarmLogic.SelectionStart, "(");
            setCursor();
        }

        private void btn_AddEndParenthessis_Click(object sender, EventArgs e)
        {
            
            txt_AlarmLogic.Text = txt_AlarmLogic.Text.Insert(txt_AlarmLogic.SelectionStart, ") ");
            setCursor();
        }

        private void setCursor()
        {
            txt_AlarmLogic.Focus();
            txt_AlarmLogic.SelectionStart = cursorPos + 2 ;
        }

        private void txt_AlarmName_Click(object sender, EventArgs e)
        {
            
        }

        private void txt_AlarmLogic_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_AlarmLogic_Click(object sender, EventArgs e)
        {
            cursorPos = txt_AlarmLogic.SelectionStart;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_AddNewOrUpdateAlarm_Click(object sender, EventArgs e)
        {
            ExprValidator validator = new ExpressionValidatorLib.ExprValidator();
            uint second;
            try
            {
                TrimAllInputFields();
                

                if (txt_AlarmName.Text == string.Empty)
                {
                    MessageBox.Show("Alarm adı boş bırakılamaz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_AlarmName.Focus();
                    return;
                }
                else if (txt_AlarmLogic.Text == string.Empty)
                {
                    MessageBox.Show("Alarm için bir koşul yazınız.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_AlarmLogic.Focus();
                    return;
                }
                else if (txt_EMailSubject.Text == string.Empty)
                {
                    MessageBox.Show("E-Posta başlığı boş bırakılamaz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_EMailSubject.Focus();
                    return;
                }
                else if (txt_EmailMessage.Text == string.Empty)
                {
                    MessageBox.Show("E-Posta mesajı boş bırakılamaz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_EmailMessage.Focus();
                    return;
                }
                else if (txt_Second.Text == string.Empty)
                {
                    MessageBox.Show("Alarm gecikme boş bırakılamaz.\nAlarm'ın çalışmasında gecikme süresi olmasını istemiyorsanız 0 giriniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_EmailMessage.Focus();
                    return;
                }
                else if (!(uint.TryParse(txt_Second.Text, out second)))
                {
                    MessageBox.Show("Alarm gecikme süresi için sadece sayı giriniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_EmailMessage.Focus();
                    return;
                }
                else if (cb_MailGroups.SelectedItem == null)
                {
                    MessageBox.Show("E-Posta grubu seçiniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cb_MailGroups.Focus();
                    bool denme = validator.Validate(txt_AlarmLogic.Text);
                    return;
                }
                else if (!validator.Validate(txt_AlarmLogic.Text))
                {

                    MessageBox.Show(string.Format("Alarm lojiğinde hata! \nAlarm lojiğini kontrol ediniz. \n{0}", validator.Message()), Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_AlarmLogic.Focus();
                    return;
                }
                else
                {
                    bool isVariableNamesValidated = ValidateVariableNamesAtLogic();

                    if(isVariableNamesValidated)
                    {
                        if (formType == FormType.AddNewSignal)
                        {
                            AlarmMail am = new AlarmMail();
                            GetFormValues(am);
                            OnAddNewAlarmButtonClicked(am);
                        }
                        else if (formType == FormType.UpdateExistingSignal)
                        {
                            GetFormValues(alarmMail);
                            OnUpdateExistingAlarmButtonClicked(alarmMail);
                        }
                        Close_frm_selectVariable();
                    }
                    else
                    {

                    }   
                }
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        private bool ValidateVariableNamesAtLogic()
        {
            List<string> _strings = StaticHelper.GetStringsBetweenGivenChar(txt_AlarmLogic.Text, '\'');
            bool result;
            foreach(string v in _strings)
            {
                result = DBHelper_AddNewOrUpdateExistingMailAlarm.IsSignalAvalibale(v);
                if(!result)
                {
                    MessageBox.Show(String.Format("'{0}' geçerli bir sinyal ismi değil. Sinyal ismini konrol ediniz.",v), Constants.MessageBoxHeader, MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

       

        private void OnUpdateExistingAlarmButtonClicked(AlarmMail am)
        {
            MailAlarmEventArgs args = new MailAlarmEventArgs();
            args.alarmMail = am;

            if (UpdateExistingAlarmButtonClicked != null)
            {
                UpdateExistingAlarmButtonClicked(this, args);
            }
        }

        private AlarmMail GetFormValues(AlarmMail am)
        {
            am.Name = txt_AlarmName.Text;
            am.EMailSubject = txt_EMailSubject.Text.Replace("'", "$");
            am.EmailText = txt_EmailMessage.Text.Replace("'", "$");
            am.LogicText = txt_AlarmLogic.Text.Replace("'", "$"); ;
            am.MailGroupID = ((MailGroup)cb_MailGroups.SelectedItem).ID;
            am.Delaytime = uint.Parse(txt_Second.Text);
                return am;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_AddNewOrUpdateMailAlarm.AddNewAlarmButtonClicked'
        public AddNewOrUpdateAlarmButtonClickedEventHandler AddNewAlarmButtonClicked;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_AddNewOrUpdateMailAlarm.AddNewAlarmButtonClicked'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_AddNewOrUpdateMailAlarm.UpdateExistingAlarmButtonClicked'
        public AddNewOrUpdateAlarmButtonClickedEventHandler UpdateExistingAlarmButtonClicked;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_AddNewOrUpdateMailAlarm.UpdateExistingAlarmButtonClicked'

        private void OnAddNewAlarmButtonClicked(AlarmMail am)
        {
            MailAlarmEventArgs args = new MailAlarmEventArgs();
            args.alarmMail = am;

            if(AddNewAlarmButtonClicked != null)
            {
                AddNewAlarmButtonClicked(this, args);
            }
        }

        private void TrimAllInputFields()
        {
            txt_AlarmLogic.Text.Trim();
            txt_AlarmName.Text.Trim();
            txt_EmailMessage.Text.Trim();
            txt_EMailSubject.Text.Trim();
           
        }

        private void frm_AddMailAlarm_Load(object sender, EventArgs e)
        {
            try
            {

                DBHelper_AddNewOrUpdateExistingMailAlarm = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
                List<MailGroup> mailGroups = DBHelper_AddNewOrUpdateExistingMailAlarm.GetMailGroups();
                if(mailGroups.Count>0)
                {
                    cb_MailGroups.Items.AddRange(mailGroups.ToArray());

                    if (formType == FormType.UpdateExistingSignal)
                    {
                        txt_AlarmName.Text = alarmMail.Name;
                        txt_AlarmLogic.Text = alarmMail.LogicText.Replace("$", "'");
                        txt_EMailSubject.Text = alarmMail.EMailSubject;
                        txt_EmailMessage.Text = alarmMail.EmailText;
                        btn_AddNewOrUpdateAlarm.Text = "Alarm'ı Güncelle";
                        cb_MailGroups.SelectedItem = mailGroups.Where((mg) => mg.Name== alarmMail.MailGroupName).First();
                }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail Grupları yüklenemedi", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.Error("Mail grupları database'den okunamadı => {0}", ex.Message);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close_frm_selectVariable();
        }

        private void Close_frm_selectVariable()
        {
            if (frm_selectVariable != null)
            {
                frm_selectVariable.Dispose();
            }

        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AddNewOrUpdateAlarmButtonClickedEventHandler'
    public delegate void AddNewOrUpdateAlarmButtonClickedEventHandler(object source, MailAlarmEventArgs args );
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AddNewOrUpdateAlarmButtonClickedEventHandler'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailAlarmEventArgs'
    public class MailAlarmEventArgs : EventArgs
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailAlarmEventArgs'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailAlarmEventArgs.alarmMail'
        public AlarmMail alarmMail { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailAlarmEventArgs.alarmMail'
    }

}


