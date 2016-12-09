namespace EnMon_Driver_Manager
{
    partial class frm_AddNewOrUpdateBinarySignal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddNewOrUpdateBinarySignal));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grp_BasicInfo = new System.Windows.Forms.GroupBox();
            this.txt_SignalIdentification = new System.Windows.Forms.TextBox();
            this.txt_SignalName = new System.Windows.Forms.TextBox();
            this.cbx_DeviceName = new System.Windows.Forms.ComboBox();
            this.cbx_StationName = new System.Windows.Forms.ComboBox();
            this.txt_SignalID = new System.Windows.Forms.TextBox();
            this.grp_CommunicationParameters = new System.Windows.Forms.GroupBox();
            this.cbx_ComparisonType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbx_IsReversed = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_ModbusAddress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbx_FunctionCode = new System.Windows.Forms.ComboBox();
            this.txt_ComparisonBitNumber_Value = new System.Windows.Forms.TextBox();
            this.txt_WordCount = new System.Windows.Forms.TextBox();
            this.lbl_ComparisonBitNumber_Value = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbx_StatusText = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_IsAlarm = new MaterialSkin.Controls.MaterialCheckBox();
            this.cbx_IsEvent = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Alarm = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.grp_BasicInfo.SuspendLayout();
            this.grp_CommunicationParameters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Binary Sinyal ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "İstasyon Adı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cihaz Adı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sinyal Adı :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sinyal Uzun Adı :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Durum Yazısı :";
            // 
            // grp_BasicInfo
            // 
            this.grp_BasicInfo.Controls.Add(this.txt_SignalIdentification);
            this.grp_BasicInfo.Controls.Add(this.txt_SignalName);
            this.grp_BasicInfo.Controls.Add(this.cbx_DeviceName);
            this.grp_BasicInfo.Controls.Add(this.cbx_StationName);
            this.grp_BasicInfo.Controls.Add(this.txt_SignalID);
            this.grp_BasicInfo.Controls.Add(this.label1);
            this.grp_BasicInfo.Controls.Add(this.label2);
            this.grp_BasicInfo.Controls.Add(this.label5);
            this.grp_BasicInfo.Controls.Add(this.label3);
            this.grp_BasicInfo.Controls.Add(this.label4);
            this.grp_BasicInfo.Location = new System.Drawing.Point(12, 7);
            this.grp_BasicInfo.Name = "grp_BasicInfo";
            this.grp_BasicInfo.Size = new System.Drawing.Size(454, 155);
            this.grp_BasicInfo.TabIndex = 6;
            this.grp_BasicInfo.TabStop = false;
            this.grp_BasicInfo.Text = "Genel Ayarlar";
            // 
            // txt_SignalIdentification
            // 
            this.txt_SignalIdentification.Location = new System.Drawing.Point(117, 120);
            this.txt_SignalIdentification.Name = "txt_SignalIdentification";
            this.txt_SignalIdentification.Size = new System.Drawing.Size(333, 20);
            this.txt_SignalIdentification.TabIndex = 10;
            // 
            // txt_SignalName
            // 
            this.txt_SignalName.Enabled = false;
            this.txt_SignalName.Location = new System.Drawing.Point(118, 94);
            this.txt_SignalName.Name = "txt_SignalName";
            this.txt_SignalName.Size = new System.Drawing.Size(224, 20);
            this.txt_SignalName.TabIndex = 9;
            this.txt_SignalName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_SignalName_KeyUp);
            // 
            // cbx_DeviceName
            // 
            this.cbx_DeviceName.DisplayMember = "Name";
            this.cbx_DeviceName.FormattingEnabled = true;
            this.cbx_DeviceName.Location = new System.Drawing.Point(118, 67);
            this.cbx_DeviceName.Name = "cbx_DeviceName";
            this.cbx_DeviceName.Size = new System.Drawing.Size(224, 21);
            this.cbx_DeviceName.TabIndex = 8;
            this.cbx_DeviceName.SelectionChangeCommitted += new System.EventHandler(this.cbx_DeviceName_SelectionChangeCommitted);
            // 
            // cbx_StationName
            // 
            this.cbx_StationName.DisplayMember = "Name";
            this.cbx_StationName.FormattingEnabled = true;
            this.cbx_StationName.Location = new System.Drawing.Point(118, 39);
            this.cbx_StationName.Name = "cbx_StationName";
            this.cbx_StationName.Size = new System.Drawing.Size(224, 21);
            this.cbx_StationName.TabIndex = 7;
            this.cbx_StationName.SelectionChangeCommitted += new System.EventHandler(this.cbx_StationName_SelectionChangeCommitted);
            // 
            // txt_SignalID
            // 
            this.txt_SignalID.Location = new System.Drawing.Point(118, 13);
            this.txt_SignalID.Name = "txt_SignalID";
            this.txt_SignalID.Size = new System.Drawing.Size(224, 20);
            this.txt_SignalID.TabIndex = 6;
            // 
            // grp_CommunicationParameters
            // 
            this.grp_CommunicationParameters.Controls.Add(this.cbx_ComparisonType);
            this.grp_CommunicationParameters.Controls.Add(this.label13);
            this.grp_CommunicationParameters.Controls.Add(this.cbx_IsReversed);
            this.grp_CommunicationParameters.Controls.Add(this.label7);
            this.grp_CommunicationParameters.Controls.Add(this.txt_ModbusAddress);
            this.grp_CommunicationParameters.Controls.Add(this.label11);
            this.grp_CommunicationParameters.Controls.Add(this.cbx_FunctionCode);
            this.grp_CommunicationParameters.Controls.Add(this.txt_ComparisonBitNumber_Value);
            this.grp_CommunicationParameters.Controls.Add(this.txt_WordCount);
            this.grp_CommunicationParameters.Controls.Add(this.lbl_ComparisonBitNumber_Value);
            this.grp_CommunicationParameters.Controls.Add(this.label9);
            this.grp_CommunicationParameters.Controls.Add(this.label8);
            this.grp_CommunicationParameters.Location = new System.Drawing.Point(12, 168);
            this.grp_CommunicationParameters.Name = "grp_CommunicationParameters";
            this.grp_CommunicationParameters.Size = new System.Drawing.Size(454, 174);
            this.grp_CommunicationParameters.TabIndex = 7;
            this.grp_CommunicationParameters.TabStop = false;
            this.grp_CommunicationParameters.Text = "Haberleşme Ayarları";
            // 
            // cbx_ComparisonType
            // 
            this.cbx_ComparisonType.Enabled = false;
            this.cbx_ComparisonType.FormattingEnabled = true;
            this.cbx_ComparisonType.Location = new System.Drawing.Point(117, 70);
            this.cbx_ComparisonType.Name = "cbx_ComparisonType";
            this.cbx_ComparisonType.Size = new System.Drawing.Size(224, 21);
            this.cbx_ComparisonType.TabIndex = 27;
            this.cbx_ComparisonType.SelectedIndexChanged += new System.EventHandler(this.cbx_ComparisonType_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Karşılaştırma Tipi :";
            // 
            // cbx_IsReversed
            // 
            this.cbx_IsReversed.AutoSize = true;
            this.cbx_IsReversed.Location = new System.Drawing.Point(117, 149);
            this.cbx_IsReversed.Name = "cbx_IsReversed";
            this.cbx_IsReversed.Size = new System.Drawing.Size(15, 14);
            this.cbx_IsReversed.TabIndex = 25;
            this.cbx_IsReversed.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Tersle :";
            // 
            // txt_ModbusAddress
            // 
            this.txt_ModbusAddress.Location = new System.Drawing.Point(117, 15);
            this.txt_ModbusAddress.Name = "txt_ModbusAddress";
            this.txt_ModbusAddress.Size = new System.Drawing.Size(224, 20);
            this.txt_ModbusAddress.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(67, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Adres :";
            // 
            // cbx_FunctionCode
            // 
            this.cbx_FunctionCode.FormattingEnabled = true;
            this.cbx_FunctionCode.Location = new System.Drawing.Point(117, 41);
            this.cbx_FunctionCode.Name = "cbx_FunctionCode";
            this.cbx_FunctionCode.Size = new System.Drawing.Size(224, 21);
            this.cbx_FunctionCode.TabIndex = 14;
            this.cbx_FunctionCode.SelectedIndexChanged += new System.EventHandler(this.cbx_FunctionCode_SelectedIndexChanged);
            // 
            // txt_ComparisonBitNumber_Value
            // 
            this.txt_ComparisonBitNumber_Value.Enabled = false;
            this.txt_ComparisonBitNumber_Value.Location = new System.Drawing.Point(118, 123);
            this.txt_ComparisonBitNumber_Value.Name = "txt_ComparisonBitNumber_Value";
            this.txt_ComparisonBitNumber_Value.Size = new System.Drawing.Size(224, 20);
            this.txt_ComparisonBitNumber_Value.TabIndex = 18;
            // 
            // txt_WordCount
            // 
            this.txt_WordCount.Enabled = false;
            this.txt_WordCount.Location = new System.Drawing.Point(118, 97);
            this.txt_WordCount.Name = "txt_WordCount";
            this.txt_WordCount.Size = new System.Drawing.Size(224, 20);
            this.txt_WordCount.TabIndex = 17;
            // 
            // lbl_ComparisonBitNumber_Value
            // 
            this.lbl_ComparisonBitNumber_Value.Location = new System.Drawing.Point(54, 126);
            this.lbl_ComparisonBitNumber_Value.Name = "lbl_ComparisonBitNumber_Value";
            this.lbl_ComparisonBitNumber_Value.Size = new System.Drawing.Size(53, 13);
            this.lbl_ComparisonBitNumber_Value.TabIndex = 16;
            this.lbl_ComparisonBitNumber_Value.Text = "Bit Sırası :";
            this.lbl_ComparisonBitNumber_Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Register Sayısı :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Fonksiyon Kodu :";
            // 
            // cbx_StatusText
            // 
            this.cbx_StatusText.DisplayMember = "Name";
            this.cbx_StatusText.Enabled = false;
            this.cbx_StatusText.FormattingEnabled = true;
            this.cbx_StatusText.Location = new System.Drawing.Point(117, 63);
            this.cbx_StatusText.Name = "cbx_StatusText";
            this.cbx_StatusText.Size = new System.Drawing.Size(224, 21);
            this.cbx_StatusText.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_IsAlarm);
            this.groupBox1.Controls.Add(this.cbx_IsEvent);
            this.groupBox1.Controls.Add(this.cbx_StatusText);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.Alarm);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 348);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 97);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alarm/Olay Listesi Ayarları";
            // 
            // cbx_IsAlarm
            // 
            this.cbx_IsAlarm.AutoSize = true;
            this.cbx_IsAlarm.BackColor = System.Drawing.Color.Black;
            this.cbx_IsAlarm.Depth = 0;
            this.cbx_IsAlarm.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbx_IsAlarm.ForeColor = System.Drawing.Color.White;
            this.cbx_IsAlarm.Location = new System.Drawing.Point(109, 8);
            this.cbx_IsAlarm.Margin = new System.Windows.Forms.Padding(0);
            this.cbx_IsAlarm.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbx_IsAlarm.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbx_IsAlarm.Name = "cbx_IsAlarm";
            this.cbx_IsAlarm.Ripple = true;
            this.cbx_IsAlarm.Size = new System.Drawing.Size(26, 30);
            this.cbx_IsAlarm.TabIndex = 24;
            this.cbx_IsAlarm.UseVisualStyleBackColor = false;
            this.cbx_IsAlarm.CheckedChanged += new System.EventHandler(this.cbx_IsAlarm_CheckedChanged);
            // 
            // cbx_IsEvent
            // 
            this.cbx_IsEvent.AutoSize = true;
            this.cbx_IsEvent.Location = new System.Drawing.Point(118, 39);
            this.cbx_IsEvent.Name = "cbx_IsEvent";
            this.cbx_IsEvent.Size = new System.Drawing.Size(15, 14);
            this.cbx_IsEvent.TabIndex = 23;
            this.cbx_IsEvent.UseVisualStyleBackColor = true;
            this.cbx_IsEvent.CheckedChanged += new System.EventHandler(this.cbx_IsEvent_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(75, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Olay:";
            // 
            // Alarm
            // 
            this.Alarm.AutoSize = true;
            this.Alarm.Location = new System.Drawing.Point(67, 16);
            this.Alarm.Name = "Alarm";
            this.Alarm.Size = new System.Drawing.Size(39, 13);
            this.Alarm.TabIndex = 21;
            this.Alarm.Text = "Alarm :";
            // 
            // btn_OK
            // 
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Location = new System.Drawing.Point(244, 451);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(109, 30);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "Ekle";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Location = new System.Drawing.Point(357, 451);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(109, 30);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "İptal";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Location = new System.Drawing.Point(130, 451);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(109, 30);
            this.btn_Delete.TabIndex = 11;
            this.btn_Delete.Text = "Sil";
            this.btn_Delete.UseVisualStyleBackColor = true;
            // 
            // frm_AddNewOrUpdateBinarySignal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(477, 487);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp_CommunicationParameters);
            this.Controls.Add(this.grp_BasicInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_AddNewOrUpdateBinarySignal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Sinyal Ekle";
            this.grp_BasicInfo.ResumeLayout(false);
            this.grp_BasicInfo.PerformLayout();
            this.grp_CommunicationParameters.ResumeLayout(false);
            this.grp_CommunicationParameters.PerformLayout();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grp_BasicInfo;
        private System.Windows.Forms.GroupBox grp_CommunicationParameters;
        private System.Windows.Forms.TextBox txt_SignalIdentification;
        private System.Windows.Forms.TextBox txt_SignalName;
        private System.Windows.Forms.ComboBox cbx_DeviceName;
        private System.Windows.Forms.ComboBox cbx_StationName;
        private System.Windows.Forms.TextBox txt_SignalID;
        private System.Windows.Forms.TextBox txt_ModbusAddress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbx_FunctionCode;
        private System.Windows.Forms.TextBox txt_ComparisonBitNumber_Value;
        private System.Windows.Forms.TextBox txt_WordCount;
        private System.Windows.Forms.Label lbl_ComparisonBitNumber_Value;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbx_StatusText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbx_IsEvent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label Alarm;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.CheckBox cbx_IsReversed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Delete;
        private MaterialSkin.Controls.MaterialCheckBox cbx_IsAlarm;
        private System.Windows.Forms.ComboBox cbx_ComparisonType;
        private System.Windows.Forms.Label label13;
    }
}