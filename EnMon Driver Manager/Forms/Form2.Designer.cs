namespace EnMon_Driver_Manager.Forms
{
    partial class MainForm2
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
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Modbus TCP");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Arşiv");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Mail Client");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Sürücüler", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("İstasyonlar");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Alarm Ayarları");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Kullanıcı Ayarları");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Alarm Listesi");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Log Kayıtları");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Grup Ayarları");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("E-Postalar");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("E-Posta Gönderimi", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Proje", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode25});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm2));
            this.contextMenuStrip_Stations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewStation_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectTreeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_databaseConnectionSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_Devices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewDevice_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_Signals = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewSignal_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSignals_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSignals_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSignalsAsTemplate_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSignalsAsTemplate_ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.modbusTCPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sNMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_Stations.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip_Devices.SuspendLayout();
            this.contextMenuStrip_Signals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip_Stations
            // 
            this.contextMenuStrip_Stations.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip_Stations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewStation_ToolStripMenuItem});
            this.contextMenuStrip_Stations.Name = "contextMenuStrip_Stations";
            this.contextMenuStrip_Stations.Size = new System.Drawing.Size(167, 26);
            // 
            // addNewStation_ToolStripMenuItem
            // 
            this.addNewStation_ToolStripMenuItem.Name = "addNewStation_ToolStripMenuItem";
            this.addNewStation_ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.addNewStation_ToolStripMenuItem.Text = "Yeni İstasyon Ekle";
            this.addNewStation_ToolStripMenuItem.Click += new System.EventHandler(this.addNewStation_ToolStripMenuItem_Click);
            // 
            // ProjectTreeView
            // 
            this.ProjectTreeView.Location = new System.Drawing.Point(0, 52);
            this.ProjectTreeView.Name = "ProjectTreeView";
            treeNode14.Name = "Node3";
            treeNode14.Text = "Modbus TCP";
            treeNode15.Name = "Node5";
            treeNode15.Text = "Arşiv";
            treeNode16.Name = "Mail Client";
            treeNode16.Text = "Mail Client";
            treeNode17.Name = "Node0";
            treeNode17.Text = "Sürücüler";
            treeNode18.ContextMenuStrip = this.contextMenuStrip_Stations;
            treeNode18.Name = "Node1";
            treeNode18.Text = "İstasyonlar";
            treeNode19.Name = "Node2";
            treeNode19.Text = "Alarm Ayarları";
            treeNode20.Name = "Node0";
            treeNode20.Text = "Kullanıcı Ayarları";
            treeNode21.Name = "Node1";
            treeNode21.Text = "Alarm Listesi";
            treeNode22.Name = "Node2";
            treeNode22.Text = "Log Kayıtları";
            treeNode23.Name = "Node_EMailGroups";
            treeNode23.Text = "Grup Ayarları";
            treeNode24.Name = "Node_EMailLogics";
            treeNode24.Text = "E-Postalar";
            treeNode25.Name = "Node_EmailSettings";
            treeNode25.Text = "E-Posta Gönderimi";
            treeNode26.Name = "ProjectName";
            treeNode26.Text = "Proje";
            this.ProjectTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode26});
            this.ProjectTreeView.Size = new System.Drawing.Size(213, 580);
            this.ProjectTreeView.TabIndex = 0;
            this.ProjectTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.ProjectTreeView_BeforeCollapse);
            this.ProjectTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.ProjectTreeView_BeforeExpand);
            this.ProjectTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.ProjectTreeView_BeforeSelect);
            this.ProjectTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.ProjectTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProjectTreeView_NodeMouseClick);
            this.ProjectTreeView.Click += new System.EventHandler(this.ProjectTreeView_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 636);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(1181, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1181, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
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
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.yardımToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1181, 24);
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
            this.düzenleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_databaseConnectionSettings});
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            // 
            // menu_databaseConnectionSettings
            // 
            this.menu_databaseConnectionSettings.Name = "menu_databaseConnectionSettings";
            this.menu_databaseConnectionSettings.Size = new System.Drawing.Size(215, 22);
            this.menu_databaseConnectionSettings.Text = "Veritabanı Bağlantı Ayarları";
            this.menu_databaseConnectionSettings.Click += new System.EventHandler(this.menu_databaseConnectionSettings_Click);
            // 
            // yardımToolStripMenuItem
            // 
            this.yardımToolStripMenuItem.Name = "yardımToolStripMenuItem";
            this.yardımToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.yardımToolStripMenuItem.Text = "Yardım";
            // 
            // contextMenuStrip_Devices
            // 
            this.contextMenuStrip_Devices.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip_Devices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewDevice_toolStripMenuItem});
            this.contextMenuStrip_Devices.Name = "contextMenuStrip_Stations";
            this.contextMenuStrip_Devices.Size = new System.Drawing.Size(153, 48);
            // 
            // addNewDevice_toolStripMenuItem
            // 
            this.addNewDevice_toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modbusTCPToolStripMenuItem,
            this.sNMPToolStripMenuItem});
            this.addNewDevice_toolStripMenuItem.Name = "addNewDevice_toolStripMenuItem";
            this.addNewDevice_toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addNewDevice_toolStripMenuItem.Text = "Yeni Cihaz Ekle";
            this.addNewDevice_toolStripMenuItem.Click += new System.EventHandler(this.addNewDevice_toolStripMenuItem_Click);
            // 
            // contextMenuStrip_Signals
            // 
            this.contextMenuStrip_Signals.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip_Signals.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSignal_toolStripMenuItem,
            this.exportSignals_toolStripMenuItem,
            this.importSignals_ToolStripMenuItem,
            this.exportSignalsAsTemplate_ToolStripMenuItem,
            this.importSignalsAsTemplate_ToolStripMenuItem1});
            this.contextMenuStrip_Signals.Name = "contextMenuStrip_Stations";
            this.contextMenuStrip_Signals.Size = new System.Drawing.Size(174, 114);
            // 
            // addNewSignal_toolStripMenuItem
            // 
            this.addNewSignal_toolStripMenuItem.Name = "addNewSignal_toolStripMenuItem";
            this.addNewSignal_toolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.addNewSignal_toolStripMenuItem.Text = "Yeni Sinyal Ekle";
            this.addNewSignal_toolStripMenuItem.Click += new System.EventHandler(this.addNewSignal_toolStripMenuItem_Click);
            // 
            // exportSignals_toolStripMenuItem
            // 
            this.exportSignals_toolStripMenuItem.Name = "exportSignals_toolStripMenuItem";
            this.exportSignals_toolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exportSignals_toolStripMenuItem.Text = "Dışarı Aktar";
            // 
            // importSignals_ToolStripMenuItem
            // 
            this.importSignals_ToolStripMenuItem.Name = "importSignals_ToolStripMenuItem";
            this.importSignals_ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.importSignals_ToolStripMenuItem.Text = "İçeri Aktar";
            // 
            // exportSignalsAsTemplate_ToolStripMenuItem
            // 
            this.exportSignalsAsTemplate_ToolStripMenuItem.Name = "exportSignalsAsTemplate_ToolStripMenuItem";
            this.exportSignalsAsTemplate_ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exportSignalsAsTemplate_ToolStripMenuItem.Text = "Şablon Dışarı Aktar";
            // 
            // importSignalsAsTemplate_ToolStripMenuItem1
            // 
            this.importSignalsAsTemplate_ToolStripMenuItem1.Name = "importSignalsAsTemplate_ToolStripMenuItem1";
            this.importSignalsAsTemplate_ToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.importSignalsAsTemplate_ToolStripMenuItem1.Text = "Şablon İçeri Aktar";
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(219, 52);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(962, 580);
            this.mainPanel.TabIndex = 0;
            // 
            // modbusTCPToolStripMenuItem
            // 
            this.modbusTCPToolStripMenuItem.Name = "modbusTCPToolStripMenuItem";
            this.modbusTCPToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modbusTCPToolStripMenuItem.Text = "ModbusTCP";
            this.modbusTCPToolStripMenuItem.Click += new System.EventHandler(this.modbusTCPToolStripMenuItem_Click);
            // 
            // sNMPToolStripMenuItem
            // 
            this.sNMPToolStripMenuItem.Name = "sNMPToolStripMenuItem";
            this.sNMPToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sNMPToolStripMenuItem.Text = "SNMP";
            // 
            // MainForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 658);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ProjectTreeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm2";
            this.Text = "EnMon Sürücü Yöneticisi";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip_Stations.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip_Devices.ResumeLayout(false);
            this.contextMenuStrip_Signals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ProjectTreeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem menu_databaseConnectionSettings;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Stations;
        private System.Windows.Forms.ToolStripMenuItem addNewStation_ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Devices;
        private System.Windows.Forms.ToolStripMenuItem addNewDevice_toolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Signals;
        private System.Windows.Forms.ToolStripMenuItem addNewSignal_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSignals_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSignals_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSignalsAsTemplate_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSignalsAsTemplate_ToolStripMenuItem1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel mainPanel;
        private System.Windows.Forms.ToolStripMenuItem modbusTCPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sNMPToolStripMenuItem;
    }
}