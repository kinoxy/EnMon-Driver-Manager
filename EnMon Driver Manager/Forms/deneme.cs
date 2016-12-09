using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Forms
{
    public partial class deneme : Form
    {
        public deneme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient client = new TcpClient();
                IAsyncResult asyncResult = client.BeginConnect(textBox1.Text, 161, null, null);
                // readTimeOut süresi kadar saniye içerisinde bağlantının kurulması bekleniyor.
                asyncResult.AsyncWaitHandle.WaitOne(3000, true);
                // readTimeOut süresi sonunda TCP baglantısı kurulamazsa
                if (asyncResult.IsCompleted)
                {
                    IList<Variable> result = Messenger.Get(VersionCode.V1,
                                                new IPEndPoint(IPAddress.Parse(textBox1.Text), 161),
                                                new OctetString("public"),
                                                new List<Variable> { new Variable(new ObjectIdentifier(textBox2.Text)) },
                                                5000);

                    textBox3.Text = result[0].Data.ToString();

                    GetNextRequestMessage message = new GetNextRequestMessage(0,
                                                              VersionCode.V1,
                                                              new OctetString("public"),
                                                              new List<Variable> { new Variable(new ObjectIdentifier("1.3.6.1.2.1.1.6.0")) });
                    ISnmpMessage response = message.GetResponse(60000, new IPEndPoint(IPAddress.Parse(textBox1.Text), 161));
                    if (response.Pdu().ErrorStatus.ToInt32() != 0)
                    {
                        //throw ErrorException.Create("error in response",receiver.Address,response);
                    }

                    var result1 = response.Pdu().Variables;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
