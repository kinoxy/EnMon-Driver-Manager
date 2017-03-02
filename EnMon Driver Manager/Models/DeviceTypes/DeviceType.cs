using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models.DeviceTypes
{
    public class DeviceType
    {
        public string Name { get; set; }

        public byte ID { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public void GetPropertyValuesFromDataRow(DataRow dr)
        {
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                switch (dr.Table.Columns[i].ToString())
                {
                    case "type_id":
                        ID = dr.Field<byte>("type_id");
                        break;

                    case "type_name":
                        Name = dr.Field<string>("type_name");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
