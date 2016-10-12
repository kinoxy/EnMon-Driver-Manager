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
            this.chkBox_runOnStartup = new System.Windows.Forms.CheckBox();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.btn_MailSettings = new System.Windows.Forms.Button();
            this.btn_Signals = new System.Windows.Forms.Button();
            this.btn_Cihazlar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pct_led = new System.Windows.Forms.PictureBox();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.tabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.sidePanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_led)).BeginInit();
            this.panel_Main.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_start.Location = new System.Drawing.Point(46, 54);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(176, 51);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Başlat";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // timer_led
            // 
            this.timer_led.Interval = 500;
            this.timer_led.Tick += new System.EventHandler(this.timer_led_Tick);
            // 
            // chkBox_runOnStartup
            // 
            this.chkBox_runOnStartup.AutoSize = true;
            this.chkBox_runOnStartup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(147)))), ((int)(((byte)(145)))));
            this.chkBox_runOnStartup.Location = new System.Drawing.Point(46, 150);
            this.chkBox_runOnStartup.Name = "chkBox_runOnStartup";
            this.chkBox_runOnStartup.Size = new System.Drawing.Size(358, 17);
            this.chkBox_runOnStartup.TabIndex = 4;
            this.chkBox_runOnStartup.Text = "Windows başladığında EnMon Driver Manager\'ı otomatik olarak başlat.";
            this.chkBox_runOnStartup.UseVisualStyleBackColor = true;
            // 
            // sidePanel
            // 
            this.sidePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.sidePanel.Controls.Add(this.btn_MailSettings);
            this.sidePanel.Controls.Add(this.btn_Signals);
            this.sidePanel.Controls.Add(this.btn_Cihazlar);
            this.sidePanel.Controls.Add(this.button1);
            this.sidePanel.Controls.Add(this.logoPanel);
            this.sidePanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(180, 564);
            this.sidePanel.TabIndex = 6;
            // 
            // btn_MailSettings
            // 
            this.btn_MailSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btn_MailSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_MailSettings.FlatAppearance.BorderSize = 0;
            this.btn_MailSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(82)))), ((int)(((byte)(98)))));
            this.btn_MailSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_MailSettings.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_MailSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(147)))), ((int)(((byte)(145)))));
            this.btn_MailSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_MailSettings.Location = new System.Drawing.Point(5, 204);
            this.btn_MailSettings.Name = "btn_MailSettings";
            this.btn_MailSettings.Size = new System.Drawing.Size(169, 46);
            this.btn_MailSettings.TabIndex = 11;
            this.btn_MailSettings.Text = "Email";
            this.btn_MailSettings.UseVisualStyleBackColor = false;
            this.btn_MailSettings.Click += new System.EventHandler(this.btn_MailSettings_Click);
            // 
            // btn_Signals
            // 
            this.btn_Signals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btn_Signals.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Signals.FlatAppearance.BorderSize = 0;
            this.btn_Signals.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(82)))), ((int)(((byte)(98)))));
            this.btn_Signals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Signals.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Signals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(147)))), ((int)(((byte)(145)))));
            this.btn_Signals.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Signals.Location = new System.Drawing.Point(5, 108);
            this.btn_Signals.Name = "btn_Signals";
            this.btn_Signals.Size = new System.Drawing.Size(169, 46);
            this.btn_Signals.TabIndex = 10;
            this.btn_Signals.Text = "Sinyal Listesi";
            this.btn_Signals.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Signals.UseVisualStyleBackColor = false;
            this.btn_Signals.Click += new System.EventHandler(this.btn_Signals_Click);
            // 
            // btn_Cihazlar
            // 
            this.btn_Cihazlar.AutoSize = true;
            this.btn_Cihazlar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btn_Cihazlar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Cihazlar.FlatAppearance.BorderSize = 0;
            this.btn_Cihazlar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(82)))), ((int)(((byte)(98)))));
            this.btn_Cihazlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cihazlar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Cihazlar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(147)))), ((int)(((byte)(145)))));
            this.btn_Cihazlar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cihazlar.Location = new System.Drawing.Point(5, 152);
            this.btn_Cihazlar.Name = "btn_Cihazlar";
            this.btn_Cihazlar.Size = new System.Drawing.Size(169, 46);
            this.btn_Cihazlar.TabIndex = 9;
            this.btn_Cihazlar.Text = "Cihazlar";
            this.btn_Cihazlar.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(82)))), ((int)(((byte)(98)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(147)))), ((int)(((byte)(145)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(5, 60);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 46);
            this.button1.TabIndex = 8;
            this.button1.Text = "            Başlat";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.logoPanel.BackgroundImage = global::EnMon_Driver_Manager.Properties.Resources.logoTR;
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logoPanel.Size = new System.Drawing.Size(180, 55);
            this.logoPanel.TabIndex = 0;
            this.logoPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragStart);
            this.logoPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDrag);
            this.logoPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragEnd);
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.headerPanel.Controls.Add(this.pictureBox2);
            this.headerPanel.Controls.Add(this.pictureBox1);
            this.headerPanel.Controls.Add(this.lblHeader);
            this.headerPanel.Location = new System.Drawing.Point(180, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(783, 54);
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
            this.pictureBox2.Location = new System.Drawing.Point(695, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
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
            this.pictureBox1.Location = new System.Drawing.Point(739, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
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
            this.lblHeader.Font = new System.Drawing.Font("AR DESTINE", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Firebrick;
            this.lblHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(367, 38);
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
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.GetFormBack);
            // 
            // pct_led
            // 
            this.pct_led.Image = global::EnMon_Driver_Manager.Properties.Resources.red;
            this.pct_led.Location = new System.Drawing.Point(242, 54);
            this.pct_led.Name = "pct_led";
            this.pct_led.Size = new System.Drawing.Size(53, 51);
            this.pct_led.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_led.TabIndex = 3;
            this.pct_led.TabStop = false;
            // 
            // panel_Main
            // 
            this.panel_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.panel_Main.Controls.Add(this.tabControl1);
            this.panel_Main.Controls.Add(this.chkBox_runOnStartup);
            this.panel_Main.Controls.Add(this.pct_led);
            this.panel_Main.Controls.Add(this.btn_start);
            this.panel_Main.Location = new System.Drawing.Point(180, 54);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(783, 510);
            this.panel_Main.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.CustomBackground = true;
            this.tabControl1.Location = new System.Drawing.Point(3, 182);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(777, 302);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.UseStyleColors = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tabPage1.HorizontalScrollbarBarColor = true;
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(769, 260);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.VerticalScrollbarBarColor = true;
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
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.ForeColor = System.Drawing.Color.Gray;
            this.tabPage2.HorizontalScrollbarBarColor = true;
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(769, 260);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.VerticalScrollbarBarColor = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(963, 564);
            this.Controls.Add(this.panel_Main);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.sidePanel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "EnMon Driver Manager";
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_led)).EndInit();
            this.panel_Main.ResumeLayout(false);
            this.panel_Main.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox chkBox_runOnStartup;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btn_MailSettings;
        private System.Windows.Forms.Button btn_Signals;
        private System.Windows.Forms.Button btn_Cihazlar;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel_Main;
        private MetroFramework.Controls.MetroTabControl tabControl1;
        private MetroFramework.Controls.MetroTabPage tabPage1;
        private MetroFramework.Controls.MetroTabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        
    }
}

