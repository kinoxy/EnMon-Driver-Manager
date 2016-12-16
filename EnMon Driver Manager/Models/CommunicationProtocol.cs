using System.Data;

namespace EnMon_Driver_Manager.Models
{
    public class CommunicationProtocol
    {
        private DataRow dr;

        public CommunicationProtocol()
        {
        }

        public CommunicationProtocol(DataRow dr)
        {
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                switch (dr.Table.Columns[i].ToString())
                {
                    case "protocolID":
                        ID = dr.Table.Rows[0].Field<byte>("protocolID");
                        break;

                    case "name":
                        Name = dr.Table.Rows[0].Field<string>("name");
                        break;

                    default:
                        break;
                }
            }
        }

        public byte ID { get; set; }
        public string Name { get; set; }
    }
}