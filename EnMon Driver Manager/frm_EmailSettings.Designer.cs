namespace EnMon_Driver_Manager
{
    partial class frm_EmailSettings
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tab_EmailSettings = new GrayIris.Utilities.UI.Controls.YaTabControl();
            this.tabPage1 = new GrayIris.Utilities.UI.Controls.YaTabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grp_MailGroups = new System.Windows.Forms.GroupBox();
            this.lstBox_UsersAddedToGroup = new System.Windows.Forms.ListBox();
            this.lstBox__UsersNotAddedToGroup = new System.Windows.Forms.ListBox();
            this.btn_ChangeGroupName = new System.Windows.Forms.Button();
            this.btn_RemoveAllUsersFromGroup = new System.Windows.Forms.Button();
            this.btn_RemoveSelectedUserFromGroup = new System.Windows.Forms.Button();
            this.btn_AddAllUsersToGroup = new System.Windows.Forms.Button();
            this.btn_AddSelectedUserToGroup = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_NewGroup = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grp_ServerSettings = new System.Windows.Forms.GroupBox();
            this.chkBox_ShowPassword = new System.Windows.Forms.CheckBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_MailServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MailServerName = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.tabPage2 = new GrayIris.Utilities.UI.Controls.YaTabPage();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_AddNewAlarm = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tab_EmailSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grp_MailGroups.SuspendLayout();
            this.grp_ServerSettings.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_EmailSettings
            // 
            this.tab_EmailSettings.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.tab_EmailSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.tab_EmailSettings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.tab_EmailSettings.CloseButton = false;
            this.tab_EmailSettings.Controls.Add(this.tabPage1);
            this.tab_EmailSettings.Controls.Add(this.tabPage2);
            this.tab_EmailSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_EmailSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.tab_EmailSettings.HoverColor = System.Drawing.Color.Silver;
            this.tab_EmailSettings.ImageIndex = -1;
            this.tab_EmailSettings.ImageList = null;
            this.tab_EmailSettings.InactiveColor = System.Drawing.Color.White;
            this.tab_EmailSettings.Location = new System.Drawing.Point(0, 0);
            this.tab_EmailSettings.Name = "tab_EmailSettings";
            this.tab_EmailSettings.NewTabButton = false;
            this.tab_EmailSettings.OverIndex = -1;
            this.tab_EmailSettings.ScrollButtonStyle = GrayIris.Utilities.UI.Controls.YaScrollButtonStyle.Always;
            this.tab_EmailSettings.SelectedIndex = 0;
            this.tab_EmailSettings.SelectedTab = this.tabPage1;
            this.tab_EmailSettings.Size = new System.Drawing.Size(739, 450);
            this.tab_EmailSettings.TabDock = System.Windows.Forms.DockStyle.Top;
            this.tab_EmailSettings.TabDrawer = null;
            this.tab_EmailSettings.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tab_EmailSettings.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.ImageIndex = -1;
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(731, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Email Ayarları";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grp_MailGroups, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grp_ServerSettings, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Send, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.84662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.15337F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(725, 410);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grp_MailGroups
            // 
            this.grp_MailGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.grp_MailGroups.Controls.Add(this.lstBox_UsersAddedToGroup);
            this.grp_MailGroups.Controls.Add(this.lstBox__UsersNotAddedToGroup);
            this.grp_MailGroups.Controls.Add(this.btn_ChangeGroupName);
            this.grp_MailGroups.Controls.Add(this.btn_RemoveAllUsersFromGroup);
            this.grp_MailGroups.Controls.Add(this.btn_RemoveSelectedUserFromGroup);
            this.grp_MailGroups.Controls.Add(this.btn_AddAllUsersToGroup);
            this.grp_MailGroups.Controls.Add(this.btn_AddSelectedUserToGroup);
            this.grp_MailGroups.Controls.Add(this.label10);
            this.grp_MailGroups.Controls.Add(this.btn_NewGroup);
            this.grp_MailGroups.Controls.Add(this.label9);
            this.grp_MailGroups.Controls.Add(this.comboBox1);
            this.grp_MailGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_MailGroups.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grp_MailGroups.Location = new System.Drawing.Point(3, 101);
            this.grp_MailGroups.Name = "grp_MailGroups";
            this.grp_MailGroups.Size = new System.Drawing.Size(719, 262);
            this.grp_MailGroups.TabIndex = 1;
            this.grp_MailGroups.TabStop = false;
            this.grp_MailGroups.Text = "E-Posta Grupları";
            // 
            // lstBox_UsersAddedToGroup
            // 
            this.lstBox_UsersAddedToGroup.DisplayMember = "Email";
            this.lstBox_UsersAddedToGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstBox_UsersAddedToGroup.FormattingEnabled = true;
            this.lstBox_UsersAddedToGroup.ItemHeight = 16;
            this.lstBox_UsersAddedToGroup.Location = new System.Drawing.Point(402, 75);
            this.lstBox_UsersAddedToGroup.Name = "lstBox_UsersAddedToGroup";
            this.lstBox_UsersAddedToGroup.Size = new System.Drawing.Size(181, 180);
            this.lstBox_UsersAddedToGroup.TabIndex = 21;
            this.lstBox_UsersAddedToGroup.ValueMember = "ID";
            // 
            // lstBox__UsersNotAddedToGroup
            // 
            this.lstBox__UsersNotAddedToGroup.DisplayMember = "Email";
            this.lstBox__UsersNotAddedToGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstBox__UsersNotAddedToGroup.FormattingEnabled = true;
            this.lstBox__UsersNotAddedToGroup.ItemHeight = 16;
            this.lstBox__UsersNotAddedToGroup.Location = new System.Drawing.Point(118, 75);
            this.lstBox__UsersNotAddedToGroup.Name = "lstBox__UsersNotAddedToGroup";
            this.lstBox__UsersNotAddedToGroup.Size = new System.Drawing.Size(181, 180);
            this.lstBox__UsersNotAddedToGroup.TabIndex = 19;
            this.lstBox__UsersNotAddedToGroup.ValueMember = "MailGroupID";
            // 
            // btn_ChangeGroupName
            // 
            this.btn_ChangeGroupName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChangeGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ChangeGroupName.Location = new System.Drawing.Point(315, 22);
            this.btn_ChangeGroupName.Name = "btn_ChangeGroupName";
            this.btn_ChangeGroupName.Size = new System.Drawing.Size(183, 32);
            this.btn_ChangeGroupName.TabIndex = 18;
            this.btn_ChangeGroupName.Text = "Grup Adını Değiştir";
            this.btn_ChangeGroupName.UseVisualStyleBackColor = true;
            this.btn_ChangeGroupName.Click += new System.EventHandler(this.btn_ChangeGroupName_Click);
            // 
            // btn_RemoveAllUsersFromGroup
            // 
            this.btn_RemoveAllUsersFromGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveAllUsersFromGroup.Location = new System.Drawing.Point(329, 216);
            this.btn_RemoveAllUsersFromGroup.Name = "btn_RemoveAllUsersFromGroup";
            this.btn_RemoveAllUsersFromGroup.Size = new System.Drawing.Size(49, 32);
            this.btn_RemoveAllUsersFromGroup.TabIndex = 16;
            this.btn_RemoveAllUsersFromGroup.Text = "<<";
            this.btn_RemoveAllUsersFromGroup.UseVisualStyleBackColor = true;
            this.btn_RemoveAllUsersFromGroup.Click += new System.EventHandler(this.btn_RemoveAllUsersFromGroup_Click);
            // 
            // btn_RemoveSelectedUserFromGroup
            // 
            this.btn_RemoveSelectedUserFromGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveSelectedUserFromGroup.Location = new System.Drawing.Point(329, 173);
            this.btn_RemoveSelectedUserFromGroup.Name = "btn_RemoveSelectedUserFromGroup";
            this.btn_RemoveSelectedUserFromGroup.Size = new System.Drawing.Size(49, 32);
            this.btn_RemoveSelectedUserFromGroup.TabIndex = 15;
            this.btn_RemoveSelectedUserFromGroup.Text = "<";
            this.btn_RemoveSelectedUserFromGroup.UseVisualStyleBackColor = true;
            this.btn_RemoveSelectedUserFromGroup.Click += new System.EventHandler(this.btn_RemoveSelectedUserFromGroup_Click);
            // 
            // btn_AddAllUsersToGroup
            // 
            this.btn_AddAllUsersToGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddAllUsersToGroup.Location = new System.Drawing.Point(329, 130);
            this.btn_AddAllUsersToGroup.Name = "btn_AddAllUsersToGroup";
            this.btn_AddAllUsersToGroup.Size = new System.Drawing.Size(49, 32);
            this.btn_AddAllUsersToGroup.TabIndex = 14;
            this.btn_AddAllUsersToGroup.Text = ">>";
            this.btn_AddAllUsersToGroup.UseVisualStyleBackColor = true;
            this.btn_AddAllUsersToGroup.Click += new System.EventHandler(this.btn_AddAllUsersToGroup_Click);
            // 
            // btn_AddSelectedUserToGroup
            // 
            this.btn_AddSelectedUserToGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddSelectedUserToGroup.Location = new System.Drawing.Point(329, 87);
            this.btn_AddSelectedUserToGroup.Name = "btn_AddSelectedUserToGroup";
            this.btn_AddSelectedUserToGroup.Size = new System.Drawing.Size(49, 32);
            this.btn_AddSelectedUserToGroup.TabIndex = 13;
            this.btn_AddSelectedUserToGroup.Text = ">";
            this.btn_AddSelectedUserToGroup.UseVisualStyleBackColor = true;
            this.btn_AddSelectedUserToGroup.Click += new System.EventHandler(this.btn_AddSelectedUserToGroup_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 75);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = ": E-Posta Adresleri";
            // 
            // btn_NewGroup
            // 
            this.btn_NewGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_NewGroup.Location = new System.Drawing.Point(510, 22);
            this.btn_NewGroup.Name = "btn_NewGroup";
            this.btn_NewGroup.Size = new System.Drawing.Size(183, 32);
            this.btn_NewGroup.TabIndex = 10;
            this.btn_NewGroup.Text = "Yeni Grup Ekle";
            this.btn_NewGroup.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 32);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = ": Grup Adı";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // grp_ServerSettings
            // 
            this.grp_ServerSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.grp_ServerSettings.Controls.Add(this.chkBox_ShowPassword);
            this.grp_ServerSettings.Controls.Add(this.txt_Password);
            this.grp_ServerSettings.Controls.Add(this.label4);
            this.grp_ServerSettings.Controls.Add(this.txt_UserName);
            this.grp_ServerSettings.Controls.Add(this.label3);
            this.grp_ServerSettings.Controls.Add(this.txt_MailServerPort);
            this.grp_ServerSettings.Controls.Add(this.label2);
            this.grp_ServerSettings.Controls.Add(this.label1);
            this.grp_ServerSettings.Controls.Add(this.txt_MailServerName);
            this.grp_ServerSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_ServerSettings.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grp_ServerSettings.Location = new System.Drawing.Point(3, 3);
            this.grp_ServerSettings.Name = "grp_ServerSettings";
            this.grp_ServerSettings.Size = new System.Drawing.Size(719, 92);
            this.grp_ServerSettings.TabIndex = 0;
            this.grp_ServerSettings.TabStop = false;
            this.grp_ServerSettings.Text = "Sunucu Ayarları";
            // 
            // chkBox_ShowPassword
            // 
            this.chkBox_ShowPassword.AutoSize = true;
            this.chkBox_ShowPassword.Location = new System.Drawing.Point(605, 58);
            this.chkBox_ShowPassword.Name = "chkBox_ShowPassword";
            this.chkBox_ShowPassword.Size = new System.Drawing.Size(88, 17);
            this.chkBox_ShowPassword.TabIndex = 9;
            this.chkBox_ShowPassword.Text = "Şifreyi Göster";
            this.chkBox_ShowPassword.UseVisualStyleBackColor = true;
            this.chkBox_ShowPassword.CheckedChanged += new System.EventHandler(this.chkBox_ShowPassword_CheckedChanged);
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Password.Location = new System.Drawing.Point(402, 53);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Password.Size = new System.Drawing.Size(181, 22);
            this.txt_Password.TabIndex = 7;
            this.txt_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 58);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = ": Şifre";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_UserName.Location = new System.Drawing.Point(402, 17);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_UserName.Size = new System.Drawing.Size(181, 22);
            this.txt_UserName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 22);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = ": E-posta Adresi";
            // 
            // txt_MailServerPort
            // 
            this.txt_MailServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_MailServerPort.Location = new System.Drawing.Point(118, 53);
            this.txt_MailServerPort.Name = "txt_MailServerPort";
            this.txt_MailServerPort.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_MailServerPort.Size = new System.Drawing.Size(181, 22);
            this.txt_MailServerPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 58);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = ": Port Numarası";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = ": Sunucu Adresi";
            // 
            // txt_MailServerName
            // 
            this.txt_MailServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_MailServerName.Location = new System.Drawing.Point(118, 17);
            this.txt_MailServerName.Name = "txt_MailServerName";
            this.txt_MailServerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_MailServerName.Size = new System.Drawing.Size(181, 22);
            this.txt_MailServerName.TabIndex = 0;
            // 
            // btn_Send
            // 
            this.btn_Send.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Send.Location = new System.Drawing.Point(541, 369);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(181, 38);
            this.btn_Send.TabIndex = 8;
            this.btn_Send.Text = "Değişiklikleri Güncelle";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.materialRaisedButton2);
            this.tabPage2.Controls.Add(this.btn_AddNewAlarm);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.ImageIndex = -1;
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(731, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alarmlar";
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialRaisedButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Icon = null;
            this.materialRaisedButton2.Location = new System.Drawing.Point(543, 376);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(185, 35);
            this.materialRaisedButton2.TabIndex = 2;
            this.materialRaisedButton2.Text = "Seçili Alarmı Sil";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            // 
            // btn_AddNewAlarm
            // 
            this.btn_AddNewAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddNewAlarm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_AddNewAlarm.Depth = 0;
            this.btn_AddNewAlarm.Icon = null;
            this.btn_AddNewAlarm.Location = new System.Drawing.Point(347, 376);
            this.btn_AddNewAlarm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_AddNewAlarm.Name = "btn_AddNewAlarm";
            this.btn_AddNewAlarm.Primary = true;
            this.btn_AddNewAlarm.Size = new System.Drawing.Size(185, 35);
            this.btn_AddNewAlarm.TabIndex = 1;
            this.btn_AddNewAlarm.Text = "Yeni Alarm Ekle";
            this.btn_AddNewAlarm.UseVisualStyleBackColor = true;
            this.btn_AddNewAlarm.Click += new System.EventHandler(this.btn_AddNewAlarm_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 6);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(728, 364);
            this.dataGridView1.TabIndex = 0;
            // 
            // frm_EmailSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(739, 450);
            this.Controls.Add(this.tab_EmailSettings);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frm_EmailSettings";
            this.Text = "EmailSettings";
            this.Load += new System.EventHandler(this.frm_EmailSettings_Load);
            this.tab_EmailSettings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grp_MailGroups.ResumeLayout(false);
            this.grp_MailGroups.PerformLayout();
            this.grp_ServerSettings.ResumeLayout(false);
            this.grp_ServerSettings.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GrayIris.Utilities.UI.Controls.YaTabControl tab_EmailSettings;
        //private System.Windows.Forms.TabControl tab_EmailSettings;
        private GrayIris.Utilities.UI.Controls.YaTabPage tabPage1;
        private GrayIris.Utilities.UI.Controls.YaTabPage tabPage2;
        //private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grp_MailGroups;
        private System.Windows.Forms.GroupBox grp_ServerSettings;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_MailServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MailServerName;
        //private System.Windows.Forms.TabPage tabPage2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox chkBox_ShowPassword;
        private System.Windows.Forms.Button btn_RemoveAllUsersFromGroup;
        private System.Windows.Forms.Button btn_RemoveSelectedUserFromGroup;
        private System.Windows.Forms.Button btn_AddAllUsersToGroup;
        private System.Windows.Forms.Button btn_AddSelectedUserToGroup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_NewGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_ChangeGroupName;
        private System.Windows.Forms.ListBox lstBox_UsersAddedToGroup;
        private System.Windows.Forms.ListBox lstBox__UsersNotAddedToGroup;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private MaterialSkin.Controls.MaterialRaisedButton btn_AddNewAlarm;
    }
}