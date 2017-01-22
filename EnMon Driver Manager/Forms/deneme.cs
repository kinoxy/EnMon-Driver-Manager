using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models;
using EnMon_Driver_Manager.Models.Signals.Modbus;

namespace EnMon_Driver_Manager.Forms
{
    public partial class deneme : Form
    {
        private AbstractDBHelper DatabaseHelper;
        public deneme()
        {
            InitializeComponent();
            
        }

        private async void button1_Click(object sender, EventArgs e)
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
                    var result = await  Messenger.GetAsync(VersionCode.V1,
                        new IPEndPoint(IPAddress.Parse(textBox1.Text), 161),
                        new OctetString("public"),
                        new List<Variable> {new Variable(new ObjectIdentifier(textBox2.Text))});
                    
                    //result = Messenger.Get(VersionCode.V1,
                    //    new IPEndPoint(IPAddress.Parse(textBox1.Text), 161),
                    //    new OctetString("public"),
                    //    new List<Variable> { new Variable(new ObjectIdentifier(textBox2.Text)) },
                    //    5000);


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

        private void deneme_Load(object sender, EventArgs e)
        {
            DatabaseHelper = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            ModbusAnalogSignal signal = new ModbusAnalogSignal();
            if (DatabaseHelper != null)
            {
                TemporaryValues.stations = DatabaseHelper.GetAllStationsInfoWithDeviceInfo();
                TemporaryValues.archivePeriods = DatabaseHelper.GetArchivePeriods();
                TemporaryValues.dataTypes = DatabaseHelper.GetAllDataTypes();
                TemporaryValues.statusTexts = DatabaseHelper.GetAllStatusTexts();
            }
            propertyGrid1.SelectedObject = signal;
        }

        private void PropertyGrid1OnKeyPress(object sender, KeyPressEventArgs keyPressEventArgs)
        {
            propertyGrid1.Refresh();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            
        }
    }
}
