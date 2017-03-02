namespace EnMon_Driver_Manager.Forms
{
    partial class frm_MailClientSettings
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
            this.grp_ServerSettings = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.cbx_UseSSL = new System.Windows.Forms.CheckBox();
            this.txt_From = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_SendTestMail = new System.Windows.Forms.Button();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_MailServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MailServerName = new System.Windows.Forms.TextBox();
            this.grp_ServerSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_ServerSettings
            // 
            this.grp_ServerSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_ServerSettings.BackColor = System.Drawing.Color.Transparent;
            this.grp_ServerSettings.Controls.Add(this.textBox1);
            this.grp_ServerSettings.Controls.Add(this.label6);
            this.grp_ServerSettings.Controls.Add(this.btn_Update);
            this.grp_ServerSettings.Controls.Add(this.cbx_UseSSL);
            this.grp_ServerSettings.Controls.Add(this.txt_From);
            this.grp_ServerSettings.Controls.Add(this.label5);
            this.grp_ServerSettings.Controls.Add(this.btn_SendTestMail);
            this.grp_ServerSettings.Controls.Add(this.txt_Password);
            this.grp_ServerSettings.Controls.Add(this.label4);
            this.grp_ServerSettings.Controls.Add(this.txt_UserName);
            this.grp_ServerSettings.Controls.Add(this.label3);
            this.grp_ServerSettings.Controls.Add(this.txt_MailServerPort);
            this.grp_ServerSettings.Controls.Add(this.label2);
            this.grp_ServerSettings.Controls.Add(this.label1);
            this.grp_ServerSettings.Controls.Add(this.txt_MailServerName);
            this.grp_ServerSettings.ForeColor = System.Drawing.Color.White;
            this.grp_ServerSettings.Location = new System.Drawing.Point(12, 12);
            this.grp_ServerSettings.Name = "grp_ServerSettings";
            this.grp_ServerSettings.Size = new System.Drawing.Size(989, 141);
            this.grp_ServerSettings.TabIndex = 1;
            this.grp_ServerSettings.TabStop = false;
            this.grp_ServerSettings.Text = "E-Posta Sunucu Ayarları";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(757, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(217, 22);
            this.textBox1.TabIndex = 29;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(680, 52);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = ": Şifre Tekrar";
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Update.Location = new System.Drawing.Point(797, 99);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(177, 32);
            this.btn_Update.TabIndex = 27;
            this.btn_Update.Text = "Değişiklikleri Güncelle";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // cbx_UseSSL
            // 
            this.cbx_UseSSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_UseSSL.AutoSize = true;
            this.cbx_UseSSL.Location = new System.Drawing.Point(784, 76);
            this.cbx_UseSSL.Name = "cbx_UseSSL";
            this.cbx_UseSSL.Size = new System.Drawing.Size(190, 17);
            this.cbx_UseSSL.TabIndex = 26;
            this.cbx_UseSSL.Text = "Hesaba Giriş Yaparken SSL Kullan";
            this.cbx_UseSSL.UseVisualStyleBackColor = true;
            // 
            // txt_From
            // 
            this.txt_From.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_From.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_From.Location = new System.Drawing.Point(436, 17);
            this.txt_From.Name = "txt_From";
            this.txt_From.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_From.Size = new System.Drawing.Size(217, 22);
            this.txt_From.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 22);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = ": Gönderen Adres";
            // 
            // btn_SendTestMail
            // 
            this.btn_SendTestMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SendTestMail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_SendTestMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SendTestMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_SendTestMail.Location = new System.Drawing.Point(616, 99);
            this.btn_SendTestMail.Name = "btn_SendTestMail";
            this.btn_SendTestMail.Size = new System.Drawing.Size(177, 32);
            this.btn_SendTestMail.TabIndex = 23;
            this.btn_SendTestMail.Text = "Test E-postası Gönder";
            this.btn_SendTestMail.UseVisualStyleBackColor = true;
            this.btn_SendTestMail.Click += new System.EventHandler(this.btn_SendTestMail_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Password.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Password.Location = new System.Drawing.Point(757, 17);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Password.Size = new System.Drawing.Size(217, 22);
            this.txt_Password.TabIndex = 7;
            this.txt_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(714, 22);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = ": Şifre";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_UserName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_UserName.Location = new System.Drawing.Point(437, 48);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_UserName.Size = new System.Drawing.Size(217, 22);
            this.txt_UserName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 53);
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
            this.txt_MailServerPort.Size = new System.Drawing.Size(217, 22);
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
            this.txt_MailServerName.Size = new System.Drawing.Size(217, 22);
            this.txt_MailServerName.TabIndex = 0;
            // 
            // frm_MailClientSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1013, 162);
            this.Controls.Add(this.grp_ServerSettings);
            this.Name = "frm_MailClientSettings";
            this.Text = "frm_MailClientSettings";
            this.Load += new System.EventHandler(this.frm_MailClientSettings_Load);
            this.grp_ServerSettings.ResumeLayout(false);
            this.grp_ServerSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_ServerSettings;
        private System.Windows.Forms.CheckBox cbx_UseSSL;
        private System.Windows.Forms.TextBox txt_From;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_SendTestMail;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_MailServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MailServerName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Update;
    }
}