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
            if(rb_AnalogSignals.Checked)
            {
                List<AnalogSignal> analogSignals = DbHelper_SelectVariable.GetDeviceAnalogSignalsInfo(((Device)cb_DeviceNames.SelectedItem).ID);
                if(analogSignals.Count>0)
                {
                    cb_SignalNames.Items.Clear();
                    cb_SignalNames.Items.AddRange(analogSignals.ToArray());
                    cb_SignalNames.SelectedItem = null;
                }
            }
            if (rb_BinarySignals.Checked)
            {
                List<BinarySignal> binarySignals = DbHelper_SelectVariable.GetDeviceBinarySignalsInfo(((Device)cb_DeviceNames.SelectedItem).ID);
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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_SelectVariable.ClickedSignalAddButton'
        public AddSignalToFormEventHandler ClickedSignalAddButton;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_SelectVariable.ClickedSignalAddButton'

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
                args.analogSignal = (AnalogSignal)cb_SignalNames.SelectedItem;
            }
            else
            {
                args.binarySignal = (BinarySignal)cb_SignalNames.SelectedItem;
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_SelectVariableEventArgs'
public class frm_SelectVariableEventArgs : EventArgs
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_SelectVariableEventArgs'
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_SelectVariableEventArgs.binarySignal'
    public BinarySignal binarySignal {get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_SelectVariableEventArgs.binarySignal'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'frm_SelectVariableEventArgs.analogSignal'
    public AnalogSignal analogSignal { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'frm_SelectVariableEventArgs.analogSignal'
}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AddSignalToFormEventHandler'
public delegate void AddSignalToFormEventHandler(object sender, frm_SelectVariableEventArgs args);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AddSignalToFormEventHandler'