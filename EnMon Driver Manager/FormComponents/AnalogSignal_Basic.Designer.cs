namespace EnMon_Driver_Manager.FormComponents
{
    partial class AnalogSignal_BasicValues
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grp_BasicInfo = new System.Windows.Forms.GroupBox();
            this.txt_Unit = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_SignalIdentification = new System.Windows.Forms.TextBox();
            this.txt_SignalName = new System.Windows.Forms.TextBox();
            this.cbx_DeviceName = new System.Windows.Forms.ComboBox();
            this.cbx_StationName = new System.Windows.Forms.ComboBox();
            this.txt_SignalID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grp_BasicInfo.SuspendLayout();
            this.SuspendLayout();
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
            this.grp_BasicInfo.Location = new System.Drawing.Point(3, 3);
            this.grp_BasicInfo.Name = "grp_BasicInfo";
            this.grp_BasicInfo.Size = new System.Drawing.Size(454, 179);
            this.grp_BasicInfo.TabIndex = 7;
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
            // 
            // txt_SignalID
            // 
            this.txt_SignalID.Enabled = false;
            this.txt_SignalID.Location = new System.Drawing.Point(118, 13);
            this.txt_SignalID.Name = "txt_SignalID";
            this.txt_SignalID.Size = new System.Drawing.Size(224, 20);
            this.txt_SignalID.TabIndex = 6;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sinyal Uzun Adı :";
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
            // AnalogSignal_BasicValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grp_BasicInfo);
            this.Name = "AnalogSignal_BasicValues";
            this.Size = new System.Drawing.Size(463, 188);
            this.grp_BasicInfo.ResumeLayout(false);
            this.grp_BasicInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_BasicInfo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbx_DeviceName;
        public System.Windows.Forms.ComboBox cbx_StationName;
        private System.Windows.Forms.TextBox txt_Unit;
        private System.Windows.Forms.TextBox txt_SignalIdentification;
        private System.Windows.Forms.TextBox txt_SignalName;
        private System.Windows.Forms.TextBox txt_SignalID;
    }
}
