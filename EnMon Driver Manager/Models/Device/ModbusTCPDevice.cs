using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models.Device
{
    public class ModbusTCPDevice : AbstractTCPDevice
    {
        public List<ModbusAnalogSignal> AnalogSignals { get; set; }

        public List<ModbusBinarySignal> BinarySignals { get; set; }

        public List<ModbusCommandSignal> CommandSignals { get; set; }

        public byte SlaveID { get; set; }

        public ModbusTCPDevice() { }

        public ModbusTCPDevice(DataRow dr)
        {
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                switch (dr.Table.Columns[i].ToString())
                {
                    case "device_id":
                        ID = dr.Field<ushort>("device_id");
                        break;

                    case "name":
                        Name = dr.Field<string>("name");
                        break;

                    case "station_id":
                        StationID = dr.Field<ushort>("station_id");
                        break;

                    case "protocol_id":
                        byte protocolID = dr.Field<byte>("protocol_id");
                        string protocolName = dr.Field<string>("protocol_name");
                        communicationProtocol = new CommunicationProtocol() { ID = protocolID, Name = protocolName };
                        break;
                    case "is_active":
                        isActive = dr.Field<bool>("is_active");
                        break;
                    case "connected":
                        Connected = dr.Field<bool>("connected");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
