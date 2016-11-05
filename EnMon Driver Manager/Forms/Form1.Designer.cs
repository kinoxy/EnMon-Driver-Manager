using System.Drawing;
using System.Globalization;
using System.Resources;

namespace EnMon_Driver_Manager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ResourceManager res_man;    // Programda çeşitli dilleri kullanabilmek için resourcemanager yaratılıyor
        private CultureInfo cul;            // CultureInfo variable yaratılıyor;
        private int timer_led_count;            // timer_led içinde sayacak olan counter

        // Drag & Drop variables
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_start = new System.Windows.Forms.Button();
            this.timer_led = new System.Windows.Forms.Timer(this.components);
            this.headerPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pct_led = new System.Windows.Forms.PictureBox();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl = new GrayIris.Utilities.UI.Controls.YaTabControl();
            this.tab_DriverSettings = new GrayIris.Utilities.UI.Controls.YaTabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkBox_AlarmMailingActivated = new System.Windows.Forms.CheckBox();
            this.txt_MailClientConfigFileLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ChangeMailClientConfigFileLocation = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBox_ArchivingActivated = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBox_ModbusTCPCommunicationActivated = new System.Windows.Forms.CheckBox();
            this.txt_ModbusTCPConfigFileLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ChangeModbusDriverConfigFileLocation = new System.Windows.Forms.Button();
            this.tabPage1 = new GrayIris.Utilities.UI.Controls.YaTabPage();
            this.panel_Devices = new System.Windows.Forms.Panel();
            this.tabPage2 = new GrayIris.Utilities.UI.Controls.YaTabPage();
            this.panel_SignalList = new System.Windows.Forms.Panel();
            this.tabPage3 = new GrayIris.Utilities.UI.Controls.YaTabPage();
            this.panel_Email = new System.Windows.Forms.Panel();
            this.tabPage4 = new GrayIris.Utilities.UI.Controls.YaTabPage();
            this.panel_EmailAlarms = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_led)).BeginInit();
            this.panel_Main.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tab_DriverSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.ForeColor = System.Drawing.Color.Black;
            this.btn_start.Location = new System.Drawing.Point(10, 13);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(176, 37);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Sürücüyü Başlat";
            this.btn_start.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // timer_led
            // 
            this.timer_led.Interval = 500;
            this.timer_led.Tick += new System.EventHandler(this.timer_led_Tick);
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.headerPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.headerPanel.Controls.Add(this.pictureBox2);
            this.headerPanel.Controls.Add(this.pictureBox1);
            this.headerPanel.Controls.Add(this.lblHeader);
            this.headerPanel.Location = new System.Drawing.Point(-86, 1);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(871, 37);
            this.headerPanel.TabIndex = 7;
            this.headerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragStart);
            this.headerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDrag);
            this.headerPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragEnd);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = global::EnMon_Driver_Manager.Properties.Resources.Minus32MouseOut;
            this.pictureBox2.Location = new System.Drawing.Point(816, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.MinimizeForm);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::EnMon_Driver_Manager.Properties.Resources.Close32MouseOut;
            this.pictureBox1.Location = new System.Drawing.Point(843, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHeader.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHeader.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHeader.Location = new System.Drawing.Point(91, 4);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(233, 29);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "EnMon Driver Manager";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragStart);
            this.lblHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDrag);
            this.lblHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragEnd);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Hey artık burdayım :)";
            this.notifyIcon.BalloonTipTitle = "EnMon Driver Manager";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "EnMon Sürücü Yöneticisi";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.GetFormBack);
            // 
            // pct_led
            // 
            this.pct_led.Image = global::EnMon_Driver_Manager.Properties.Resources.red;
            this.pct_led.Location = new System.Drawing.Point(210, 13);
            this.pct_led.Name = "pct_led";
            this.pct_led.Size = new System.Drawing.Size(37, 37);
            this.pct_led.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_led.TabIndex = 3;
            this.pct_led.TabStop = false;
            // 
            // panel_Main
            // 
            this.panel_Main.BackColor = System.Drawing.Color.SteelBlue;
            this.panel_Main.Controls.Add(this.tabControl);
            this.panel_Main.Controls.Add(this.pct_led);
            this.panel_Main.Controls.Add(this.btn_start);
            this.panel_Main.Location = new System.Drawing.Point(2, 37);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(783, 616);
            this.panel_Main.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(44, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(340, 97);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.ActiveColor = System.Drawing.Color.SteelBlue;
            this.tabControl.BackColor = System.Drawing.Color.SteelBlue;
            this.tabControl.BorderColor = System.Drawing.Color.SteelBlue;
            this.tabControl.CloseButton = false;
            this.tabControl.Controls.Add(this.tab_DriverSettings);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.HoverColor = System.Drawing.Color.Azure;
            this.tabControl.ImageIndex = -1;
            this.tabControl.ImageList = null;
            this.tabControl.InactiveColor = System.Drawing.Color.Azure;
            this.tabControl.Location = new System.Drawing.Point(0, 63);
            this.tabControl.Name = "tabControl";
            this.tabControl.NewTabButton = false;
            this.tabControl.OverIndex = -1;
            this.tabControl.ScrollButtonStyle = GrayIris.Utilities.UI.Controls.YaScrollButtonStyle.Always;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedTab = this.tab_DriverSettings;
            this.tabControl.Size = new System.Drawing.Size(783, 553);
            this.tabControl.TabDock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.TabDrawer = null;
            this.tabControl.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl.TabIndex = 4;
            this.tabControl.Text = "tabControl";
            this.tabControl.TabChanged += new System.EventHandler(this.yaTabControl1_TabChanged);
            // 
            // tab_DriverSettings
            // 
            this.tab_DriverSettings.Controls.Add(this.groupBox3);
            this.tab_DriverSettings.Controls.Add(this.groupBox2);
            this.tab_DriverSettings.Controls.Add(this.groupBox1);
            this.tab_DriverSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_DriverSettings.ImageIndex = -1;
            this.tab_DriverSettings.Location = new System.Drawing.Point(4, 31);
            this.tab_DriverSettings.Name = "tab_DriverSettings";
            this.tab_DriverSettings.Size = new System.Drawing.Size(775, 518);
            this.tab_DriverSettings.TabIndex = 0;
            this.tab_DriverSettings.Text = "Sürücü Ayarları";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkBox_AlarmMailingActivated);
            this.groupBox3.Controls.Add(this.txt_MailClientConfigFileLocation);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btn_ChangeMailClientConfigFileLocation);
            this.groupBox3.Location = new System.Drawing.Point(6, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(762, 98);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Alarm E-Postaları Gönderimi";
            // 
            // chkBox_AlarmMailingActivated
            // 
            this.chkBox_AlarmMailingActivated.AutoSize = true;
            this.chkBox_AlarmMailingActivated.Checked = true;
            this.chkBox_AlarmMailingActivated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_AlarmMailingActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkBox_AlarmMailingActivated.Location = new System.Drawing.Point(128, 60);
            this.chkBox_AlarmMailingActivated.Name = "chkBox_AlarmMailingActivated";
            this.chkBox_AlarmMailingActivated.Size = new System.Drawing.Size(290, 20);
            this.chkBox_AlarmMailingActivated.TabIndex = 3;
            this.chkBox_AlarmMailingActivated.Text = "E-Posta Alarm Gönderimini Sürücü İle Başlat";
            this.chkBox_AlarmMailingActivated.UseVisualStyleBackColor = true;
            this.chkBox_AlarmMailingActivated.CheckedChanged += new System.EventHandler(this.chkBox_AlarmMailingActivated_CheckedChanged);
            // 
            // txt_MailClientConfigFileLocation
            // 
            this.txt_MailClientConfigFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_MailClientConfigFileLocation.Location = new System.Drawing.Point(128, 19);
            this.txt_MailClientConfigFileLocation.Name = "txt_MailClientConfigFileLocation";
            this.txt_MailClientConfigFileLocation.Size = new System.Drawing.Size(510, 22);
            this.txt_MailClientConfigFileLocation.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ayar Dosyası Konumu :";
            // 
            // btn_ChangeMailClientConfigFileLocation
            // 
            this.btn_ChangeMailClientConfigFileLocation.Location = new System.Drawing.Point(655, 17);
            this.btn_ChangeMailClientConfigFileLocation.Name = "btn_ChangeMailClientConfigFileLocation";
            this.btn_ChangeMailClientConfigFileLocation.Size = new System.Drawing.Size(86, 27);
            this.btn_ChangeMailClientConfigFileLocation.TabIndex = 0;
            this.btn_ChangeMailClientConfigFileLocation.Text = "Değiştir";
            this.btn_ChangeMailClientConfigFileLocation.UseVisualStyleBackColor = true;
            this.btn_ChangeMailClientConfigFileLocation.Click += new System.EventHandler(this.btn_ChangeMailClientConfigFileLocation_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkBox_ArchivingActivated);
            this.groupBox2.Location = new System.Drawing.Point(6, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(762, 55);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Arşivleme";
            // 
            // chkBox_ArchivingActivated
            // 
            this.chkBox_ArchivingActivated.AutoSize = true;
            this.chkBox_ArchivingActivated.Checked = true;
            this.chkBox_ArchivingActivated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_ArchivingActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkBox_ArchivingActivated.Location = new System.Drawing.Point(128, 19);
            this.chkBox_ArchivingActivated.Name = "chkBox_ArchivingActivated";
            this.chkBox_ArchivingActivated.Size = new System.Drawing.Size(199, 20);
            this.chkBox_ArchivingActivated.TabIndex = 3;
            this.chkBox_ArchivingActivated.Text = "Arşivlemeyi Sürücü İle Başlat";
            this.chkBox_ArchivingActivated.UseVisualStyleBackColor = true;
            this.chkBox_ArchivingActivated.CheckedChanged += new System.EventHandler(this.chkBox_ArchivingActivated_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBox_ModbusTCPCommunicationActivated);
            this.groupBox1.Controls.Add(this.txt_ModbusTCPConfigFileLocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_ChangeModbusDriverConfigFileLocation);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 98);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modbus TCP Haberleşmesi";
            // 
            // chkBox_ModbusTCPCommunicationActivated
            // 
            this.chkBox_ModbusTCPCommunicationActivated.AutoSize = true;
            this.chkBox_ModbusTCPCommunicationActivated.Checked = true;
            this.chkBox_ModbusTCPCommunicationActivated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_ModbusTCPCommunicationActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkBox_ModbusTCPCommunicationActivated.Location = new System.Drawing.Point(128, 60);
            this.chkBox_ModbusTCPCommunicationActivated.Name = "chkBox_ModbusTCPCommunicationActivated";
            this.chkBox_ModbusTCPCommunicationActivated.Size = new System.Drawing.Size(306, 20);
            this.chkBox_ModbusTCPCommunicationActivated.TabIndex = 3;
            this.chkBox_ModbusTCPCommunicationActivated.Text = "Modbus TCP Haberleşmesini Sürücü İle Başlat";
            this.chkBox_ModbusTCPCommunicationActivated.UseVisualStyleBackColor = true;
            this.chkBox_ModbusTCPCommunicationActivated.CheckedChanged += new System.EventHandler(this.chkBox_ModbusTCPCommunicationActivated_CheckedChanged);
            // 
            // txt_ModbusTCPConfigFileLocation
            // 
            this.txt_ModbusTCPConfigFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_ModbusTCPConfigFileLocation.Location = new System.Drawing.Point(128, 19);
            this.txt_ModbusTCPConfigFileLocation.Name = "txt_ModbusTCPConfigFileLocation";
            this.txt_ModbusTCPConfigFileLocation.Size = new System.Drawing.Size(510, 22);
            this.txt_ModbusTCPConfigFileLocation.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ayar Dosyası Konumu :";
            // 
            // btn_ChangeModbusDriverConfigFileLocation
            // 
            this.btn_ChangeModbusDriverConfigFileLocation.Location = new System.Drawing.Point(655, 17);
            this.btn_ChangeModbusDriverConfigFileLocation.Name = "btn_ChangeModbusDriverConfigFileLocation";
            this.btn_ChangeModbusDriverConfigFileLocation.Size = new System.Drawing.Size(86, 27);
            this.btn_ChangeModbusDriverConfigFileLocation.TabIndex = 0;
            this.btn_ChangeModbusDriverConfigFileLocation.Text = "Değiştir";
            this.btn_ChangeModbusDriverConfigFileLocation.UseVisualStyleBackColor = true;
            this.btn_ChangeModbusDriverConfigFileLocation.Click += new System.EventHandler(this.btn_ChangeModbusDriverConfigFileLocation_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel_Devices);
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.ImageIndex = -1;
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(775, 518);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Cihazlar";
            // 
            // panel_Devices
            // 
            this.panel_Devices.AutoScroll = true;
            this.panel_Devices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Devices.Location = new System.Drawing.Point(0, 0);
            this.panel_Devices.Name = "panel_Devices";
            this.panel_Devices.Size = new System.Drawing.Size(775, 518);
            this.panel_Devices.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.tabPage2.Controls.Add(this.panel_SignalList);
            this.tabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage2.ImageIndex = -1;
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(775, 518);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sinyaller";
            // 
            // panel_SignalList
            // 
            this.panel_SignalList.BackColor = System.Drawing.Color.SteelBlue;
            this.panel_SignalList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_SignalList.Location = new System.Drawing.Point(0, 0);
            this.panel_SignalList.Name = "panel_SignalList";
            this.panel_SignalList.Size = new System.Drawing.Size(775, 518);
            this.panel_SignalList.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel_Email);
            this.tabPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage3.ImageIndex = -1;
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(775, 518);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "E-Posta Ayarları";
            // 
            // panel_Email
            // 
            this.panel_Email.BackColor = System.Drawing.Color.SteelBlue;
            this.panel_Email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Email.Location = new System.Drawing.Point(0, 0);
            this.panel_Email.Name = "panel_Email";
            this.panel_Email.Size = new System.Drawing.Size(775, 518);
            this.panel_Email.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel_EmailAlarms);
            this.tabPage4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage4.ImageIndex = -1;
            this.tabPage4.Location = new System.Drawing.Point(4, 31);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(775, 518);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "E-Posta Alarmları";
            // 
            // panel_EmailAlarms
            // 
            this.panel_EmailAlarms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_EmailAlarms.Location = new System.Drawing.Point(0, 0);
            this.panel_EmailAlarms.Name = "panel_EmailAlarms";
            this.panel_EmailAlarms.Size = new System.Drawing.Size(775, 518);
            this.panel_EmailAlarms.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(786, 653);
            this.Controls.Add(this.panel_Main);
            this.Controls.Add(this.headerPanel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "EnMon Driver Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_led)).EndInit();
            this.panel_Main.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tab_DriverSettings.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitializeLanguageSettings()
        {
            res_man = new ResourceManager("EnMon_Driver_Manager.Resources.res", typeof(MainForm).Assembly);
            cul = CultureInfo.CreateSpecificCulture("tr");

            //
            //  Components
            //
            //this.fileToolStripMenuItem.Text = res_man.GetString("File", cul);
            //this.editToolStripMenuItem.Text = res_man.GetString("Edit", cul);
            //this.languageToolStripMenuItem.Text = res_man.GetString("Language", cul);
            //this.turkishToolStripMenuItem.Text = res_man.GetString("Turkish", cul);
            //this.englishToolStripMenuItem.Text = res_man.GetString("English", cul);
            this.lblHeader.Text = res_man.GetString("EnMon_Driver_Manager", cul);

        }



        #endregion
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.PictureBox pct_led;
        private System.Windows.Forms.Timer timer_led;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel_Main;

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private GrayIris.Utilities.UI.Controls.YaTabControl tabControl;
        private GrayIris.Utilities.UI.Controls.YaTabPage tabPage1;
        private GrayIris.Utilities.UI.Controls.YaTabPage tabPage2;
        private GrayIris.Utilities.UI.Controls.YaTabPage tabPage3;
        private GrayIris.Utilities.UI.Controls.YaTabPage tabPage4;
        private System.Windows.Forms.Panel panel_Devices;
        private System.Windows.Forms.Panel panel_SignalList;
        private System.Windows.Forms.Panel panel_Email;
        private System.Windows.Forms.Panel panel_EmailAlarms;
        private GrayIris.Utilities.UI.Controls.YaTabPage tab_DriverSettings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkBox_AlarmMailingActivated;
        private System.Windows.Forms.TextBox txt_MailClientConfigFileLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ChangeMailClientConfigFileLocation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkBox_ArchivingActivated;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBox_ModbusTCPCommunicationActivated;
        private System.Windows.Forms.TextBox txt_ModbusTCPConfigFileLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ChangeModbusDriverConfigFileLocation;
    }
}

