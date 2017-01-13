using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Models.Signals.Modbus;
using EnMon_Driver_Manager.Models.StatusTexts;

namespace EnMon_Driver_Manager
{

    public partial class frm_AddNewOrUpdateModbusBinarySignal : Form

    {
        #region Private Properties

        private AbstractDBHelper DBHelper_AddNewOrUpdateModbusBinarySignalForm;

        private ModbusBinarySignal binarySignal;

        private uint ID;

        private List<Station> stations;
        private List<StatusText> statusTexts;

        #endregion Private Properties

        #region Constructors


        public frm_AddNewOrUpdateModbusBinarySignal()
        {
            
            InitializeComponent();

            InitializeDatabase();

            ID = DBHelper_AddNewOrUpdateModbusBinarySignalForm.GetNextBinarySignalID();

            InitializeControlProperties();

            binarySignal = new ModbusBinarySignal();

            btn_Delete.Hide();
            btn_Delete.Enabled = false;
        }

        public frm_AddNewOrUpdateModbusBinarySignal(ModbusBinarySignal signal)
        {
            InitializeComponent();

            InitializeDatabase();

            InitializeControlProperties();

            this.Text = "Binary Sinyal Güncelle";
            this.btn_OK.Text = "Güncelle";
            binarySignal = signal;

            UpdateControlsWithSignalInfo();
        }

        private void UpdateControlsWithSignalInfo()
        {
            InsertInfoToGeneralSettingsGroup();

            InsertInfoToCommmunicationSettingGroup();

            InsertInfoToAlarmEventGroup();
        }

        private void InsertInfoToAlarmEventGroup()
        {
            cbx_IsAlarm.Checked = binarySignal.IsAlarm ? true : false;
            cbx_IsEvent.Checked = binarySignal.IsEvent ? true : false;
            cbx_StatusText.SelectedItem = statusTexts.Find((s) => s.StatusID == binarySignal.StatusID); 
        }

        private void InsertInfoToCommmunicationSettingGroup()
        {
            txt_ModbusAddress.Text = binarySignal.Address.ToString();

            switch (binarySignal.FunctionCode)
            {
                case 1:
                    cbx_FunctionCode.SelectedItem = "FC 1";
                    break;
                case 2:
                    cbx_FunctionCode.SelectedItem = "FC 2";
                    break;
                case 3:
                    cbx_FunctionCode.SelectedItem = "FC 3";
                    break;
                case 4:
                    cbx_FunctionCode.SelectedItem = "FC 4";
                    break;
                default:
                    break;
            }

            txt_WordCount.Text = binarySignal.WordCount.ToString();

            if(binarySignal.FunctionCode == 3 || binarySignal.FunctionCode == 4)
            {
                switch (binarySignal.comparisonType)
                {
                    case ModbusBinarySignal.ComparisonType.bit:
                        cbx_ComparisonType.Text = "Bit";
                        txt_ComparisonBitNumber_Value.Name = "Bit Sırası :";
                        txt_ComparisonBitNumber_Value.Text = binarySignal.ComparisonBitNumber.ToString();
                        break;
                    case ModbusBinarySignal.ComparisonType.value:
                        cbx_ComparisonType.Text = "Değer";
                        txt_ComparisonBitNumber_Value.Name = "Değer";
                        txt_ComparisonBitNumber_Value.Text = binarySignal.ComparisonValue.ToString();
                        break;
                    default:
                        break;
                }
            }

            cbx_IsReversed.Checked = binarySignal.IsReversed ? true : false;
        }

        private void InsertInfoToGeneralSettingsGroup()
        {
            txt_SignalID.Text = binarySignal.ID.ToString();
            cbx_StationName.SelectedItem = stations.Find((s) => s.ModbusTCPDevices.Exists((d) => d.ID == binarySignal.deviceID));
            cbx_DeviceName.Items.AddRange(((Station)cbx_StationName.SelectedItem).ModbusTCPDevices.ToArray());
            cbx_DeviceName.SelectedItem = stations.Find((s) => s.ModbusTCPDevices.Exists((d) => d.ID == binarySignal.deviceID)).ModbusTCPDevices.Find((d) => d.ID == binarySignal.deviceID);
            cbx_DeviceName.Enabled = true;
            //cbx_DeviceName.fi
            txt_SignalName.Text = binarySignal.Name;
            txt_SignalName.Enabled = true;
            txt_SignalIdentification.Text = binarySignal.Identification;

        }

        #endregion Constructors

        #region Events

        private void cbx_StationName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbx_DeviceName.Items.Clear();
            var devices = ((Station)(cbx_StationName.SelectedItem)).Devices;
            if (devices != null)
            {
                var list_modbusTCPDevices = devices.Where(((d) => d.communicationProtocol.Name == "ModbusTCP"));
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

        private void cbx_IsAlarm_CheckedChanged(object sender, EventArgs e)
        {
            cbx_IsEvent.Checked = cbx_IsAlarm.Checked ? true : false;
            cbx_IsEvent.Enabled = cbx_IsAlarm.Checked ? false : true;
            cbx_StatusText.Enabled = cbx_IsAlarm.Checked ? true : false;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (btn_OK.Text == "Ekle")
            {
                AddNewSignal();
            }
            else if (btn_OK.Text == "Güncelle")
            {
                UpdateSignal();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_SignalName_KeyUp(object sender, KeyEventArgs e)
        {
            txt_SignalIdentification.Text = ((Station)cbx_StationName.SelectedItem).Name + " " + ((Device)cbx_DeviceName.SelectedItem).Name + " " + txt_SignalName.Text;
        }

        private void cbx_DeviceName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txt_SignalName.Enabled = true;
        }

        private void cbx_IsEvent_CheckedChanged(object sender, EventArgs e)
        {
            cbx_StatusText.Enabled = cbx_IsEvent.Checked ? true : false;
        }

        private void cbx_ComparisonType_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        #endregion Events

        #region Private Methods

        private void InitializeDatabase()
        {
            try
            {
                DBHelper_AddNewOrUpdateModbusBinarySignalForm = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Database bağlantısı oluşturulamadı => {1}", this.GetType().Name, ex.Message);
                MessageBox.Show("Veritabanına bağlanılamadı", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InitializeControlProperties()
        {
            txt_SignalID.Enabled = false;
            txt_SignalID.Text = ID.ToString();

            stations = GetStations();
            cbx_StationName.Items.AddRange(stations.ToArray());
            cbx_DeviceName.Enabled = false;

            statusTexts = GetStatusNames();

            
            txt_SignalID.Text = ID.ToString();

            cbx_FunctionCode.Items.AddRange(new string[] { "FC 1", "FC 2", "FC 3", "FC 4" });
            cbx_ComparisonType.Items.AddRange(new string[] { "Bit", "Değer" });

            statusTexts = GetStatusNames();
            cbx_StatusText.Items.AddRange(statusTexts.ToArray());

        }

        private List<StatusText> GetStatusNames()
        {
            List<StatusText> statusTexts = new List<StatusText>();
            try
            {
                return DBHelper_AddNewOrUpdateModbusBinarySignalForm.GetAllStatusTexts();
            }

            catch (Exception ex)
            {
                return statusTexts;
                throw;
            }
        }

        private List<Station> GetStations()
        {
            List<Station> stations = new List<Station>();
            try
            {
                stations = DBHelper_AddNewOrUpdateModbusBinarySignalForm.GetAllStationsInfoWithDeviceInfo();
                return stations;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Station bilgileri veritabanından okunamadı =>{1}", this.GetType().Name, ex.Message);
                return stations;
            }
        }

        private bool AddNewBinarySignalToDatabase()
        {
            return DBHelper_AddNewOrUpdateModbusBinarySignalForm.AddNewModbusBinarySignal(binarySignal);
        }

        private void GetAlarmEventInfo()
        {
            binarySignal.IsAlarm = cbx_IsAlarm.Checked;
            binarySignal.IsEvent = cbx_IsEvent.Checked;

            if (cbx_StatusText.SelectedItem == null)
            {
                binarySignal.StatusID = 1;
            }
            else
            {
                binarySignal.StatusID = ((StatusText)(cbx_StatusText.SelectedItem)).StatusID;
            }
        }

        private void GetCommunicationInfo()
        {
            binarySignal.Address = ushort.Parse(txt_ModbusAddress.Text);
            binarySignal.ComparisonBitNumber = byte.Parse(txt_ComparisonBitNumber_Value.Text);
            binarySignal.WordCount = byte.Parse(txt_WordCount.Text);
            binarySignal.IsReversed = cbx_IsReversed.Checked;
            switch (cbx_FunctionCode.SelectedItem.ToString())
            {
                case "FC 1":
                    binarySignal.FunctionCode = 1;
                    break;

                case "FC 2":
                    binarySignal.FunctionCode = 2;
                    break;

                case "FC 3":
                    binarySignal.FunctionCode = 3;
                    break;

                case "FC 4":
                    binarySignal.FunctionCode = 4;
                    break;

                default:
                    break;
            }
            switch(cbx_ComparisonType.SelectedText)
            {
                case "Bit":
                    binarySignal.comparisonType = ModbusBinarySignal.ComparisonType.bit;
                    break;
                case "Değer":
                    binarySignal.comparisonType = ModbusBinarySignal.ComparisonType.value;
                    break;
                default:
                    break;
            }

            if(binarySignal.comparisonType == ModbusBinarySignal.ComparisonType.value)
            {
                binarySignal.ComparisonValue = int.Parse(txt_ComparisonBitNumber_Value.ToString());
                binarySignal.ComparisonBitNumber = 1;
            }
            else
            {
                binarySignal.ComparisonBitNumber = byte.Parse(txt_ComparisonBitNumber_Value.ToString());
                binarySignal.ComparisonValue = 1;
            }
        }

        private void GetGeneralInfo()
        {
            binarySignal.Name = txt_SignalName.Text;
            binarySignal.Identification = txt_SignalIdentification.Text;
            binarySignal.deviceID = ((Device)cbx_DeviceName.SelectedItem).ID;
        }

        private void TrimAllInputFields()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Text.Trim();
                }
            }
        }

        private void UpdateSignal()
        {
            if (VerifyInputsAtFormControls())
            {
                try
                {
                    GetInfoFromFormInputs();

                    if (UpdateBinarySignalAtDatabase())
                    {
                        MessageBox.Show("Sinyal başarılı bir şekilde güncellendi", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sinyale ait bilgileri güncelleme işlemi yapılırken hata oluştu.\nAyrıntılı bilgi için log dosyasını kontrol ediniz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {
                    Log.Instance.Error("{0}: Binary sinyal güncellenirken hata oluştu=> {1}", this.GetType().Name, ex.Message);
                    MessageBox.Show("Sinyal güncellenemedi.\nAyrıntılı bilgi için log dosyasını kontrol ediniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void GetInfoFromFormInputs()
        {
            GetGeneralInfo();

            GetCommunicationInfo();

            GetAlarmEventInfo();
        }

        private bool UpdateBinarySignalAtDatabase()
        {
            return DBHelper_AddNewOrUpdateModbusBinarySignalForm.UpdateModbusBinarySignal(binarySignal);
        }

        private void AddNewSignal()
        {
            if (VerifyInputsAtFormControls())
            {
                try
                {
                    GetInfoFromFormInputs();

                    if (AddNewBinarySignalToDatabase())
                    {
                        MessageBox.Show("Sinyal başarılı bir şekilde eklendi", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sinyal veritabanında oluşturulamadı.\nAyrıntılı bilgi için log dosyasını kontrol ediniz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Log.Instance.Error("{0}: Binary sinyal eklenirken hata oluştu=> {1}", this.GetType().Name, ex.Message);
                    MessageBox.Show("Sinyal Eklenemedi.\nAyrıntılı bilgi için log dosyasını kontrol ediniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool VerifyInputsAtFormControls()
        {
            TrimAllInputFields();

            return VerifyGeneralSettings() & VerifyCommunicationSettings() & VerifyAlarmEventSettings();
        }

        private bool VerifyAlarmEventSettings()
        {
            if ((cbx_IsAlarm.Checked || cbx_IsAlarm.Checked == false & cbx_IsEvent.Checked) & cbx_StatusText.SelectedItem == null)
            {
                MessageBox.Show("Durum yazısı bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbx_StatusText.Focus();
                return false;
            }
            return true;
        }

        private bool VerifyCommunicationSettings()
        {
            ushort modbusAddress;
            byte wordCount;
            byte bitNumber;
            int value;

            if (!(ushort.TryParse((txt_ModbusAddress.Text), out modbusAddress)))
            {
                MessageBox.Show("Modbus Adres bilgisi için geçerli bir sayı giriniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ModbusAddress.Focus();
                return false;
            }
            else if (!(byte.TryParse((txt_WordCount.Text), out wordCount)))
            {
                MessageBox.Show("Register Sayısı bilgisi için geçerli bir sayı giriniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ModbusAddress.Focus();
                return false;
            }
            else if (cbx_ComparisonType.SelectedText == "bit" & !(byte.TryParse((txt_ComparisonBitNumber_Value.Text), out bitNumber)))
            {
                MessageBox.Show("Bit Sırası bilgisi için geçerli bir sayı giriniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ModbusAddress.Focus();
                return false;
            }
            else if (cbx_ComparisonType.SelectedText == "value" & !(int.TryParse((txt_ComparisonBitNumber_Value.Text), out value)))
            {
                MessageBox.Show("Değer bilgisi için geçerli bir sayı giriniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ModbusAddress.Focus();
                return false;
            }

            else if (cbx_FunctionCode.SelectedItem == null)
            {
                MessageBox.Show("Fonksiyon Kodu bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_FunctionCode.Focus();
                return false;
            }
            return true;
        }

        private bool VerifyGeneralSettings()
        {
            if (txt_SignalName.Text == string.Empty)
            {
                MessageBox.Show("Sinyal Adı bilgisi boş bırakılamaz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SignalName.Focus();
                return false;
            }
            else if (txt_SignalIdentification.Text == string.Empty)
            {
                MessageBox.Show("Sinyal Uzun Adı bilgisi boş bırakılamaz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SignalIdentification.Focus();
                return false;
            }
            else if (cbx_StationName.SelectedItem == null)
            {
                MessageBox.Show("Station Adı bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_StationName.Focus();
                return false;
            }
            else if (cbx_DeviceName.SelectedItem == null)
            {
                MessageBox.Show("Cihaz Adı bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_DeviceName.Focus();
                return false;
            }
            return true;
        }





        #endregion Private Methods

        private void cbx_ComparisonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbx_ComparisonType.SelectedItem.ToString() == "Bit")
            {
                lbl_ComparisonBitNumber_Value.Text = "Bit Sırası :";
            }
            else
            {
                lbl_ComparisonBitNumber_Value.Text = "Değer :";
            }
        }

        private void cbx_FunctionCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_FunctionCode.Text == "FC 3" || cbx_FunctionCode.Text == "FC 4")
            {
                cbx_ComparisonType.Enabled = true;
                txt_ComparisonBitNumber_Value.Enabled = true;
                txt_WordCount.Enabled = true;
            }
            else
            {
                cbx_ComparisonType.Enabled = false;
                txt_ComparisonBitNumber_Value.Enabled = false;
                txt_WordCount.Enabled = false;
            }
        }
    }
}