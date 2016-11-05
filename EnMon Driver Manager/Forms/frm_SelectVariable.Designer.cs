namespace EnMon_Driver_Manager
{
    partial class frm_SelectVariable
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_StationNames = new System.Windows.Forms.ComboBox();
            this.cb_DeviceNames = new System.Windows.Forms.ComboBox();
            this.cb_SignalNames = new System.Windows.Forms.ComboBox();
            this.rb_AnalogSignals = new System.Windows.Forms.RadioButton();
            this.rb_BinarySignals = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "İstasyon Adı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cihaz Adı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sinyal Adı :";
            // 
            // cb_StationNames
            // 
            this.cb_StationNames.DisplayMember = "Name";
            this.cb_StationNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cb_StationNames.FormattingEnabled = true;
            this.cb_StationNames.Location = new System.Drawing.Point(89, 31);
            this.cb_StationNames.Name = "cb_StationNames";
            this.cb_StationNames.Size = new System.Drawing.Size(156, 24);
            this.cb_StationNames.TabIndex = 3;
            this.cb_StationNames.SelectionChangeCommitted += new System.EventHandler(this.cb_StationNames_SelectionChangeCommitted);
            // 
            // cb_DeviceNames
            // 
            this.cb_DeviceNames.DisplayMember = "Name";
            this.cb_DeviceNames.Enabled = false;
            this.cb_DeviceNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cb_DeviceNames.FormattingEnabled = true;
            this.cb_DeviceNames.Location = new System.Drawing.Point(89, 74);
            this.cb_DeviceNames.Name = "cb_DeviceNames";
            this.cb_DeviceNames.Size = new System.Drawing.Size(156, 24);
            this.cb_DeviceNames.TabIndex = 4;
            this.cb_DeviceNames.DropDown += new System.EventHandler(this.cb_DeviceNames_DropDown);
            this.cb_DeviceNames.SelectionChangeCommitted += new System.EventHandler(this.cb_DeviceNames_SelectionChangeCommitted);
            // 
            // cb_SignalNames
            // 
            this.cb_SignalNames.DisplayMember = "Name";
            this.cb_SignalNames.Enabled = false;
            this.cb_SignalNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cb_SignalNames.FormattingEnabled = true;
            this.cb_SignalNames.Location = new System.Drawing.Point(88, 124);
            this.cb_SignalNames.Name = "cb_SignalNames";
            this.cb_SignalNames.Size = new System.Drawing.Size(157, 24);
            this.cb_SignalNames.TabIndex = 5;
            // 
            // rb_AnalogSignals
            // 
            this.rb_AnalogSignals.AutoSize = true;
            this.rb_AnalogSignals.Checked = true;
            this.rb_AnalogSignals.Location = new System.Drawing.Point(98, 8);
            this.rb_AnalogSignals.Name = "rb_AnalogSignals";
            this.rb_AnalogSignals.Size = new System.Drawing.Size(58, 17);
            this.rb_AnalogSignals.TabIndex = 6;
            this.rb_AnalogSignals.TabStop = true;
            this.rb_AnalogSignals.Text = "Analog";
            this.rb_AnalogSignals.UseVisualStyleBackColor = true;
            this.rb_AnalogSignals.CheckedChanged += new System.EventHandler(this.rb_AnalogSignals_CheckedChanged);
            // 
            // rb_BinarySignals
            // 
            this.rb_BinarySignals.AutoSize = true;
            this.rb_BinarySignals.Location = new System.Drawing.Point(191, 8);
            this.rb_BinarySignals.Name = "rb_BinarySignals";
            this.rb_BinarySignals.Size = new System.Drawing.Size(54, 17);
            this.rb_BinarySignals.TabIndex = 7;
            this.rb_BinarySignals.Text = "Digital";
            this.rb_BinarySignals.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sinyal Tipi :";
            // 
            // btn_Add
            // 
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Location = new System.Drawing.Point(88, 163);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 9;
            this.btn_Add.Text = "Ekle";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Location = new System.Drawing.Point(170, 163);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "İptal";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // frm_SelectVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(263, 207);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rb_BinarySignals);
            this.Controls.Add(this.rb_AnalogSignals);
            this.Controls.Add(this.cb_SignalNames);
            this.Controls.Add(this.cb_DeviceNames);
            this.Controls.Add(this.cb_StationNames);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_SelectVariable";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sinyal Ekle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_SelectVariable_FormClosing);
            this.Load += new System.EventHandler(this.frm_SelectVariable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_StationNames;
        private System.Windows.Forms.ComboBox cb_DeviceNames;
        private System.Windows.Forms.ComboBox cb_SignalNames;
        private System.Windows.Forms.RadioButton rb_AnalogSignals;
        private System.Windows.Forms.RadioButton rb_BinarySignals;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Cancel;
    }
}