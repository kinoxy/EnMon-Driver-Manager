using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Drivers.Mail
{
    public class MailClient : IDisposable
    {
        private string MailServerName;
        private string MailServerPort;
        private string UserName;
        private string Password;
        private SmtpClient client;
        public SmtpClient Client
        {
            get { return client; }
            set { client = value; }
        } 

        public MailClient(string _mailServerName, string _mailServerPort, string _userName, string _password)
        {
            MailServerName = _mailServerName;
            MailServerPort = _mailServerPort;
            UserName = _userName;
            Password = _password;

            client = new SmtpClient();

            client.ServerCertificateValidationCallback = (s, c, h, fe) => true;

            client.Connect(_mailServerName, Convert.ToInt32(_mailServerPort), false);

            client.AuthenticationMechanisms.Remove("XOAUTH2");

            client.Authenticate(_userName, _password);
        }

        public void Dispose()
        {
            Client = null;
        }

        public void SendMail(List<string> toWho, MimeEntity _message, string _subject = "Enmon Enerji Takibi")
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
    }
}
