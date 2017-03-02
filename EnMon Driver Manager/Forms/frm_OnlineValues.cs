using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Properties;
using System;
using System.Data;
using System.Windows.Forms;
using EnMon_Driver_Manager.Models.Signals.Modbus;

namespace EnMon_Driver_Manager
{
    [System.Runtime.InteropServices.Guid("D1B0EC7D-244A-4BBF-B04C-F11DD010C91D")]
    public partial class frm_OnlineValues : Form

    {
        #region Private Properties

        private Timer timer_GetAnalogSignals;
        private Timer timer_GetBinarySignals;
        private AbstractDBHelper DBHelper_OnlineValues;
        private DataTable dt_AnalogValues;
        private DataTable dt_BinaryValues;

        #endregion Private Properties

        #region Constructors

        public frm_OnlineValues()
        {
            InitializeComponent();
            dt_AnalogValues = new DataTable();
            dt_BinaryValues = new DataTable();
            InitializeTimers();
        }

        #endregion Constructors

        #region Events

        private void Timer_GetBinarySignals_Tick(object sender, EventArgs e)
        {
            LoaddgvBinaryValuesWithData();
            FilterDataGridView(dgv_BinaryValues, txt_Binary_Filter.Text); ;
        }

        private void Timer_GetAnalogSignals_Tick(object sender, EventArgs e)
        {
            LoaddgvAnalogValuesWithData();
            FilterDataGridView(dgv_AnalogValues, txt_Analog_Filter.Text);
        }

        private void frm_OnlineValues_Load(object sender, EventArgs e)
        {
            DBHelper_OnlineValues = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            LoaddgvAnalogValuesWithData();
            LoaddgvBinaryValuesWithData();
        }

        private void cbx_AutoRefresh_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbx_AutoRefreshAnalogValues.CheckState == CheckState.Checked)
            {
                timer_GetAnalogSignals.Start();
            }
            else
            {
                timer_GetAnalogSignals.Stop();
            }
        }

        private void txt_Filtre_TextChanged(object sender, EventArgs e)
        {
        }

        private void FilterDataGridView(DataGridView dgv, string text)
        {
            string[] filtre = text.Split('?');
            string fs = "";
            if (filtre[0] != "")
            {
                fs = string.Format("[Sinyal İsmi] Like '%{0}%'", filtre[0]);
            }

            for (int i = 1; i < filtre.Length; i++)
            {
                if (filtre[i] != "")
                {
                    fs += string.Format("AND [Sinyal İsmi] Like '%{0}%'", filtre[i]);
                }
            }
            if (fs != "")
            {
                (dgv.DataSource as DataTable).DefaultView.RowFilter = fs;
            }
        }

        private void btn_SendChanges_Click(object sender, EventArgs e)
        {
            DataTable dt = (dgv_AnalogValues.DataSource as DataTable).GetChanges();
            if (dt.Rows.Count > 0)
            {
                //DBHelper_OnlineValues.UpdateAnalogSignals();
            }
        }

        private void txt_Analog_Filter_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView(dgv_AnalogValues, txt_Analog_Filter.Text);
        }

        private void txt_Binary_Filter_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView(dgv_BinaryValues, txt_Binary_Filter.Text);
        }

        private void cbx_AutoRefreshAnalogValues_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbx_AutoRefreshAnalogValues.CheckState == CheckState.Checked)
            {
                timer_GetAnalogSignals.Start();
            }
            else
            {
                timer_GetAnalogSignals.Stop();
            }
        }

        private void cbx_AutoRefreshBinaryValues_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_AutoRefreshBinaryValues.CheckState == CheckState.Checked)
            {
                timer_GetBinarySignals.Start();
            }
            else
            {
                timer_GetBinarySignals.Stop();
            }
        }

        private void dgv_AnalogValues_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string signalIdentification = dgv_AnalogValues.Rows[e.RowIndex].Cells[0].Value.ToString();
            string protocol_id = dgv_AnalogValues.Rows[e.RowIndex].Cells["protocol_id"].Value.ToString();
            switch (protocol_id)
            {
                // ModbusTCP
                case "1":
                    ModbusAnalogSignal analogSignal =
                        DBHelper_OnlineValues.GetAnalogSignalsInfoByIdentification<ModbusAnalogSignal>(signalIdentification);
                    if (analogSignal != null)
                    {
                        frm_AddNewOrUpdateModbusAnalogSignal frm_UpdateAnalogSignal = new frm_AddNewOrUpdateModbusAnalogSignal(analogSignal);
                        frm_UpdateAnalogSignal.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Modus analog sinyal bilgileri veritabanından okunamadı.\nAyrıntılı bilgi için log dosyasına bakınız.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "2":
                    MessageBox.Show("SNMP updade signal Not implemented");
                    //SNMPAnalogSignal analogSignal =
                    //    DBHelper_OnlineValues.GetSignalsInfoByIdentification<SNMPAnalogSignal>(signalIdentification);
                    //if (analogSignal != null)
                    //{
                    //    frm_AddNewOrUpdateModbusAnalogSignal frm_UpdateAnalogSignal = new frm_AddNewOrUpdateModbusAnalogSignal(analogSignal);
                    //    frm_UpdateAnalogSignal.ShowDialog();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("SNMP analog sinyal bilgileri veritabanından okunamadı.\nAyrıntılı bilgi için log dosyasına bakınız.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    break;
                default:
                    Log.Instance.Error("{0}: Sinyala ait protocol bilgisi bulunamadı", this.GetType().Name);
                    break;
            }
            
        }

        private void dgv_BinaryValues_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var protocol_id = dgv_BinaryValues.Rows[e.RowIndex].Cells["protocol_id"].Value.ToString();
            var signalIdentification = dgv_BinaryValues.Rows[e.RowIndex].Cells["identification"].Value.ToString();

            switch (protocol_id)
            {
                // ModbusTCP
                case "1":
                    ModbusBinarySignal binarySignal = DBHelper_OnlineValues.GetBinarySignalInfoByIdentification<ModbusBinarySignal>(signalIdentification);
                    if (binarySignal != null)
                    {
                        frm_AddNewOrUpdateModbusBinarySignal frm_UpdateBinarySignal = new frm_AddNewOrUpdateModbusBinarySignal(binarySignal);
                        frm_UpdateBinarySignal.ShowDialog();
                    }
                    else
                    {
                        if (Resources.frm_OnlineValues__dgv_BinaryValues_CellContentDoubleClick_ != null)
                            MessageBox.Show(Resources.frm_OnlineValues__dgv_BinaryValues_CellContentDoubleClick_,
                                Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                // SNMP
                case "2":
                    MessageBox.Show("SNMP not implemented yet");
                    break;
            }

        }

        #endregion Events

        #region Private Properties

        private void InitializeTimers()
        {
            timer_GetAnalogSignals = new Timer();
            timer_GetAnalogSignals.Interval = 5000;
            timer_GetAnalogSignals.Tick += Timer_GetAnalogSignals_Tick;

            timer_GetBinarySignals = new Timer();
            timer_GetBinarySignals.Interval = 5000;
            timer_GetBinarySignals.Tick += Timer_GetBinarySignals_Tick;
        }

        private void LoaddgvAnalogValuesWithData()
        {
            dt_AnalogValues = DBHelper_OnlineValues.GetAllAnalogSignalsInfoWithLastValues();
            //     dt_AnalogValues.Columns["Alarm"].DataType = System.Type.GetType("System.Boolean");
            dgv_AnalogValues.DataSource = dt_AnalogValues;
        }

        private void LoaddgvBinaryValuesWithData()
        {
            dt_BinaryValues = DBHelper_OnlineValues.GetAllBinarySignalsInfoWithLastValues();
            if (dgv_BinaryValues != null)
            {
                dgv_BinaryValues.DataSource = dt_BinaryValues;
                // Online deger gosterirken sinyalin protokol bilgisi gizleniyor.
                var dataGridViewColumn = dgv_BinaryValues.Columns["protocol_id"];
                if (dataGridViewColumn != null)
                {
                    dataGridViewColumn.Visible = false;
                }
            }
        }

        #endregion Private Properties

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}