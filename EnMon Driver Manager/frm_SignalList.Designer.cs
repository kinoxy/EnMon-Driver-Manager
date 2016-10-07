using MaterialSkin.Controls;

namespace EnMon_Driver_Manager
{
    partial class frm_SignalList
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBox_AddTimeInformation = new MaterialSkin.Controls.MaterialCheckBox();
            this.btn_ExportDigitalSignalsAsCSV = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_ExportAnalogSignalsAsCSV = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_ImportDigitalSignalsToDatabase = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdButton_DeleteOldSignals = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdButton_OverWriteOldSignals = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdButton_DoNotDeleteOrOverWriteOldSignals = new MaterialSkin.Controls.MaterialRadioButton();
            this.btn_ImportAnalogSignalsToDataBase = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkBox_AddTimeInformation);
            this.groupBox2.Controls.Add(this.btn_ExportDigitalSignalsAsCSV);
            this.groupBox2.Controls.Add(this.btn_ExportAnalogSignalsAsCSV);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(10, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(350, 414);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DataBase\'den Sinyal Listesini Çek";
            // 
            // chkBox_AddTimeInformation
            // 
            this.chkBox_AddTimeInformation.AutoSize = true;
            this.chkBox_AddTimeInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chkBox_AddTimeInformation.Depth = 0;
            this.chkBox_AddTimeInformation.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkBox_AddTimeInformation.ForeColor = System.Drawing.Color.LavenderBlush;
            this.chkBox_AddTimeInformation.Location = new System.Drawing.Point(10, 18);
            this.chkBox_AddTimeInformation.Margin = new System.Windows.Forms.Padding(0);
            this.chkBox_AddTimeInformation.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkBox_AddTimeInformation.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkBox_AddTimeInformation.Name = "chkBox_AddTimeInformation";
            this.chkBox_AddTimeInformation.Ripple = true;
            this.chkBox_AddTimeInformation.Size = new System.Drawing.Size(243, 30);
            this.chkBox_AddTimeInformation.TabIndex = 1;
            this.chkBox_AddTimeInformation.Text = "Dosyanın ismine tarih bilgisini ekle";
            this.chkBox_AddTimeInformation.UseVisualStyleBackColor = false;
            // 
            // btn_ExportDigitalSignalsAsCSV
            // 
            this.btn_ExportDigitalSignalsAsCSV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ExportDigitalSignalsAsCSV.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_ExportDigitalSignalsAsCSV.Depth = 0;
            this.btn_ExportDigitalSignalsAsCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExportDigitalSignalsAsCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ExportDigitalSignalsAsCSV.ForeColor = System.Drawing.Color.Black;
            this.btn_ExportDigitalSignalsAsCSV.Icon = null;
            this.btn_ExportDigitalSignalsAsCSV.Location = new System.Drawing.Point(10, 51);
            this.btn_ExportDigitalSignalsAsCSV.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_ExportDigitalSignalsAsCSV.Name = "btn_ExportDigitalSignalsAsCSV";
            this.btn_ExportDigitalSignalsAsCSV.Primary = true;
            this.btn_ExportDigitalSignalsAsCSV.Size = new System.Drawing.Size(247, 36);
            this.btn_ExportDigitalSignalsAsCSV.TabIndex = 1;
            this.btn_ExportDigitalSignalsAsCSV.Text = "Dijital Sinyalleri dışarı aktar ";
            this.btn_ExportDigitalSignalsAsCSV.UseVisualStyleBackColor = false;
            this.btn_ExportDigitalSignalsAsCSV.Click += new System.EventHandler(this.btn_ExportDigitalSignalsAsCSV_Click);
            // 
            // btn_ExportAnalogSignalsAsCSV
            // 
            this.btn_ExportAnalogSignalsAsCSV.AutoSize = true;
            this.btn_ExportAnalogSignalsAsCSV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ExportAnalogSignalsAsCSV.Depth = 0;
            this.btn_ExportAnalogSignalsAsCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExportAnalogSignalsAsCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ExportAnalogSignalsAsCSV.ForeColor = System.Drawing.Color.Black;
            this.btn_ExportAnalogSignalsAsCSV.Icon = null;
            this.btn_ExportAnalogSignalsAsCSV.Location = new System.Drawing.Point(10, 93);
            this.btn_ExportAnalogSignalsAsCSV.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_ExportAnalogSignalsAsCSV.Name = "btn_ExportAnalogSignalsAsCSV";
            this.btn_ExportAnalogSignalsAsCSV.Primary = true;
            this.btn_ExportAnalogSignalsAsCSV.Size = new System.Drawing.Size(247, 36);
            this.btn_ExportAnalogSignalsAsCSV.TabIndex = 2;
            this.btn_ExportAnalogSignalsAsCSV.Text = "Analog Sinyalleri Dışarı Aktar";
            this.btn_ExportAnalogSignalsAsCSV.UseVisualStyleBackColor = true;
            this.btn_ExportAnalogSignalsAsCSV.Click += new System.EventHandler(this.btn_ExportAnalogSignalsAsCSV_Click);
            // 
            // btn_ImportDigitalSignalsToDatabase
            // 
            this.btn_ImportDigitalSignalsToDatabase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ImportDigitalSignalsToDatabase.Depth = 0;
            this.btn_ImportDigitalSignalsToDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ImportDigitalSignalsToDatabase.ForeColor = System.Drawing.Color.Black;
            this.btn_ImportDigitalSignalsToDatabase.Icon = null;
            this.btn_ImportDigitalSignalsToDatabase.Location = new System.Drawing.Point(9, 122);
            this.btn_ImportDigitalSignalsToDatabase.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_ImportDigitalSignalsToDatabase.Name = "btn_ImportDigitalSignalsToDatabase";
            this.btn_ImportDigitalSignalsToDatabase.Primary = true;
            this.btn_ImportDigitalSignalsToDatabase.Size = new System.Drawing.Size(237, 36);
            this.btn_ImportDigitalSignalsToDatabase.TabIndex = 0;
            this.btn_ImportDigitalSignalsToDatabase.Text = "Dijital Sinyalleri İçeri aktar   ";
            this.btn_ImportDigitalSignalsToDatabase.UseVisualStyleBackColor = true;
            this.btn_ImportDigitalSignalsToDatabase.Click += new System.EventHandler(this.btn_ImportDigitalSignalsToDatabase_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(730, 434);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdButton_DeleteOldSignals);
            this.groupBox1.Controls.Add(this.rdButton_OverWriteOldSignals);
            this.groupBox1.Controls.Add(this.rdButton_DoNotDeleteOrOverWriteOldSignals);
            this.groupBox1.Controls.Add(this.btn_ImportDigitalSignalsToDatabase);
            this.groupBox1.Controls.Add(this.btn_ImportAnalogSignalsToDataBase);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.groupBox1.Location = new System.Drawing.Point(370, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(350, 414);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DataBase\'e Sinyal Listesi Gönder";
            // 
            // rdButton_DeleteOldSignals
            // 
            this.rdButton_DeleteOldSignals.AutoSize = true;
            this.rdButton_DeleteOldSignals.Depth = 0;
            this.rdButton_DeleteOldSignals.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdButton_DeleteOldSignals.ForeColor = System.Drawing.Color.Lavender;
            this.rdButton_DeleteOldSignals.Location = new System.Drawing.Point(9, 81);
            this.rdButton_DeleteOldSignals.Margin = new System.Windows.Forms.Padding(0);
            this.rdButton_DeleteOldSignals.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdButton_DeleteOldSignals.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdButton_DeleteOldSignals.Name = "rdButton_DeleteOldSignals";
            this.rdButton_DeleteOldSignals.Ripple = true;
            this.rdButton_DeleteOldSignals.Size = new System.Drawing.Size(248, 30);
            this.rdButton_DeleteOldSignals.TabIndex = 4;
            this.rdButton_DeleteOldSignals.TabStop = true;
            this.rdButton_DeleteOldSignals.Text = "Database\'de kayıtlı tüm sinyalleri sil";
            this.rdButton_DeleteOldSignals.UseVisualStyleBackColor = true;
            this.rdButton_DeleteOldSignals.Click += new System.EventHandler(this.rdButton_DeleteOldSignals_Click);
            // 
            // rdButton_OverWriteOldSignals
            // 
            this.rdButton_OverWriteOldSignals.AutoSize = true;
            this.rdButton_OverWriteOldSignals.Depth = 0;
            this.rdButton_OverWriteOldSignals.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdButton_OverWriteOldSignals.Location = new System.Drawing.Point(9, 51);
            this.rdButton_OverWriteOldSignals.Margin = new System.Windows.Forms.Padding(0);
            this.rdButton_OverWriteOldSignals.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdButton_OverWriteOldSignals.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdButton_OverWriteOldSignals.Name = "rdButton_OverWriteOldSignals";
            this.rdButton_OverWriteOldSignals.Ripple = true;
            this.rdButton_OverWriteOldSignals.Size = new System.Drawing.Size(290, 30);
            this.rdButton_OverWriteOldSignals.TabIndex = 3;
            this.rdButton_OverWriteOldSignals.Text = "Database\'deki mevcut kayıtları da güncelle";
            this.rdButton_OverWriteOldSignals.UseVisualStyleBackColor = true;
            this.rdButton_OverWriteOldSignals.Click += new System.EventHandler(this.rdButton_OverWriteOldSignals_Click);
            // 
            // rdButton_DoNotDeleteOrOverWriteOldSignals
            // 
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.AutoSize = true;
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.Checked = true;
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.Depth = 0;
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.Location = new System.Drawing.Point(9, 22);
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.Margin = new System.Windows.Forms.Padding(0);
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.Name = "rdButton_DoNotDeleteOrOverWriteOldSignals";
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.Ripple = true;
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.Size = new System.Drawing.Size(283, 30);
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.TabIndex = 2;
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.TabStop = true;
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.Text = "Database\'deki kayıtlı sinyalleri değiştirme";
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.UseVisualStyleBackColor = true;
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.Click += new System.EventHandler(this.rdButton_DoNotDeleteOrOverWriteOldSignals_Click);
            // 
            // btn_ImportAnalogSignalsToDataBase
            // 
            this.btn_ImportAnalogSignalsToDataBase.AutoSize = true;
            this.btn_ImportAnalogSignalsToDataBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ImportAnalogSignalsToDataBase.Depth = 0;
            this.btn_ImportAnalogSignalsToDataBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ImportAnalogSignalsToDataBase.ForeColor = System.Drawing.Color.Black;
            this.btn_ImportAnalogSignalsToDataBase.Icon = null;
            this.btn_ImportAnalogSignalsToDataBase.Location = new System.Drawing.Point(9, 164);
            this.btn_ImportAnalogSignalsToDataBase.MouseState = MaterialSkin.MouseState.DOWN;
            this.btn_ImportAnalogSignalsToDataBase.Name = "btn_ImportAnalogSignalsToDataBase";
            this.btn_ImportAnalogSignalsToDataBase.Primary = true;
            this.btn_ImportAnalogSignalsToDataBase.Size = new System.Drawing.Size(237, 36);
            this.btn_ImportAnalogSignalsToDataBase.TabIndex = 1;
            this.btn_ImportAnalogSignalsToDataBase.Text = "Analog Sinyalleri İçeri Aktar";
            this.btn_ImportAnalogSignalsToDataBase.UseVisualStyleBackColor = false;
            this.btn_ImportAnalogSignalsToDataBase.Click += new System.EventHandler(this.btn_ImportAnalogSignalsToDataBase_Click);
            // 
            // tabSelector1
            // 
            this.tabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSelector1.BaseTabControl = null;
            this.tabSelector1.Depth = 0;
            this.tabSelector1.Location = new System.Drawing.Point(0, 64);
            this.tabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabSelector1.Name = "tabSelector1";
            this.tabSelector1.Size = new System.Drawing.Size(625, 48);
            this.tabSelector1.TabIndex = 17;
            this.tabSelector1.Text = "materialTabSelector1";
            // 
            // frm_SignalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(730, 434);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "frm_SignalList";
            this.Text = "frm_SignalList";
            this.Load += new System.EventHandler(this.frm_SignalList_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialRaisedButton btn_ExportAnalogSignalsAsCSV;
        private MaterialSkin.Controls.MaterialRaisedButton btn_ExportDigitalSignalsAsCSV;
        private MaterialSkin.Controls.MaterialTabSelector tabSelector1;
        private MaterialSkin.Controls.MaterialCheckBox chkBox_AddTimeInformation;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialRaisedButton btn_ImportDigitalSignalsToDatabase;
        private MaterialRaisedButton btn_ImportAnalogSignalsToDataBase;
        private MaterialRadioButton rdButton_DeleteOldSignals;
        private MaterialRadioButton rdButton_OverWriteOldSignals;
        private MaterialRadioButton rdButton_DoNotDeleteOrOverWriteOldSignals;
    }
}