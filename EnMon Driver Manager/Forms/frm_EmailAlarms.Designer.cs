namespace EnMon_Driver_Manager
{
    partial class frm_EmailAlarms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_DeleteAlarm = new System.Windows.Forms.Button();
            this.btn_AddNewAlarm = new System.Windows.Forms.Button();
            this.dgv_MailAlarms = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MailAlarms)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_DeleteAlarm
            // 
            this.btn_DeleteAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DeleteAlarm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_DeleteAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteAlarm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_DeleteAlarm.Location = new System.Drawing.Point(516, 389);
            this.btn_DeleteAlarm.Margin = new System.Windows.Forms.Padding(1);
            this.btn_DeleteAlarm.Name = "btn_DeleteAlarm";
            this.btn_DeleteAlarm.Size = new System.Drawing.Size(185, 35);
            this.btn_DeleteAlarm.TabIndex = 2;
            this.btn_DeleteAlarm.Text = "Seçili Alarmı Sil";
            this.btn_DeleteAlarm.UseVisualStyleBackColor = true;
            this.btn_DeleteAlarm.Click += new System.EventHandler(this.btn_DeleteAlarm_Click);
            // 
            // btn_AddNewAlarm
            // 
            this.btn_AddNewAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddNewAlarm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_AddNewAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddNewAlarm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddNewAlarm.Location = new System.Drawing.Point(320, 389);
            this.btn_AddNewAlarm.Margin = new System.Windows.Forms.Padding(1);
            this.btn_AddNewAlarm.Name = "btn_AddNewAlarm";
            this.btn_AddNewAlarm.Size = new System.Drawing.Size(185, 35);
            this.btn_AddNewAlarm.TabIndex = 1;
            this.btn_AddNewAlarm.Text = "Yeni Alarm Ekle";
            this.btn_AddNewAlarm.UseVisualStyleBackColor = true;
            this.btn_AddNewAlarm.Click += new System.EventHandler(this.btn_AddNewAlarm_Click);
            // 
            // dgv_MailAlarms
            // 
            this.dgv_MailAlarms.AllowUserToAddRows = false;
            this.dgv_MailAlarms.AllowUserToDeleteRows = false;
            this.dgv_MailAlarms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_MailAlarms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_MailAlarms.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_MailAlarms.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_MailAlarms.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_MailAlarms.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_MailAlarms.Location = new System.Drawing.Point(3, 2);
            this.dgv_MailAlarms.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.dgv_MailAlarms.MultiSelect = false;
            this.dgv_MailAlarms.Name = "dgv_MailAlarms";
            this.dgv_MailAlarms.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_MailAlarms.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_MailAlarms.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_MailAlarms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_MailAlarms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_MailAlarms.ShowEditingIcon = false;
            this.dgv_MailAlarms.Size = new System.Drawing.Size(698, 384);
            this.dgv_MailAlarms.TabIndex = 0;
            this.dgv_MailAlarms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_MailAlarms_CellDoubleClick);
            // 
            // frm_EmailAlarms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(706, 432);
            this.Controls.Add(this.btn_DeleteAlarm);
            this.Controls.Add(this.btn_AddNewAlarm);
            this.Controls.Add(this.dgv_MailAlarms);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_EmailAlarms";
            this.Text = "EmailSettings";
            this.Load += new System.EventHandler(this.frm_EmailSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MailAlarms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        //private System.Windows.Forms.TabPage tabPage2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgv_MailAlarms;
        private System.Windows.Forms.Button btn_DeleteAlarm;
        private System.Windows.Forms.Button btn_AddNewAlarm;
    }
}