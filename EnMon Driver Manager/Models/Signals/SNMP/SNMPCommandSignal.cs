
using System.Data;

namespace EnMon_Driver_Manager.Models.Signals.SNMP
{
    public class SNMPCommandSignal : CommandSignal, ISNMPSignal
    {
        public string Address { get; set; }

        public enum CommandType

        {
            /// <summary>
            /// The binary
            /// </summary>
            Binary,

            /// <summary>
            /// The analog
            /// </summary>
            Analog
        }

        public CommandType commandType { get; set; }

        public override void GetPropertyValuesFromDataRow(DataRow dr)
        {
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                switch (dr.Table.Columns[i].ColumnName)
                {
                    case "command_signal_id":
                        ID = dr.Field<uint>("command_signal_id");
                        break;
                    case "identification":
                        Identification = dr.Field<string>("identification");
                        break;
                    case "address":
                        Address = dr.Field<string>("address");
                        break;
                    case "is_event":
                        IsEvent = dr.Field<bool>("is_event");
                        break;
                    case "device_id":
                        deviceID = dr.Field<ushort>("device_id");
                        break;
                    case "command_type":
                        switch (dr.Field<string>("command_type"))
                        {
                            case "binary":
                                commandType = CommandType.Binary;
                                break;

                            case "analog":
                                commandType = CommandType.Analog;
                                break;
                        }
                        break;
                }
            }


        }
    }
}
