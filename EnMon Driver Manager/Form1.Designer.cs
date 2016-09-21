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
            this.btn_start = new System.Windows.Forms.Button();
            this.timer_led = new System.Windows.Forms.Timer(this.components);
            this.chkBox_runOnStartup = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pct_led = new System.Windows.Forms.PictureBox();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.switchButton5 = new EnMon_Driver_Manager.SwitchButton();
            this.switchButton4 = new EnMon_Driver_Manager.SwitchButton();
            this.switchButton3 = new EnMon_Driver_Manager.SwitchButton();
            this.switchButton2 = new EnMon_Driver_Manager.SwitchButton();
            this.switchButton1 = new EnMon_Driver_Manager.SwitchButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_led)).BeginInit();
            this.panel_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_start.Location = new System.Drawing.Point(46, 12);
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
            this.chkBox_runOnStartup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.chkBox_runOnStartup.Location = new System.Drawing.Point(47, 88);
            this.chkBox_runOnStartup.Name = "chkBox_runOnStartup";
            this.chkBox_runOnStartup.Size = new System.Drawing.Size(358, 17);
            this.chkBox_runOnStartup.TabIndex = 4;
            this.chkBox_runOnStartup.Text = "Windows başladığında EnMon Driver Manager\'ı otomatik olarak başlat.";
            this.chkBox_runOnStartup.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(44, 146);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(455, 225);
            this.dataGridView1.TabIndex = 5;
            // 
            // sidePanel
            // 
            this.sidePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(54)))), ((int)(((byte)(72)))));
            this.sidePanel.Controls.Add(this.pictureBox3);
            this.sidePanel.Controls.Add(this.button4);
            this.sidePanel.Controls.Add(this.button3);
            this.sidePanel.Controls.Add(this.button2);
            this.sidePanel.Controls.Add(this.button1);
            this.sidePanel.Controls.Add(this.logoPanel);
            this.sidePanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(180, 562);
            this.sidePanel.TabIndex = 6;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Location = new System.Drawing.Point(94, 411);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(54)))), ((int)(((byte)(72)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(0, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 46);
            this.button4.TabIndex = 11;
            this.button4.Text = "            Başlat";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(54)))), ((int)(((byte)(72)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 108);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 46);
            this.button3.TabIndex = 10;
            this.button3.Text = "            Başlat";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(54)))), ((int)(((byte)(72)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 46);
            this.button2.TabIndex = 9;
            this.button2.Text = "            Başlat";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(54)))), ((int)(((byte)(72)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(113)))), ((int)(((byte)(133)))));
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
            this.logoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(196)))), ((int)(((byte)(174)))));
            this.logoPanel.BackgroundImage = global::EnMon_Driver_Manager.Properties.Resources.logoTR;
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logoPanel.Size = new System.Drawing.Size(180, 54);
            this.logoPanel.TabIndex = 0;
            this.logoPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragStart);
            this.logoPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnDrag);
            this.logoPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragEnd);
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(54)))), ((int)(((byte)(72)))));
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
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHeader.Location = new System.Drawing.Point(17, 7);
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(546, 53);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.ThreeState = true;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pct_led
            // 
            this.pct_led.Image = global::EnMon_Driver_Manager.Properties.Resources.red;
            this.pct_led.Location = new System.Drawing.Point(246, 19);
            this.pct_led.Name = "pct_led";
            this.pct_led.Size = new System.Drawing.Size(53, 50);
            this.pct_led.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_led.TabIndex = 3;
            this.pct_led.TabStop = false;
            // 
            // panel_Main
            // 
            this.panel_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panel_Main.Controls.Add(this.switchButton5);
            this.panel_Main.Controls.Add(this.switchButton4);
            this.panel_Main.Controls.Add(this.switchButton3);
            this.panel_Main.Controls.Add(this.switchButton2);
            this.panel_Main.Controls.Add(this.switchButton1);
            this.panel_Main.Controls.Add(this.checkBox1);
            this.panel_Main.Controls.Add(this.dataGridView1);
            this.panel_Main.Controls.Add(this.chkBox_runOnStartup);
            this.panel_Main.Controls.Add(this.pct_led);
            this.panel_Main.Controls.Add(this.btn_start);
            this.panel_Main.Location = new System.Drawing.Point(180, 54);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(783, 508);
            this.panel_Main.TabIndex = 14;
            // 
            // switchButton5
            // 
            this.switchButton5.BackColor = System.Drawing.Color.Transparent;
            this.switchButton5.Location = new System.Drawing.Point(569, 286);
            this.switchButton5.Name = "switchButton5";
            this.switchButton5.Size = new System.Drawing.Size(83, 34);
            this.switchButton5.TabIndex = 13;
            // 
            // switchButton4
            // 
            this.switchButton4.BackColor = System.Drawing.Color.Transparent;
            this.switchButton4.Location = new System.Drawing.Point(569, 246);
            this.switchButton4.Name = "switchButton4";
            this.switchButton4.Size = new System.Drawing.Size(83, 34);
            this.switchButton4.TabIndex = 12;
            // 
            // switchButton3
            // 
            this.switchButton3.BackColor = System.Drawing.Color.Transparent;
            this.switchButton3.Location = new System.Drawing.Point(569, 206);
            this.switchButton3.Name = "switchButton3";
            this.switchButton3.Size = new System.Drawing.Size(83, 34);
            this.switchButton3.TabIndex = 11;
            // 
            // switchButton2
            // 
            this.switchButton2.BackColor = System.Drawing.Color.Transparent;
            this.switchButton2.Location = new System.Drawing.Point(569, 166);
            this.switchButton2.Name = "switchButton2";
            this.switchButton2.Size = new System.Drawing.Size(83, 34);
            this.switchButton2.TabIndex = 10;
            // 
            // switchButton1
            // 
            this.switchButton1.BackColor = System.Drawing.Color.Transparent;
            this.switchButton1.Location = new System.Drawing.Point(569, 126);
            this.switchButton1.Name = "switchButton1";
            this.switchButton1.Size = new System.Drawing.Size(83, 34);
            this.switchButton1.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(963, 562);
            this.Controls.Add(this.panel_Main);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.sidePanel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "EnMon Driver Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_led)).EndInit();
            this.panel_Main.ResumeLayout(false);
            this.panel_Main.PerformLayout();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private SwitchButton switchButton1;
        private SwitchButton switchButton5;
        private SwitchButton switchButton4;
        private SwitchButton switchButton3;
        private SwitchButton switchButton2;
        private System.Windows.Forms.Panel panel_Main;
    }
}

