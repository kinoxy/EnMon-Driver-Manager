namespace EnMon_Driver_Manager
{
    partial class frm_AddDevice
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
            this.label1 = new MaterialSkin.Controls.MaterialLabel();
            this.label2 = new MaterialSkin.Controls.MaterialLabel();
            this.label3 = new MaterialSkin.Controls.MaterialLabel();
            this.pnl_ModbusRTU = new System.Windows.Forms.Panel();
            this.txt_SlaveID = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_IpAddress = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pnl_ModbusTCP = new System.Windows.Forms.Panel();
            this.cbx_StationName = new System.Windows.Forms.ComboBox();
            this.cbx_Protocol = new System.Windows.Forms.ComboBox();
            this.txt_DeviceName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btn_AddDevice = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_Cancel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pnl_ModbusRTU.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.MouseState = MaterialSkin.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "İstasyon Adı ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.label2.Depth = 0;
            this.label2.Font = new System.Drawing.Font("Roboto", 11F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.MouseState = MaterialSkin.MouseState.HOVER;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cihaz Adı ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.label3.Depth = 0;
            this.label3.Font = new System.Drawing.Font("Roboto", 11F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.MouseState = MaterialSkin.MouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Protokol ";
            // 
            // pnl_ModbusRTU
            // 
            this.pnl_ModbusRTU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.pnl_ModbusRTU.Controls.Add(this.txt_SlaveID);
            this.pnl_ModbusRTU.Controls.Add(this.materialLabel2);
            this.pnl_ModbusRTU.Controls.Add(this.materialLabel1);
            this.pnl_ModbusRTU.Controls.Add(this.txt_IpAddress);
            this.pnl_ModbusRTU.Location = new System.Drawing.Point(8, 157);
            this.pnl_ModbusRTU.Name = "pnl_ModbusRTU";
            this.pnl_ModbusRTU.Size = new System.Drawing.Size(261, 82);
            this.pnl_ModbusRTU.TabIndex = 3;
            // 
            // txt_SlaveID
            // 
            this.txt_SlaveID.BackColor = System.Drawing.SystemColors.Control;
            this.txt_SlaveID.Depth = 0;
            this.txt_SlaveID.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txt_SlaveID.Hint = "";
            this.txt_SlaveID.Location = new System.Drawing.Point(106, 31);
            this.txt_SlaveID.MaxLength = 32767;
            this.txt_SlaveID.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_SlaveID.Name = "txt_SlaveID";
            this.txt_SlaveID.PasswordChar = '\0';
            this.txt_SlaveID.SelectedText = "";
            this.txt_SlaveID.SelectionLength = 0;
            this.txt_SlaveID.SelectionStart = 0;
            this.txt_SlaveID.Size = new System.Drawing.Size(155, 23);
            this.txt_SlaveID.TabIndex = 11;
            this.txt_SlaveID.TabStop = false;
            this.txt_SlaveID.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.materialLabel2.Location = new System.Drawing.Point(5, 35);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(92, 19);
            this.materialLabel2.TabIndex = 10;
            this.materialLabel2.Text = "Slave Adresi";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.materialLabel1.Location = new System.Drawing.Point(5, 7);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(68, 19);
            this.materialLabel1.TabIndex = 9;
            this.materialLabel1.Text = "Ip Adresi";
            // 
            // txt_IpAddress
            // 
            this.txt_IpAddress.BackColor = System.Drawing.SystemColors.Control;
            this.txt_IpAddress.Depth = 0;
            this.txt_IpAddress.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txt_IpAddress.Hint = "";
            this.txt_IpAddress.Location = new System.Drawing.Point(106, 3);
            this.txt_IpAddress.MaxLength = 32767;
            this.txt_IpAddress.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_IpAddress.Name = "txt_IpAddress";
            this.txt_IpAddress.PasswordChar = '\0';
            this.txt_IpAddress.SelectedText = "";
            this.txt_IpAddress.SelectionLength = 0;
            this.txt_IpAddress.SelectionStart = 0;
            this.txt_IpAddress.Size = new System.Drawing.Size(155, 23);
            this.txt_IpAddress.TabIndex = 9;
            this.txt_IpAddress.TabStop = false;
            this.txt_IpAddress.UseSystemPasswordChar = false;
            // 
            // pnl_ModbusTCP
            // 
            this.pnl_ModbusTCP.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnl_ModbusTCP.Location = new System.Drawing.Point(8, 157);
            this.pnl_ModbusTCP.Name = "pnl_ModbusTCP";
            this.pnl_ModbusTCP.Size = new System.Drawing.Size(261, 82);
            this.pnl_ModbusTCP.TabIndex = 4;
            this.pnl_ModbusTCP.Visible = false;
            // 
            // cbx_StationName
            // 
            this.cbx_StationName.FormattingEnabled = true;
            this.cbx_StationName.Location = new System.Drawing.Point(114, 74);
            this.cbx_StationName.Name = "cbx_StationName";
            this.cbx_StationName.Size = new System.Drawing.Size(155, 21);
            this.cbx_StationName.TabIndex = 5;
            // 
            // cbx_Protocol
            // 
            this.cbx_Protocol.FormattingEnabled = true;
            this.cbx_Protocol.Location = new System.Drawing.Point(114, 127);
            this.cbx_Protocol.Name = "cbx_Protocol";
            this.cbx_Protocol.Size = new System.Drawing.Size(155, 21);
            this.cbx_Protocol.TabIndex = 7;
            // 
            // txt_DeviceName
            // 
            this.txt_DeviceName.BackColor = System.Drawing.SystemColors.Control;
            this.txt_DeviceName.Depth = 0;
            this.txt_DeviceName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txt_DeviceName.Hint = "";
            this.txt_DeviceName.Location = new System.Drawing.Point(114, 101);
            this.txt_DeviceName.MaxLength = 32767;
            this.txt_DeviceName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt_DeviceName.Name = "txt_DeviceName";
            this.txt_DeviceName.PasswordChar = '\0';
            this.txt_DeviceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_DeviceName.SelectedText = "";
            this.txt_DeviceName.SelectionLength = 0;
            this.txt_DeviceName.SelectionStart = 0;
            this.txt_DeviceName.Size = new System.Drawing.Size(155, 23);
            this.txt_DeviceName.TabIndex = 8;
            this.txt_DeviceName.TabStop = false;
            this.txt_DeviceName.Text = "DeviceName";
            this.txt_DeviceName.UseSystemPasswordChar = false;
            this.txt_DeviceName.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // btn_AddDevice
            // 
            this.btn_AddDevice.AutoSize = true;
            this.btn_AddDevice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_AddDevice.Depth = 0;
            this.btn_AddDevice.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_AddDevice.Icon = null;
            this.btn_AddDevice.Location = new System.Drawing.Point(31, 260);
            this.btn_AddDevice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_AddDevice.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_AddDevice.Name = "btn_AddDevice";
            this.btn_AddDevice.Primary = false;
            this.btn_AddDevice.Size = new System.Drawing.Size(100, 36);
            this.btn_AddDevice.TabIndex = 9;
            this.btn_AddDevice.Text = "Cihazı Ekle";
            this.btn_AddDevice.UseVisualStyleBackColor = true;
            this.btn_AddDevice.Click += new System.EventHandler(this.btn_AddDevice_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Cancel.Depth = 0;
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Cancel.Icon = null;
            this.btn_Cancel.Location = new System.Drawing.Point(148, 260);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_Cancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Primary = false;
            this.btn_Cancel.Size = new System.Drawing.Size(100, 36);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "İptal";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // frm_AddDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(279, 311);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_AddDevice);
            this.Controls.Add(this.txt_DeviceName);
            this.Controls.Add(this.cbx_Protocol);
            this.Controls.Add(this.cbx_StationName);
            this.Controls.Add(this.pnl_ModbusRTU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnl_ModbusTCP);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_AddDevice";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cihaz Ekle";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.pnl_ModbusRTU.ResumeLayout(false);
            this.pnl_ModbusRTU.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnl_ModbusRTU;
        private System.Windows.Forms.Panel pnl_ModbusTCP;
        private System.Windows.Forms.ComboBox cbx_StationName;
        private System.Windows.Forms.ComboBox cbx_Protocol;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_DeviceName;
        private MaterialSkin.Controls.MaterialLabel label1;
        private MaterialSkin.Controls.MaterialLabel label2;
        private MaterialSkin.Controls.MaterialLabel label3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_IpAddress;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt_SlaveID;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRaisedButton btn_AddDevice;
        private MaterialSkin.Controls.MaterialRaisedButton btn_Cancel;
    }
}