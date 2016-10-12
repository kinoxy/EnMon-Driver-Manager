namespace EnMon_Driver_Manager
{
    partial class frm_AddMailAlarm
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_AlarmName = new System.Windows.Forms.TextBox();
            this.btn_AddSignal = new System.Windows.Forms.Button();
            this.btn_AddEQUAL = new System.Windows.Forms.Button();
            this.btn_AddGREATER = new System.Windows.Forms.Button();
            this.txt_AlarmLogic = new System.Windows.Forms.TextBox();
            this.btn_AddLESS = new System.Windows.Forms.Button();
            this.btn_AddAND = new System.Windows.Forms.Button();
            this.btn_AddOR = new System.Windows.Forms.Button();
            this.btn_AddFirstParenthessis = new System.Windows.Forms.Button();
            this.btn_AddEndParenthessis = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel1.Location = new System.Drawing.Point(23, 19);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(83, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Alarm Adı :";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel2.Location = new System.Drawing.Point(19, 309);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(107, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "E-Posta Konu :";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel3.Location = new System.Drawing.Point(14, 277);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(112, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "E-Posta Grubu :";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel4.Location = new System.Drawing.Point(8, 343);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(118, 19);
            this.materialLabel4.TabIndex = 3;
            this.materialLabel4.Text = "E-Posta Mesajı :";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel5.Location = new System.Drawing.Point(8, 46);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(98, 19);
            this.materialLabel5.TabIndex = 4;
            this.materialLabel5.Text = "Alarm Lojiği :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_AddEndParenthessis);
            this.groupBox1.Controls.Add(this.btn_AddFirstParenthessis);
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
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(815, 185);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txt_AlarmName
            // 
            this.txt_AlarmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_AlarmName.Location = new System.Drawing.Point(116, 12);
            this.txt_AlarmName.Name = "txt_AlarmName";
            this.txt_AlarmName.Size = new System.Drawing.Size(239, 29);
            this.txt_AlarmName.TabIndex = 12;
            this.txt_AlarmName.Click += new System.EventHandler(this.txt_AlarmName_Click);
            // 
            // btn_AddSignal
            // 
            this.btn_AddSignal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddSignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddSignal.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_AddSignal.Location = new System.Drawing.Point(116, 46);
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
            this.btn_AddEQUAL.Location = new System.Drawing.Point(321, 46);
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
            this.btn_AddGREATER.Location = new System.Drawing.Point(280, 46);
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
            this.txt_AlarmLogic.Location = new System.Drawing.Point(116, 82);
            this.txt_AlarmLogic.Multiline = true;
            this.txt_AlarmLogic.Name = "txt_AlarmLogic";
            this.txt_AlarmLogic.Size = new System.Drawing.Size(690, 96);
            this.txt_AlarmLogic.TabIndex = 5;
            this.txt_AlarmLogic.Click += new System.EventHandler(this.txt_AlarmLogic_Click);
            this.txt_AlarmLogic.TextChanged += new System.EventHandler(this.txt_AlarmLogic_TextChanged);
            // 
            // btn_AddLESS
            // 
            this.btn_AddLESS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddLESS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddLESS.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddLESS.Location = new System.Drawing.Point(239, 46);
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
            this.btn_AddAND.Location = new System.Drawing.Point(198, 46);
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
            this.btn_AddOR.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_AddOR.Location = new System.Drawing.Point(157, 46);
            this.btn_AddOR.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddOR.Name = "btn_AddOR";
            this.btn_AddOR.Size = new System.Drawing.Size(34, 34);
            this.btn_AddOR.TabIndex = 6;
            this.btn_AddOR.Text = "OR";
            this.btn_AddOR.UseVisualStyleBackColor = false;
            this.btn_AddOR.Click += new System.EventHandler(this.btn_AddOR_Click);
            // 
            // btn_AddFirstParenthessis
            // 
            this.btn_AddFirstParenthessis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddFirstParenthessis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddFirstParenthessis.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddFirstParenthessis.Location = new System.Drawing.Point(361, 46);
            this.btn_AddFirstParenthessis.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddFirstParenthessis.Name = "btn_AddFirstParenthessis";
            this.btn_AddFirstParenthessis.Size = new System.Drawing.Size(34, 34);
            this.btn_AddFirstParenthessis.TabIndex = 13;
            this.btn_AddFirstParenthessis.Text = "(";
            this.btn_AddFirstParenthessis.UseVisualStyleBackColor = false;
            this.btn_AddFirstParenthessis.Click += new System.EventHandler(this.btn_AddFirstParenthessis_Click);
            // 
            // btn_AddEndParenthessis
            // 
            this.btn_AddEndParenthessis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_AddEndParenthessis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddEndParenthessis.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddEndParenthessis.Location = new System.Drawing.Point(400, 46);
            this.btn_AddEndParenthessis.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AddEndParenthessis.Name = "btn_AddEndParenthessis";
            this.btn_AddEndParenthessis.Size = new System.Drawing.Size(34, 34);
            this.btn_AddEndParenthessis.TabIndex = 14;
            this.btn_AddEndParenthessis.Text = ")";
            this.btn_AddEndParenthessis.UseVisualStyleBackColor = false;
            this.btn_AddEndParenthessis.Click += new System.EventHandler(this.btn_AddEndParenthessis_Click);
            // 
            // frm_AddMailAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(833, 426);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_AddMailAlarm";
            this.Text = "Yeni Alarm Ekle";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
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
    }
}