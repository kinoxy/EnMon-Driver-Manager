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
            this.label9 = new System.Windows.Forms.Label();
            this.btn_NewGroup = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_AddSelectedUserToGroup = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_AddAllUsersToGroup = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_RemoveSelectedUserFromGroup = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_RemoveAllUsersFromGroup = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btn_ChangeGroupName = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lstBox_UsersNotAddedToGroup = new System.Windows.Forms.ListBox();
            this.lstBox_UsersAddedToGroup = new System.Windows.Forms.ListBox();
            this.btn_DeleteGroup = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_Update = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(40, 13);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = ": Grup Adı";
            // 
            // btn_NewGroup
            // 
            this.btn_NewGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_NewGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_NewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_NewGroup.Location = new System.Drawing.Point(578, 3);
            this.btn_NewGroup.Name = "btn_NewGroup";
            this.btn_NewGroup.Size = new System.Drawing.Size(132, 32);
            this.btn_NewGroup.TabIndex = 10;
            this.btn_NewGroup.Values.Text = "Yeni Grup Ekle";
            this.btn_NewGroup.Click += new System.EventHandler(this.btn_NewGroup_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(4, 56);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = ": E-Posta Adresleri";
            // 
            // btn_AddSelectedUserToGroup
            // 
            this.btn_AddSelectedUserToGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_AddSelectedUserToGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_AddSelectedUserToGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_AddSelectedUserToGroup.Location = new System.Drawing.Point(383, 56);
            this.btn_AddSelectedUserToGroup.Name = "btn_AddSelectedUserToGroup";
            this.btn_AddSelectedUserToGroup.Size = new System.Drawing.Size(49, 40);
            this.btn_AddSelectedUserToGroup.TabIndex = 13;
            this.btn_AddSelectedUserToGroup.Values.Text = ">";
            this.btn_AddSelectedUserToGroup.Click += new System.EventHandler(this.btn_AddSelectedUserToGroup_Click);
            // 
            // btn_AddAllUsersToGroup
            // 
            this.btn_AddAllUsersToGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_AddAllUsersToGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_AddAllUsersToGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_AddAllUsersToGroup.Location = new System.Drawing.Point(383, 108);
            this.btn_AddAllUsersToGroup.Name = "btn_AddAllUsersToGroup";
            this.btn_AddAllUsersToGroup.Size = new System.Drawing.Size(49, 40);
            this.btn_AddAllUsersToGroup.TabIndex = 14;
            this.btn_AddAllUsersToGroup.Values.Text = ">>";
            this.btn_AddAllUsersToGroup.Click += new System.EventHandler(this.btn_AddAllUsersToGroup_Click);
            // 
            // btn_RemoveSelectedUserFromGroup
            // 
            this.btn_RemoveSelectedUserFromGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_RemoveSelectedUserFromGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_RemoveSelectedUserFromGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_RemoveSelectedUserFromGroup.Location = new System.Drawing.Point(383, 160);
            this.btn_RemoveSelectedUserFromGroup.Name = "btn_RemoveSelectedUserFromGroup";
            this.btn_RemoveSelectedUserFromGroup.Size = new System.Drawing.Size(49, 40);
            this.btn_RemoveSelectedUserFromGroup.TabIndex = 15;
            this.btn_RemoveSelectedUserFromGroup.Values.Text = "<";
            this.btn_RemoveSelectedUserFromGroup.Click += new System.EventHandler(this.btn_RemoveSelectedUserFromGroup_Click);
            // 
            // btn_RemoveAllUsersFromGroup
            // 
            this.btn_RemoveAllUsersFromGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_RemoveAllUsersFromGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_RemoveAllUsersFromGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_RemoveAllUsersFromGroup.Location = new System.Drawing.Point(383, 212);
            this.btn_RemoveAllUsersFromGroup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_RemoveAllUsersFromGroup.Name = "btn_RemoveAllUsersFromGroup";
            this.btn_RemoveAllUsersFromGroup.Size = new System.Drawing.Size(49, 40);
            this.btn_RemoveAllUsersFromGroup.TabIndex = 16;
            this.btn_RemoveAllUsersFromGroup.Values.Text = "<<";
            this.btn_RemoveAllUsersFromGroup.Click += new System.EventHandler(this.btn_RemoveAllUsersFromGroup_Click);
            // 
            // btn_ChangeGroupName
            // 
            this.btn_ChangeGroupName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ChangeGroupName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ChangeGroupName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_ChangeGroupName.Location = new System.Drawing.Point(302, 3);
            this.btn_ChangeGroupName.Name = "btn_ChangeGroupName";
            this.btn_ChangeGroupName.Size = new System.Drawing.Size(132, 32);
            this.btn_ChangeGroupName.TabIndex = 18;
            this.btn_ChangeGroupName.Values.Text = "Grup Adını Değiştir";
            this.btn_ChangeGroupName.Click += new System.EventHandler(this.btn_ChangeGroupName_Click);
            // 
            // lstBox_UsersNotAddedToGroup
            // 
            this.lstBox_UsersNotAddedToGroup.BackColor = System.Drawing.Color.White;
            this.lstBox_UsersNotAddedToGroup.DisplayMember = "Email";
            this.lstBox_UsersNotAddedToGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstBox_UsersNotAddedToGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lstBox_UsersNotAddedToGroup.FormattingEnabled = true;
            this.lstBox_UsersNotAddedToGroup.ItemHeight = 16;
            this.lstBox_UsersNotAddedToGroup.Location = new System.Drawing.Point(103, 56);
            this.lstBox_UsersNotAddedToGroup.Name = "lstBox_UsersNotAddedToGroup";
            this.lstBox_UsersNotAddedToGroup.Size = new System.Drawing.Size(246, 196);
            this.lstBox_UsersNotAddedToGroup.TabIndex = 19;
            this.lstBox_UsersNotAddedToGroup.ValueMember = "MailGroupID";
            // 
            // lstBox_UsersAddedToGroup
            // 
            this.lstBox_UsersAddedToGroup.BackColor = System.Drawing.Color.White;
            this.lstBox_UsersAddedToGroup.DisplayMember = "Email";
            this.lstBox_UsersAddedToGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstBox_UsersAddedToGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lstBox_UsersAddedToGroup.FormattingEnabled = true;
            this.lstBox_UsersAddedToGroup.ItemHeight = 16;
            this.lstBox_UsersAddedToGroup.Location = new System.Drawing.Point(464, 56);
            this.lstBox_UsersAddedToGroup.Name = "lstBox_UsersAddedToGroup";
            this.lstBox_UsersAddedToGroup.Size = new System.Drawing.Size(246, 196);
            this.lstBox_UsersAddedToGroup.TabIndex = 21;
            this.lstBox_UsersAddedToGroup.ValueMember = "ID";
            // 
            // btn_DeleteGroup
            // 
            this.btn_DeleteGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_DeleteGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_DeleteGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_DeleteGroup.Location = new System.Drawing.Point(440, 3);
            this.btn_DeleteGroup.Name = "btn_DeleteGroup";
            this.btn_DeleteGroup.Size = new System.Drawing.Size(132, 32);
            this.btn_DeleteGroup.TabIndex = 22;
            this.btn_DeleteGroup.Values.Text = "Seçili Grubu Sil";
            this.btn_DeleteGroup.Click += new System.EventHandler(this.btn_DeleteGroup_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 21);
            this.comboBox1.TabIndex = 24;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Update.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Update.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Update.Location = new System.Drawing.Point(822, 272);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(152, 32);
            this.btn_Update.TabIndex = 23;
            this.btn_Update.Values.Text = "Değişiklikleri Güncelle";
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonGroupBox1.Location = new System.Drawing.Point(6, 6);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.comboBox1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lstBox_UsersNotAddedToGroup);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btn_Update);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label9);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btn_DeleteGroup);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btn_NewGroup);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lstBox_UsersAddedToGroup);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label10);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btn_AddSelectedUserToGroup);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btn_ChangeGroupName);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btn_AddAllUsersToGroup);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btn_RemoveAllUsersFromGroup);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btn_RemoveSelectedUserFromGroup);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(981, 331);
            this.kryptonGroupBox1.TabIndex = 25;
            this.kryptonGroupBox1.Values.Heading = "E-Posta Grupları\r\n";
            this.kryptonGroupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonGroupBox1_Paint);
            // 
            // frm_Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(993, 342);
            this.Controls.Add(this.kryptonGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Email";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frm_Email";
            this.Load += new System.EventHandler(this.frm_Email_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_NewGroup;
        private System.Windows.Forms.Label label10;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_AddSelectedUserToGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_AddAllUsersToGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_RemoveSelectedUserFromGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_RemoveAllUsersFromGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ChangeGroupName;
        private System.Windows.Forms.ListBox lstBox_UsersNotAddedToGroup;
        private System.Windows.Forms.ListBox lstBox_UsersAddedToGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_DeleteGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btn_Update;
        private System.Windows.Forms.ComboBox comboBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
    }
}