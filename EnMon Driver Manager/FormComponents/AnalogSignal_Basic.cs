using System;
using EnMon_Driver_Manager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models.Devices;

namespace EnMon_Driver_Manager.FormComponents
{
    public partial class AnalogSignal_BasicValues : UserControl
    {
        #region Public Properties

        public uint AnalogSignalID
        {
            get { return uint.Parse(txt_SignalID.Text); }
            set { txt_SignalID.Text = value.ToString(); }
        }

        public List<Station> Stations
        {
            get
            {
                List<Station> valueList = new List<Station>();
                foreach (var item in cbx_StationName.Items)
                {
                    valueList.Add((item as Station));
                }
                return valueList;
            }
            set
            {
                cbx_StationName.Items.Clear();
                cbx_StationName.Items.AddRange(value.ToArray());
            }
        }

        public string SignalName
        {
            get { return txt_SignalName.Text; }
            set
            {
                txt_SignalName.Enabled = true;
                txt_SignalName.Text = value;
            }
        }

        public string Identification
        {
            get { return txt_SignalIdentification.Text; }
            set { txt_SignalIdentification.Text = value; }
        }

        public string Unit
        {
            get { return txt_Unit.Text; }
            set { txt_Unit.Text = value; }
        }

        #endregion Public Properties

        #region Private Properties

        private CommunicationProtocol Protocol { get; set; }
        private AbstractDBHelper DBHelper { get; set; }

        #endregion Private Properties

        public AnalogSignal_BasicValues(CommunicationProtocol protocol, AbstractDBHelper dbHelper)
        {
            Protocol = protocol;
            DBHelper = dbHelper;

            InitializeComponent();

            var stations = GetStations();
            if(stations!=null) cbx_StationName.Items.AddRange(stations.ToArray());
        }

        #region Public Properties



        #endregion

        #region Events

        private void cbx_StationName_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            cbx_DeviceName.Enabled = true;
            cbx_DeviceName.Items.Clear();
            var devices = ((Station)(cbx_StationName.SelectedItem)).Devices;
            if (devices != null)
            {
                var list_modbusTCPDevices = devices.Where(((d) => d.Protocol.Name == "ModbusTCP"));
                var array_modbusTcpDevices = list_modbusTCPDevices as Device[] ?? list_modbusTCPDevices.ToArray();
                if (array_modbusTcpDevices.Any())
                {
                    cbx_DeviceName.Items.AddRange(array_modbusTcpDevices);
                }
            }
            cbx_DeviceName.Enabled = true;
            cbx_DeviceName.ResetText();
            cbx_DeviceName.SelectedIndex = -1;
            txt_SignalName.Enabled = false;
        }

        private void cbx_DeviceName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txt_SignalName.Enabled = cbx_DeviceName.SelectedItem != null ? true : false;
            SetIdentificationTextBoxText();
        }

        private void txt_SignalName_KeyUp(object sender, KeyEventArgs e)
        {
            SetIdentificationTextBoxText();
        }

        #endregion

        #region Public Methods

        public bool VerifyInputs()
        {
            if (txt_SignalName.Text == string.Empty)
            {
                MessageBox.Show("Sinyal Adı bilgisi boş bırakılamaz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SignalName.Focus();
                return false;
            }
            if (txt_SignalIdentification.Text == string.Empty)
            {
                MessageBox.Show("Sinyal Uzun Adı bilgisi boş bırakılamaz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SignalIdentification.Focus();
                return false;
            }
            if (cbx_StationName.SelectedItem == null)
            {
                MessageBox.Show("Station Adı bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_StationName.Focus();
                return false;
            }
            if (cbx_DeviceName.SelectedItem == null)
            {
                MessageBox.Show("Cihaz Adı bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_DeviceName.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region Private Methods

        private List<Station> GetStations()
        {
            List<Station> stations = new List<Station>();
            try
            {
                stations = DBHelper.GetAllStationsInfoWithDeviceInfo();
                return stations;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Station bilgileri veritabanından okunamadı/nAyrıntılı bilgi için log dosyasına bakınız.",
                    Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Instance.Error("{0}: Station bilgileri veritabanından okunamadı =>{1}", this.GetType().Name, ex.Message);
                return stations;
            }
        }

        private void SetIdentificationTextBoxText()
        {
            txt_SignalIdentification.Text = ((Station)cbx_StationName.SelectedItem).Name + " " + ((Device)cbx_DeviceName.SelectedItem).Name + " " + txt_SignalName.Text;
        }
        #endregion
    }
}