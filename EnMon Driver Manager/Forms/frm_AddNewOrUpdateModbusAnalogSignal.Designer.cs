namespace EnMon_Driver_Manager
{
    partial class frm_AddNewOrUpdateModbusAnalogSignal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddNewOrUpdateModbusAnalogSignal));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grp_BasicInfo = new System.Windows.Forms.GroupBox();
            this.txt_Unit = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_SignalIdentification = new System.Windows.Forms.TextBox();
            this.txt_SignalName = new System.Windows.Forms.TextBox();
            this.cbx_DeviceName = new System.Windows.Forms.ComboBox();
            this.cbx_StationName = new System.Windows.Forms.ComboBox();
            this.txt_SignalID = new System.Windows.Forms.TextBox();
            this.grp_CommunicationParameters = new System.Windows.Forms.GroupBox();
            this.cbx_DataType = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_ModbusAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbx_FunctionCode = new System.Windows.Forms.ComboBox();
            this.txt_ScaleValue = new System.Windows.Forms.TextBox();
            this.txt_WordCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbx_MaxAlarmStatus = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbx_HasMaxAlarm = new System.Windows.Forms.CheckBox();
            this.txt_MaxAlarmValue = new System.Windows.Forms.TextBox();
            this.Alarm = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbx_HasMinAlarm = new System.Windows.Forms.CheckBox();
            this.txt_MinAlarmValue = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbx_MinAlarmStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbx_IsArchive = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbx_Archive = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.grp_BasicInfo.SuspendLayout();
            this.grp_CommunicationParameters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Analog Sinyal ID :";
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
            this.label6.Location = new System.Drawing.Point(31, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Durum Yazısı :";
            // 
            // grp_BasicInfo
            // 
            this.grp_BasicInfo.Controls.Add(this.txt_Unit);
            this.grp_BasicInfo.Controls.Add(this.label14);
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
            this.grp_BasicInfo.Size = new System.Drawing.Size(454, 179);
            this.grp_BasicInfo.TabIndex = 6;
            this.grp_BasicInfo.TabStop = false;
            this.grp_BasicInfo.Text = "Genel Ayarlar";
            // 
            // txt_Unit
            // 
            this.txt_Unit.Location = new System.Drawing.Point(117, 149);
            this.txt_Unit.Name = "txt_Unit";
            this.txt_Unit.Size = new System.Drawing.Size(116, 20);
            this.txt_Unit.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(72, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Birim :";
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
            this.cbx_DeviceName.Enabled = false;
            this.cbx_DeviceName.FormattingEnabled = true;
            this.cbx_DeviceName.Location = new System.Drawing.Point(118, 67);
            this.cbx_DeviceName.Name = "cbx_DeviceName";
            this.cbx_DeviceName.Size = new System.Drawing.Size(224, 21);
            this.cbx_DeviceName.TabIndex = 8;
            this.cbx_DeviceName.ValueMember = "ID";
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
            this.cbx_StationName.SelectedValueChanged += new System.EventHandler(this.cbx_StationName_SelectedValueChanged);
            // 
            // txt_SignalID
            // 
            this.txt_SignalID.Enabled = false;
            this.txt_SignalID.Location = new System.Drawing.Point(118, 13);
            this.txt_SignalID.Name = "txt_SignalID";
            this.txt_SignalID.Size = new System.Drawing.Size(224, 20);
            this.txt_SignalID.TabIndex = 6;
            // 
            // grp_CommunicationParameters
            // 
            this.grp_CommunicationParameters.Controls.Add(this.cbx_DataType);
            this.grp_CommunicationParameters.Controls.Add(this.label16);
            this.grp_CommunicationParameters.Controls.Add(this.txt_ModbusAddress);
            this.grp_CommunicationParameters.Controls.Add(this.label13);
            this.grp_CommunicationParameters.Controls.Add(this.label11);
            this.grp_CommunicationParameters.Controls.Add(this.cbx_FunctionCode);
            this.grp_CommunicationParameters.Controls.Add(this.txt_ScaleValue);
            this.grp_CommunicationParameters.Controls.Add(this.txt_WordCount);
            this.grp_CommunicationParameters.Controls.Add(this.label9);
            this.grp_CommunicationParameters.Controls.Add(this.label8);
            this.grp_CommunicationParameters.Location = new System.Drawing.Point(12, 192);
            this.grp_CommunicationParameters.Name = "grp_CommunicationParameters";
            this.grp_CommunicationParameters.Size = new System.Drawing.Size(454, 152);
            this.grp_CommunicationParameters.TabIndex = 7;
            this.grp_CommunicationParameters.TabStop = false;
            this.grp_CommunicationParameters.Text = "Haberleşme Ayarları";
            // 
            // cbx_DataType
            // 
            this.cbx_DataType.DisplayMember = "Name";
            this.cbx_DataType.FormattingEnabled = true;
            this.cbx_DataType.Location = new System.Drawing.Point(118, 120);
            this.cbx_DataType.Name = "cbx_DataType";
            this.cbx_DataType.Size = new System.Drawing.Size(224, 21);
            this.cbx_DataType.TabIndex = 21;
            this.cbx_DataType.ValueMember = "ID";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(48, 123);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Data Tipi :";
            // 
            // txt_ModbusAddress
            // 
            this.txt_ModbusAddress.Location = new System.Drawing.Point(117, 15);
            this.txt_ModbusAddress.Name = "txt_ModbusAddress";
            this.txt_ModbusAddress.Size = new System.Drawing.Size(224, 20);
            this.txt_ModbusAddress.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Skala Değeri :";
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
            // 
            // txt_ScaleValue
            // 
            this.txt_ScaleValue.Location = new System.Drawing.Point(118, 94);
            this.txt_ScaleValue.Name = "txt_ScaleValue";
            this.txt_ScaleValue.Size = new System.Drawing.Size(224, 20);
            this.txt_ScaleValue.TabIndex = 18;
            // 
            // txt_WordCount
            // 
            this.txt_WordCount.Location = new System.Drawing.Point(118, 68);
            this.txt_WordCount.Name = "txt_WordCount";
            this.txt_WordCount.Size = new System.Drawing.Size(224, 20);
            this.txt_WordCount.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 71);
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
            // cbx_MaxAlarmStatus
            // 
            this.cbx_MaxAlarmStatus.DisplayMember = "Name";
            this.cbx_MaxAlarmStatus.Enabled = false;
            this.cbx_MaxAlarmStatus.FormattingEnabled = true;
            this.cbx_MaxAlarmStatus.Location = new System.Drawing.Point(117, 69);
            this.cbx_MaxAlarmStatus.Name = "cbx_MaxAlarmStatus";
            this.cbx_MaxAlarmStatus.Size = new System.Drawing.Size(224, 21);
            this.cbx_MaxAlarmStatus.TabIndex = 11;
            this.cbx_MaxAlarmStatus.ValueMember = "ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbx_HasMaxAlarm);
            this.groupBox1.Controls.Add(this.txt_MaxAlarmValue);
            this.groupBox1.Controls.Add(this.cbx_MaxAlarmStatus);
            this.groupBox1.Controls.Add(this.Alarm);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 428);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 101);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maksimum Değer Alarm Ayarları";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Alarm Değeri :";
            // 
            // cbx_HasMaxAlarm
            // 
            this.cbx_HasMaxAlarm.AutoSize = true;
            this.cbx_HasMaxAlarm.Location = new System.Drawing.Point(117, 17);
            this.cbx_HasMaxAlarm.Name = "cbx_HasMaxAlarm";
            this.cbx_HasMaxAlarm.Size = new System.Drawing.Size(15, 14);
            this.cbx_HasMaxAlarm.TabIndex = 24;
            this.cbx_HasMaxAlarm.UseVisualStyleBackColor = true;
            this.cbx_HasMaxAlarm.CheckedChanged += new System.EventHandler(this.cbx_HasMaxAlarm_CheckedChanged);
            // 
            // txt_MaxAlarmValue
            // 
            this.txt_MaxAlarmValue.Enabled = false;
            this.txt_MaxAlarmValue.Location = new System.Drawing.Point(117, 40);
            this.txt_MaxAlarmValue.Name = "txt_MaxAlarmValue";
            this.txt_MaxAlarmValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_MaxAlarmValue.Size = new System.Drawing.Size(69, 20);
            this.txt_MaxAlarmValue.TabIndex = 27;
            this.txt_MaxAlarmValue.Text = "0";
            this.txt_MaxAlarmValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Alarm
            // 
            this.Alarm.AutoSize = true;
            this.Alarm.Location = new System.Drawing.Point(14, 17);
            this.Alarm.Name = "Alarm";
            this.Alarm.Size = new System.Drawing.Size(92, 13);
            this.Alarm.TabIndex = 21;
            this.Alarm.Text = "Maksimum Alarm :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Alarm Değeri :";
            // 
            // cbx_HasMinAlarm
            // 
            this.cbx_HasMinAlarm.AutoSize = true;
            this.cbx_HasMinAlarm.Location = new System.Drawing.Point(117, 16);
            this.cbx_HasMinAlarm.Name = "cbx_HasMinAlarm";
            this.cbx_HasMinAlarm.Size = new System.Drawing.Size(15, 14);
            this.cbx_HasMinAlarm.TabIndex = 29;
            this.cbx_HasMinAlarm.UseVisualStyleBackColor = true;
            this.cbx_HasMinAlarm.CheckedChanged += new System.EventHandler(this.cbx_HasMinAlarm_CheckedChanged);
            // 
            // txt_MinAlarmValue
            // 
            this.txt_MinAlarmValue.Enabled = false;
            this.txt_MinAlarmValue.Location = new System.Drawing.Point(117, 38);
            this.txt_MinAlarmValue.Name = "txt_MinAlarmValue";
            this.txt_MinAlarmValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_MinAlarmValue.Size = new System.Drawing.Size(69, 20);
            this.txt_MinAlarmValue.TabIndex = 31;
            this.txt_MinAlarmValue.Text = "0";
            this.txt_MinAlarmValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Minimum Alarm :";
            // 
            // btn_OK
            // 
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Location = new System.Drawing.Point(244, 637);
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
            this.btn_Cancel.Location = new System.Drawing.Point(357, 637);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(109, 30);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "İptal";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbx_MinAlarmStatus);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_MinAlarmValue);
            this.groupBox2.Controls.Add(this.cbx_HasMinAlarm);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(12, 535);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 96);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Minimum Değer Alarm Ayarları";
            // 
            // cbx_MinAlarmStatus
            // 
            this.cbx_MinAlarmStatus.DisplayMember = "Name";
            this.cbx_MinAlarmStatus.Enabled = false;
            this.cbx_MinAlarmStatus.FormattingEnabled = true;
            this.cbx_MinAlarmStatus.Location = new System.Drawing.Point(117, 64);
            this.cbx_MinAlarmStatus.Name = "cbx_MinAlarmStatus";
            this.cbx_MinAlarmStatus.Size = new System.Drawing.Size(224, 21);
            this.cbx_MinAlarmStatus.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Durum Yazısı :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbx_IsArchive);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.cbx_Archive);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Location = new System.Drawing.Point(12, 350);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(450, 72);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Arşivleme";
            // 
            // cbx_IsArchive
            // 
            this.cbx_IsArchive.AutoSize = true;
            this.cbx_IsArchive.Location = new System.Drawing.Point(115, 16);
            this.cbx_IsArchive.Name = "cbx_IsArchive";
            this.cbx_IsArchive.Size = new System.Drawing.Size(15, 14);
            this.cbx_IsArchive.TabIndex = 31;
            this.cbx_IsArchive.UseVisualStyleBackColor = true;
            this.cbx_IsArchive.CheckedChanged += new System.EventHandler(this.cbx_IsArchive_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(46, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "Arşivleme :";
            // 
            // cbx_Archive
            // 
            this.cbx_Archive.DisplayMember = "Description";
            this.cbx_Archive.Enabled = false;
            this.cbx_Archive.FormattingEnabled = true;
            this.cbx_Archive.Location = new System.Drawing.Point(115, 41);
            this.cbx_Archive.Name = "cbx_Archive";
            this.cbx_Archive.Size = new System.Drawing.Size(224, 21);
            this.cbx_Archive.TabIndex = 29;
            this.cbx_Archive.ValueMember = "ID";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(2, 44);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 13);
            this.label18.TabIndex = 28;
            this.label18.Text = "Arşivleme Periyodu :";
            // 
            // btn_Delete
            // 
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Location = new System.Drawing.Point(130, 637);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(109, 30);
            this.btn_Delete.TabIndex = 13;
            this.btn_Delete.Text = "Sil";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // frm_AddNewOrUpdateAnalogSignal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(473, 672);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp_CommunicationParameters);
            this.Controls.Add(this.grp_BasicInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_AddNewOrUpdateAnalogSignal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Analog Sinyal Ekle";
            this.Load += new System.EventHandler(this.frm_AddNewOrUpdateAnalogSignal_Load);
            this.grp_BasicInfo.ResumeLayout(false);
            this.grp_BasicInfo.PerformLayout();
            this.grp_CommunicationParameters.ResumeLayout(false);
            this.grp_CommunicationParameters.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.TextBox txt_ModbusAddress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbx_FunctionCode;
        private System.Windows.Forms.TextBox txt_ScaleValue;
        private System.Windows.Forms.TextBox txt_WordCount;
        private System.Windows.Forms.TextBox txt_SignalID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbx_MaxAlarmStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbx_HasMaxAlarm;
        private System.Windows.Forms.Label Alarm;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txt_Unit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbx_HasMinAlarm;
        private System.Windows.Forms.TextBox txt_MinAlarmValue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_MaxAlarmValue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbx_MinAlarmStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbx_DataType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbx_IsArchive;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbx_Archive;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btn_Delete;
    }
}