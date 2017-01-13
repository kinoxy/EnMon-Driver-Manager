namespace EnMon_Driver_Manager.Forms
{
    partial class frm_GetDatabaseConnectionProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_GetDatabaseConnectionProperties));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.cbx_DatabaseType = new System.Windows.Forms.ComboBox();
            this.txt_ServerAddress = new System.Windows.Forms.TextBox();
            this.txt_DatabaseName = new System.Windows.Forms.TextBox();
            this.txt_DatabaseUserName = new System.Windows.Forms.TextBox();
            this.txt_DatabaseUserPassword = new System.Windows.Forms.TextBox();
            this.txt_DatabaseUserPasswordConfirmation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Veritabanı Tipi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Veritabanı Adresi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Veritabanı Adı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kullanıcı Adı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Şifre";
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_OK.Location = new System.Drawing.Point(112, 199);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = "Tamam";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(193, 199);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "İptal";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // cbx_DatabaseType
            // 
            this.cbx_DatabaseType.FormattingEnabled = true;
            this.cbx_DatabaseType.Location = new System.Drawing.Point(108, 19);
            this.cbx_DatabaseType.Name = "cbx_DatabaseType";
            this.cbx_DatabaseType.Size = new System.Drawing.Size(141, 21);
            this.cbx_DatabaseType.TabIndex = 7;
            // 
            // txt_ServerAddress
            // 
            this.txt_ServerAddress.Location = new System.Drawing.Point(108, 46);
            this.txt_ServerAddress.Name = "txt_ServerAddress";
            this.txt_ServerAddress.Size = new System.Drawing.Size(141, 20);
            this.txt_ServerAddress.TabIndex = 8;
            // 
            // txt_DatabaseName
            // 
            this.txt_DatabaseName.Location = new System.Drawing.Point(108, 73);
            this.txt_DatabaseName.Name = "txt_DatabaseName";
            this.txt_DatabaseName.Size = new System.Drawing.Size(141, 20);
            this.txt_DatabaseName.TabIndex = 9;
            // 
            // txt_DatabaseUserName
            // 
            this.txt_DatabaseUserName.Location = new System.Drawing.Point(108, 99);
            this.txt_DatabaseUserName.Name = "txt_DatabaseUserName";
            this.txt_DatabaseUserName.Size = new System.Drawing.Size(141, 20);
            this.txt_DatabaseUserName.TabIndex = 10;
            // 
            // txt_DatabaseUserPassword
            // 
            this.txt_DatabaseUserPassword.Location = new System.Drawing.Point(108, 125);
            this.txt_DatabaseUserPassword.Name = "txt_DatabaseUserPassword";
            this.txt_DatabaseUserPassword.Size = new System.Drawing.Size(141, 20);
            this.txt_DatabaseUserPassword.TabIndex = 11;
            // 
            // txt_DatabaseUserPasswordConfirmation
            // 
            this.txt_DatabaseUserPasswordConfirmation.Location = new System.Drawing.Point(108, 151);
            this.txt_DatabaseUserPasswordConfirmation.Name = "txt_DatabaseUserPasswordConfirmation";
            this.txt_DatabaseUserPasswordConfirmation.Size = new System.Drawing.Size(141, 20);
            this.txt_DatabaseUserPasswordConfirmation.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Şifre Tekrar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_DatabaseUserPasswordConfirmation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_DatabaseUserPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_DatabaseUserName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_DatabaseName);
            this.groupBox1.Controls.Add(this.cbx_DatabaseType);
            this.groupBox1.Controls.Add(this.txt_ServerAddress);
            this.groupBox1.Location = new System.Drawing.Point(11, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 184);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Veritabanı Bilgileri";
            // 
            // frm_GetDatabaseConnectionProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(280, 231);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_GetDatabaseConnectionProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veritabanı Bilgileri";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ComboBox cbx_DatabaseType;
        private System.Windows.Forms.TextBox txt_ServerAddress;
        private System.Windows.Forms.TextBox txt_DatabaseName;
        private System.Windows.Forms.TextBox txt_DatabaseUserName;
        private System.Windows.Forms.TextBox txt_DatabaseUserPassword;
        private System.Windows.Forms.TextBox txt_DatabaseUserPasswordConfirmation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}