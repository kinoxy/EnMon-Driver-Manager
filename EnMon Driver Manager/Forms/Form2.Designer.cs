namespace EnMon_Driver_Manager.Forms
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Modbus TCP");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Arşiv");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Mail Client");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Sürücüler", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("İstasyonlar");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Alarm Ayarları");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Kullanıcı Ayarları");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Alarm Listesi");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Log Kayıtları");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("E-Posta Grupları");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_Drivers_ModbusTCP = new System.Windows.Forms.Panel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.grpBox_ModbusTCP_GeneralSettings = new System.Windows.Forms.GroupBox();
            this.chkBox_ModbusTCPCommunicationActivated = new System.Windows.Forms.CheckBox();
            this.txt_ModbusTCPConfigFileLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnl_Drivers_ModbusTCP.SuspendLayout();
            this.grpBox_ModbusTCP_GeneralSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 49);
            this.treeView1.Name = "treeView1";
            treeNode21.Name = "Node3";
            treeNode21.Text = "Modbus TCP";
            treeNode22.Name = "Node5";
            treeNode22.Text = "Arşiv";
            treeNode23.Name = "Node6";
            treeNode23.Text = "Mail Client";
            treeNode24.Name = "Node0";
            treeNode24.Text = "Sürücüler";
            treeNode25.Name = "Node1";
            treeNode25.Text = "İstasyonlar";
            treeNode26.Name = "Node2";
            treeNode26.Text = "Alarm Ayarları";
            treeNode27.Name = "Node0";
            treeNode27.Text = "Kullanıcı Ayarları";
            treeNode28.Name = "Node1";
            treeNode28.Text = "Alarm Listesi";
            treeNode29.Name = "Node2";
            treeNode29.Text = "Log Kayıtları";
            treeNode30.Name = "Node_EmailGroups";
            treeNode30.Text = "E-Posta Grupları";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30});
            this.treeView1.Size = new System.Drawing.Size(183, 575);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(68, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(67, 22);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 632);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1036, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1036, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.yardımToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1036, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            // 
            // yardımToolStripMenuItem
            // 
            this.yardımToolStripMenuItem.Name = "yardımToolStripMenuItem";
            this.yardımToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.yardımToolStripMenuItem.Text = "Yardım";
            // 
            // pnl_Drivers_ModbusTCP
            // 
            this.pnl_Drivers_ModbusTCP.Controls.Add(this.panel1);
            this.pnl_Drivers_ModbusTCP.Controls.Add(this.label2);
            this.pnl_Drivers_ModbusTCP.Controls.Add(this.grpBox_ModbusTCP_GeneralSettings);
            this.pnl_Drivers_ModbusTCP.Controls.Add(this.chkBox_ModbusTCPCommunicationActivated);
            this.pnl_Drivers_ModbusTCP.Location = new System.Drawing.Point(186, 49);
            this.pnl_Drivers_ModbusTCP.Name = "pnl_Drivers_ModbusTCP";
            this.pnl_Drivers_ModbusTCP.Size = new System.Drawing.Size(618, 575);
            this.pnl_Drivers_ModbusTCP.TabIndex = 4;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // grpBox_ModbusTCP_GeneralSettings
            // 
            this.grpBox_ModbusTCP_GeneralSettings.Controls.Add(this.label4);
            this.grpBox_ModbusTCP_GeneralSettings.Controls.Add(this.textBox2);
            this.grpBox_ModbusTCP_GeneralSettings.Controls.Add(this.label5);
            this.grpBox_ModbusTCP_GeneralSettings.Controls.Add(this.textBox3);
            this.grpBox_ModbusTCP_GeneralSettings.Controls.Add(this.label3);
            this.grpBox_ModbusTCP_GeneralSettings.Controls.Add(this.textBox1);
            this.grpBox_ModbusTCP_GeneralSettings.Controls.Add(this.label1);
            this.grpBox_ModbusTCP_GeneralSettings.Controls.Add(this.txt_ModbusTCPConfigFileLocation);
            this.grpBox_ModbusTCP_GeneralSettings.Location = new System.Drawing.Point(3, 33);
            this.grpBox_ModbusTCP_GeneralSettings.Name = "grpBox_ModbusTCP_GeneralSettings";
            this.grpBox_ModbusTCP_GeneralSettings.Size = new System.Drawing.Size(612, 96);
            this.grpBox_ModbusTCP_GeneralSettings.TabIndex = 0;
            this.grpBox_ModbusTCP_GeneralSettings.TabStop = false;
            this.grpBox_ModbusTCP_GeneralSettings.Text = "Genel Ayarlar";
            // 
            // chkBox_ModbusTCPCommunicationActivated
            // 
            this.chkBox_ModbusTCPCommunicationActivated.AutoSize = true;
            this.chkBox_ModbusTCPCommunicationActivated.Checked = true;
            this.chkBox_ModbusTCPCommunicationActivated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_ModbusTCPCommunicationActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkBox_ModbusTCPCommunicationActivated.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkBox_ModbusTCPCommunicationActivated.Location = new System.Drawing.Point(3, 135);
            this.chkBox_ModbusTCPCommunicationActivated.Name = "chkBox_ModbusTCPCommunicationActivated";
            this.chkBox_ModbusTCPCommunicationActivated.Size = new System.Drawing.Size(306, 20);
            this.chkBox_ModbusTCPCommunicationActivated.TabIndex = 7;
            this.chkBox_ModbusTCPCommunicationActivated.Text = "Modbus TCP Haberleşmesini Sürücü İle Başlat";
            this.chkBox_ModbusTCPCommunicationActivated.UseVisualStyleBackColor = true;
            // 
            // txt_ModbusTCPConfigFileLocation
            // 
            this.txt_ModbusTCPConfigFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_ModbusTCPConfigFileLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_ModbusTCPConfigFileLocation.Location = new System.Drawing.Point(152, 21);
            this.txt_ModbusTCPConfigFileLocation.Name = "txt_ModbusTCPConfigFileLocation";
            this.txt_ModbusTCPConfigFileLocation.Size = new System.Drawing.Size(121, 22);
            this.txt_ModbusTCPConfigFileLocation.TabIndex = 6;
            this.txt_ModbusTCPConfigFileLocation.TextChanged += new System.EventHandler(this.txt_ModbusTCPConfigFileLocation_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Okuma Zaman Aşım Süresi :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(31, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tekrar Bağlantı Sayısı :";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox1.Location = new System.Drawing.Point(152, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 22);
            this.textBox1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(315, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Register / Sorgu Sayısı :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox2.Location = new System.Drawing.Point(442, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 22);
            this.textBox2.TabIndex = 14;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(363, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Sorgü Süresi :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox3.Location = new System.Drawing.Point(442, 21);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(121, 22);
            this.textBox3.TabIndex = 12;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(618, 35);
            this.label2.TabIndex = 8;
            this.label2.Text = "Modbus TCP Ayarlar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 575);
            this.panel1.TabIndex = 9;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 654);
            this.Controls.Add(this.pnl_Drivers_ModbusTCP);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "EnMon Sürücü Yöneticisi";
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnl_Drivers_ModbusTCP.ResumeLayout(false);
            this.pnl_Drivers_ModbusTCP.PerformLayout();
            this.grpBox_ModbusTCP_GeneralSettings.ResumeLayout(false);
            this.grpBox_ModbusTCP_GeneralSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel pnl_Drivers_ModbusTCP;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.GroupBox grpBox_ModbusTCP_GeneralSettings;
        private System.Windows.Forms.CheckBox chkBox_ModbusTCPCommunicationActivated;
        private System.Windows.Forms.TextBox txt_ModbusTCPConfigFileLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}