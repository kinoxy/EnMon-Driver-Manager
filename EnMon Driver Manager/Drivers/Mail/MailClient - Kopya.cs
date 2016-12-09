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
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EnMon_Driver_Manager.Drivers.Mail
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient'

    public class MailClient : IDisposable
    {
        #region Private Properties

        private AbstractDBHelper DBHelper_MailClient;

        private List<AlarmMail> _alarmMails;

        private Timer cyclicTimer;

        private List<MailClientTimer> mailClientTimers; //Gecikmeli mail alarmları için gerekli timerları tutuyor.

        #endregion

        #region Public Properties
        public string MailServerName;

        public string MailServerPort;
        public string UserName;
        public string Password;

        public string ConfigFileLocation;

        public bool isStarted { get; private set; }

        public MailKit.Net.Smtp.SmtpClient client;

        public MailKit.Net.Smtp.SmtpClient Client
        {
            get { return client; }
            set { client = value; }
        }
        #endregion

        #region Constructors

        public MailClient()
        {
        }

        public MailClient(string _configFileLocation) : this()
        {
            MailServerPort = "587";
            mailClientTimers = new List<MailClientTimer>();

            ConfigFileLocation = _configFileLocation;
            ReadConfigFile(_configFileLocation);

            DBHelper_MailClient = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            // Mail alarmları kontrol etmek için cyclic timer
            cyclicTimer = new Timer();
            cyclicTimer.Interval = 1000;
            cyclicTimer.Enabled = true;
            cyclicTimer.Elapsed += Timer_Elapsed;
        }

        #endregion

        #region Public Methods

        public void StartDriver()
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

        public List<AlarmMail> GetAlarmMails()

        {
            return DBHelper_MailClient.GetAllAlarmMails();
        }

        public void Dispose()

        {
            Client = null;
            DBHelper_MailClient = null;
        }

        public void SendMail(string from, List<string> toWho, MimeEntity _message, string _subject = "Enmon Enerji Takibi")
        {
            var message = new MimeMessage();
            try
            {

                foreach (string mailAddress in toWho)
                {
                    message.To.Add(new MailboxAddress(mailAddress, mailAddress));
                }
                message.From.Add(new MailboxAddress(from, from));
                message.Subject = _subject;
                message.Body = _message;
                client.Send(message);

                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: {1} başlıklı e-postayı gönderirken hata => {1}", this.GetType().Name, _subject, ex.Message);
                throw;
            }
        }

        public void SendMail(AlarmMail _alarm)

        {
            client = new MailKit.Net.Smtp.SmtpClient();
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
                    Log.Instance.Info("{0}: {1} adlı alarm {2} grubundaki tüm kullanıcılara gönderildi.", this.GetType().Name, _alarm.Name, _alarm.MailGroupName);
                    client.Disconnect(true);
                }
                else
                {
                    Log.Instance.Error("{0} isimli alarm mail server'a bağlanılamadı için gönderilemedi", _alarm.Name);
                }
            }
        }

        public MailClient(string _mailServerName, string _mailServerPort, string _userName, string _password)
        {
            try
            {
                MailServerName = _mailServerName;
                MailServerPort = _mailServerPort;
                UserName = _userName;
                Password = _password;
                if (client == null)
                {
                    client = new MailKit.Net.Smtp.SmtpClient();
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("MailClient sürücüsü oluşturulamadı  => {0} ", ex.Message);
            }
        }

        public bool ConnectToMailServer()
        {
            try
            {
                if (!(client.IsConnected))
                {

                    Connect(MailServerName, MailServerPort, UserName, Password);

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

        public void ConnectAsync(string _mailServerName, string _mailServerPort, string _userName, string _password)
        {
            if (client == null)
            {
                client = new MailKit.Net.Smtp.SmtpClient();
            }

            try
            {
                System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("denizli_kyk_enerji_izleme@outlook.com");
                mail.To.Add("umutn86@gmail.com");
                mail.Subject = "Test Mail - 1";
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = "Write some HTML code here";
                mail.Body = htmlBody;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("denizli_kyk_enerji_izleme@outlook.com", "Denizli20");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

                throw ex;
            }


            /*Task t1 = Task.Factory.StartNew(() =>
            {
                try
                {
                    
                    
                    IPHostEntry host = Dns.GetHostEntry(_mailServerName);

                    string IPAddress = host.AddressList[0].ToString();

                    IPAddress iPAddress = host.AddressList[0];


                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    //client.Connect(socket, iPAddress.ToString(), int.Parse(_mailServerPort));

                    client.Connect(_mailServerName, int.Parse(_mailServerPort), false);

                    if(client.IsConnected)
                    {
                        client.AuthenticationMechanisms.Remove("XOAUTH2");

                        client.Authenticate(_userName, _password);
                    }
                    else
                    {
                        throw new Exception("Mail servera baglanılamadı");
                    }
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
            return t1;*/
        }

        public void Connect(string _mailServerName, string _mailServerPort, string _userName, string _password)
        {
            if (client == null)
            {
                client = new MailKit.Net.Smtp.SmtpClient();
            }
                try
                {

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                IPHostEntry host = Dns.GetHostEntry(_mailServerName);

                string IPAddress = host.AddressList[0].ToString();

                IPAddress iPAddress = host.AddressList[0];

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                //client.Connect(socket, iPAddress.ToString(), int.Parse(_mailServerPort));

                client.Connect(iPAddress.ToString(), int.Parse(_mailServerPort), false);
                if (client.IsConnected)
                    {
                        client.AuthenticationMechanisms.Remove("XOAUTH2");

                        client.Authenticate(_userName, _password);
                    }
                    else
                    {
                        throw new Exception("Mail servera baglanılamadı");
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

        #endregion

        #region Private Methods

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
                        string logicTextWithVariables = ReplaceVariableNamesWithVariableValues(alarmMail.LogicText);

                        // Logicte yazım hatası, sinyal ismi bulunamaması vb durumu varsa ReplaceVariableNamesWithVariableValues methodundan logicText null olarak doner.
                        // Aksi durumda işlem devam eder.
                        if (logicTextWithVariables != null)
                        {
                            // Güncel değerlerin yer aldığı logictext dynamic olarak çalıştırılır.
                            int calculatedValue = CalculateLogic(logicTextWithVariables);

                            bool result = calculatedValue > 0;

                            // Logic sonucu kaydedilen önceki sonuç ile aynı değilse, logic sonucu değişmis ise
                            if (result != alarmMail.Status)
                            {
                                // yeni sonuc database'de kaydedilir.
                                alarmMail.Status = result;
                                DBHelper_MailClient.UpdateMailAlarmStatus(alarmMail);

                                // logic sonucu true ise e-mail gönderme işlemleri başlatılır.
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
                string logicTextWithVariables = ReplaceVariableNamesWithVariableValues(args.alarmMail.LogicText);
                int result = CalculateLogic(logicTextWithVariables);
                // Logic hala true donuyorsa e-mail gonderilir.
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

        private string ReplaceVariableNamesWithVariableValues(string logicText)
        {
            // Koşul içerisindeki sinyal isimleri alınır.
            List<string> variables = StaticHelper.GetStringsBetweenGivenChar(logicText, '$');

            // Koşul içerisinde sinyal ismi varsa sinyallerin isimleri sinyal değerleri ile değiştirilir.
            if (variables.Count > 0)
            {
                // Koşul text'i içerisinde sinyal isimleri güncel değerleri ile değiştirilir.
                try
                {
                    foreach (string variable in variables)
                    {
                        string oldValue = string.Format("${0}$", variable);
                        string newValue = DBHelper_MailClient.GetSignalValueByIdentification(variable);
                        newValue = newValue.Replace(",", ".");
                        logicText = logicText.Replace(oldValue, newValue);
                    }
                }
                catch
                {
                    return null;
                }
            }

            return logicText;
        }

        private List<User> GetMailRecipients(AlarmMail _alarm)
        {
            return DBHelper_MailClient.GetMailRecipients(_alarm.MailGroupID);
        }
        #endregion
    }
}
