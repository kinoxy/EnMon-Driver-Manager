using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models.Device;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Drivers.Modbus
{
    class Modbus_MySqlDBHelper : MySqlDBHelper
    {
        public List<ModbusTCPDevice> GetStationDevices(string _stationName)
        {
            Log.Instance.Trace("{0}: {1} methodu cagrıldı", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            List<ModbusTCPDevice> _deviceList = new List<ModbusTCPDevice>();
            ModbusTCPDevice _device;

            try
            {
                string query = String.Format("CALL getStationDevicesInfo('{0}')", _stationName);
                DataTable dt = new DataTable();
                dt = ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        _device = new ModbusTCPDevice();
                        _device.ID = dr.Field<ushort>("device_id");
                        _device.Name = dr.Field<string>("name");
                        _device.StationID = dr.Field<ushort>("station_id");
                        int protocolID = dr.Field<byte>("protocol_id");
                        switch (protocolID)
                        {
                            case 0:
                                _device.ProtocolID = AbstractDevice.Protocol.ModbusRTU;
                                break;

                            case 1:
                                _device.ProtocolID = AbstractDevice.Protocol.ModbusTCP;
                                break;

                            case 2:
                                _device.ProtocolID = AbstractDevice.Protocol.ModbusASCII;
                                break;

                            default:
                                break;
                        }

                        if(_device.ProtocolID == AbstractDevice.Protocol.ModbusTCP)
                        {
                            _device.IpAddress = dr.Field<string>("ip_address");
                            _device.SlaveID = dr.Field<byte>("slave_id");
                        }

                        _device.isActive = dr.Field<bool>("is_active");
                        _device.Connected = dr.Field<bool>("connected");

                        _deviceList.Add(_device);
                    }
                }
                else
                {
                    Log.Instance.Warn("{0} adlı station için device bulunamadı", _stationName);
                }

            }
            catch (Exception ex)
            {
                Log.Instance.Trace("{0}.{1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                Log.Instance.Fatal("Database hatası: {0}", ex.Message);
                //throw;
            }

            return _deviceList;
        }
    }
}
