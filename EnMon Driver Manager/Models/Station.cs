using EnMon_Driver_Manager.Models.Device;
using System;
using System.Collections.Generic;
using System.Data;

namespace EnMon_Driver_Manager
{
    public class Station

    {
        public Station() { }

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

        public ushort ID { get; set; }

        public String Name { get; set; }

        public List<AbstractDevice> Devices { get; set; }

        public List<ModbusTCPDevice> ModbusTCPDevices { get; set; }

        public List<SNMPDevice> SNMPDevices {get; set; }

    }
}