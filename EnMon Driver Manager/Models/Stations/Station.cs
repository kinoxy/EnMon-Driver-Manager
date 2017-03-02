using EnMon_Driver_Manager.Extensions;
using EnMon_Driver_Manager.Models.Devices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace EnMon_Driver_Manager
{
    public class Station

    {
        public Station()
        {
            Name = "Yeni İstasyon";
        }

        public Station(DataRow dr)
        {
            for(int i = 0; i < dr.Table.Columns.Count; i++)
            {
                switch (dr.Table.Columns[i].ToString())
                {
                    case "station_id":
                        ID = dr.Field<ushort>("station_id");
                        break;
                    case "name":
                        Name = dr.Field<string>("name");
                        break;
                    default:
                        break;
                }
            }
        }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Yazılım tarafından verilen bir değerdir. Değiştirilemez")]
        [CustomSortedCategory("Station ID", 1)]
        [DisplayName("ID")]
        public ushort ID { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("İstasyon İsmi")]
        [CustomSortedCategory("Genel Ayarlar", 2)]
        [CustomSortedDisplayName("İstasyon İsmi", 1)]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        [Browsable(false)]
        public List<Device> Devices { get; set; }

        [Browsable(false)]
        public List<ModbusTCPDevice> ModbusTCPDevices { get; set; }

        [Browsable(false)]
        public List<SNMPDevice> SNMPDevices {get; set; }

    }
}