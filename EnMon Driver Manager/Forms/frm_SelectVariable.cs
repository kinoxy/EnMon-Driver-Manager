using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager;
using EnMon_Driver_Manager.Models;

namespace EnMon_Driver_Manager
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_SelectVariable'
    public partial class frm_SelectVariable : Form
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_SelectVariable'
    {
        private AbstractDBHelper DbHelper_SelectVariable;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_SelectVariable.frm_SelectVariable()'
        public frm_SelectVariable()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_SelectVariable.frm_SelectVariable()'
        {
            InitializeComponent();
        }

        private void frm_SelectVariable_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelper_SelectVariable = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
                List<Station> stations = DbHelper_SelectVariable.GetAllStationsInfo();
                cb_StationNames.Items.AddRange(stations.ToArray());
            }
            catch(Exception)
            {
                MessageBox.Show("Database'e bağlanılamadı", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void cb_DeviceNames_DropDown(object sender, EventArgs e)
        {
           
        }

        private void cb_StationNames_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cb_DeviceNames.Enabled = true;
            cb_DeviceNames.Items.Clear();
            cb_DeviceNames.Items.AddRange(((Station)cb_StationNames.SelectedItem).ModbusTCPDevices.ToArray());
        }

        private void cb_DeviceNames_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AbstractDevice device = ((AbstractDevice)cb_DeviceNames.SelectedItem);
            if (rb_AnalogSignals.Checked)
            {
                List<Signal> analogSignals;
                analogSignals = DbHelper_SelectVariable.GetDeviceAnalogSignalsBasicInfo(device.ID);
                if(analogSignals.Count>0)
                {
                    cb_SignalNames.Items.Clear();
                    cb_SignalNames.Items.AddRange(analogSignals.ToArray());
                    cb_SignalNames.SelectedItem = null;
                }
            }
            if (rb_BinarySignals.Checked)
            {
                List<Signal> binarySignals = DbHelper_SelectVariable.GetDeviceBinarySignalsBaiscInfo(device.ID);
                if (binarySignals.Count > 0)
                {
                    cb_SignalNames.Items.Clear();
                    cb_SignalNames.Items.AddRange(binarySignals.ToArray());
                    cb_SignalNames.SelectedItem = null;
                }
            }

            cb_SignalNames.Enabled = true;
        }

        private void rb_AnalogSignals_CheckedChanged(object sender, EventArgs e)
        {
            cb_DeviceNames.Enabled = false;
            cb_DeviceNames.SelectedItem = null;
            cb_SignalNames.Enabled = false;
            cb_SignalNames.SelectedItem = null;


        }
        public AddSignalToFormEventHandler ClickedSignalAddButton;

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if(cb_SignalNames.SelectedItem != null)
            {
                OnclickedSignalAddButton();
            }
        }

        private void OnclickedSignalAddButton()
        {
            frm_SelectVariableEventArgs args = new frm_SelectVariableEventArgs();
            if(rb_AnalogSignals.Checked)
            {
                args.analogSignal = (ModbusAnalogSignal)cb_SignalNames.SelectedItem;
            }
            else
            {
                args.binarySignal = (ModbusBinarySignal)cb_SignalNames.SelectedItem;
            }
            
            if(ClickedSignalAddButton != null)
            {
                ClickedSignalAddButton(this, args);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_SelectVariable_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}


public class frm_SelectVariableEventArgs : EventArgs

{ 
    public ModbusBinarySignal binarySignal {get; set; }

    public ModbusAnalogSignal analogSignal { get; set; }

}


public delegate void AddSignalToFormEventHandler(object sender, frm_SelectVariableEventArgs args);
