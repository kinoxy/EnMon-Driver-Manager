namespace EnMon_Driver_Manager
{
    partial class frm_ChangeGroupName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChangeGroupName));
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBox_OldName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtbox_NewName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btn_ChangeGroupName = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_Cancel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.Black;
            this.materialLabel1.Location = new System.Drawing.Point(12, 13);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(81, 19);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "Grup İsmi :";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.Black;
            this.materialLabel2.Location = new System.Drawing.Point(12, 42);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(79, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Yeni İsim :";
            this.materialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBox_OldName
            // 
            this.txtBox_OldName.Depth = 0;
            this.txtBox_OldName.Enabled = false;
            this.txtBox_OldName.ForeColor = System.Drawing.Color.White;
            this.txtBox_OldName.Hint = "";
            this.txtBox_OldName.Location = new System.Drawing.Point(108, 9);
            this.txtBox_OldName.MaxLength = 32767;
            this.txtBox_OldName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBox_OldName.Name = "txtBox_OldName";
            this.txtBox_OldName.PasswordChar = '\0';
            this.txtBox_OldName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBox_OldName.SelectedText = "";
            this.txtBox_OldName.SelectionLength = 0;
            this.txtBox_OldName.SelectionStart = 0;
            this.txtBox_OldName.Size = new System.Drawing.Size(165, 23);
            this.txtBox_OldName.TabIndex = 4;
            this.txtBox_OldName.TabStop = false;
            this.txtBox_OldName.Text = "materialSingleLineTextField1";
            this.txtBox_OldName.UseSystemPasswordChar = false;
            // 
            // txtbox_NewName
            // 
            this.txtbox_NewName.Depth = 0;
            this.txtbox_NewName.Hint = "";
            this.txtbox_NewName.Location = new System.Drawing.Point(108, 38);
            this.txtbox_NewName.MaxLength = 32767;
            this.txtbox_NewName.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtbox_NewName.Name = "txtbox_NewName";
            this.txtbox_NewName.PasswordChar = '\0';
            this.txtbox_NewName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbox_NewName.SelectedText = "";
            this.txtbox_NewName.SelectionLength = 0;
            this.txtbox_NewName.SelectionStart = 0;
            this.txtbox_NewName.Size = new System.Drawing.Size(165, 23);
            this.txtbox_NewName.TabIndex = 5;
            this.txtbox_NewName.TabStop = false;
            this.txtbox_NewName.UseSystemPasswordChar = false;
            // 
            // btn_ChangeGroupName
            // 
            this.btn_ChangeGroupName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ChangeGroupName.Depth = 0;
            this.btn_ChangeGroupName.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_ChangeGroupName.Icon = null;
            this.btn_ChangeGroupName.Location = new System.Drawing.Point(16, 77);
            this.btn_ChangeGroupName.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_ChangeGroupName.Name = "btn_ChangeGroupName";
            this.btn_ChangeGroupName.Primary = true;
            this.btn_ChangeGroupName.Size = new System.Drawing.Size(124, 36);
            this.btn_ChangeGroupName.TabIndex = 8;
            this.btn_ChangeGroupName.Text = "Değiştir";
            this.btn_ChangeGroupName.UseVisualStyleBackColor = true;
            this.btn_ChangeGroupName.Click += new System.EventHandler(this.btn_ChangeGroupName_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.Depth = 0;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Icon = null;
            this.btn_Cancel.Location = new System.Drawing.Point(149, 77);
            this.btn_Cancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Primary = true;
            this.btn_Cancel.Size = new System.Drawing.Size(124, 36);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "İptal";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // frm_ChangeGroupName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(285, 123);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_ChangeGroupName);
            this.Controls.Add(this.txtbox_NewName);
            this.Controls.Add(this.txtBox_OldName);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChangeGroupName";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Grup Adını Değiştir";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBox_OldName;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtbox_NewName;
        private MaterialSkin.Controls.MaterialRaisedButton btn_Cancel;
        public MaterialSkin.Controls.MaterialLabel materialLabel1;
        public MaterialSkin.Controls.MaterialLabel materialLabel2;
        public MaterialSkin.Controls.MaterialRaisedButton btn_ChangeGroupName;
    }
}