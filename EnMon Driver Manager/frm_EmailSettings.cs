using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EnMon_Driver_Manager
{
    public partial class frm_EmailSettings : Form
    {
        private string MailServerName { get; set; }
        private string MailServerPort { get; set; }

        private string MailServerUserName { get; set; }
        private string MailServerPassword { get; set; }
        private AbstractDbHelper DBHelper { get; set; }
        public frm_EmailSettings()
        {
            InitializeComponent();
            InitializeDBConnection();
        }

        private void InitializeDBConnection()
        {
            if(File.Exists("/Config/DatabaseConfig.ini"))
            {
                
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_MailServerName.Text != null || txt_MailServerPort.Text != null || txt_Password.Text != null || txt_UserName.Text != null)
                {
                    using (var client = new SmtpClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, fe) => true;

                        client.Connect(txt_MailServerName.Text, Convert.ToInt32(txt_MailServerPort.Text), false);

                        client.AuthenticationMechanisms.Remove("XOAUTH2");

                        client.Authenticate(txt_UserName.Text, txt_Password.Text);

                        var message = new MimeMessage();

                        message.From.Add(new MailboxAddress("EnMon Enerji Takip Sistemi", txt_UserName.Text));

                        message.To.Add(new MailboxAddress("deneme", txt_UserName.Text));

                        message.Subject = "Alarm";

                        message.Body = new TextPart("plain")
                        {
                            Text = @"Merhaba
Bu bir deneme mesajıdır.

EnMon Enerji Takip Sistemi"
                        };

                        client.Send(message);

                        client.Disconnect(true);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
