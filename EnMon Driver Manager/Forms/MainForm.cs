using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Drivers;
using EnMon_Driver_Manager.Drivers.Archiving;
using EnMon_Driver_Manager.Drivers.Mail;
using EnMon_Driver_Manager.Modbus;
using IniParser;
using IniParser.Model;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager
{
    public partial class MainForm : Form

    {
        #region Private Properties

#pragma warning disable CS0649 // Field 'MainForm.frm_devices' is never assigned to, and will always have its default value null
        private frm_Devices frm_devices;
#pragma warning restore CS0649 // Field 'MainForm.frm_devices' is never assigned to, and will always have its default value null
        private frm_SignalList frm_signallist;
        private frm_Email frm_email;
        private frm_EmailAlarms frm_emailAlarms;
        private ModbusTCP modbusTCP;
        private MailClient mailClient;
        private AbstractArchiving archivist;

        #endregion Private Properties

        #region Public Properties

        public AbstractDBHelper dbhelper;

        public bool IsDriverStarted { get; private set; }

        #endregion Public Properties

        #region Constructors

        public MainForm()

        {
            InitializeComponent();
            InitializeLanguageSettings();
            InitializeSettings();

            IsDriverStarted = false;

            WriteConfigFileLocationsToTextBoxes();

            InitializeDatabase();

            GetActiveDrivers();

        }

        #endregion Constructors

        #region Events

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsDriverStarted)
            {
                e.Cancel = true;
                MessageBox.Show("Sürücü şuan çalışmaktadır. Sürücüyü durdurmadan Yönetici'yi kapatamazsınız.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Programın dilini değiştirir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void switch_language(object sender, EventArgs e)
        {
            //if (sender.Equals(turkishToolStripMenuItem))
            //{
            //    turkishToolStripMenuItem.Checked = true;
            //    englishToolStripMenuItem.Checked = false;
            //    cul = CultureInfo.CreateSpecificCulture("tr");
            //}

            //else if (sender.Equals(englishToolStripMenuItem))
            //{
            //    turkishToolStripMenuItem.Checked = false;
            //    englishToolStripMenuItem.Checked = true;
            //    cul = CultureInfo.CreateSpecificCulture("en");
            //}

            //this.fileToolStripMenuItem.Text = res_man.GetString("File", cul);
            //this.editToolStripMenuItem.Text = res_man.GetString("Edit", cul);
            //this.languageToolStripMenuItem.Text = res_man.GetString("Language", cul);
            //this.turkishToolStripMenuItem.Text = res_man.GetString("Turkish", cul);
            //this.englishToolStripMenuItem.Text = res_man.GetString("English", cul);
            this.lblHeader.Text = res_man.GetString("EnMon Driver Manager", cul);
            this.btn_start.Text = res_man.GetString("btn_Start", cul);
            //this.chkBox_runOnStartup.Text = res_man.GetString("chkBox_runOnStartup", cul);

            Log.Instance.Info(String.Format("Language ayarları {0} olarak değiştirildi", cul));
        }

        /// <summary>
        /// Led'in method icersinde belirtilen sayıda yanıp sonmesini saglar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_led_Tick(object sender, EventArgs e)
        {
            pct_led.Visible = !pct_led.Visible;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            RunEnMon();
        }

        private async void RunEnMon()
        {
            if (!IsDriverStarted)
            {
                try
                {
                    timer_led.Start();
                    pct_led.Image = EnMon_Driver_Manager.Properties.Resources.green;
                    btn_start.Enabled = false;
                    Task t = Task.Factory.StartNew(StartDrivers);
                    await t;
                    btn_start.Text = res_man.GetString("btn_Stop", cul);
                    btn_start.Enabled = true;
                    DisableControls();
                    timer_led.Stop();
                    pct_led.Image = EnMon_Driver_Manager.Properties.Resources.green;
                    pct_led.Visible = true;
                }
                catch (Exception ex)
                {
                    Log.Instance.Error("{0}: EnMon Sürücüsü başlatılamadı => {1}", this.GetType().Name, ex.Message);
                    pct_led.Image = EnMon_Driver_Manager.Properties.Resources.red;
                    timer_led.Start();
                    btn_start.Enabled = false;
                    Task t = Task.Factory.StartNew(StopDrivers);
                    await t;
                    btn_start.Text = res_man.GetString("btn_Start", cul);
                    btn_start.Enabled = true;
                    timer_led.Stop();
                    pct_led.Image = EnMon_Driver_Manager.Properties.Resources.red;
                    pct_led.Visible = true;
                    throw;
                }
            }
            else
            {
                try
                {
                    timer_led.Start();
                    pct_led.Image = EnMon_Driver_Manager.Properties.Resources.red;
                    btn_start.Enabled = false;
                    Task t = Task.Factory.StartNew(StopDrivers);
                    await t;
                    btn_start.Text = res_man.GetString("btn_Start", cul);
                    btn_start.Enabled = true;
                    timer_led.Stop();
                    pct_led.Image = EnMon_Driver_Manager.Properties.Resources.red;
                    pct_led.Visible = true;
                }
                catch (Exception ex)
                {
                    Log.Instance.Error("{0}: EnMon Sürücüsü durdurururken hata oluştu => {1}", this.GetType().Name, ex.Message);
                    throw;
                }
            }
        }

        private void DragStart(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void OnDrag(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void DragEnd(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Close32MouseOut;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.Minus32MouseIn;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.Minus32MouseOut;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Close32MouseIn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (frm_devices == null)
            //{
            //    frm_Devices frm = new frm_Devices();
            //    frm.TopLevel = false;
            //    frm.FormBorderStyle = FormBorderStyle.None;
            //    if (modbusTCP != null)
            //    {
            //        frm.AddDevicesToForm(modbusTCP);
            //    }
            //    frm.StateChanged += UpdateDeviceActiveState;
            //    frm.Dock = DockStyle.Fill;
            //    panel_Main.Controls.Clear();
            //    panel_Main.Controls.Add(frm);
            //    frm.Visible = true;
            //    //(sender as Button).BackColor = Color.FromArgb(0, 0, 196, 174);
            //}
        }

        /// <summary>
        /// Updates the state of the device active.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="frm_DevicesEventArgs"/> instance containing the event data.</param>
        private void UpdateDeviceActiveState(object source, frm_DevicesEventArgs args)
        {
            // DeviceInfo control'unden gönderilen eventteki args'lara göre ilgili device'ın haberleşme durumu değiştirilir.
            if (modbusTCP != null)
            {
                // Device'ın drivera eklenip eklenmedigi kontrol edilir.
                if (modbusTCP.Devices.Exists(d => d.ID == args.deviceId))
                {
                    modbusTCP.Devices.Where(d => d.ID == args.deviceId).First().isActive = args.state;
                }
            }
            dbhelper.UpdateDeviceActiveState(args.deviceId, args.state);
            if (args.state)
            {
                Log.Instance.Info("{0} nolu Device için haberleşme aktif edildi", args.deviceId);
                // Haberleşme aktif edilse bile haberleşmenin kurulacağı kesin olmadığı için device.Connected burada true yapılmaz.
                // modbusTCP.Devices.Where(d => d.ID == args.deviceId).First().Connected = true;
            }
            else
            {
                Log.Instance.Info("{0} nolu Device için haberleşme kapatıldı", args.deviceId);
                if (modbusTCP != null)
                {
                    if (modbusTCP.Devices.Exists(d => d.ID == args.deviceId))
                    {
                        modbusTCP.Devices.Where(d => d.ID == args.deviceId).First().Connected = false;
                    }
                }

                dbhelper.UpdateDeviceConnectedState(args.deviceId, args.state);
                // Haberleşme kapatıldıgında haberleşme sağlanamayacağı için device.Connected burada false'a çekilir.
            }
        }

        private void MinimizeForm(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void ResizeForm(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }
        }

        private void GetFormBack(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void btn_Signals_Click(object sender, EventArgs e)
        {
        }

        private void btn_MailSettings_Click(object sender, EventArgs e)
        {
        }

        private void btn_Cihazlar_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbx_AutoStart.Checked = Properties.Settings.Default.StartDrivers == true ? true : false;
            //frm_devices = new frm_Devices();
            Load_frm_devices();

            //frm_signallist = new frm_SignalList();
            Load_frm_signalList();

            //frm_email = new frm_EmailSettings();
            Load_frm_eMailSettings();

            Load_frm_emailAlarms();

            if (Properties.Settings.Default.StartDrivers)
            {
                RunEnMon();
            }
        }

        private void yaTabControl1_TabChanged(object sender, EventArgs e)
        {
            switch (mainTabControl.SelectedTab.Text)
            {
                case "E-Posta Alarmları":
                    Load_frm_emailAlarms();
                    //frm_emailAlarms.LoadMailAlarmsToGridView();
                    break;

                default:
                    break;
            }
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

        #endregion Events

        #region Private Methods

        private DelegateEnMonDrivers EnMonDrivers;

        private void WriteConfigFileLocationsToTextBoxes()
        {
            if (Properties.Settings.Default.ModbusTCPDriverConfigFileLocation == "")
            {
                Properties.Settings.Default.ModbusTCPDriverConfigFileLocation = Constants.ModbusTCPDriverConfigFileLocation;
                Properties.Settings.Default.Save();
            }
            if (Properties.Settings.Default.DatabaseConfigFileLocation == "")
            {
                Properties.Settings.Default.DatabaseConfigFileLocation = Constants.MailClientConfigFileLocation;
                Properties.Settings.Default.Save();
            }
            txt_ModbusTCPConfigFileLocation.Text = Properties.Settings.Default.ModbusTCPDriverConfigFileLocation;
            txt_MailClientConfigFileLocation.Text = Properties.Settings.Default.DatabaseConfigFileLocation;
        }

        private void GetActiveDrivers()
        {
            if (chkBox_ModbusTCPCommunicationActivated.Checked)
            {
                EnMonDrivers += StartModbusDriver;
            }
            if (chkBox_ArchivingActivated.Checked)
            {
                EnMonDrivers += StartArchiving;
            }
            if (chkBox_AlarmMailingActivated.Checked)
            {
                EnMonDrivers += StartAlarmMailing;
            }
        }

        private void DisableControls()
        {
            foreach (Control ctrl in this.tab_DriverSettings.Controls)
            {
                ctrl.Enabled = false;
            }
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

        private void StartArchiving()
       {
            archivist = new ArchiveToDatabase();
        }

        private void InitializeDatabase()
        {
            if (dbhelper == null)
            {
                dbhelper = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            }
        }

        private void Load_frm_eMailSettings()
        {
            if (frm_email == null)
            {
                frm_email = new frm_Email();

                frm_email.TopLevel = false;
                frm_email.FormBorderStyle = FormBorderStyle.None;
                frm_email.Dock = DockStyle.Fill;
                panel_Email.Controls.Clear();
                panel_Email.Controls.Add(frm_email);
                frm_email.Visible = true;
            }
        }

        private void Load_frm_signalList()
        {
            if (frm_signallist == null)
            {
                frm_signallist = new frm_SignalList();
                frm_signallist.TopLevel = false;
                frm_signallist.FormBorderStyle = FormBorderStyle.None;
                frm_signallist.Dock = DockStyle.Fill;
                panel_SignalList.Controls.Clear();
                panel_SignalList.Controls.Add(frm_signallist);
                frm_signallist.Visible = true;
            }
        }

        private void Load_frm_devices()
        {
            if (frm_devices == null)
            {
                frm_Devices frm = new frm_Devices();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.StateChanged += UpdateDeviceActiveState;
                frm.Dock = DockStyle.Fill;
                panel_Devices.Controls.Clear();
                panel_Devices.Controls.Add(frm);
                frm.Visible = true;
            }
        }

        private void Load_frm_emailAlarms()
        {
            if (frm_emailAlarms == null)
            {
                frm_emailAlarms = new frm_EmailAlarms();

                frm_emailAlarms.TopLevel = false;
                frm_emailAlarms.FormBorderStyle = FormBorderStyle.None;
                frm_emailAlarms.Dock = DockStyle.Fill;
                panel_EmailAlarms.Controls.Clear();
                panel_EmailAlarms.Controls.Add(frm_emailAlarms);
                frm_emailAlarms.Visible = true;
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

        private void InitializeSettings()
        {
            if (!Properties.Settings.Default.Initialized)
            {
                Properties.Settings.Default.ModbusTCPDriverConfigFileLocation = Constants.ModbusTCPDriverConfigFileLocation;
                Properties.Settings.Default.MailClientConfigFileLocation = Constants.MailClientConfigFileLocation;
                Properties.Settings.Default.DatabaseConfigFileLocation = Constants.DatabaseConfigFileLocation;
                Properties.Settings.Default.Initialized = true;
                Properties.Settings.Default.Save();
            }
        }

        private void StopDrivers()
        {
            if (modbusTCP != null)
            {
                foreach (ModbusTCPClient client in modbusTCP)
                {
                    client.Dismiss();
                }

                if (dbhelper != null)
                {
                    modbusTCP.SetAllDevicesDisconnected();

                    while (dbhelper.HasAnyValuAtBuffers())
                    {
                    }

                }
                modbusTCP = null;
            }
            if (mailClient != null)
            {
                mailClient = null;
            }
            if (archivist != null)
            {
                archivist = null;
            }
            IsDriverStarted = false;

            Log.Instance.Info("EnMon Sürücü Yöneticisi durduruldu.");
        }

        private void StartDrivers()
        {
            timer_led.Start();

            EnMonDrivers();

            timer_led.Stop();

            IsDriverStarted = true;
            Log.Instance.Info("EnMon Sürücü Yöneticisi Başlatıldı");
        }

        #endregion Private Methods

        private void cbx_AutoStart_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartDrivers = cbx_AutoStart.Checked;
            Properties.Settings.Default.Save();
        }
    }

    public delegate void DelegateEnMonDrivers();
}