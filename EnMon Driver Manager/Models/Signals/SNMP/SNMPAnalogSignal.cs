using System.Data;

namespace EnMon_Driver_Manager.Models.Signals.SNMP
{
    public class SNMPAnalogSignal : AnalogSignal, ISNMPSignal
    {
        public string Address { get; set; }

        public override void GetPropertyValuesFromDataRow(DataRow dr)
        {
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                switch (dr.Table.Columns[i].ColumnName)
                {
                    case "analog_signal_id":
                        ID = dr.Field<uint>("analog_signal_id");
                        break;
                    case "device_id":
                        deviceID = dr.Field<ushort>("device_id");
                        break;
                    case "name":
                        Name = dr.Field<string>("name");
                        break;
                    case "identification":
                        Identification = dr.Field<string>("identification");
                        break;
                    case "data_type_id":
                        dataType.ID = dr.Field<byte>("data_type_id");
                        break;
                    case "scale_value":
                        ScaleValue = dr.Field<float>("scale_value");
                        break;
                    case "max_value":
                        MaxAlarmValue = dr.Field<float>("max_value");
                        break;
                    case "min_value":
                        MinAlarmValue = dr.Field<float>("min_value");
                        break;
                    case "has_max_alarm":
                        HasMaxAlarm = dr.Field<bool>("has_max_alarm");
                        break;
                    case "has_min_alarm":
                        HasMinAlarm = dr.Field<bool>("has_min_alarm");
                        break;
                    case "is_event":
                        IsEvent = dr.Field<bool>("is_event");
                        break;
                    case "current_value":
                        CurrentValue = dr.Field<uint>("current_value");
                        break;
                    case "is_summary":
                        DisplayAtStationDetailPage = dr.Field<bool>("is_summary");
                        break;
                    case "is_gauge":
                        DisplayAtDeviceDetailPage = dr.Field<bool>("is_gauge");
                        break;
                    case "archive_period_id":
                        archivePeriod.ID = dr.Field<uint>("archive_period_id");
                        break;
                    case "address":
                        Address = dr.Field<string>("address");
                        break;
                }
            }
        }

    }
}
