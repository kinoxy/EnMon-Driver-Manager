using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Extensions;
using EnMon_Driver_Manager.Models;
using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Models.Signals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Forms
{
    public partial class frm_Signals<T> : Form where T : Signal, new()
    {
        private BindingList<T> Signals;
        private AbstractDBHelper DBHelper;
        private bool updateNeeded;
        private Device device;
        private DataTable dt;
        private BindingSource bs;

        public frm_Signals(List<T> signals, Device device, AbstractDBHelper dbHelper)
        {
            this.device = device;
            DBHelper = dbHelper;
            InitializeComponent();
            if (signals.Count > 0)
            {
                Signals = new BindingList<T>(signals);
            }
            else
            {
                Signals = new BindingList<T>();
            }
            LoadDataGridView();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var id = (uint)dataGridView1.SelectedRows[0].Cells["ID"].Value;
                AssignObjectToPropertyGrid(id);
            }
        }

        private void AssignObjectToPropertyGrid(uint id)
        {
            T signal = Signals.First((s) => (s as Signal).ID == id);
            propertyGrid_Signal.SelectedObject = signal;
        }

        private void propertyGrid_Signal_Leave(object sender, EventArgs e)
        {
            if (updateNeeded)
            {
                T signal = (T)propertyGrid_Signal.SelectedObject;
                if (DBHelper.UpdateSignal(signal))
                {
                    updateNeeded = false;
                }
                else
                {
                    MessageBox.Show($"{signal.ID} nolu sinyal güncellenirken hata oluştu. Ayrıntılı bilgi için log dosyasına bakınız.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void propertyGrid_Signal_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            updateNeeded = true;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                if (rowSelected != -1)
                {
                    dataGridView1.Rows[rowSelected].Selected = true;
                    contextMenuStrip1.Items[0].Enabled = true;
                }
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = false;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items[0].Enabled = false;

            DeleteSignal();
        }

        private void DeleteSignal()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                var id = (uint)dataGridView1.SelectedRows[0].Cells["ID"].Value;
                if (DBHelper.DeleteSignal<T>(Signals.First((s) => (s as Signal).ID == id)))
                {
                    Signals.Remove(Signals.First((s) => (s as Signal).ID == id));
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows[0].Selected = true;
                    }
                }
                else
                {
                    MessageBox.Show("Sinyal silinemedi");
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var id = (uint)dataGridView1.SelectedRows[0].Cells["ID"].Value;
                AssignObjectToPropertyGrid(id);
            }
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSignal();
        }

        private void AddSignal()
        {
            T signal = CreateNewSignal();

            if (signal != null)
            {
                if (AddSignalToDatabase(signal))
                {
                    Signals.Add(signal);
                    LoadDataGridView();
                    propertyGrid_Signal.SelectedObject = signal;
                } 
            }
            else
            {
                MessageBox.Show("Yeni sinyal eklenemedi.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private T CreateNewSignal()
        {
            T signal = new T();
            // İstasyon ve cihaz bilgileri sinyale atanıyor.
            signal.DeviceName = device.Name;
            signal.deviceID = device.ID;
            signal.StationName = TemporaryValues.stations.Find((s) => s.ID == device.StationID).Name;

            // Sinyal ID'si oluşturuluyor
            switch (signal.GetBaseClassType())
            {
                case "EnMon_Driver_Manager.Models.Signals.BinarySignal":
                    signal.ID = DBHelper.GetNextBinarySignalID();
                    break;

                case "EnMon_Driver_Manager.Models.Signals.AnalogSignal":
                    signal.ID = DBHelper.GetNextAnalogSignalID();
                    break;
            }

            // Cihaz içerisinde aynı tipteki sinyaller aynı identification'ı alamazlar.
            // 'Yeni Sinyal' isimli başka bir sinyal varsa yeni oluşturulucak sinyalin ismi 'Yeni Sinyalx' olarak değiştiriliyor.
            // x => Sayı

            List<T> signalsContainName_YeniSinyal = Signals.Where((s) => s.Name.Contains("Yeni Sinyal")).ToList<T>();
            if (signalsContainName_YeniSinyal.Count > 0)
            {
                signal.Name = "Yeni Sinyal" + signalsContainName_YeniSinyal.Count.ToString();
            }

            // ID sıfırdan büyük ise başarılı bir şekilde veritabanından yeni ID değeri okunmuştur.
            // ID sıfır ise yeni ID değeri alınamamıştır ve sinyal oluşturulmaz.
            return signal.ID > 0 ? signal : null;
        }

        private void LoadDataGridView()
        {
            dataGridView1.DataSource = Signals;

            // Dgv'e bos satırlar eklemek için deneme
            //if (dataGridView1.Rows.Count < 20)
            //{
            //    int r = 20 - dataGridView1.Rows.Count;
            //    for (int i = 0; i < r; i++)
            //    {
            //        dataGridView1.Rows.Add(new DataGridViewRow());
            //    }

            //}
            dataGridView1.HideAllColumns();
            dataGridView1.ShowColumn("ID");
            dataGridView1.Columns["ID"].DisplayIndex = 0;
            dataGridView1.ShowColumn("Name");
            dataGridView1.Columns["Name"].DisplayIndex = 1;
            dataGridView1.ShowColumn("CurrentValue");
            dataGridView1.Columns["CurrentValue"].DisplayIndex = 2;
            dataGridView1.Refresh();
        }

        private bool AddSignalToDatabase(T signal)
        {
            string baseClassName = signal.GetBaseClassType();
            switch (baseClassName)
            {
                case "EnMon_Driver_Manager.Models.Signals.BinarySignal":
                    return DBHelper.AddBinarySignalToDataBase<T>(signal);

                case "EnMon_Driver_Manager.Models.Signals.AnalogSignal":
                    return DBHelper.AddAnalogSignalToDataBase<T>(signal);
            }
            return false;
        }

        private void AddSignalToDatabase(object source, PropertyGridEventArgs<T> args)
        {
            string baseClassName = args.item.GetBaseClassType();
            switch (baseClassName)
            {
                case "EnMon_Driver_Manager.Models.Signals.BinarySignal":
                    DBHelper.AddBinarySignalToDataBase<T>(args.item);
                    break;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 12, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FilterDataGridView(DataGridView dgv, string text)
        {
            string[] filtre = text.Split('?');
            //string fs = "";

            BindingList<T> bl = new BindingList<T>(Signals);
            foreach(var fs in filtre)
            {
                bl = new BindingList<T>(bl.Where((l) => l.Name.Contains(fs)).ToList());
            }

            dataGridView1.DataSource = bl;
            
        }

        private void txt_Filter_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView(dataGridView1, txt_Filter.Text);
        }

        private void cbx_AutoRefreshBinaryValues_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbx_AutoRefreshValues_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_AutoRefreshValues.CheckState == CheckState.Checked)
            {
                timer_GetSignalsFromDatabase.Start();
            }
            else
            {
                timer_GetSignalsFromDatabase.Stop();
            }
        }

        private void timer_GetSignalsFromDatabase_Tick(object sender, EventArgs e)
        {
            GetDeviceSignalsFromDatabase();
        }

        private void GetDeviceSignalsFromDatabase()
        {
            if(Signals.Count>0)
            {
                switch(Signals[0].GetBaseClassType())
                {
                    case "BinarySignals":
                        List<T> signals = DBHelper.GetDeviceBinarySignalsInfo<T>(device);
                        if (signals!=null)
                        {
                            Signals = new BindingList<T>(signals);
                            LoadDataGridView(); 
                        }
                        break;
                    case "AnalogSignals":
                        List<T> signals2 = DBHelper.GetDeviceAnalogSignalsInfo<T>(device);
                        if (signals2 != null)
                        {
                            Signals = new BindingList<T>(signals2);
                            LoadDataGridView();
                        }
                        break;
                }
            }
        }
    }
}