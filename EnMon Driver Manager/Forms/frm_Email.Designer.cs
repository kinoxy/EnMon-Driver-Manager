namespace EnMon_Driver_Manager
{
    partial class frm_Email
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grp_ServerSettings = new System.Windows.Forms.GroupBox();
            this.cbx_UseSSL = new System.Windows.Forms.CheckBox();
            this.txt_From = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_SendTestMail = new System.Windows.Forms.Button();
            this.chkBox_ShowPassword = new System.Windows.Forms.CheckBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_MailServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MailServerName = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.grp_MailGroups = new System.Windows.Forms.GroupBox();
            this.btn_DeleteGroup = new System.Windows.Forms.Button();
            this.lstBox_UsersAddedToGroup = new System.Windows.Forms.ListBox();
            this.lstBox_UsersNotAddedToGroup = new System.Windows.Forms.ListBox();
            this.btn_ChangeGroupName = new System.Windows.Forms.Button();
            this.btn_RemoveAllUsersFromGroup = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_RemoveSelectedUserFromGroup = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_AddAllUsersToGroup = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_AddSelectedUserToGroup = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_NewGroup = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.grp_ServerSettings.SuspendLayout();
            this.grp_MailGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.SteelBlue;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grp_ServerSettings, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Update, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grp_MailGroups, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.92434F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.07567F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(723, 533);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grp_ServerSettings
            // 
            this.grp_ServerSettings.BackColor = System.Drawing.Color.SteelBlue;
            this.grp_ServerSettings.Controls.Add(this.cbx_UseSSL);
            this.grp_ServerSettings.Controls.Add(this.txt_From);
            this.grp_ServerSettings.Controls.Add(this.label5);
            this.grp_ServerSettings.Controls.Add(this.btn_SendTestMail);
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
            this.grp_ServerSettings.ForeColor = System.Drawing.Color.White;
            this.grp_ServerSettings.Location = new System.Drawing.Point(3, 3);
            this.grp_ServerSettings.Name = "grp_ServerSettings";
            this.grp_ServerSettings.Size = new System.Drawing.Size(717, 155);
            this.grp_ServerSettings.TabIndex = 0;
            this.grp_ServerSettings.TabStop = false;
            this.grp_ServerSettings.Text = "Sunucu Ayarları";
            this.grp_ServerSettings.Enter += new System.EventHandler(this.grp_ServerSettings_Enter);
            // 
            // cbx_UseSSL
            // 
            this.cbx_UseSSL.AutoSize = true;
            this.cbx_UseSSL.Location = new System.Drawing.Point(402, 84);
            this.cbx_UseSSL.Name = "cbx_UseSSL";
            this.cbx_UseSSL.Size = new System.Drawing.Size(190, 17);
            this.cbx_UseSSL.TabIndex = 26;
            this.cbx_UseSSL.Text = "Hesaba Giriş Yaparken SSL Kullan";
            this.cbx_UseSSL.UseVisualStyleBackColor = true;
            // 
            // txt_From
            // 
            this.txt_From.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_From.Location = new System.Drawing.Point(106, 79);
            this.txt_From.Name = "txt_From";
            this.txt_From.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_From.Size = new System.Drawing.Size(181, 22);
            this.txt_From.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 84);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = ": Gönderen Adres";
            // 
            // btn_SendTestMail
            // 
            this.btn_SendTestMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SendTestMail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_SendTestMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SendTestMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_SendTestMail.Location = new System.Drawing.Point(536, 117);
            this.btn_SendTestMail.Name = "btn_SendTestMail";
            this.btn_SendTestMail.Size = new System.Drawing.Size(177, 32);
            this.btn_SendTestMail.TabIndex = 23;
            this.btn_SendTestMail.Text = "Test E-postası Gönder";
            this.btn_SendTestMail.UseVisualStyleBackColor = true;
            this.btn_SendTestMail.Click += new System.EventHandler(this.btn_SendTestMail_Click);
            // 
            // chkBox_ShowPassword
            // 
            this.chkBox_ShowPassword.AutoSize = true;
            this.chkBox_ShowPassword.Location = new System.Drawing.Point(625, 52);
            this.chkBox_ShowPassword.Name = "chkBox_ShowPassword";
            this.chkBox_ShowPassword.Size = new System.Drawing.Size(88, 17);
            this.chkBox_ShowPassword.TabIndex = 9;
            this.chkBox_ShowPassword.Text = "Şifreyi Göster";
            this.chkBox_ShowPassword.UseVisualStyleBackColor = true;
            this.chkBox_ShowPassword.CheckStateChanged += new System.EventHandler(this.chkBox_ShowPassword_CheckStateChanged);
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Password.Location = new System.Drawing.Point(402, 48);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Password.Size = new System.Drawing.Size(217, 22);
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
            this.txt_UserName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_UserName.Location = new System.Drawing.Point(402, 17);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_UserName.Size = new System.Drawing.Size(217, 22);
            this.txt_UserName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 22);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = ": Kullanıcı Adı";
            // 
            // txt_MailServerPort
            // 
            this.txt_MailServerPort.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_MailServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_MailServerPort.Location = new System.Drawing.Point(106, 48);
            this.txt_MailServerPort.Name = "txt_MailServerPort";
            this.txt_MailServerPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_MailServerPort.Size = new System.Drawing.Size(181, 22);
            this.txt_MailServerPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 53);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = ": Port Numarası";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = ": Sunucu Adresi";
            // 
            // txt_MailServerName
            // 
            this.txt_MailServerName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_MailServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_MailServerName.Location = new System.Drawing.Point(106, 17);
            this.txt_MailServerName.Name = "txt_MailServerName";
            this.txt_MailServerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_MailServerName.Size = new System.Drawing.Size(181, 22);
            this.txt_MailServerName.TabIndex = 0;
            // 
            // btn_Update
            // 
            this.btn_Update.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Update.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Update.Location = new System.Drawing.Point(539, 492);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(181, 38);
            this.btn_Update.TabIndex = 8;
            this.btn_Update.Text = "Değişiklikleri Güncelle";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // grp_MailGroups
            // 
            this.grp_MailGroups.BackColor = System.Drawing.Color.SteelBlue;
            this.grp_MailGroups.Controls.Add(this.btn_DeleteGroup);
            this.grp_MailGroups.Controls.Add(this.lstBox_UsersAddedToGroup);
            this.grp_MailGroups.Controls.Add(this.lstBox_UsersNotAddedToGroup);
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
            this.grp_MailGroups.ForeColor = System.Drawing.Color.White;
            this.grp_MailGroups.Location = new System.Drawing.Point(3, 164);
            this.grp_MailGroups.Name = "grp_MailGroups";
            this.grp_MailGroups.Size = new System.Drawing.Size(717, 322);
            this.grp_MailGroups.TabIndex = 1;
            this.grp_MailGroups.TabStop = false;
            this.grp_MailGroups.Text = "E-Posta Grupları";
            // 
            // btn_DeleteGroup
            // 
            this.btn_DeleteGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_DeleteGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_DeleteGroup.ForeColor = System.Drawing.Color.White;
            this.btn_DeleteGroup.Location = new System.Drawing.Point(447, 15);
            this.btn_DeleteGroup.Name = "btn_DeleteGroup";
            this.btn_DeleteGroup.Size = new System.Drawing.Size(130, 32);
            this.btn_DeleteGroup.TabIndex = 22;
            this.btn_DeleteGroup.Text = "Seçili Grubu Sil";
            this.btn_DeleteGroup.UseVisualStyleBackColor = true;
            this.btn_DeleteGroup.Click += new System.EventHandler(this.btn_DeleteGroup_Click);
            // 
            // lstBox_UsersAddedToGroup
            // 
            this.lstBox_UsersAddedToGroup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstBox_UsersAddedToGroup.DisplayMember = "Email";
            this.lstBox_UsersAddedToGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstBox_UsersAddedToGroup.FormattingEnabled = true;
            this.lstBox_UsersAddedToGroup.ItemHeight = 16;
            this.lstBox_UsersAddedToGroup.Location = new System.Drawing.Point(415, 68);
            this.lstBox_UsersAddedToGroup.Name = "lstBox_UsersAddedToGroup";
            this.lstBox_UsersAddedToGroup.Size = new System.Drawing.Size(181, 180);
            this.lstBox_UsersAddedToGroup.TabIndex = 21;
            this.lstBox_UsersAddedToGroup.ValueMember = "ID";
            // 
            // lstBox_UsersNotAddedToGroup
            // 
            this.lstBox_UsersNotAddedToGroup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstBox_UsersNotAddedToGroup.DisplayMember = "Email";
            this.lstBox_UsersNotAddedToGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstBox_UsersNotAddedToGroup.FormattingEnabled = true;
            this.lstBox_UsersNotAddedToGroup.ItemHeight = 16;
            this.lstBox_UsersNotAddedToGroup.Location = new System.Drawing.Point(106, 68);
            this.lstBox_UsersNotAddedToGroup.Name = "lstBox_UsersNotAddedToGroup";
            this.lstBox_UsersNotAddedToGroup.Size = new System.Drawing.Size(181, 180);
            this.lstBox_UsersNotAddedToGroup.TabIndex = 19;
            this.lstBox_UsersNotAddedToGroup.ValueMember = "MailGroupID";
            // 
            // btn_ChangeGroupName
            // 
            this.btn_ChangeGroupName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ChangeGroupName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChangeGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ChangeGroupName.ForeColor = System.Drawing.Color.White;
            this.btn_ChangeGroupName.Location = new System.Drawing.Point(295, 15);
            this.btn_ChangeGroupName.Name = "btn_ChangeGroupName";
            this.btn_ChangeGroupName.Size = new System.Drawing.Size(146, 32);
            this.btn_ChangeGroupName.TabIndex = 18;
            this.btn_ChangeGroupName.Text = "Grup Adını Değiştir";
            this.btn_ChangeGroupName.UseVisualStyleBackColor = true;
            this.btn_ChangeGroupName.Click += new System.EventHandler(this.btn_ChangeGroupName_Click);
            // 
            // btn_RemoveAllUsersFromGroup
            // 
            this.btn_RemoveAllUsersFromGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_RemoveAllUsersFromGroup.Depth = 0;
            this.btn_RemoveAllUsersFromGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveAllUsersFromGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_RemoveAllUsersFromGroup.ForeColor = System.Drawing.Color.White;
            this.btn_RemoveAllUsersFromGroup.Icon = null;
            this.btn_RemoveAllUsersFromGroup.Location = new System.Drawing.Point(329, 206);
            this.btn_RemoveAllUsersFromGroup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_RemoveAllUsersFromGroup.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_RemoveAllUsersFromGroup.Name = "btn_RemoveAllUsersFromGroup";
            this.btn_RemoveAllUsersFromGroup.Primary = false;
            this.btn_RemoveAllUsersFromGroup.Size = new System.Drawing.Size(49, 40);
            this.btn_RemoveAllUsersFromGroup.TabIndex = 16;
            this.btn_RemoveAllUsersFromGroup.Text = "<<";
            this.btn_RemoveAllUsersFromGroup.UseVisualStyleBackColor = true;
            this.btn_RemoveAllUsersFromGroup.Click += new System.EventHandler(this.btn_RemoveAllUsersFromGroup_Click);
            // 
            // btn_RemoveSelectedUserFromGroup
            // 
            this.btn_RemoveSelectedUserFromGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_RemoveSelectedUserFromGroup.Depth = 0;
            this.btn_RemoveSelectedUserFromGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveSelectedUserFromGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_RemoveSelectedUserFromGroup.ForeColor = System.Drawing.Color.White;
            this.btn_RemoveSelectedUserFromGroup.Icon = null;
            this.btn_RemoveSelectedUserFromGroup.Location = new System.Drawing.Point(329, 160);
            this.btn_RemoveSelectedUserFromGroup.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_RemoveSelectedUserFromGroup.Name = "btn_RemoveSelectedUserFromGroup";
            this.btn_RemoveSelectedUserFromGroup.Primary = false;
            this.btn_RemoveSelectedUserFromGroup.Size = new System.Drawing.Size(49, 40);
            this.btn_RemoveSelectedUserFromGroup.TabIndex = 15;
            this.btn_RemoveSelectedUserFromGroup.Text = "<";
            this.btn_RemoveSelectedUserFromGroup.UseVisualStyleBackColor = true;
            this.btn_RemoveSelectedUserFromGroup.Click += new System.EventHandler(this.btn_RemoveSelectedUserFromGroup_Click);
            // 
            // btn_AddAllUsersToGroup
            // 
            this.btn_AddAllUsersToGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_AddAllUsersToGroup.Depth = 0;
            this.btn_AddAllUsersToGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddAllUsersToGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_AddAllUsersToGroup.ForeColor = System.Drawing.Color.White;
            this.btn_AddAllUsersToGroup.Icon = null;
            this.btn_AddAllUsersToGroup.Location = new System.Drawing.Point(329, 114);
            this.btn_AddAllUsersToGroup.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_AddAllUsersToGroup.Name = "btn_AddAllUsersToGroup";
            this.btn_AddAllUsersToGroup.Primary = false;
            this.btn_AddAllUsersToGroup.Size = new System.Drawing.Size(49, 40);
            this.btn_AddAllUsersToGroup.TabIndex = 14;
            this.btn_AddAllUsersToGroup.Text = ">>";
            this.btn_AddAllUsersToGroup.UseVisualStyleBackColor = true;
            this.btn_AddAllUsersToGroup.Click += new System.EventHandler(this.btn_AddAllUsersToGroup_Click);
            // 
            // btn_AddSelectedUserToGroup
            // 
            this.btn_AddSelectedUserToGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_AddSelectedUserToGroup.Depth = 0;
            this.btn_AddSelectedUserToGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddSelectedUserToGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_AddSelectedUserToGroup.ForeColor = System.Drawing.Color.White;
            this.btn_AddSelectedUserToGroup.Icon = null;
            this.btn_AddSelectedUserToGroup.Location = new System.Drawing.Point(329, 68);
            this.btn_AddSelectedUserToGroup.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_AddSelectedUserToGroup.Name = "btn_AddSelectedUserToGroup";
            this.btn_AddSelectedUserToGroup.Primary = false;
            this.btn_AddSelectedUserToGroup.Size = new System.Drawing.Size(49, 40);
            this.btn_AddSelectedUserToGroup.TabIndex = 13;
            this.btn_AddSelectedUserToGroup.Text = ">";
            this.btn_AddSelectedUserToGroup.UseVisualStyleBackColor = true;
            this.btn_AddSelectedUserToGroup.Click += new System.EventHandler(this.btn_AddSelectedUserToGroup_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(7, 68);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = ": E-Posta Adresleri";
            // 
            // btn_NewGroup
            // 
            this.btn_NewGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_NewGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_NewGroup.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_NewGroup.Location = new System.Drawing.Point(583, 15);
            this.btn_NewGroup.Name = "btn_NewGroup";
            this.btn_NewGroup.Size = new System.Drawing.Size(130, 32);
            this.btn_NewGroup.TabIndex = 10;
            this.btn_NewGroup.Text = "Yeni Grup Ekle";
            this.btn_NewGroup.UseVisualStyleBackColor = true;
            this.btn_NewGroup.Click += new System.EventHandler(this.btn_NewGroup_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(43, 25);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = ": Grup Adı";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.Location = new System.Drawing.Point(106, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "Name";
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frm_Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(729, 539);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Email";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frm_Email";
            this.Load += new System.EventHandler(this.frm_Email_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grp_ServerSettings.ResumeLayout(false);
            this.grp_ServerSettings.PerformLayout();
            this.grp_MailGroups.ResumeLayout(false);
            this.grp_MailGroups.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grp_MailGroups;
        private System.Windows.Forms.ListBox lstBox_UsersAddedToGroup;
        private System.Windows.Forms.ListBox lstBox_UsersNotAddedToGroup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_NewGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox grp_ServerSettings;
        private System.Windows.Forms.CheckBox chkBox_ShowPassword;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_MailServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MailServerName;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_DeleteGroup;
        private System.Windows.Forms.Button btn_SendTestMail;
        private MaterialSkin.Controls.MaterialRaisedButton btn_RemoveAllUsersFromGroup;
        private MaterialSkin.Controls.MaterialRaisedButton btn_RemoveSelectedUserFromGroup;
        private MaterialSkin.Controls.MaterialRaisedButton btn_AddAllUsersToGroup;
        private MaterialSkin.Controls.MaterialRaisedButton btn_AddSelectedUserToGroup;
        private System.Windows.Forms.Button btn_ChangeGroupName;
        private System.Windows.Forms.TextBox txt_From;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbx_UseSSL;
    }
}