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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turkishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_start = new System.Windows.Forms.Button();
            this.pct_led = new System.Windows.Forms.PictureBox();
            this.timer_led = new System.Windows.Forms.Timer(this.components);
            this.chkBox_runOnStartup = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_led)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(483, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(483, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.fileToolStripMenuItem.Text = "Dosya";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.editToolStripMenuItem.Text = "Düzenle";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.turkishToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.languageToolStripMenuItem.Text = "Dil";
            // 
            // turkishToolStripMenuItem
            // 
            this.turkishToolStripMenuItem.Name = "turkishToolStripMenuItem";
            this.turkishToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.turkishToolStripMenuItem.Text = "Turkçe";
            this.turkishToolStripMenuItem.Click += new System.EventHandler(this.switch_language);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.englishToolStripMenuItem.Text = "İngilizce";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.switch_language);
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_start.Location = new System.Drawing.Point(12, 64);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(176, 51);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Başlat";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // pct_led
            // 
            this.pct_led.Image = global::EnMon_Driver_Manager.Properties.Resources.red;
            this.pct_led.Location = new System.Drawing.Point(228, 64);
            this.pct_led.Name = "pct_led";
            this.pct_led.Size = new System.Drawing.Size(53, 50);
            this.pct_led.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pct_led.TabIndex = 3;
            this.pct_led.TabStop = false;
            // 
            // timer_led
            // 
            this.timer_led.Interval = 500;
            this.timer_led.Tick += new System.EventHandler(this.timer_led_Tick);
            // 
            // chkBox_runOnStartup
            // 
            this.chkBox_runOnStartup.AutoSize = true;
            this.chkBox_runOnStartup.Location = new System.Drawing.Point(13, 140);
            this.chkBox_runOnStartup.Name = "chkBox_runOnStartup";
            this.chkBox_runOnStartup.Size = new System.Drawing.Size(358, 17);
            this.chkBox_runOnStartup.TabIndex = 4;
            this.chkBox_runOnStartup.Text = "Windows başladığında EnMon Driver Manager\'ı otomatik olarak başlat.";
            this.chkBox_runOnStartup.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 198);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(455, 225);
            this.dataGridView1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 457);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chkBox_runOnStartup);
            this.Controls.Add(this.pct_led);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "EnMon Driver Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pct_led)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeLanguageSettings()
        {
            res_man = new ResourceManager("EnMon_Driver_Manager.Resources.res", typeof(MainForm).Assembly);
            cul = CultureInfo.CreateSpecificCulture("tr");

            //
            //  Components
            //
            this.fileToolStripMenuItem.Text = res_man.GetString("File", cul);
            this.editToolStripMenuItem.Text = res_man.GetString("Edit", cul);
            this.languageToolStripMenuItem.Text = res_man.GetString("Language", cul);
            this.turkishToolStripMenuItem.Text = res_man.GetString("Turkish", cul);
            this.englishToolStripMenuItem.Text = res_man.GetString("English", cul);

        }



        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turkishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.PictureBox pct_led;
        private System.Windows.Forms.Timer timer_led;
        private System.Windows.Forms.CheckBox chkBox_runOnStartup;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

