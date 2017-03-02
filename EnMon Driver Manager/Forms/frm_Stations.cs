using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Extensions;
using EnMon_Driver_Manager.Models.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Forms
{
    public partial class frm_Stations<T> : Form where T : Station, new()
    {
        private BindingList<T> Stations;
        private AbstractDBHelper DBHelper;
        private bool updateNeeded;

        public frm_Stations(List<T> stations, AbstractDBHelper dbHelper)
        {
            DBHelper = dbHelper;
            InitializeComponent();
            if (stations.Count > 0)
            {
                Stations = new BindingList<T>(stations);
            }
            else
            {
                Stations = new BindingList<T>();
            }
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            dataGridView1.DataSource = Stations;
            dataGridView1.HideAllColumns();
            dataGridView1.ShowColumn("ID");
            dataGridView1.Columns["ID"].DisplayIndex = 0;
            dataGridView1.ShowColumn("Name");
            dataGridView1.Columns["Name"].DisplayIndex = 1;
            dataGridView1.Refresh();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var id = (ushort)dataGridView1.SelectedRows[0].Cells["ID"].Value;
                T station = Stations.First((s) => (s as Station).ID == id);
                propertyGrid_Station.SelectedObject = station;
            }
        }

        private void propertyGrid_Signal_Leave(object sender, EventArgs e)
        {
            if (updateNeeded)
            {
                T station = (propertyGrid_Station.SelectedObject as T);

                DBHelper.UpdateStation((T)propertyGrid_Station.SelectedObject);
            }
        }

        private void propertyGrid_Station_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            updateNeeded = true;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                T station = Stations.First((s) => s.ID == (ushort)dataGridView1.SelectedRows[0].Cells["ID"].Value);
                frm_Devices<Device> frm = new frm_Devices<Device>(station.Devices, DBHelper);
                frm.AddToPanel((Panel)this.Parent, true);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items[0].Enabled = false;
            DeleteStation();
        }

        private void DeleteStation()
        {
            throw new NotImplementedException();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStation();
        }

        private void AddStation()
        {
            T station = CreateNewStation();

            if (station != null)
            {
                if (AddStationToDatabase(station))
                {
                    Stations.Add(station);
                    LoadDataGridView();
                    propertyGrid_Station.SelectedObject = station;
                } 
            }
            else
            {
                MessageBox.Show("Yeni istasyon eklenemedi.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private T CreateNewStation()
        {
            T station = new T();
            ushort id = DBHelper.GetNextStationID();

            if (id != 0)
            {
                station.ID = DBHelper.GetNextStationID();

                // İstasyon isimleri aynı olamaz. 
                // "Yeni İstasyon" isimli istasyon var ise yeni istasyona "Yeni İstasyonx" şeklinde isim veriliyor. 
                List<T> stationsContainName_YeniIstasyon = Stations.Where((s) => s.Name.Contains("Yeni İstasyon")).ToList<T>();
                if (stationsContainName_YeniIstasyon.Count > 0)
                {
                    station.Name = "Yeni Sinyal" + stationsContainName_YeniIstasyon.Count.ToString();
                }

                return station; 
            }
            return null;
        }

        private bool AddStationToDatabase(T station)
        {
            return DBHelper.AddStation(station);
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

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 12, e.RowBounds.Location.Y + 4);
            }
        }

        private void kryptonContextMenu1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}