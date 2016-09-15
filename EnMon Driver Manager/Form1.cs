using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Resources;
using Modbus.Device;
using NLog;
using IniParser;
using IniParser.Model;
using EnMon_Driver_Manager.Modbus;
using System.IO;

namespace EnMon_Driver_Manager
{
    public partial class MainForm: Form
    {
        private ModbusTCP modbusTCP;
        public MainForm()
        {
            InitializeComponent();
            InitializeLanguageSettings();
            timer_led_count = 0;
        }
        /// <summary>
        /// Programın dilini değiştirir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void switch_language(object sender, EventArgs e)
        {
            
            if (sender.Equals(turkishToolStripMenuItem))
            {
                turkishToolStripMenuItem.Checked = true;
                englishToolStripMenuItem.Checked = false;
                cul = CultureInfo.CreateSpecificCulture("tr");
            }

            else if (sender.Equals(englishToolStripMenuItem))
            {
                turkishToolStripMenuItem.Checked = false;
                englishToolStripMenuItem.Checked = true;
                cul = CultureInfo.CreateSpecificCulture("en");
            }

            this.fileToolStripMenuItem.Text = res_man.GetString("File", cul);
            this.editToolStripMenuItem.Text = res_man.GetString("Edit", cul);
            this.languageToolStripMenuItem.Text = res_man.GetString("Language", cul);
            this.turkishToolStripMenuItem.Text = res_man.GetString("Turkish", cul);
            this.englishToolStripMenuItem.Text = res_man.GetString("English", cul);
            this.btn_start.Text = res_man.GetString("btn_Start", cul);
            this.chkBox_runOnStartup.Text = res_man.GetString("chkBox_runOnStartup", cul);

            Log.Instance.Info(String.Format("Language ayarları {0} olarak değiştirildi",cul));
            
        }
        /// <summary>
        /// Led'in method icersinde belirtilen sayıda yanıp sonmesini saglar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_led_Tick(object sender, EventArgs e)
        {
            if (timer_led_count % 2 == 1)
            {
                pct_led.Visible = false;
                timer_led_count++;
                //timer_led.Start();
            }
            else if(timer_led_count % 2 == 0)
            {
                pct_led.Visible = true;
                timer_led_count++;
                //timer_led.Start();

            }
            if(timer_led_count == 7)
            {
                if(pct_led.Image == EnMon_Driver_Manager.Properties.Resources.green)
                {
                    pct_led.Image = EnMon_Driver_Manager.Properties.Resources.red;
                }
                else
                {
                    pct_led.Image = EnMon_Driver_Manager.Properties.Resources.green;
                }
                timer_led.Stop();
                timer_led_count = 0;
                pct_led.Visible = true;
            }
        }

        private async void btn_start_Click(object sender, EventArgs e)
        {
            timer_led.Start();

            if (File.Exists("ModbusTCPConfig.ini"))
            {
                Task t1 = Task.Factory.StartNew(() => modbusTCP = new ModbusTCP("ModbusTCPConfig.ini"));
                await t1;
                if (modbusTCP.Devices.Count > 0)
                {
                    pct_led.Image = EnMon_Driver_Manager.Properties.Resources.green;
                    modbusTCP.StartCommunication();
                }
            }
            else
            {
                Log.Instance.Error("Driver config dosyası bulunamadı");
            }
            timer_led.Stop();
            pct_led.Visible = true;
            
   
        }
    }
}
