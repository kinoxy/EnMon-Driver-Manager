using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnMon_Driver_Manager.Modbus;
using System.IO;
using EnMon_Driver_Manager.DataBase;

namespace EnMon_Driver_Manager
{
    public partial class MainForm: Form
    {
        private frm_Devices frm_devices;
        private frm_SignalList frm_signallist;
        private ModbusTCP modbusTCP;
        public MySqlDBHelper dbhelper;
        public MainForm()
        {
            InitializeComponent();
            InitializeLanguageSettings();

            timer_led_count = 0;

            Task t1 = new Task(CreateDatabaseHelperInstance);
            t1.Start();
            


        }
        /// <summary>
        /// Programın dilini değiştirir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void switch_language(object sender, EventArgs e)
        {

            //if (sender.Equals(turkishToolStripMenuItem))
            //{
            //    turkishToolStripMenuItem.Checked = true;
            //    englishToolStripMenuItem.Checked = false;
            //    cul = CultureInfo.CreateSpecificCulture("tr");
            //}

            //else if (sender.Equals(englishToolStripMenuItem))
            //{
            //    turkishToolStripMenuItem.Checked = false;
            //    englishToolStripMenuItem.Checked = true;
            //    cul = CultureInfo.CreateSpecificCulture("en");
            //}

            //this.fileToolStripMenuItem.Text = res_man.GetString("File", cul);
            //this.editToolStripMenuItem.Text = res_man.GetString("Edit", cul);
            //this.languageToolStripMenuItem.Text = res_man.GetString("Language", cul);
            //this.turkishToolStripMenuItem.Text = res_man.GetString("Turkish", cul);
            //this.englishToolStripMenuItem.Text = res_man.GetString("English", cul);
            this.lblHeader.Text = res_man.GetString("EnMon Driver Manager", cul);
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
            if (timer_led_count % 2 == 0)
            {
                pct_led.Visible = false;
                timer_led_count++;
                //timer_led.Start();
            }
            else if(timer_led_count % 2 == 1)
            {
                pct_led.Visible = true;
                timer_led_count++;
                //timer_led.Start();

            }
            
        }

        private async void btn_start_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
            timer_led.Start();

            
            // ModbusTCP Config dosyası okunuyor
            if (File.Exists("ModbusTCPConfig.ini"))
            {
                Task t1 = Task.Factory.StartNew(() => modbusTCP = new ModbusTCP(("ModbusTCPConfig.ini"), dbhelper));
                await t1;
                if (modbusTCP.Devices.Count > 0 & !modbusTCP.IsError)
                {
                    timer_led.Stop();
                    pct_led.Image = EnMon_Driver_Manager.Properties.Resources.green;
                    pct_led.Visible = true;
                    btn_start.Text = res_man.GetString("btn_Stop", cul);
                    modbusTCP.StartCommunication();
                }
            }
            else
            {
                Log.Instance.Error("Driver config dosyası bulunamadı");
            }
            timer_led.Stop();
            btn_start.Enabled = true;
            pct_led.Visible = true;
            
    
        }

        private void DragStart(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void OnDrag(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void DragEnd(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Close32MouseOut;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.Minus32MouseIn;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.Minus32MouseOut;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Close32MouseIn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(frm_devices == null)
            {
                frm_Devices frm = new frm_Devices();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                if(modbusTCP != null)
                {
                    frm.addDeviceInfo(modbusTCP); 
                }
                frm.StateChanged += UpdateDeviceActiveState;
                frm.Dock = DockStyle.Fill;
                panel_Main.Controls.Clear();
                panel_Main.Controls.Add(frm);
                frm.Visible = true;
                //(sender as Button).BackColor = Color.FromArgb(0, 0, 196, 174);
            }
            

        }

        /// <summary>
        /// Updates the state of the device active.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="frm_DevicesEventArgs"/> instance containing the event data.</param>
        private void UpdateDeviceActiveState(object source, frm_DevicesEventArgs args)
        {
            // DeviceInfo control'unden gönderilen eventteki args'lara göre ilgili device'ın haberleşme durumu değiştirilir.
            modbusTCP.Devices.Where(d => d.ID == args.deviceId).First().isActive = args.state;
            dbhelper.UpdateDeviceActiveState(args.deviceId, args.state);
            if(args.state)
            {
                Log.Instance.Info("{0} nolu Device için haberleşme aktif edildi", args.deviceId);
                // Haberleşme aktif edilse bile haberleşmenin kurulacağı kesin olmadığı için device.Connected burada true yapılmaz.
                // modbusTCP.Devices.Where(d => d.ID == args.deviceId).First().Connected = true;
                
            }
            else
            {
                Log.Instance.Info("{0} nolu Device için haberleşme kapatıldı", args.deviceId);
                modbusTCP.Devices.Where(d => d.ID == args.deviceId).First().Connected = false;
                dbhelper.UpdateDeviceConnectedState(args.deviceId, args.state);
                // Haberleşme kapatıldıgında haberleşme sağlanamayacağı için device.Connected burada false'a çekilir.
            }
        }

        private void MinimizeForm(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ResizeForm(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }
        }

        private void GetFormBack(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void btn_Signals_Click(object sender, EventArgs e)
        {

            frm_signallist = new frm_SignalList();
           
                frm_signallist.TopLevel = false;
                frm_signallist.FormBorderStyle = FormBorderStyle.None;
                frm_signallist.Dock = DockStyle.Fill;
                frm_signallist.DbHelper = dbhelper;
                panel_Main.Controls.Clear();
                panel_Main.Controls.Add(frm_signallist);
                frm_signallist.Visible = true;
           
                
                //(sender as Button).BackColor = Color.FromArgb(0, 0, 196, 174);
            

        }

        /// <summary>
        /// Creates the database helper instance.
        /// </summary>
        private void CreateDatabaseHelperInstance()
        {
            if (dbhelper == null)
            {
                dbhelper = new MySqlDBHelper();
            }
        }
    }
}
