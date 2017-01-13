using System.Data;

namespace EnMon_Driver_Manager.Models.Signals.Modbus
{
    public class ModbusCommandSignal : CommandSignal, IModbusSignal

    {
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

        public byte BitNumber { get; set; }

        public ushort Address { get; set; }

        public byte FunctionCode { get; set; }

        public byte WordCount { get; set; }

        public override void GetPropertyValuesFromDataRow(DataRow dr)
        {
            for(int i = 0; i < dr.Table.Columns.Count; i++)
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
                        Address = dr.Field<ushort>("address");
                        break;
                    case "function_code":
                        FunctionCode = dr.Field<byte>("function_code");
                        break;
                    case "word_count":
                        WordCount = dr.Field<byte>("word_count");
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
                    case "bit_number":
                        BitNumber = dr.Field<byte>("bit_number");
                        break;
                }
            }
            
            
        }
    }
}