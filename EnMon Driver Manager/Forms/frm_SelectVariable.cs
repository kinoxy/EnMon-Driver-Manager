using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Models.Signals.Modbus;

namespace EnMon_Driver_Manager
{

    public partial class frm_SelectVariable : Form
    {
        private AbstractDBHelper DbHelper_SelectVariable;
        public frm_SelectVariable()
        {
            InitializeComponent();
        }

        private void frm_SelectVariable_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelper_SelectVariable = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
                List<Station> stations = DbHelper_SelectVariable.GetAllStationsInfoWithDeviceInfo();
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
            cb_DeviceNames.Items.AddRange(((Station)cb_StationNames.SelectedItem).Devices.ToArray());
        }

        private void cb_DeviceNames_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Device device = ((Device)cb_DeviceNames.SelectedItem);
            if (rb_AnalogSignals.Checked)
            {
                var analogSignals = DbHelper_SelectVariable.GetDeviceSignalsInfo<ModbusAnalogSignal>(device);
                if(analogSignals.Count>0)
                {
                    cb_SignalNames.Items.Clear();
                    cb_SignalNames.Items.AddRange(analogSignals.ToArray());
                    cb_SignalNames.SelectedItem = null;
                }
            }
            if (rb_BinarySignals.Checked)
            {
                var binarySignals = DbHelper_SelectVariable.GetDeviceSignalsInfo<ModbusBinarySignal>(device);
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
