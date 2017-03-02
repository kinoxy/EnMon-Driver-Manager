using EnMon_Driver_Manager.Drivers.Archiving;
using EnMon_Driver_Manager.Drivers.Mail;
using EnMon_Driver_Manager.Modbus;
using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Forms
{
    public partial class frm_Drivers : Form
    {
        private ModbusTCP modbusTCP;
        private MailClient mailClient;
        private AbstractArchiving archivist;
        public frm_Drivers()
        {
            InitializeComponent();
        }

        private void chkBox_ModbusTCPCommunicationActivated_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox_ModbusTCPCommunicationActivated.Checked)
            {
                if (!IsDriverAdded("StartModbusDriver"))
                {
                    EnMonDrivers += StartModbusDriver;
                }
            }
            else
            {
                EnMonDrivers -= StartModbusDriver;
            }
        }

        private void chkBox_ArchivingActivated_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox_ModbusTCPCommunicationActivated.Checked)
            {
                if (!IsDriverAdded("StartArchiving"))
                {
                    EnMonDrivers += StartArchiving;
                }
            }
            else
            {
                EnMonDrivers -= StartArchiving;
            }
        }
        
        private void chkBox_AlarmMailingActivated_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox_ModbusTCPCommunicationActivated.Checked)
            {
                if (!IsDriverAdded("StartAlarmMailing"))
                {
                    EnMonDrivers += StartAlarmMailing;
                }
            }
            else
            {
                EnMonDrivers -= StartAlarmMailing;
            }
        }
        private void StartArchiving()
        {
            archivist = new ArchiveToDatabase();
        }
        private void btn_ChangeModbusDriverConfigFileLocation_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Ini Files (*.ini)|*.ini";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(ofd.FileName) == ".ini")
                {
                    var parser = new FileIniDataParser();
                    IniData data = parser.ReadFile(ofd.FileName, Encoding.UTF8);
                    SectionDataCollection sdc = data.Sections;
                    if (sdc.First().SectionName == "Communication Parameters")
                    {
                        Properties.Settings.Default.ModbusTCPDriverConfigFileLocation = ofd.FileName;
                        Properties.Settings.Default.Save();
                        txt_ModbusTCPConfigFileLocation.Text = ofd.FileName;
                    }
                    else
                    {
                        MessageBox.Show("Seçtiğiniz dosya 'Modbus Haberleşme Ayarları' dosyası değil. Lütfen doğru dosyayı seçiniz.");
                    }
                }
                else
                {
                    Log.Instance.Info("{0}: Seçilen dosya bir yapılandırma ayarları dosyası değil.", this.GetType().Name);
                    MessageBox.Show("Seçilen dosya 'Yapılandırma Ayarları' dosyası değil!", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void StartAlarmMailing()
        {
            // MailClient Config dosyası mevcutsa
            if (File.Exists(Constants.MailClientConfigFileLocation))
            {
                Task t1 = Task.Factory.StartNew(() =>
                {
                    mailClient = new MailClient(Constants.MailClientConfigFileLocation);
                    mailClient.StartDriver();
                });
                await t1;
            }
            else
            {
                Log.Instance.Error("{0}: Alarm Mail Driver'ı Config dosyası bulunamadığı için başlatılamadı.", this.GetType().Name);
            }
        }
        private void btn_ChangeMailClientConfigFileLocation_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Ini Files (*.ini)|*.ini";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(ofd.FileName) == ".ini")
                {
                    var parser = new FileIniDataParser();
                    IniData data = parser.ReadFile(ofd.FileName, Encoding.UTF8);
                    SectionDataCollection sdc = data.Sections;
                    if (sdc.First().SectionName == "MailClient Parameters")
                    {
                        Properties.Settings.Default.MailClientConfigFileLocation = ofd.FileName;
                        Properties.Settings.Default.Save();
                        txt_MailClientConfigFileLocation.Text = ofd.FileName;
                    }
                    else
                    {
                        MessageBox.Show("Seçtiğiniz dosya 'Alarm E-Postaları Gönderimi Ayar' dosyası değil. Lütfen doğru dosyayı seçiniz.");
                    }
                }
                else
                {
                    Log.Instance.Info("{0}: Seçilen dosya bir yapılandırma ayarları dosyası değil.", this.GetType().Name);
                    MessageBox.Show("Seçilen dosya 'Yapılandırma Ayarları' dosyası değil!", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsDriverAdded(string driverStartMethodName)
        {
            if (this.EnMonDrivers != null)
            {
                foreach (Delegate existingMethods in this.EnMonDrivers.GetInvocationList())
                {
                    if (existingMethods.Method.Name == driverStartMethodName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private DelegateEnMonDrivers EnMonDrivers;

        private void btn_ChangeModbusDriverConfigFileLocation_Click_1(object sender, EventArgs e)
        {

        }
     

    private async void StartModbusDriver()
    {
        // ModbusTCP Config dosyası mevcutsa
        if (File.Exists(Constants.ModbusTCPDriverConfigFileLocation))
        {
            // Ayrı bir thread içerisinde ModbusTCP driver'ı çalıştırılıyor.
            Task t1 = Task.Factory.StartNew(() =>
            {
                modbusTCP = new ModbusTCP(Constants.ModbusTCPDriverConfigFileLocation);
                modbusTCP.SetAllDevicesDisconnected();
                modbusTCP.StartCommunication();
            });
            await t1;
        }
        else
        {
            Log.Instance.Error("{0}: Modbus Driver Config dosyası bulunamadığı için ModbusDriver başlatılamadı.", this.GetType().Name);
        }
    }

    public delegate void DelegateEnMonDrivers();
}
}
