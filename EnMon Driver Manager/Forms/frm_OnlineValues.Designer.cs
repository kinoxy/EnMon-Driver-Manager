namespace EnMon_Driver_Manager
{
    partial class frm_OnlineValues
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_OnlineValues));
            this.btn_SendChangesOfBinaryDgv = new GrayIris.Utilities.UI.Controls.YaTabControl();
            this.tabPage1 = new GrayIris.Utilities.UI.Controls.YaTabPage();
            this.dgv_AnalogValues = new System.Windows.Forms.DataGridView();
            this.txt_Analog_Filter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_AutoRefreshAnalogValues = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new GrayIris.Utilities.UI.Controls.YaTabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_BinaryValues = new System.Windows.Forms.DataGridView();
            this.txt_Binary_Filter = new System.Windows.Forms.TextBox();
            this.cbx_AutoRefreshBinaryValues = new System.Windows.Forms.CheckBox();
            this.dgv_DigitalSignals = new System.Windows.Forms.DataGridView();
            this.btn_SendChangesOfBinaryDgv.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AnalogValues)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BinaryValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DigitalSignals)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_SendChangesOfBinaryDgv
            // 
            this.btn_SendChangesOfBinaryDgv.ActiveColor = System.Drawing.SystemColors.Control;
            this.btn_SendChangesOfBinaryDgv.BackColor = System.Drawing.SystemColors.Control;
            this.btn_SendChangesOfBinaryDgv.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_SendChangesOfBinaryDgv.CloseButton = true;
            this.btn_SendChangesOfBinaryDgv.Controls.Add(this.tabPage1);
            this.btn_SendChangesOfBinaryDgv.Controls.Add(this.tabPage2);
            this.btn_SendChangesOfBinaryDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SendChangesOfBinaryDgv.HoverColor = System.Drawing.Color.Silver;
            this.btn_SendChangesOfBinaryDgv.ImageIndex = -1;
            this.btn_SendChangesOfBinaryDgv.ImageList = null;
            this.btn_SendChangesOfBinaryDgv.InactiveColor = System.Drawing.SystemColors.Window;
            this.btn_SendChangesOfBinaryDgv.Location = new System.Drawing.Point(0, 0);
            this.btn_SendChangesOfBinaryDgv.Name = "btn_SendChangesOfBinaryDgv";
            this.btn_SendChangesOfBinaryDgv.NewTabButton = false;
            this.btn_SendChangesOfBinaryDgv.OverIndex = -1;
            this.btn_SendChangesOfBinaryDgv.ScrollButtonStyle = GrayIris.Utilities.UI.Controls.YaScrollButtonStyle.Always;
            this.btn_SendChangesOfBinaryDgv.SelectedIndex = 1;
            this.btn_SendChangesOfBinaryDgv.SelectedTab = this.tabPage2;
            this.btn_SendChangesOfBinaryDgv.Size = new System.Drawing.Size(859, 523);
            this.btn_SendChangesOfBinaryDgv.TabDock = System.Windows.Forms.DockStyle.Top;
            this.btn_SendChangesOfBinaryDgv.TabDrawer = null;
            this.btn_SendChangesOfBinaryDgv.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_SendChangesOfBinaryDgv.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_AnalogValues);
            this.tabPage1.Controls.Add(this.txt_Analog_Filter);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbx_AutoRefreshAnalogValues);
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.ImageIndex = -1;
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(851, 489);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Analog Sinyaller";
            // 
            // dgv_AnalogValues
            // 
            this.dgv_AnalogValues.AllowUserToAddRows = false;
            this.dgv_AnalogValues.AllowUserToDeleteRows = false;
            this.dgv_AnalogValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_AnalogValues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_AnalogValues.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_AnalogValues.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_AnalogValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AnalogValues.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_AnalogValues.Location = new System.Drawing.Point(0, 30);
            this.dgv_AnalogValues.Name = "dgv_AnalogValues";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_AnalogValues.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_AnalogValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_AnalogValues.Size = new System.Drawing.Size(851, 463);
            this.dgv_AnalogValues.TabIndex = 4;
            this.dgv_AnalogValues.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_AnalogValues_CellContentDoubleClick);
            // 
            // txt_Analog_Filter
            // 
            this.txt_Analog_Filter.Location = new System.Drawing.Point(49, 4);
            this.txt_Analog_Filter.Name = "txt_Analog_Filter";
            this.txt_Analog_Filter.Size = new System.Drawing.Size(145, 20);
            this.txt_Analog_Filter.TabIndex = 3;
            this.txt_Analog_Filter.TextChanged += new System.EventHandler(this.txt_Analog_Filter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtre :";
            // 
            // cbx_AutoRefreshAnalogValues
            // 
            this.cbx_AutoRefreshAnalogValues.AutoSize = true;
            this.cbx_AutoRefreshAnalogValues.Location = new System.Drawing.Point(200, 7);
            this.cbx_AutoRefreshAnalogValues.Name = "cbx_AutoRefreshAnalogValues";
            this.cbx_AutoRefreshAnalogValues.Size = new System.Drawing.Size(100, 17);
            this.cbx_AutoRefreshAnalogValues.TabIndex = 1;
            this.cbx_AutoRefreshAnalogValues.Text = "Otomatik Yenile";
            this.cbx_AutoRefreshAnalogValues.UseVisualStyleBackColor = true;
            this.cbx_AutoRefreshAnalogValues.CheckStateChanged += new System.EventHandler(this.cbx_AutoRefreshAnalogValues_CheckStateChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.dgv_BinaryValues);
            this.tabPage2.Controls.Add(this.txt_Binary_Filter);
            this.tabPage2.Controls.Add(this.cbx_AutoRefreshBinaryValues);
            this.tabPage2.Controls.Add(this.dgv_DigitalSignals);
            this.tabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage2.ImageIndex = -1;
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(851, 489);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Digital Sinyaller";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filtre :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgv_BinaryValues
            // 
            this.dgv_BinaryValues.AllowUserToAddRows = false;
            this.dgv_BinaryValues.AllowUserToDeleteRows = false;
            this.dgv_BinaryValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_BinaryValues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_BinaryValues.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_BinaryValues.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_BinaryValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BinaryValues.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_BinaryValues.Location = new System.Drawing.Point(0, 30);
            this.dgv_BinaryValues.MultiSelect = false;
            this.dgv_BinaryValues.Name = "dgv_BinaryValues";
            this.dgv_BinaryValues.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_BinaryValues.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_BinaryValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_BinaryValues.Size = new System.Drawing.Size(851, 463);
            this.dgv_BinaryValues.TabIndex = 9;
            this.dgv_BinaryValues.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_BinaryValues_CellContentDoubleClick);
            // 
            // txt_Binary_Filter
            // 
            this.txt_Binary_Filter.Location = new System.Drawing.Point(49, 4);
            this.txt_Binary_Filter.Name = "txt_Binary_Filter";
            this.txt_Binary_Filter.Size = new System.Drawing.Size(145, 20);
            this.txt_Binary_Filter.TabIndex = 8;
            this.txt_Binary_Filter.TextChanged += new System.EventHandler(this.txt_Binary_Filter_TextChanged);
            // 
            // cbx_AutoRefreshBinaryValues
            // 
            this.cbx_AutoRefreshBinaryValues.AutoSize = true;
            this.cbx_AutoRefreshBinaryValues.Location = new System.Drawing.Point(200, 7);
            this.cbx_AutoRefreshBinaryValues.Name = "cbx_AutoRefreshBinaryValues";
            this.cbx_AutoRefreshBinaryValues.Size = new System.Drawing.Size(100, 17);
            this.cbx_AutoRefreshBinaryValues.TabIndex = 7;
            this.cbx_AutoRefreshBinaryValues.Text = "Otomatik Yenile";
            this.cbx_AutoRefreshBinaryValues.UseVisualStyleBackColor = true;
            this.cbx_AutoRefreshBinaryValues.CheckedChanged += new System.EventHandler(this.cbx_AutoRefreshBinaryValues_CheckedChanged);
            // 
            // dgv_DigitalSignals
            // 
            this.dgv_DigitalSignals.AllowUserToAddRows = false;
            this.dgv_DigitalSignals.AllowUserToDeleteRows = false;
            this.dgv_DigitalSignals.AllowUserToOrderColumns = true;
            this.dgv_DigitalSignals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_DigitalSignals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DigitalSignals.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_DigitalSignals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DigitalSignals.Location = new System.Drawing.Point(0, 30);
            this.dgv_DigitalSignals.Name = "dgv_DigitalSignals";
            this.dgv_DigitalSignals.ReadOnly = true;
            this.dgv_DigitalSignals.Size = new System.Drawing.Size(851, 459);
            this.dgv_DigitalSignals.TabIndex = 2;
            // 
            // frm_OnlineValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 523);
            this.Controls.Add(this.btn_SendChangesOfBinaryDgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_OnlineValues";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online Degerler";
            this.Load += new System.EventHandler(this.frm_OnlineValues_Load);
            this.btn_SendChangesOfBinaryDgv.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AnalogValues)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BinaryValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DigitalSignals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GrayIris.Utilities.UI.Controls.YaTabControl btn_SendChangesOfBinaryDgv;
        private GrayIris.Utilities.UI.Controls.YaTabPage tabPage1;
        private GrayIris.Utilities.UI.Controls.YaTabPage tabPage2;
        private System.Windows.Forms.CheckBox cbx_AutoRefreshAnalogValues;
        private System.Windows.Forms.DataGridView dgv_DigitalSignals;
        private System.Windows.Forms.TextBox txt_Analog_Filter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_AnalogValues;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_BinaryValues;
        private System.Windows.Forms.TextBox txt_Binary_Filter;
        private System.Windows.Forms.CheckBox cbx_AutoRefreshBinaryValues;
    }
}