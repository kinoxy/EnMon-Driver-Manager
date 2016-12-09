using EnMon_Driver_Manager.Models;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager
{
    public delegate void AddDeviceEventHandler(object source, AddDeviceEventArgs e);

    public partial class frm_AddDevice : MaterialForm
    {
        public string MessageBoxHeader {get;set;}
        private List<int> usedModbusSlaveAddresses;

        public frm_AddDevice()
        {
            InitializeComponent();
            MessageBoxHeader = "EnMon Sürücü Yöneticisi";

        }
       public frm_AddDevice(string _stationName, string _deviceName, List<CommunicationProtocol> _protocols, List<int> _usedModbusSlaveAddresses) : this()
        {
            cbx_StationName.Items.Add(_stationName);
            cbx_StationName.SelectedItem = _stationName;
            cbx_StationName.Enabled = false;
            txt_DeviceName.Text = _deviceName;
            txt_DeviceName.Enabled = false;
            if (_protocols != null)
            {
                foreach (CommunicationProtocol p in _protocols)
                {
                    cbx_Protocol.Items.Add(p.Name);
                }
                cbx_Protocol.SelectedIndex = 0;
            }

            usedModbusSlaveAddresses = new List<int>();
            if(_usedModbusSlaveAddresses.Count>0)
            {
                usedModbusSlaveAddresses = _usedModbusSlaveAddresses;
            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        public void btn_AddDevice_Click(object sender, EventArgs e)
        {
            // Girilen modbus slave adresi ve ip adresinde bir sorun yoksa,
            if(ValidateSlaveAddress(txt_SlaveID.Text) & ValidateIpAddress(txt_IpAddress.Text))
            {
                this.DialogResult = DialogResult.OK;
                OnClickedAddDeviceButton();
            }
            
        }

        private bool ValidateIpAddress(string _ipAddress)
        {
            if (String.IsNullOrWhiteSpace(_ipAddress))
            {
                MessageBox.Show("Geçerli bir ip adresi giriniz.", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            string[] splitValues = _ipAddress.Split('.');
            if (splitValues.Length != 4)
            {
                MessageBox.Show("Geçerli bir ip adresi giriniz.", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            byte tempForParsing;

            if(splitValues.All(r => byte.TryParse(r, out tempForParsing)))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Geçerli bir ip adresi giriniz.", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private bool ValidateSlaveAddress(string _str_slaveAddress)
        {
            int _int_slaveAddress;
            if(int.TryParse(_str_slaveAddress, out _int_slaveAddress))
            {
                if(_int_slaveAddress>0 & _int_slaveAddress<256)
                {
                    if(usedModbusSlaveAddresses.Count>0)
                    {
                        if(!usedModbusSlaveAddresses.Exists((e)=>e==_int_slaveAddress))
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Girilen adres aynı istasyonda başka bir cihaz için kullanılmaktadır. Başka bir adres deneyiniz.", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return false;
                        }
                    }
                    {
                        return true;
                    }
                }
                {
                    MessageBox.Show("Modbus Slave Adresi 1-255 sayıları arasında bir sayı olmalıdır. Girdiğiniz adresi kontrol ediniz.", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Modbus Slave Adresi 1-255 sayıları arasında bir sayı olmalıdır. Girdiğiniz adresi kontrol ediniz.", MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;

            }

        }

        public event AddDeviceEventHandler ClickedAddDeviceButton;
        private void OnClickedAddDeviceButton()
        {
            AddDeviceEventArgs args = new AddDeviceEventArgs();
            args.StationName = cbx_StationName.SelectedItem.ToString();
            args.DeviceName = txt_DeviceName.Text;
            args.IpAddress = txt_IpAddress.Text;
            args.SlaveID = txt_SlaveID.Text;
            args.ProtocolName = cbx_Protocol.SelectedItem.ToString();
            
            if (ClickedAddDeviceButton != null)
            {
                ClickedAddDeviceButton(this, args);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }



    public class AddDeviceEventArgs : EventArgs
    {
       public string StationName { get; set; }

        public string DeviceName { get; set; }

        public string IpAddress { get; set; }

        public string SlaveID { get; set; }

        public string ProtocolName { get; set; }
    }
}
