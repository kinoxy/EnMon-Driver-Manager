using System.Collections.Generic;
using System.Data;
using EnMon_Driver_Manager.Models.Signals.SNMP;
using System.ComponentModel;
using EnMon_Driver_Manager.Extensions;

namespace EnMon_Driver_Manager.Models.Devices
{
    public class SNMPDevice : Device, ITCPDevice
    {
        [Browsable(false)]
        public List<SNMPAnalogSignal> AnalogSignals { get; set; }

        [Browsable(false)]
        public List<SNMPBinarySignal> BinarySignals { get; set; }

        [Browsable(false)]
        public List<SNMPCommandSignal> CommandSignals { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("ModbusTCP Ip adresi bilgisi")]
        [CustomSortedCategory("Haberleşme Ayarları", 2)]
        [CustomSortedDisplayName("Ip Adres", 1)]
        public string IpAddress { get; set; }

        public override void GetPropertyValuesFromDataRow(DataRow dr)
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
                        if (Protocol == null)
                            Protocol = new CommunicationProtocol() { ID = protocolID, Name = "SNMP"};
                        else
                            Protocol.ID = protocolID;
                        break;
                    case "protocol_name":
                        string protocolName = dr.Field<string>("protocol_name");
                        ;
                        if (Protocol == null)
                            Protocol = new CommunicationProtocol() { Name = protocolName };
                        else
                            Protocol.Name = protocolName;
                        break;
                    case "is_active":
                        isActive = dr.Field<bool>("is_active");
                        break;
                    case "connected":
                        Connected = dr.Field<bool>("connected");
                        break;
                    case "ip_address":
                        IpAddress = dr.Field<string>("ip_address");
                        break;
                    default:
                        Log.Instance.Error("{0}: ModbusTCP Deevice tanımlanmamış property adı => {1}", this.GetType().Name, dr.Table.Columns[i].ToString());
                        break;
                }
            }
        }
    }
}
