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
            this.btn_ExportCommandSignalsAsCSV = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.chkBox_AddTimeInformation = new MaterialSkin.Controls.MaterialCheckBox();
            this.btn_ExportDigitalSignalsAsCSV = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_ExportAnalogSignalsAsCSV = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_ImportDigitalSignalsToDatabase = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ImportCommandSignalsToDataBase = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdButton_DeleteOldSignals = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdButton_OverWriteOldSignals = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdButton_DoNotDeleteOrOverWriteOldSignals = new MaterialSkin.Controls.MaterialRadioButton();
            this.btn_ImportAnalogSignalsToDataBase = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_AddCommandSignal = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_ShowOnlineValues = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_AddAnalogSignal = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_AddDigitalSignal = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_ExportCommandSignalsAsCSV);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chkBox_AddTimeInformation);
            this.groupBox2.Controls.Add(this.btn_ExportDigitalSignalsAsCSV);
            this.groupBox2.Controls.Add(this.btn_ExportAnalogSignalsAsCSV);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(353, 237);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DataBase\'den Sinyal Listesini Çek";
            // 
            // btn_ExportCommandSignalsAsCSV
            // 
            this.btn_ExportCommandSignalsAsCSV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ExportCommandSignalsAsCSV.Depth = 0;
            this.btn_ExportCommandSignalsAsCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExportCommandSignalsAsCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ExportCommandSignalsAsCSV.ForeColor = System.Drawing.Color.Black;
            this.btn_ExportCommandSignalsAsCSV.Icon = null;
            this.btn_ExportCommandSignalsAsCSV.Location = new System.Drawing.Point(49, 208);
            this.btn_ExportCommandSignalsAsCSV.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_ExportCommandSignalsAsCSV.Name = "btn_ExportCommandSignalsAsCSV";
            this.btn_ExportCommandSignalsAsCSV.Primary = false;
            this.btn_ExportCommandSignalsAsCSV.Size = new System.Drawing.Size(247, 36);
            this.btn_ExportCommandSignalsAsCSV.TabIndex = 7;
            this.btn_ExportCommandSignalsAsCSV.Text = "Komut Sinyalleri Dışarı Aktar";
            this.btn_ExportCommandSignalsAsCSV.UseVisualStyleBackColor = true;
            this.btn_ExportCommandSignalsAsCSV.Click += new System.EventHandler(this.btn_ExportCommandSignalsAsCSV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(23, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dışarı Aktarma Ayarları";
            // 
            // chkBox_AddTimeInformation
            // 
            this.chkBox_AddTimeInformation.AutoSize = true;
            this.chkBox_AddTimeInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.chkBox_AddTimeInformation.Depth = 0;
            this.chkBox_AddTimeInformation.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkBox_AddTimeInformation.ForeColor = System.Drawing.Color.LavenderBlush;
            this.chkBox_AddTimeInformation.Location = new System.Drawing.Point(44, 39);
            this.chkBox_AddTimeInformation.Margin = new System.Windows.Forms.Padding(0);
            this.chkBox_AddTimeInformation.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkBox_AddTimeInformation.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkBox_AddTimeInformation.Name = "chkBox_AddTimeInformation";
            this.chkBox_AddTimeInformation.Ripple = true;
            this.chkBox_AddTimeInformation.Size = new System.Drawing.Size(224, 30);
            this.chkBox_AddTimeInformation.TabIndex = 1;
            this.chkBox_AddTimeInformation.Text = "Dosya ismine tarih bilgisini ekle";
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
            this.btn_ExportDigitalSignalsAsCSV.Location = new System.Drawing.Point(49, 124);
            this.btn_ExportDigitalSignalsAsCSV.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_ExportDigitalSignalsAsCSV.Name = "btn_ExportDigitalSignalsAsCSV";
            this.btn_ExportDigitalSignalsAsCSV.Primary = false;
            this.btn_ExportDigitalSignalsAsCSV.Size = new System.Drawing.Size(247, 36);
            this.btn_ExportDigitalSignalsAsCSV.TabIndex = 1;
            this.btn_ExportDigitalSignalsAsCSV.Text = "Dijital Sinyalleri dışarı aktar ";
            this.btn_ExportDigitalSignalsAsCSV.UseVisualStyleBackColor = false;
            this.btn_ExportDigitalSignalsAsCSV.Click += new System.EventHandler(this.btn_ExportDigitalSignalsAsCSV_Click);
            // 
            // btn_ExportAnalogSignalsAsCSV
            // 
            this.btn_ExportAnalogSignalsAsCSV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ExportAnalogSignalsAsCSV.AutoSize = true;
            this.btn_ExportAnalogSignalsAsCSV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ExportAnalogSignalsAsCSV.Depth = 0;
            this.btn_ExportAnalogSignalsAsCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExportAnalogSignalsAsCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ExportAnalogSignalsAsCSV.ForeColor = System.Drawing.Color.Black;
            this.btn_ExportAnalogSignalsAsCSV.Icon = null;
            this.btn_ExportAnalogSignalsAsCSV.Location = new System.Drawing.Point(49, 166);
            this.btn_ExportAnalogSignalsAsCSV.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_ExportAnalogSignalsAsCSV.Name = "btn_ExportAnalogSignalsAsCSV";
            this.btn_ExportAnalogSignalsAsCSV.Primary = false;
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
            this.btn_ImportDigitalSignalsToDatabase.Location = new System.Drawing.Point(55, 126);
            this.btn_ImportDigitalSignalsToDatabase.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_ImportDigitalSignalsToDatabase.Name = "btn_ImportDigitalSignalsToDatabase";
            this.btn_ImportDigitalSignalsToDatabase.Primary = false;
            this.btn_ImportDigitalSignalsToDatabase.Size = new System.Drawing.Size(237, 36);
            this.btn_ImportDigitalSignalsToDatabase.TabIndex = 0;
            this.btn_ImportDigitalSignalsToDatabase.Text = "Dijital Sinyalleri İçeri aktar   ";
            this.btn_ImportDigitalSignalsToDatabase.UseVisualStyleBackColor = true;
            this.btn_ImportDigitalSignalsToDatabase.Click += new System.EventHandler(this.btn_ImportDigitalSignalsToDatabase_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(713, 237);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ImportCommandSignalsToDataBase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdButton_DeleteOldSignals);
            this.groupBox1.Controls.Add(this.rdButton_OverWriteOldSignals);
            this.groupBox1.Controls.Add(this.rdButton_DoNotDeleteOrOverWriteOldSignals);
            this.groupBox1.Controls.Add(this.btn_ImportDigitalSignalsToDatabase);
            this.groupBox1.Controls.Add(this.btn_ImportAnalogSignalsToDataBase);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.groupBox1.Location = new System.Drawing.Point(359, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(354, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DataBase\'e Sinyal Listesi Gönder";
            // 
            // btn_ImportCommandSignalsToDataBase
            // 
            this.btn_ImportCommandSignalsToDataBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ImportCommandSignalsToDataBase.Depth = 0;
            this.btn_ImportCommandSignalsToDataBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ImportCommandSignalsToDataBase.ForeColor = System.Drawing.Color.Black;
            this.btn_ImportCommandSignalsToDataBase.Icon = null;
            this.btn_ImportCommandSignalsToDataBase.Location = new System.Drawing.Point(55, 210);
            this.btn_ImportCommandSignalsToDataBase.MouseState = MaterialSkin.MouseState.DOWN;
            this.btn_ImportCommandSignalsToDataBase.Name = "btn_ImportCommandSignalsToDataBase";
            this.btn_ImportCommandSignalsToDataBase.Primary = false;
            this.btn_ImportCommandSignalsToDataBase.Size = new System.Drawing.Size(237, 36);
            this.btn_ImportCommandSignalsToDataBase.TabIndex = 6;
            this.btn_ImportCommandSignalsToDataBase.Text = "Komut Sinyalleri İçeri Aktar";
            this.btn_ImportCommandSignalsToDataBase.UseVisualStyleBackColor = false;
            this.btn_ImportCommandSignalsToDataBase.Click += new System.EventHandler(this.btn_ImportCommandSignalsToDataBase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "İçeri Aktarma Ayarları";
            // 
            // rdButton_DeleteOldSignals
            // 
            this.rdButton_DeleteOldSignals.AutoSize = true;
            this.rdButton_DeleteOldSignals.Depth = 0;
            this.rdButton_DeleteOldSignals.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdButton_DeleteOldSignals.ForeColor = System.Drawing.Color.Lavender;
            this.rdButton_DeleteOldSignals.Location = new System.Drawing.Point(39, 98);
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
            this.rdButton_OverWriteOldSignals.Location = new System.Drawing.Point(39, 68);
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
            this.rdButton_DoNotDeleteOrOverWriteOldSignals.Location = new System.Drawing.Point(39, 38);
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
            this.btn_ImportAnalogSignalsToDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ImportAnalogSignalsToDataBase.AutoSize = true;
            this.btn_ImportAnalogSignalsToDataBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ImportAnalogSignalsToDataBase.Depth = 0;
            this.btn_ImportAnalogSignalsToDataBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ImportAnalogSignalsToDataBase.ForeColor = System.Drawing.Color.Black;
            this.btn_ImportAnalogSignalsToDataBase.Icon = null;
            this.btn_ImportAnalogSignalsToDataBase.Location = new System.Drawing.Point(55, 168);
            this.btn_ImportAnalogSignalsToDataBase.MouseState = MaterialSkin.MouseState.DOWN;
            this.btn_ImportAnalogSignalsToDataBase.Name = "btn_ImportAnalogSignalsToDataBase";
            this.btn_ImportAnalogSignalsToDataBase.Primary = false;
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
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.btn_AddCommandSignal);
            this.groupBox3.Controls.Add(this.btn_ShowOnlineValues);
            this.groupBox3.Controls.Add(this.btn_AddAnalogSignal);
            this.groupBox3.Controls.Add(this.btn_AddDigitalSignal);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(5, 248);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(719, 216);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sinyaller";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btn_AddCommandSignal
            // 
            this.btn_AddCommandSignal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_AddCommandSignal.Depth = 0;
            this.btn_AddCommandSignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddCommandSignal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_AddCommandSignal.ForeColor = System.Drawing.Color.Black;
            this.btn_AddCommandSignal.Icon = null;
            this.btn_AddCommandSignal.Location = new System.Drawing.Point(9, 103);
            this.btn_AddCommandSignal.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_AddCommandSignal.Name = "btn_AddCommandSignal";
            this.btn_AddCommandSignal.Primary = false;
            this.btn_AddCommandSignal.Size = new System.Drawing.Size(174, 36);
            this.btn_AddCommandSignal.TabIndex = 10;
            this.btn_AddCommandSignal.Text = "Komut Sinyali Ekle";
            this.btn_AddCommandSignal.UseVisualStyleBackColor = true;
            this.btn_AddCommandSignal.Click += new System.EventHandler(this.btn_AddCommandSignal_Click);
            // 
            // btn_ShowOnlineValues
            // 
            this.btn_ShowOnlineValues.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ShowOnlineValues.Depth = 0;
            this.btn_ShowOnlineValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowOnlineValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ShowOnlineValues.ForeColor = System.Drawing.Color.Black;
            this.btn_ShowOnlineValues.Icon = null;
            this.btn_ShowOnlineValues.Location = new System.Drawing.Point(189, 18);
            this.btn_ShowOnlineValues.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_ShowOnlineValues.Name = "btn_ShowOnlineValues";
            this.btn_ShowOnlineValues.Primary = false;
            this.btn_ShowOnlineValues.Size = new System.Drawing.Size(174, 36);
            this.btn_ShowOnlineValues.TabIndex = 9;
            this.btn_ShowOnlineValues.Text = "Tüm sinyaller";
            this.btn_ShowOnlineValues.UseVisualStyleBackColor = true;
            this.btn_ShowOnlineValues.Click += new System.EventHandler(this.btn_ShowOnlineValues_Click);
            // 
            // btn_AddAnalogSignal
            // 
            this.btn_AddAnalogSignal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_AddAnalogSignal.Depth = 0;
            this.btn_AddAnalogSignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddAnalogSignal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_AddAnalogSignal.ForeColor = System.Drawing.Color.Black;
            this.btn_AddAnalogSignal.Icon = null;
            this.btn_AddAnalogSignal.Location = new System.Drawing.Point(9, 61);
            this.btn_AddAnalogSignal.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_AddAnalogSignal.Name = "btn_AddAnalogSignal";
            this.btn_AddAnalogSignal.Primary = false;
            this.btn_AddAnalogSignal.Size = new System.Drawing.Size(174, 36);
            this.btn_AddAnalogSignal.TabIndex = 8;
            this.btn_AddAnalogSignal.Text = "Analog Sinyal Ekle";
            this.btn_AddAnalogSignal.UseVisualStyleBackColor = true;
            this.btn_AddAnalogSignal.Click += new System.EventHandler(this.btn_AddAnalogSignal_Click);
            // 
            // btn_AddDigitalSignal
            // 
            this.btn_AddDigitalSignal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_AddDigitalSignal.Depth = 0;
            this.btn_AddDigitalSignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddDigitalSignal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_AddDigitalSignal.ForeColor = System.Drawing.Color.Black;
            this.btn_AddDigitalSignal.Icon = null;
            this.btn_AddDigitalSignal.Location = new System.Drawing.Point(9, 18);
            this.btn_AddDigitalSignal.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_AddDigitalSignal.Name = "btn_AddDigitalSignal";
            this.btn_AddDigitalSignal.Primary = false;
            this.btn_AddDigitalSignal.Size = new System.Drawing.Size(174, 36);
            this.btn_AddDigitalSignal.TabIndex = 7;
            this.btn_AddDigitalSignal.Text = "Digital Sinyal Ekle";
            this.btn_AddDigitalSignal.UseVisualStyleBackColor = true;
            this.btn_AddDigitalSignal.Click += new System.EventHandler(this.btn_AddDigitalSignal_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(729, 469);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // frm_SignalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(729, 469);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_SignalList";
            this.Text = "frm_SignalList";
            this.Load += new System.EventHandler(this.frm_SignalList_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private MaterialRaisedButton btn_ShowOnlineValues;
        private MaterialRaisedButton btn_AddAnalogSignal;
        private MaterialRaisedButton btn_AddDigitalSignal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialRaisedButton btn_AddCommandSignal;
        private MaterialRaisedButton btn_ExportCommandSignalsAsCSV;
        private MaterialRaisedButton btn_ImportCommandSignalsToDataBase;
    }
}