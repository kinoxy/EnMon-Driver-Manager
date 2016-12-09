namespace EnMon_Driver_Manager
{
    partial class frm_AddNewOrUpdateMailAlarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddNewOrUpdateMailAlarm));
            this.materialLabel1 = new System.Windows.Forms.Label();
            this.materialLabel2 = new System.Windows.Forms.Label();
            this.materialLabel3 = new System.Windows.Forms.Label();
            this.materialLabel4 = new System.Windows.Forms.Label();
            this.materialLabel5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_AddNewOrUpdateAlarm = new System.Windows.Forms.Button();
            this.materialLabel7 = new System.Windows.Forms.Label();
            this.materialLabel6 = new System.Windows.Forms.Label();
            this.txt_Second = new System.Windows.Forms.TextBox();
            this.cb_MailGroups = new System.Windows.Forms.ComboBox();
            this.txt_EmailMessage = new System.Windows.Forms.TextBox();
            this.txt_EMailSubject = new System.Windows.Forms.TextBox();
            this.btn_AddEndParenthessis = new System.Windows.Forms.Button();
            this.btn_AddFirstParenthessis = new System.Windows.Forms.Button();
            this.txt_AlarmName = new System.Windows.Forms.TextBox();
            this.btn_AddSignal = new System.Windows.Forms.Button();
            this.btn_AddEQUAL = new System.Windows.Forms.Button();
            this.btn_AddGREATER = new System.Windows.Forms.Button();
            this.txt_AlarmLogic = new System.Windows.Forms.TextBox();
            this.btn_AddLESS = new System.Windows.Forms.Button();
            this.btn_AddAND = new System.Windows.Forms.Button();
            this.btn_AddOR = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.materialLabel1.ForeColor = System.Drawing.Color.Black;
            this.materialLabel1.Location = new System.Drawing.Point(39, 22);
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(65, 15);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Alarm Adı :";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.materialLabel2.ForeColor = System.Drawing.Color.Black;
            this.materialLabel2.Location = new System.Drawing.Point(12, 251);
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(92, 15);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "E-Posta Başlık :";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.materialLabel3.ForeColor = System.Drawing.Color.Black;
            this.materialLabel3.Location = new System.Drawing.Point(7, 187);
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(97, 15);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Alarm Gecikme :";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.materialLabel4.ForeColor = System.Drawing.Color.Black;
            this.materialLabel4.Location = new System.Drawing.Point(8, 278);
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(96, 15);
            this.materialLabel4.TabIndex = 3;
            this.materialLabel4.Text = "E-Posta Mesajı :";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.materialLabel5.ForeColor = System.Drawing.Color.Black;
            this.materialLabel5.Location = new System.Drawing.Point(26, 45);
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(78, 15);
            this.materialLabel5.TabIndex = 4;
            this.materialLabel5.Text = "Alarm Lojiği :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Cancel);
            this.groupBox1.Controls.Add(this.btn_AddNewOrUpdateAlarm);
            this.groupBox1.Controls.Add(this.materialLabel7);
            this.groupBox1.Controls.Add(this.materialLabel6);
            this.groupBox1.Controls.Add(this.txt_Second);
            this.groupBox1.Controls.Add(this.cb_MailGroups);
            this.groupBox1.Controls.Add(this.txt_EmailMessage);
            this.groupBox1.Controls.Add(this.txt_EMailSubject);
            this.groupBox1.Controls.Add(this.btn_AddEndParenthessis);
            this.groupBox1.Controls.Add(this.materialLabel4);
            this.groupBox1.Controls.Add(this.btn_AddFirstParenthessis);
            this.groupBox1.Controls.Add(this.materialLabel3);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.txt_AlarmName);
            this.groupBox1.Controls.Add(this.btn_AddSignal);
            this.groupBox1.Controls.Add(this.btn_AddEQUAL);
            this.groupBox1.Controls.Add(this.btn_AddGREATER);
            this.groupBox1.Controls.Add(this.txt_AlarmLogic);
            this.groupBox1.Controls.Add(this.btn_AddLESS);
            this.groupBox1.Controls.Add(this.materialLabel5);
            this.groupBox1.Controls.Add(this.btn_AddAND);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.btn_AddOR);
            this.groupBox1.Location = new System.Drawing.Point(9, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 449);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Cancel.Location = new System.Drawing.Point(509, 412);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(122, 28);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "İptal";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_AddNewOrUpdateAlarm
            // 
            this.btn_AddNewOrUpdateAlarm.BackColor = System.Drawing.SystemColors.Control;
            this.btn_AddNewOrUpdateAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddNewOrUpdateAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_AddNewOrUpdateAlarm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_AddNewOrUpdateAlarm.Location = new System.Drawing.Point(381, 412);
            this.btn_AddNewOrUpdateAlarm.Name = "btn_AddNewOrUpdateAlarm";
            this.btn_AddNewOrUpdateAlarm.Size = new System.Drawing.Size(122, 28);
            this.btn_AddNewOrUpdateAlarm.TabIndex = 9;
            this.btn_AddNewOrUpdateAlarm.Text = "Alarm Ekle";
            this.btn_AddNewOrUpdateAlarm.UseVisualStyleBackColor = false;
            this.btn_AddNewOrUpdateAlarm.Click += new System.EventHandler(this.btn_AddNewOrUpdateAlarm_Click);
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.materialLabel7.ForeColor = System.Drawing.Color.Black;
            this.materialLabel7.Location = new System.Drawing.Point(11, 219);
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(93, 15);
            this.materialLabel7.TabIndex = 21;
            this.materialLabel7.Text = "E-Posta Grubu :";
            this.materialLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.materialLabel6.ForeColor = System.Drawing.Color.Black;
            this.materialLabel6.Location = new System.Drawing.Point(345, 188);
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(181, 15);
            this.materialLabel6.TabIndex = 20;
            this.materialLabel6.Text = "- Saniye cinsinden değer giriniz.";
            // 
            // txt_Second
            // 
            this.txt_Second.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Second.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_Second.Location = new System.Drawing.Point(110, 184);
            this.txt_Second.Name = "txt_Second";
            this.txt_Second.Size = new System.Drawing.Size(229, 21);
            this.txt_Second.TabIndex = 19;
            // 
            // cb_MailGroups
            // 
            this.cb_MailGroups.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_MailGroups.DisplayMember = "Name";
            this.cb_MailGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cb_MailGroups.FormattingEnabled = true;
            this.cb_MailGroups.Location = new System.Drawing.Point(110, 216);
            this.cb_MailGroups.Name = "cb_MailGroups";
            this.cb_MailGroups.Size = new System.Drawing.Size(229, 23);
            this.cb_MailGroups.TabIndex = 18;
            // 
            // txt_EmailMessage
            // 
            this.txt_EmailMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_EmailMessage.Location = new System.Drawing.Point(110, 278);
            this.txt_EmailMessage.Multiline = true;
            this.txt_EmailMessage.Name = "txt_EmailMessage";
            this.txt_EmailMessage.Size = new System.Drawing.Size(521, 128);
            this.txt_EmailMessage.TabIndex = 17;
            // 
            // txt_EMailSubject
            // 
            this.txt_EMailSubject.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_EMailSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_EMailSubject.Location = new System.Drawing.Point(110, 248);
            this.txt_EMailSubject.Name = "txt_EMailSubject";
            this.txt_EMailSubject.Size = new System.Drawing.Size(229, 21);
            this.txt_EMailSubject.TabIndex = 16;
            // 
            // btn_AddEndParenthessis
            // 
            this.btn_AddEndParenthessis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddEndParenthessis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddEndParenthessis.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddEndParenthessis.Location = new System.Drawing.Point(394, 45);
            this.btn_AddEndParenthessis.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddEndParenthessis.Name = "btn_AddEndParenthessis";
            this.btn_AddEndParenthessis.Size = new System.Drawing.Size(34, 34);
            this.btn_AddEndParenthessis.TabIndex = 14;
            this.btn_AddEndParenthessis.Text = ")";
            this.btn_AddEndParenthessis.UseVisualStyleBackColor = false;
            this.btn_AddEndParenthessis.Click += new System.EventHandler(this.btn_AddEndParenthessis_Click);
            // 
            // btn_AddFirstParenthessis
            // 
            this.btn_AddFirstParenthessis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddFirstParenthessis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddFirstParenthessis.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddFirstParenthessis.Location = new System.Drawing.Point(355, 45);
            this.btn_AddFirstParenthessis.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddFirstParenthessis.Name = "btn_AddFirstParenthessis";
            this.btn_AddFirstParenthessis.Size = new System.Drawing.Size(34, 34);
            this.btn_AddFirstParenthessis.TabIndex = 13;
            this.btn_AddFirstParenthessis.Text = "(";
            this.btn_AddFirstParenthessis.UseVisualStyleBackColor = false;
            this.btn_AddFirstParenthessis.Click += new System.EventHandler(this.btn_AddFirstParenthessis_Click);
            // 
            // txt_AlarmName
            // 
            this.txt_AlarmName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_AlarmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_AlarmName.Location = new System.Drawing.Point(110, 19);
            this.txt_AlarmName.Name = "txt_AlarmName";
            this.txt_AlarmName.Size = new System.Drawing.Size(229, 21);
            this.txt_AlarmName.TabIndex = 12;
            this.txt_AlarmName.Click += new System.EventHandler(this.txt_AlarmName_Click);
            // 
            // btn_AddSignal
            // 
            this.btn_AddSignal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddSignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddSignal.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_AddSignal.Location = new System.Drawing.Point(110, 45);
            this.btn_AddSignal.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddSignal.Name = "btn_AddSignal";
            this.btn_AddSignal.Size = new System.Drawing.Size(34, 34);
            this.btn_AddSignal.TabIndex = 11;
            this.btn_AddSignal.Text = "+";
            this.btn_AddSignal.UseVisualStyleBackColor = false;
            this.btn_AddSignal.Click += new System.EventHandler(this.btn_AddSignal_Click);
            // 
            // btn_AddEQUAL
            // 
            this.btn_AddEQUAL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddEQUAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddEQUAL.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddEQUAL.Location = new System.Drawing.Point(315, 45);
            this.btn_AddEQUAL.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddEQUAL.Name = "btn_AddEQUAL";
            this.btn_AddEQUAL.Size = new System.Drawing.Size(34, 34);
            this.btn_AddEQUAL.TabIndex = 10;
            this.btn_AddEQUAL.Text = "=";
            this.btn_AddEQUAL.UseVisualStyleBackColor = false;
            this.btn_AddEQUAL.Click += new System.EventHandler(this.btn_AddEQUAL_Click);
            // 
            // btn_AddGREATER
            // 
            this.btn_AddGREATER.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddGREATER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddGREATER.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddGREATER.Location = new System.Drawing.Point(274, 45);
            this.btn_AddGREATER.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddGREATER.Name = "btn_AddGREATER";
            this.btn_AddGREATER.Size = new System.Drawing.Size(34, 34);
            this.btn_AddGREATER.TabIndex = 9;
            this.btn_AddGREATER.Text = ">";
            this.btn_AddGREATER.UseVisualStyleBackColor = false;
            this.btn_AddGREATER.Click += new System.EventHandler(this.btn_AddGREATER_Click);
            // 
            // txt_AlarmLogic
            // 
            this.txt_AlarmLogic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_AlarmLogic.Location = new System.Drawing.Point(110, 82);
            this.txt_AlarmLogic.Multiline = true;
            this.txt_AlarmLogic.Name = "txt_AlarmLogic";
            this.txt_AlarmLogic.Size = new System.Drawing.Size(521, 96);
            this.txt_AlarmLogic.TabIndex = 5;
            this.txt_AlarmLogic.Click += new System.EventHandler(this.txt_AlarmLogic_Click);
            this.txt_AlarmLogic.TextChanged += new System.EventHandler(this.txt_AlarmLogic_TextChanged);
            // 
            // btn_AddLESS
            // 
            this.btn_AddLESS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddLESS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddLESS.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddLESS.Location = new System.Drawing.Point(233, 45);
            this.btn_AddLESS.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddLESS.Name = "btn_AddLESS";
            this.btn_AddLESS.Size = new System.Drawing.Size(34, 34);
            this.btn_AddLESS.TabIndex = 8;
            this.btn_AddLESS.Text = "<";
            this.btn_AddLESS.UseVisualStyleBackColor = false;
            this.btn_AddLESS.Click += new System.EventHandler(this.btn_AddLESS_Click);
            // 
            // btn_AddAND
            // 
            this.btn_AddAND.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddAND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddAND.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddAND.Location = new System.Drawing.Point(192, 45);
            this.btn_AddAND.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddAND.Name = "btn_AddAND";
            this.btn_AddAND.Size = new System.Drawing.Size(34, 34);
            this.btn_AddAND.TabIndex = 7;
            this.btn_AddAND.Text = "&&";
            this.btn_AddAND.UseVisualStyleBackColor = false;
            this.btn_AddAND.Click += new System.EventHandler(this.btn_AddAND_Click);
            // 
            // btn_AddOR
            // 
            this.btn_AddOR.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddOR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_AddOR.Location = new System.Drawing.Point(151, 45);
            this.btn_AddOR.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddOR.Name = "btn_AddOR";
            this.btn_AddOR.Size = new System.Drawing.Size(34, 34);
            this.btn_AddOR.TabIndex = 6;
            this.btn_AddOR.Text = "OR";
            this.btn_AddOR.UseVisualStyleBackColor = false;
            this.btn_AddOR.Click += new System.EventHandler(this.btn_AddOR_Click);
            // 
            // frm_AddNewOrUpdateMailAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(656, 454);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_AddNewOrUpdateMailAlarm";
            this.Text = "Yeni Alarm Ekle";
            this.Load += new System.EventHandler(this.frm_AddMailAlarm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label materialLabel1;
        private System.Windows.Forms.Label materialLabel2;
        private System.Windows.Forms.Label materialLabel3;
        private System.Windows.Forms.Label materialLabel4;
        private System.Windows.Forms.Label materialLabel5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_AlarmName;
        private System.Windows.Forms.TextBox txt_AlarmLogic;
        private System.Windows.Forms.Button btn_AddSignal;
        private System.Windows.Forms.Button btn_AddEQUAL;
        private System.Windows.Forms.Button btn_AddGREATER;
        private System.Windows.Forms.Button btn_AddLESS;
        private System.Windows.Forms.Button btn_AddAND;
        private System.Windows.Forms.Button btn_AddOR;
        private System.Windows.Forms.Button btn_AddEndParenthessis;
        private System.Windows.Forms.Button btn_AddFirstParenthessis;
        private System.Windows.Forms.TextBox txt_EmailMessage;
        private System.Windows.Forms.TextBox txt_EMailSubject;
        private System.Windows.Forms.ComboBox cb_MailGroups;
        private System.Windows.Forms.Button btn_AddNewOrUpdateAlarm;
        private System.Windows.Forms.Button btn_Cancel;
        System.Windows.Forms.Label materialLabel6;
        private System.Windows.Forms.TextBox txt_Second;
        System.Windows.Forms.Label materialLabel7;
    }
}