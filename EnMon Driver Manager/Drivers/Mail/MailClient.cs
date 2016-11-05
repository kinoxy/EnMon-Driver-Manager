using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models;
using IniParser;
using IniParser.Model;
using MailKit.Net.Smtp;
using MimeKit;
using NCalc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EnMon_Driver_Manager.Drivers.Mail
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient'
    public class MailClient : IDisposable
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.MailServerName'
        public string MailServerName;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.MailServerName'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.MailServerPort'
        public string MailServerPort;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.MailServerPort'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.UserName'
        public string UserName;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.UserName'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.Password'
        public string Password;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.Password'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.ConfigFileLocation'
        public string ConfigFileLocation;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.ConfigFileLocation'
        private AbstractDBHelper DBHelper_MailClient;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.isStarted'
        public bool isStarted { get; private set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.isStarted'
        private List<AlarmMail> _alarmMails;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.client'
        public SmtpClient client;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.client'
        private Timer cyclicTimer;
        private List<MailClientTimer> mailClientTimers; //Gecikmeli mail alarmları için gerekli timerları tutuyor.

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.Client'
        public SmtpClient Client
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.Client'
        {
            get { return client; }
            set { client = value; }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.MailClient()'
        public MailClient()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.MailClient()'
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.MailClient(string)'
        public MailClient(string _configFileLocation) : this()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.MailClient(string)'
        {
            MailServerPort = "587";
            mailClientTimers = new List<MailClientTimer>();

            ConfigFileLocation = _configFileLocation;
            ReadConfigFile(_configFileLocation);

            DBHelper_MailClient = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            // Mail alarmları kontrol etmek için cyclic timer
            cyclicTimer = new Timer();
            cyclicTimer.Interval = 100;
            cyclicTimer.Enabled = true;
            cyclicTimer.Elapsed += Timer_Elapsed;
        }

        private void ReadConfigFile(string _configFileLocation)
        {
            if (File.Exists(_configFileLocation))
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(_configFileLocation, Encoding.UTF8);
                var _parameters = data["MailClient Parameters"];

                foreach (KeyData kd in _parameters)
                {
                    switch (kd.KeyName.Trim())
                    {
                        case "MailServerName":
                            MailServerName = kd.Value.Trim();
                            break;

                        case "MailServerPort":
                            MailServerPort = kd.Value.Trim();
                            break;

                        case "UserName":
                            UserName = kd.Value.Trim();
                            break;

                        case "Password":
                            Password = kd.Value.Trim();
                            break;

                        default:
                            break;
                    }
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.MailClient(string, string, string, string)'
        public MailClient(string _mailServerName, string _mailServerPort, string _userName, string _password)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.MailClient(string, string, string, string)'
        {
            try
            {
                MailServerName = _mailServerName;
                MailServerPort = _mailServerPort;
                UserName = _userName;
                Password = _password;
                if (client == null)
                {
                    client = new SmtpClient();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("MailClient sürücüsü oluşturulamadı  => {0} ", ex.Message);
            }
        }

        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            cyclicTimer.Stop();
            Task t1 = Task.Factory.StartNew(() => CheckAlarmConditions());
            await t1;
            cyclicTimer.Start();
        }

        private void CheckAlarmConditions()
        {
            try
            {
                if (isStarted)
                {
                    _alarmMails = GetAlarmMails();
                    // Her alarmın koşulu kontrol edilir.
                    foreach (AlarmMail alarmMail in _alarmMails)
                    {
                        // Alarm koşulu içerisindeki sinyal isimleri anlık değerler ile değiştirilir.
                        string logicTextWithVariables = ReplaceVariableNamesWithVariableValue(alarmMail.LogicText);

                        // Güncel değerlerin yer aldığı logictext çalıştırılır.
                        int calculatedValue = CalculateLogic(logicTextWithVariables);

                        bool result = calculatedValue > 0;

                        // Logic sonucu onceki sonuclar ile aynı değilse,
                        if (result != alarmMail.Status)
                        {
                            // yeni sonuc database'de kaydedilir.
                            alarmMail.Status = result;
                            DBHelper_MailClient.UpdateMailAlarmStatus(alarmMail);

                            // eğer logic sonucu false'tan true'ta gectiyse
                            if (result == true)
                            {
                                // mail alarm'a atanmıs gecikme suresi yoksa e-posta anında gönderilir.
                                if (alarmMail.Delaytime == 0)
                                {
                                    SendMail(alarmMail);
                                }
                                // eğer mail alarm'a atanmış bir gecikme süresi varsa girilen süre sonra logic'in durumunun tekrardan kontrol edilmesi için timer olusturulur.
                                else
                                {
                                    MailClientTimer mailClientTimer = new MailClientTimer(alarmMail);
                                    mailClientTimer.TimerElapsed += MailClientTimer_TimerElapsed;
                                    mailClientTimers.Add(mailClientTimer);
                                    mailClientTimer.Start();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("MailClient sürücüsü beklenmedik bir hata ile karşılaştı => {0}", ex.Message);
            }
        }

        private void MailClientTimer_TimerElapsed(object source, MailClientTimerEventArgs args)
        {
            MailClientTimer mailClientTimer = (MailClientTimer)source;
            mailClientTimer.Stop();
            try
            {
                string logicTextWithVariables = ReplaceVariableNamesWithVariableValue(args.alarmMail.LogicText);
                int result = CalculateLogic(logicTextWithVariables);
                if (result > 0)
                {
                    SendMail(args.alarmMail);
                }
                mailClientTimers.Remove(mailClientTimer);
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0} isimli alarm için mail gonderilemedi => {1}", args.alarmMail.Name, ex.Message);
                throw;
            }
        }

        private int CalculateLogic(string logicText)
        {
            // Evaluate'den integer, true ya da false donebiliyor. Method'un devamı için int gerektiğinden donen deger int'e cevriliyor.
            // TODO: logicte - deger varsa sorun cıkabilir. float ya da unsigned kullanmak gerekli gibi....
            Expression e = new Expression(logicText, EvaluateOptions.NoCache);
            var r = (e.Evaluate());
            int evaluateValue;
            string result2 = r.ToString();
            if (result2 == "True")
            {
                evaluateValue = 1;
            }
            else if (result2 == "False")
            {
                evaluateValue = 0;
            }
            else
            {
                evaluateValue = int.Parse(result2);
            }
            return evaluateValue;
        }

        private string ReplaceVariableNamesWithVariableValue(string logicText)
        {
            // Koşul içerisindeki sinyal isimleri alınır.
            List<string> variables = StaticHelper.GetStringsBetweenGivenChar(logicText, '$');

            // Koşul içerisinde sinyal ismi varsa,
            if (variables.Count > 0)
            {
                // Koşul text'i içerisinde sinyal isimleri güncel değerleri ile değiştirilir.
                foreach (string variable in variables)
                {
                    string oldValue = string.Format("${0}$", variable);
                    string newValue = DBHelper_MailClient.GetSignalValueByIdentification(variable);
                    logicText = logicText.Replace(oldValue, newValue);
                }
            }

            return logicText;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.StartDriver()'
        public void StartDriver()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.StartDriver()'
        {
            
            // Mail client ve database helper olusturulduysa
            if (DBHelper_MailClient != null)
            {
                // Database'den alarm mail bilgileri çekilir.
                _alarmMails = GetAlarmMails();

                // Database'den alarm mail donduyse,
                if (_alarmMails != null)
                {
                    isStarted = true;
                    cyclicTimer.Start();
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.GetAlarmMails()'
        public List<AlarmMail> GetAlarmMails()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.GetAlarmMails()'
        {
            return DBHelper_MailClient.GetAllAlarmMails();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.Dispose()'
        public void Dispose()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.Dispose()'
        {
            Client = null;
            DBHelper_MailClient = null;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.SendMail(List<string>, MimeEntity, string)'
        public void SendMail(List<string> toWho, MimeEntity _message, string _subject = "Enmon Enerji Takibi")
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.SendMail(List<string>, MimeEntity, string)'
        {
           
            try
            {
                
                    var message = new MimeMessage();
                    foreach (string mailAddress in toWho)
                    {
                        message.To.Add(new MailboxAddress(mailAddress, mailAddress));
                    }
                    message.From.Add(new MailboxAddress(UserName, UserName));
                    message.Subject = _subject;
                    message.Body = _message;
                    client.Send(message);

                    client.Disconnect(true);
                
                    
            }
            catch (Exception)
            {
                throw;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.SendMail(AlarmMail)'
        public void SendMail(AlarmMail _alarm)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.SendMail(AlarmMail)'
        {
            client = new SmtpClient();
            List<User> recipients = GetMailRecipients(_alarm);
            if (recipients.Count > 0)
            {
                var message = new MimeMessage();
                foreach (User recipient in recipients)
                {
                    message.To.Add(new MailboxAddress(recipient.Name + " " + recipient.Surname, recipient.Email));
                }
                message.From.Add(new MailboxAddress(Constants.MessageBoxHeader, UserName));
                message.Subject = _alarm.EMailSubject;
                message.Body = new TextPart("plain") { Text = @_alarm.EmailText };

                if (ConnectToMailServer())
                {
                    client.Send(message);
                    client.Disconnect(true);
                }
                else
                {
                    Log.Instance.Error("{0} isimli alarm mail server'a bağlanılamadı için gönderilemedi", _alarm.Name);
                }
            }
        }

        private List<User> GetMailRecipients(AlarmMail _alarm)
        {
            return DBHelper_MailClient.GetMailRecipients(_alarm.MailGroupID);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.ConnectToMailServer()'
        public bool ConnectToMailServer()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.ConnectToMailServer()'
        {
            try
            {
                if (!(client.IsConnected))
                {
                    client.ServerCertificateValidationCallback = (s, c, h, fe) => true;

                    client.Connect(MailServerName, Convert.ToInt32(MailServerPort), false);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    client.Authenticate(UserName, Password);
                }
                if (client.IsConnected)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Mail Server ile bağlantı kurulamadı");
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient.Connect(string, string, string, string)'
        public void Connect(string _mailServerName, string _mailServerPort, string _userName, string _password)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClient.Connect(string, string, string, string)'
        {
            MailServerName = _mailServerName;
            MailServerPort = _mailServerPort;
            UserName = _userName;
            Password = _password;
            if (client == null)
            {
                client = new SmtpClient();
            }
            try
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(MailServerName, int.Parse(MailServerPort), false);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Authenticate(UserName, Password);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}