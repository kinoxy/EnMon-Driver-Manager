using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models;
using IniParser;
using IniParser.Model;
using NCalc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EnMon_Driver_Manager.Drivers.Mail
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClient'

    public class MailClient : IDisposable
    {
        #region Public Properties

        public string MailServerName
        {
            get;
            protected set;
        }

        public string MailServerPort
        {
            get;
            protected set;
        }

        public string UserName
        {
            get;
            protected set;
        }

        public string Password
        {
            get;
            protected set;
        }



        public SmtpClient Client
        {
            get;
            protected set;
        }

        public bool isStarted
        {
            get;
            protected set;
        }

        public bool UseSSL
        {
            get;
            protected set;
        }

        public string FromMailAddress
        {
            get;
            protected set;
        }
        #endregion Public Properties

        #region Private Properties

        private AbstractDBHelper DBHelper_MailClient;

        private List<AlarmMail> _alarmMails;

        private Timer cyclicTimer;

        private List<MailClientTimer> mailClientTimers; //Gecikmeli mail alarmları için gerekli timerları tutuyor.

        private string ConfigFileLocation
        {
            get;
            set;
        }

        #endregion Private Properties

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
            cyclicTimer.Interval = 500;
            cyclicTimer.Elapsed += Timer_Elapsed;
        }

        public MailClient(string _mailServerName, string _mailServerPort, string _userName, string _password, string _fromMailAddress, bool _useSSL)
        {
            try
            {
                MailServerName = _mailServerName;
                MailServerPort = _mailServerPort;
                UserName = _userName;
                Password = _password;
                FromMailAddress = _fromMailAddress;
                UseSSL = _useSSL;
                if (Client == null)
                {
                    Client = new SmtpClient(_mailServerName);
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("MailClient sürücüsü oluşturulamadı  => {0} ", ex.Message);
            }
        }

        #endregion

        #region Public Methods

        public void StartDriver()
        {
            try
            {
                // Database helper oluşturulmadıysa veritabanı baglantısı için database helper oluşturulur
                if (DBHelper_MailClient == null)
                {
                    DBHelper_MailClient = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
                }

                if (DBHelper_MailClient != null)
                {
                    // Database'den alarm mail bilgileri çekilir.
                    _alarmMails = GetAlarmMails();

                    // Database'den alarm mail donduyse,
                    if (_alarmMails != null)
                    {
                        // Timer'ın olup olmadığına bakılır. Timer oluşturulmadıysa timer oluşturulur.
                        if (cyclicTimer == null)
                        {
                            cyclicTimer = new Timer();
                            cyclicTimer.Interval = 500;
                            cyclicTimer.Elapsed += Timer_Elapsed;
                        }

                        isStarted = true;
                        cyclicTimer.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Mail client sürücüsü başlatılamadı => {1}", this.GetType().Name, ex.Message);
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

        public Task SendMailAsync(List<string> toWho, string _message, string _subject = "Enmon Enerji Takibi")

        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(FromMailAddress);
                foreach (string address in toWho)
                {
                    mail.To.Add(address);
                }
                mail.Subject = _subject;
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = _message;
                mail.Body = htmlBody;
                Client.Port = int.Parse(MailServerPort);
                Client.UseDefaultCredentials = false;
                Client.Credentials = new System.Net.NetworkCredential(UserName, Password);
                Client.EnableSsl = UseSSL;
                return Client.SendMailAsync(mail);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async void SendMailAsync(AlarmMail _alarm)
        {
            if (Client == null)
            {
                Client = new SmtpClient(MailServerName);
            }

            try
            {
                List<User> recipients = GetMailRecipients(_alarm);
                if (recipients.Count > 0)
                {
                    var toWho = from recipient in recipients select recipient.Email;

                    await SendMailAsync(toWho.ToList(), _alarm.EmailText, _alarm.EMailSubject);
                    Log.Instance.Info("{0}: '{1}' adlı alarm '{2}' nolu e-posta grubundaki kullanıcalara iletildi.", this.GetType().Name, _alarm.Name, _alarm.MailGroupName);
                }
                else
                {
                    Log.Instance.Warn("{0}: Veritabanında alıcı bulunamadığı için {1} adlı alarm iletilemedi.", this.GetType().Name, _alarm.Name);
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: {1} adlı alarm ilgili kullanıcalara iletilemedi => {2}", this.GetType().Name, _alarm.Name, ex.Message);
                throw;
            }
        }

        /*public bool ConnectToMailServer()
        {
            try
            {
                if (!(Client.IsConnected))
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
        }*/

        /*public void Connect(string _mailServerName, string _mailServerPort, string _userName, string _password)
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
        }*/

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
                        case "MailAddress":
                            FromMailAddress = kd.Value.Trim();
                            break;
                        case "EnableSSL":
                            UseSSL = kd.Value.Trim() == "TRUE" ? true : false;
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
                                        SendMailAsync(alarmMail);
                                    }
                                    // eğer mail alarm'a atanmış gecikme süresi varsa girilen süre sonra logic'in değerinin tekrardan kontrol edilmesi için timer olusturulur.
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
                    SendMailAsync(args.alarmMail);
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

                    logicText = logicText.ToUpper();
                    logicText = logicText.Replace("FALSE", "0");
                    logicText = logicText.Replace("TRUE", "1");
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