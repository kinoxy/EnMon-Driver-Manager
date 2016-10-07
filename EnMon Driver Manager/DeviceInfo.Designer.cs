namespace EnMon_Driver_Manager
{
    partial class DeviceInfo
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
            this.lbl_StationName = new System.Windows.Forms.Label();
            this.lbl_DeviceName = new System.Windows.Forms.Label();
            this.lbl_SlaveId = new System.Windows.Forms.Label();
            this.pictureBox_ConnectionStatus = new System.Windows.Forms.PictureBox();
            this.switchButton_DeviceIsActive = new EnMon_Driver_Manager.SwitchButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ConnectionStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_StationName
            // 
            this.lbl_StationName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_StationName.AutoSize = true;
            this.lbl_StationName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_StationName.Location = new System.Drawing.Point(3, 10);
            this.lbl_StationName.Name = "lbl_StationName";
            this.lbl_StationName.Size = new System.Drawing.Size(91, 18);
            this.lbl_StationName.TabIndex = 0;
            this.lbl_StationName.Text = "Station Name";
            this.lbl_StationName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_DeviceName
            // 
            this.lbl_DeviceName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_DeviceName.AutoSize = true;
            this.lbl_DeviceName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_DeviceName.Location = new System.Drawing.Point(133, 10);
            this.lbl_DeviceName.Name = "lbl_DeviceName";
            this.lbl_DeviceName.Size = new System.Drawing.Size(90, 18);
            this.lbl_DeviceName.TabIndex = 1;
            this.lbl_DeviceName.Text = "Device Name";
            this.lbl_DeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_SlaveId
            // 
            this.lbl_SlaveId.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_SlaveId.AutoSize = true;
            this.lbl_SlaveId.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_SlaveId.Location = new System.Drawing.Point(261, 10);
            this.lbl_SlaveId.Name = "lbl_SlaveId";
            this.lbl_SlaveId.Size = new System.Drawing.Size(57, 18);
            this.lbl_SlaveId.TabIndex = 3;
            this.lbl_SlaveId.Text = "Slave ID";
            this.lbl_SlaveId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox_ConnectionStatus
            // 
            this.pictureBox_ConnectionStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox_ConnectionStatus.Image = global::EnMon_Driver_Manager.Properties.Resources.green;
            this.pictureBox_ConnectionStatus.Location = new System.Drawing.Point(382, 5);
            this.pictureBox_ConnectionStatus.Name = "pictureBox_ConnectionStatus";
            this.pictureBox_ConnectionStatus.Size = new System.Drawing.Size(34, 28);
            this.pictureBox_ConnectionStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ConnectionStatus.TabIndex = 4;
            this.pictureBox_ConnectionStatus.TabStop = false;
            // 
            // switchButton_DeviceIsActive
            // 
            this.switchButton_DeviceIsActive.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.switchButton_DeviceIsActive.BackColor = System.Drawing.Color.Transparent;
            this.switchButton_DeviceIsActive.Location = new System.Drawing.Point(438, 3);
            this.switchButton_DeviceIsActive.Margin = new System.Windows.Forms.Padding(0);
            this.switchButton_DeviceIsActive.Name = "switchButton_DeviceIsActive";
            this.switchButton_DeviceIsActive.Size = new System.Drawing.Size(83, 34);
            this.switchButton_DeviceIsActive.Click += SwitchButton_DeviceIsActive_Click;
            this.switchButton_DeviceIsActive.TabIndex = 2;
            // 
            // DeviceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox_ConnectionStatus);
            this.Controls.Add(this.lbl_SlaveId);
            this.Controls.Add(this.switchButton_DeviceIsActive);
            this.Controls.Add(this.lbl_DeviceName);
            this.Controls.Add(this.lbl_StationName);
            this.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.Name = "DeviceInfo";
            this.Size = new System.Drawing.Size(521, 40);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ConnectionStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Device _device;
        public System.Windows.Forms.Label lbl_StationName;
        public System.Windows.Forms.Label lbl_DeviceName;
        public SwitchButton switchButton_DeviceIsActive;
        public System.Windows.Forms.Label lbl_SlaveId;
        public System.Windows.Forms.PictureBox pictureBox_ConnectionStatus;

        public Device device
        {
            private get { return _device; }
            set
            {
                lbl_DeviceName.Text = value.Name;
                lbl_SlaveId.Text = value.SlaveID.ToString();
                switchButton_DeviceIsActive.SetState(value.isActive);
                _device = value;
            }
        }
    }
}
