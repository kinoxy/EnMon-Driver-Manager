using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Extensions;
using EnMon_Driver_Manager.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EnMon_Driver_Manager
{

    public partial class frm_AddNewOrUpdateAnalogSignal : Form

    {
        #region Private Properties

        private AbstractDBHelper DBHelper_AddNewOrUpdateAnalogSignalForm;

        private ModbusAnalogSignal analogSignal;

        private uint ID;

        private List<Station> stations;
        private List<StatusText> statusTexts;
        private List<DataType> dataTypes;
       
        private List<ArchivePeriod> archivePeriods;


        #endregion Private Properties

        #region Constructors

        public frm_AddNewOrUpdateAnalogSignal()
        {
            
            InitializeComponent();

            InitializeDatabase();

            ID = DBHelper_AddNewOrUpdateAnalogSignalForm.GetNextAnalogSignalID();

            InitializeControlProperties();

            btn_Delete.Enabled = false;
            btn_Delete.Hide();

            analogSignal = new ModbusAnalogSignal();
        }

        public frm_AddNewOrUpdateAnalogSignal(ModbusAnalogSignal analogSignal) 
        {
            InitializeComponent();

            InitializeDatabase();

            InitializeControlProperties();

            this.Text = "Analog Sinyal Güncelle";
            this.btn_OK.Text = "Güncelle"; 
            this.analogSignal = analogSignal;

            UpdateControlsWithSignalInfo();

        }
    
        private void UpdateControlsWithSignalInfo()
        {
            InsertInfoToGeneralSettingsGroup();

            InsertInfoToCommmunicationSettingGroup();

            InsertInfoToArchivingGroup();

            InsertInfoToMaxAlarmSettingsGroup();

            InsertInfoToMinAlarmSettingsGroup();
        }

        private void InsertInfoToMaxAlarmSettingsGroup()
        {
            cbx_HasMaxAlarm.Checked = analogSignal.HasMaxAlarm ? true : false;
            txt_MaxAlarmValue.Enabled = analogSignal.HasMaxAlarm ? true : false;
            txt_MaxAlarmValue.Text = analogSignal.MaxAlarmValue.ToString();
            cbx_MaxAlarmStatus.SelectedItem = statusTexts.Find((s) => s.StatusID == analogSignal.MaxAlarmStatusID);
        }

        private void InsertInfoToMinAlarmSettingsGroup()
        {
            cbx_HasMinAlarm.Checked = analogSignal.HasMinAlarm ? true : false;
            txt_MinAlarmValue.Enabled = analogSignal.HasMinAlarm ? true : false;
            txt_MinAlarmValue.Text = analogSignal.MinAlarmValue.ToString();
            cbx_MinAlarmStatus.SelectedItem = statusTexts.Find((s) => s.StatusID == analogSignal.MinAlarmStatusID);
        }

        private void InsertInfoToArchivingGroup()
        {
            cbx_IsArchive.Checked = analogSignal.IsArchive ? true : false;
            cbx_Archive.Enabled = analogSignal.IsArchive ? true : false;
            cbx_Archive.SelectedItem = archivePeriods.Find((ap) => ap.ID == analogSignal.archivePeriod.ID);
        }

        private void InsertInfoToCommmunicationSettingGroup()
        {
            txt_ModbusAddress.Text = analogSignal.Address.ToString();
            switch(analogSignal.FunctionCode)
            {
                case 3:
                    cbx_FunctionCode.SelectedItem = "FC 3";
                    break;
                case 4:
                    cbx_FunctionCode.SelectedItem = "FC 4";
                    break;
                default:
                    break;
            }
            txt_WordCount.Text = analogSignal.WordCount.ToString();
            txt_ScaleValue.Text = analogSignal.ScaleValue.ToString();
            cbx_DataType.SelectedItem = dataTypes.Find((dt) => dt.ID == analogSignal.dataType.ID);
        }

        private void InsertInfoToGeneralSettingsGroup()
        {
            txt_SignalID.Text = analogSignal.ID.ToString();
            cbx_StationName.SelectedItem = stations.Find((s) => s.ModbusTCPDevices.Exists((d) => d.ID == analogSignal.DeviceID));
            cbx_DeviceName.Items.AddRange(((Station)cbx_StationName.SelectedItem).ModbusTCPDevices.ToArray());
            cbx_DeviceName.SelectedItem = stations.Find((s) => s.ModbusTCPDevices.Exists((d) => d.ID == analogSignal.DeviceID)).ModbusTCPDevices.Find((d) => d.ID == analogSignal.DeviceID);
            cbx_DeviceName.Enabled = true;
            //cbx_DeviceName.fi
            txt_SignalName.Text = analogSignal.Name;
            txt_SignalName.Enabled = true;
            txt_SignalIdentification.Text = analogSignal.Identification;
            txt_Unit.Text = analogSignal.Unit;
        }

        #endregion Constructors

        #region Events

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteSignal(analogSignal);

        }


        private void cbx_StationName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbx_DeviceName.Items.Clear();
            cbx_DeviceName.Items.AddRange(((Station)cbx_StationName.SelectedItem).ModbusTCPDevices.ToArray());
            cbx_DeviceName.Enabled = true;
            cbx_DeviceName.ResetText();
            cbx_DeviceName.SelectedIndex = -1;
            txt_SignalName.Enabled = false;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if(btn_OK.Text== "Ekle")
            {
                AddNewSignal();
            }
            else if(btn_OK.Text =="Güncelle")
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
            SetTextAtIdentificationTextBox();
        }
        private void cbx_DeviceName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txt_SignalName.Enabled = cbx_DeviceName.SelectedItem != null ? true : false;
            SetTextAtIdentificationTextBox();
        }

        private void cbx_HasMaxAlarm_CheckedChanged(object sender, EventArgs e)
        {
            txt_MaxAlarmValue.Enabled = cbx_HasMaxAlarm.Checked ? true : false;
            cbx_MaxAlarmStatus.Enabled = cbx_HasMaxAlarm.Checked ? true : false;
        }

        private void cbx_HasMinAlarm_CheckedChanged(object sender, EventArgs e)
        {
            txt_MinAlarmValue.Enabled = cbx_HasMinAlarm.Checked ? true : false;
            cbx_MinAlarmStatus.Enabled = cbx_HasMinAlarm.Checked ? true : false;
        }

        private void cbx_StationName_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbx_IsArchive_CheckedChanged(object sender, EventArgs e)
        {
            cbx_Archive.Enabled = cbx_IsArchive.Checked ? true : false;
        }

        private void frm_AddNewOrUpdateAnalogSignal_Load(object sender, EventArgs e)
        {
            
        }

        #endregion Events

        #region Private Methods
        private void DeleteSignal(ModbusAnalogSignal analogSignal)
        {
            DialogResult result = MessageBox.Show($"İşleme devam ederseniz {analogSignal.Identification} sinyali ve bu sinyale ait diğer tüm kayıtlar silinecektir.\nİşleme devam etmek istiyor musunuz? ", Constants.MessageBoxHeader, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                if (DBHelper_AddNewOrUpdateAnalogSignalForm.DeleteAnalogSignal(analogSignal.ID))
                {
                    MessageBox.Show($"{analogSignal.Identification} adlı sinyal ve bu sinyale ait tüm kayıtlar başarılı bir şekilde silinmiştir.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Log.Instance.Info($"{this.GetType().Name}: {analogSignal.Identification} adlı sinyal ve bu sinyale ait tüm kayıtlar silinmiştir.");
                }
                else
                {
                    MessageBox.Show($"{analogSignal.Identification} adlı silinirken bir hata oluştu. Bazı verileri kaybetmiş olabilirsiniz.\nAyrıntılı bilgi için log dosyasını kontrol ediniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void InitializeDatabase()
        {
            try
            {
                DBHelper_AddNewOrUpdateAnalogSignalForm = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Database bağlantısı oluşturulamadı => {1}", this.GetType().Name, ex.Message);
                MessageBox.Show("Veritabanına bağlanılamadı", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateSignal()
        {
            if (VerifyInputsAtFormControls())
            {
                try
                {
                    if (UpdateAnalogSignalAtDatabase())
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
                    Log.Instance.Error("{0}: Analog sinyal güncellenirken hata oluştu=> {1}", this.GetType().Name, ex.Message);
                    MessageBox.Show("Sinyal güncellenemedi.\nAyrıntılı bilgi için log dosyasını kontrol ediniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private bool UpdateAnalogSignalAtDatabase()
        {
            GetGeneralInfo();

            GetCommunicationInfo();

            GetAlarmInfo();

            GetArchiveInfo();

            return DBHelper_AddNewOrUpdateAnalogSignalForm.UpdateAnalogSignal(analogSignal);
        }

        private void AddNewSignal()
        {
            if (VerifyInputsAtFormControls())
            {
                try
                {
                    if (AddNewAnalogSignalToDatabase())
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
                    Log.Instance.Error("{0}: Analog sinyal eklenirken hata oluştu=> {1}", this.GetType().Name, ex.Message);
                    MessageBox.Show("Sinyal Eklenemedi.\nAyrıntılı bilgi için log dosyasını kontrol ediniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool VerifyInputsAtFormControls()
        {
            TrimAllInputFields();

            return VerifyGeneralSettings() & VerifyCommunicationSettings() & VerifyArchivingSettings() & VerifyAlarmSettings();    
           
        }

        private bool VerifyAlarmSettings()
        {
            float maxValue;
            float minValue;

            if (cbx_HasMaxAlarm.Checked && !float.TryParse(txt_MaxAlarmValue.Text, out maxValue))
            {
                MessageBox.Show("Maksimum Alarm Değeri için geçerli bir sayı giriniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaxAlarmValue.Focus();
                return false;
            }
            else if (cbx_HasMaxAlarm.Checked && !float.TryParse(txt_MinAlarmValue.Text, out minValue))
            {
                MessageBox.Show("Maksimum Alarm Değeri için geçerli bir sayı giriniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaxAlarmValue.Focus();
                return false;
            }
            else if (cbx_HasMinAlarm.Checked && cbx_HasMinAlarm.Checked && (txt_MaxAlarmValue == txt_MinAlarmValue))
            {
                MessageBox.Show("Maksimum Alarm ve Minimum Alarm değerleri aynı olamaz.\n Farklı değerler giriniz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaxAlarmValue.Focus();
                return false;
            }
            else if (cbx_HasMaxAlarm.Checked && cbx_MaxAlarmStatus.SelectedItem == null)
            {
                MessageBox.Show("Maksimum Değer Alarm bilgisi için durum yazısı seçiniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_MaxAlarmStatus.Focus();
                return false;
            }
            else if (cbx_HasMinAlarm.Checked && cbx_MinAlarmStatus.SelectedItem == null)
            {
                MessageBox.Show("Minimum Değer Alarm bilgisi için durum yazısı seçiniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_MinAlarmStatus.Focus();
                return false;
            }
            return true;
        }

        private bool VerifyArchivingSettings()
        {
            if(cbx_IsArchive.Enabled == true & cbx_Archive == null)
            {
                MessageBox.Show("Arşiv periyodu bilgisi için periyot seçiniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_Archive.Focus();
                return false;
            }
            return true;
        }

        private bool VerifyCommunicationSettings()
        {
            ushort modbusAddress;
            byte wordCount;
            float scaleValue;

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
            else if (!(float.TryParse((txt_ScaleValue.Text), out scaleValue)))
            {
                MessageBox.Show("Skala Değeri bilgisi için geçerli bir sayı giriniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ScaleValue.Focus();
                return false;
            }

            else if (cbx_FunctionCode.SelectedItem == null)
            {
                MessageBox.Show("Fonksiyon Kodu bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_FunctionCode.Focus();
                return false;
            }
            else if (cbx_DataType.SelectedItem == null)
            {
                MessageBox.Show("Data Tipi bilgisi boş bırakılamaz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_DataType.Focus();
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

        private void InitializeControlProperties()
        {

            txt_SignalID.Text = ID.ToString();

            stations = GetStations();
            cbx_StationName.Items.AddRange(stations.ToArray());

            cbx_FunctionCode.Items.AddRange(new string[] { "FC 3", "FC 4" });

            statusTexts = GetStatusNames();
            cbx_MaxAlarmStatus.Items.AddRange(statusTexts.ToArray());
            cbx_MinAlarmStatus.Items.AddRange(statusTexts.ToArray());

            dataTypes = GetDataTypes();
            cbx_DataType.Items.AddRange(dataTypes.ToArray());

            archivePeriods = GetArchivePeriodTypes();
            cbx_Archive.Items.AddRange(archivePeriods.ToArray());

        }

        private List<ArchivePeriod> GetArchivePeriodTypes()
        {
            List<ArchivePeriod> archiveperiods = new List<ArchivePeriod>();
            try
            {
                return DBHelper_AddNewOrUpdateAnalogSignalForm.GetAllArchivePeriods();
            }

            catch (Exception ex)
            {
                return archiveperiods;
                throw;
            }
        }

        private List<DataType> GetDataTypes()
        {
            List<DataType> dataTypes= new List<DataType>();
            try
            {
                return DBHelper_AddNewOrUpdateAnalogSignalForm.GetAllDataTypes();
            }

            catch (Exception ex)
            {
                return dataTypes;
                throw;
            }
        }

        private List<StatusText> GetStatusNames()
        {
            List<StatusText> statusTexts = new List<StatusText>();
            try
            {
                return DBHelper_AddNewOrUpdateAnalogSignalForm.GetAllStatusTexts();
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
                stations = DBHelper_AddNewOrUpdateAnalogSignalForm.GetAllStationsInfo();
                return stations;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Station bilgileri veritabanından okunamadı =>{1}", this.GetType().Name, ex.Message);
                return stations;
            }
        }

        private bool AddNewAnalogSignalToDatabase()
        {

            GetGeneralInfo();

            GetCommunicationInfo();
            
            GetAlarmInfo();

            GetArchiveInfo();
            

            return DBHelper_AddNewOrUpdateAnalogSignalForm.addNewAnalogSignal(analogSignal);
        }

        private void GetArchiveInfo()
        {
            analogSignal.IsArchive = cbx_IsArchive.Checked;
            if(cbx_Archive.SelectedItem != null)
            {
                analogSignal.archivePeriod.ID = ((ArchivePeriod)cbx_Archive.SelectedItem).ID;
            }
        }

        private void GetCommunicationInfo()
        {
            analogSignal.Address = ushort.Parse(txt_ModbusAddress.Text);
            analogSignal.WordCount = byte.Parse(txt_WordCount.Text);
            switch (cbx_FunctionCode.SelectedItem.ToString())
            {
                case "FC 3":
                    analogSignal.FunctionCode = 3;
                    break;

                case "FC 4":
                    analogSignal.FunctionCode = 4;
                    break;

                default:
                    break;
            }
            analogSignal.ScaleValue = float.Parse(txt_ScaleValue.Text);
            analogSignal.dataType.ID = ((DataType)(cbx_DataType.SelectedItem)).ID;
        }

        private void GetGeneralInfo()
        {
            analogSignal.ID = uint.Parse(txt_SignalID.Text);
            analogSignal.DeviceID = ((AbstractDevice)cbx_DeviceName.SelectedItem).ID;
            analogSignal.Name = txt_SignalName.Text;
            analogSignal.Identification = txt_SignalIdentification.Text;
            analogSignal.Unit = txt_Unit.Text;
        }

        private void GetAlarmInfo()
        {
            analogSignal.HasMaxAlarm = cbx_HasMaxAlarm.Checked;
            analogSignal.HasMinAlarm = cbx_HasMinAlarm.Checked;
            analogSignal.MaxAlarmValue = float.Parse(txt_MaxAlarmValue.Text.Replace(".",","));
            analogSignal.MinAlarmValue = float.Parse(txt_MinAlarmValue.Text.Replace(".",","));

            if (cbx_MaxAlarmStatus.SelectedItem == null)
            {
                analogSignal.MaxAlarmStatusID = 1;
            }
            else
            {
                analogSignal.MaxAlarmStatusID = ((StatusText)(cbx_MinAlarmStatus.SelectedItem)).StatusID;
            }

            if (cbx_MinAlarmStatus.SelectedItem == null)
            {
                analogSignal.MinAlarmStatusID = 1;
            }
            else
            {
                analogSignal.MinAlarmStatusID = ((StatusText)(cbx_MinAlarmStatus.SelectedItem)).StatusID;
            }
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

        private void SetTextAtIdentificationTextBox()
        {
            txt_SignalIdentification.Text = ((Station)cbx_StationName.SelectedItem).Name + " " + ((AbstractDevice)cbx_DeviceName.SelectedItem).Name + " " + txt_SignalName.Text;
        }


        #endregion Private Methods    
    }
}