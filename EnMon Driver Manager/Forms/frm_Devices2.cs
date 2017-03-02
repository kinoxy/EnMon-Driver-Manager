using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Extensions;
using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Models.Signals;
using EnMon_Driver_Manager.Models.Signals.Modbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Forms
{
    public partial class frm_Devices<T> : Form where T : Device
    {
        private List<T> Devices;
        private AbstractDBHelper DBHelper;
        private bool updateNeeded;
        public frm_Devices(List<T> devices, AbstractDBHelper dbHelper)
        {
            DBHelper = dbHelper;
            InitializeComponent();
            if(devices.Count>0)
            {
                Devices = devices;
                dataGridView1.DataSource = Devices;
                dataGridView1.HideAllColumns();
                dataGridView1.ShowColumn("ID");
                dataGridView1.Columns["ID"].DisplayIndex = 0;
                dataGridView1.ShowColumn("Name");
                dataGridView1.Columns["Name"].DisplayIndex = 1;
                dataGridView1.ShowColumn("Protocol");
                dataGridView1.Columns["Protocol"].DisplayIndex = 2;
                dataGridView1.ShowColumn("isActive");
                dataGridView1.Columns["isActive"].DisplayIndex = 3;
                dataGridView1.ShowColumn("Connected");
                dataGridView1.Columns["Connected"].DisplayIndex = 4;

            }
            
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.SelectedRows.Count>0)
            {
                var id = (ushort)dataGridView1.SelectedRows[0].Cells["ID"].Value;
                T device = Devices.Find((d) => (d as Device).ID == id);
                switch ((device as Device).Protocol.ID)
                {
                    case 1: //ModbusTCP
                        ModbusTCPDevice modbusTCPDevice = new ModbusTCPDevice();
                        modbusTCPDevice = DBHelper.GetDeviceInfo<ModbusTCPDevice>(device as Device);
                        if(modbusTCPDevice !=null) propertyGrid_Signal.SelectedObject = modbusTCPDevice;
                        break;
                }
                
            }

        }

        private void propertyGrid_Signal_Leave(object sender, EventArgs e)
        {
            if(updateNeeded)
            {
                T device = (propertyGrid_Signal.SelectedObject as T);
                switch (device.Protocol.ID)
                {
                    case 1: //ModbusTCP
                        DBHelper.UpdateDevice(propertyGrid_Signal.SelectedObject as ModbusTCPDevice);
                        updateNeeded = false;
                        break;
                }

                
            }
            
        }

        private void propertyGrid_Signal_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            updateNeeded = true;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 12, e.RowBounds.Location.Y + 4);
            }
        }

        
    }
}
