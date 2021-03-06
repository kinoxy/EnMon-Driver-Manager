﻿using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EnMon_Driver_Manager.Models.DataTypes;
using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Models.Signals.Modbus;
using EnMon_Driver_Manager.Models.StatusTexts;

namespace EnMon_Driver_Manager
{
    public partial class frm_AddNewOrUpdateModbusCommandSignal : Form

    {
        #region Private Properties

        private AbstractDBHelper DBHelper_AddNewOrUpdateCommandSignalForm;

        private ModbusCommandSignal commandSignal;

        #endregion Private Properties

        #region Constructors

        public frm_AddNewOrUpdateModbusCommandSignal()
        {
            InitializeComponent();

            InitializeDatabase();

            InitializeControlProperties();

            commandSignal = new ModbusCommandSignal();
        }

        #endregion Constructors

        #region Events

        private void cbx_StationName_SelectionChangeCommitted(object sender, EventArgs e)
        {
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

        private void btn_OK_Click(object sender, EventArgs e)
        {
            TrimAllInputFields();

            if (CheckCommunicationSettings() & CheckGeneralSettings())
                try
                {
                    if (AddNewCommandSignalToDatabase())
                    {
                        MessageBox.Show("Sinyal başarılı bir şekilde eklendi", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sinyal veritabanında oluşturulamadı.\nAyrıntılı bilgi için log dosyasını kontrol ediniz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Log.Instance.Error("{0}: command sinyal eklenirken hata oluştu=> {1}", this.GetType().Name, ex.Message);
                    MessageBox.Show("Sinyal Eklenemedi.\nAyrıntılı bilgi için log dosyasını kontrol ediniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private bool CheckGeneralSettings()
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
            else
            {
                return true;
            }
        }

        private bool CheckCommunicationSettings()
        {
            ushort modbusAddress;
            byte wordCount;
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
            else if (cbx_FunctionCode.SelectedItem == null)
            {
                MessageBox.Show("Fonksiyon Kodu bilgisi boş bırakılamaz", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbx_FunctionCode.Focus();
                return false;
            }
            else
            {
                return true;
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

        private void cbx_StationName_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        #endregion Events

        #region Private Methods

        private void InitializeDatabase()
        {
            try
            {
                DBHelper_AddNewOrUpdateCommandSignalForm = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
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
            txt_SignalID.Text = "ID";
            cbx_StationName.Items.AddRange(GetStationsInfo().ToArray());
            cbx_DeviceName.Enabled = false;

            cbx_FunctionCode.Items.AddRange(new string[] { "FC 5", "FC 6" });

            txt_SignalID.Text = DBHelper_AddNewOrUpdateCommandSignalForm.GetNextCommandSignalID().ToString();
        }

        private List<DataType> GetDataTypes()
        {
            List<DataType> dataTypes = new List<DataType>();
            try
            {
                return DBHelper_AddNewOrUpdateCommandSignalForm.GetAllDataTypes();
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
                return DBHelper_AddNewOrUpdateCommandSignalForm.GetAllStatusTexts();
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        private List<Station> GetStationsInfo()
        {
            List<Station> stations = new List<Station>();
            try
            {
                stations = DBHelper_AddNewOrUpdateCommandSignalForm.GetAllStationsInfoWithDeviceInfo();
                return stations;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Station bilgileri veritabanından okunamadı =>{1}", this.GetType().Name, ex.Message);
                return stations;
            }
        }

        private bool AddNewCommandSignalToDatabase()
        {
            GetGeneralInfo();

            GetCommunicationInfo();

            return DBHelper_AddNewOrUpdateCommandSignalForm.AddNewModbusCommandSignal(commandSignal);
        }

        private void GetCommunicationInfo()
        {
            commandSignal.Address = ushort.Parse(txt_ModbusAddress.Text);
            commandSignal.WordCount = byte.Parse(txt_WordCount.Text);
            switch (cbx_FunctionCode.SelectedItem.ToString())
            {
                case "FC 5":
                    commandSignal.commandType = ModbusCommandSignal.CommandType.Binary;
                    break;

                case "FC 6":
                    commandSignal.commandType = ModbusCommandSignal.CommandType.Analog; ;
                    break;

                default:
                    break;
            }
        }

        private void GetGeneralInfo()
        {
            commandSignal.ID = uint.Parse(txt_SignalID.Text);
            commandSignal.deviceID = ((Device)cbx_DeviceName.SelectedItem).ID;
            commandSignal.Name = txt_SignalName.Text;
            commandSignal.Identification = txt_SignalIdentification.Text;
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
            txt_SignalIdentification.Text = ((Station)cbx_StationName.SelectedItem).Name + " " + ((Device)cbx_DeviceName.SelectedItem).Name + " " + txt_SignalName.Text;
        }

        #endregion Private Methods
    }
}