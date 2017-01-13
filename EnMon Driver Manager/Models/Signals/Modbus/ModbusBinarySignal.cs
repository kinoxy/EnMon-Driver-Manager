using System.Data;


namespace EnMon_Driver_Manager.Models.Signals.Modbus
{
    public class ModbusBinarySignal : BinarySignal, IModbusSignal
    {
        public float ComparisonValue { get; set; }

        public enum ComparisonType
        {
            bit,
            value
        }

        public ComparisonType comparisonType { get; set;}

        public byte ComparisonBitNumber { get; set; }

        public ushort Address { get; set; }

        public byte FunctionCode { get; set; }

        public byte WordCount { get; set; }

        public override void GetPropertyValuesFromDataRow(DataRow dr)
        {
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                switch (dr.Table.Columns[i].ColumnName)
                {
                    case "binary_signal_id":
                        ID = dr.Field<uint>("binary_signal_id");
                        break;
                    case "name":
                        Name = dr.Field<string>("name");
                        break;
                    case "identification":
                        Identification = dr.Field<string>("identification");
                        break;
                    case "device_id":
                        deviceID = dr.Field<ushort>("device_id");
                        break;
                    case "status_id":
                        StatusID = dr.Field<uint>("status_id");
                        break;
                    case "is_detail_page":
                        DisplayAtDeviceDetailPage = dr.Field<bool>("is_detail_page");
                        break;
                    case "is_summary":
                        DisplayAtStationDetailPage = dr.Field<bool>("is_summary");
                        break;;
                    case "is_alarm":
                        IsAlarm = dr.Field<bool>("is_alarm");
                        break;
                    case "is_event":
                        IsEvent = dr.Field<bool>("is_event");
                        break;
                    case "is_reversed":
                        IsReversed = dr.Field<bool>("is_reversed");
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
                    case "comparison_bit_number":
                        ComparisonBitNumber = dr.Field<byte>("comparison_bit_number");
                        break;
                    case "comparison_value":
                        ComparisonValue = dr.Field<int>("comparison_value");
                        break;
                    case "comparison_type":
                        switch (dr.Field<string>("comparison_type"))
                        {
                            case "bit":
                                comparisonType = ComparisonType.bit;
                                break;

                            case "value":
                                comparisonType = ComparisonType.value;
                                break;
                        }
                        break;
                }
            }
        }
    }
}