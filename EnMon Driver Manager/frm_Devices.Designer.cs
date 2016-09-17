using System.Collections.Generic;

namespace EnMon_Driver_Manager
{
    partial class frm_Devices
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
            this.components = new System.ComponentModel.Container();
            this.timer_Loop2Seconds = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer_Loop2Seconds
            // 
            this.timer_Loop2Seconds.Interval = 2000;
            this.timer_Loop2Seconds.Tick += new System.EventHandler(this.CheckConnectionStatusOfDevices);
            // 
            // frm_Devices
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(402, 253);
            this.Name = "frm_Devices";
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Timer timer_Loop2Seconds;
    }
}