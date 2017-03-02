namespace EnMon_Driver_Manager.Forms
{
    partial class frm_Drivers
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkBox_AlarmMailingActivated = new System.Windows.Forms.CheckBox();
            this.txt_MailClientConfigFileLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ChangeMailClientConfigFileLocation = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBox_ArchivingActivated = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBox_ModbusTCPCommunicationActivated = new System.Windows.Forms.CheckBox();
            this.txt_ModbusTCPConfigFileLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ChangeModbusDriverConfigFileLocation = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox4.Location = new System.Drawing.Point(12, 116);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(762, 98);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SNMP Haberleşmesi";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkBox1.Location = new System.Drawing.Point(128, 60);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(266, 20);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "SNMP Haberleşmesini Sürücü İle Başlat";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(128, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(510, 22);
            this.textBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ayar Dosyası Konumu :";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button1.Location = new System.Drawing.Point(655, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Değiştir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chkBox_AlarmMailingActivated);
            this.groupBox3.Controls.Add(this.txt_MailClientConfigFileLocation);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btn_ChangeMailClientConfigFileLocation);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(12, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(762, 98);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Alarm E-Postaları Gönderimi";
            // 
            // chkBox_AlarmMailingActivated
            // 
            this.chkBox_AlarmMailingActivated.AutoSize = true;
            this.chkBox_AlarmMailingActivated.Checked = true;
            this.chkBox_AlarmMailingActivated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_AlarmMailingActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkBox_AlarmMailingActivated.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkBox_AlarmMailingActivated.Location = new System.Drawing.Point(128, 60);
            this.chkBox_AlarmMailingActivated.Name = "chkBox_AlarmMailingActivated";
            this.chkBox_AlarmMailingActivated.Size = new System.Drawing.Size(290, 20);
            this.chkBox_AlarmMailingActivated.TabIndex = 3;
            this.chkBox_AlarmMailingActivated.Text = "E-Posta Alarm Gönderimini Sürücü İle Başlat";
            this.chkBox_AlarmMailingActivated.UseVisualStyleBackColor = true;
            // 
            // txt_MailClientConfigFileLocation
            // 
            this.txt_MailClientConfigFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_MailClientConfigFileLocation.Location = new System.Drawing.Point(128, 19);
            this.txt_MailClientConfigFileLocation.Name = "txt_MailClientConfigFileLocation";
            this.txt_MailClientConfigFileLocation.Size = new System.Drawing.Size(510, 22);
            this.txt_MailClientConfigFileLocation.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ayar Dosyası Konumu :";
            // 
            // btn_ChangeMailClientConfigFileLocation
            // 
            this.btn_ChangeMailClientConfigFileLocation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_ChangeMailClientConfigFileLocation.Location = new System.Drawing.Point(655, 17);
            this.btn_ChangeMailClientConfigFileLocation.Name = "btn_ChangeMailClientConfigFileLocation";
            this.btn_ChangeMailClientConfigFileLocation.Size = new System.Drawing.Size(86, 27);
            this.btn_ChangeMailClientConfigFileLocation.TabIndex = 0;
            this.btn_ChangeMailClientConfigFileLocation.Text = "Değiştir";
            this.btn_ChangeMailClientConfigFileLocation.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkBox_ArchivingActivated);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(12, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(762, 55);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Arşivleme";
            // 
            // chkBox_ArchivingActivated
            // 
            this.chkBox_ArchivingActivated.AutoSize = true;
            this.chkBox_ArchivingActivated.Checked = true;
            this.chkBox_ArchivingActivated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_ArchivingActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkBox_ArchivingActivated.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkBox_ArchivingActivated.Location = new System.Drawing.Point(128, 19);
            this.chkBox_ArchivingActivated.Name = "chkBox_ArchivingActivated";
            this.chkBox_ArchivingActivated.Size = new System.Drawing.Size(199, 20);
            this.chkBox_ArchivingActivated.TabIndex = 3;
            this.chkBox_ArchivingActivated.Text = "Arşivlemeyi Sürücü İle Başlat";
            this.chkBox_ArchivingActivated.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkBox_ModbusTCPCommunicationActivated);
            this.groupBox1.Controls.Add(this.txt_ModbusTCPConfigFileLocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_ChangeModbusDriverConfigFileLocation);
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 98);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modbus TCP Haberleşmesi";
            // 
            // chkBox_ModbusTCPCommunicationActivated
            // 
            this.chkBox_ModbusTCPCommunicationActivated.AutoSize = true;
            this.chkBox_ModbusTCPCommunicationActivated.Checked = true;
            this.chkBox_ModbusTCPCommunicationActivated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_ModbusTCPCommunicationActivated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkBox_ModbusTCPCommunicationActivated.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkBox_ModbusTCPCommunicationActivated.Location = new System.Drawing.Point(128, 60);
            this.chkBox_ModbusTCPCommunicationActivated.Name = "chkBox_ModbusTCPCommunicationActivated";
            this.chkBox_ModbusTCPCommunicationActivated.Size = new System.Drawing.Size(306, 20);
            this.chkBox_ModbusTCPCommunicationActivated.TabIndex = 3;
            this.chkBox_ModbusTCPCommunicationActivated.Text = "Modbus TCP Haberleşmesini Sürücü İle Başlat";
            this.chkBox_ModbusTCPCommunicationActivated.UseVisualStyleBackColor = true;
            // 
            // txt_ModbusTCPConfigFileLocation
            // 
            this.txt_ModbusTCPConfigFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_ModbusTCPConfigFileLocation.Location = new System.Drawing.Point(128, 19);
            this.txt_ModbusTCPConfigFileLocation.Name = "txt_ModbusTCPConfigFileLocation";
            this.txt_ModbusTCPConfigFileLocation.Size = new System.Drawing.Size(510, 22);
            this.txt_ModbusTCPConfigFileLocation.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ayar Dosyası Konumu :";
            // 
            // btn_ChangeModbusDriverConfigFileLocation
            // 
            this.btn_ChangeModbusDriverConfigFileLocation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_ChangeModbusDriverConfigFileLocation.Location = new System.Drawing.Point(655, 17);
            this.btn_ChangeModbusDriverConfigFileLocation.Name = "btn_ChangeModbusDriverConfigFileLocation";
            this.btn_ChangeModbusDriverConfigFileLocation.Size = new System.Drawing.Size(86, 27);
            this.btn_ChangeModbusDriverConfigFileLocation.TabIndex = 0;
            this.btn_ChangeModbusDriverConfigFileLocation.Text = "Değiştir";
            this.btn_ChangeModbusDriverConfigFileLocation.UseVisualStyleBackColor = true;
            this.btn_ChangeModbusDriverConfigFileLocation.Click += new System.EventHandler(this.btn_ChangeModbusDriverConfigFileLocation_Click_1);
            // 
            // frm_Drivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(788, 390);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_Drivers";
            this.Text = "frm_Drivers";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkBox_AlarmMailingActivated;
        private System.Windows.Forms.TextBox txt_MailClientConfigFileLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ChangeMailClientConfigFileLocation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkBox_ArchivingActivated;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBox_ModbusTCPCommunicationActivated;
        private System.Windows.Forms.TextBox txt_ModbusTCPConfigFileLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ChangeModbusDriverConfigFileLocation;
    }
}