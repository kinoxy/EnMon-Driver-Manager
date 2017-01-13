using System;
using System.Data;

namespace EnMon_Driver_Manager.Models.Devices
{
    /// <summary>
    ///
    /// </summary>
    public class Device
    {
        #region Public Properties

        public ushort ID { get; set; }

        public String Name { get; set; }

        public ushort StationID { get; set; }

        public CommunicationProtocol communicationProtocol { get; set; }

        public bool isActive { get; set; }

        public bool Connected { get; set; }

        public int disconnectionCounter { get; set; }

        #endregion Public Properties

        #region Constructor

        public Device()
        {
        }

        //public Device(DataRow dr)
        //{
        //    for (int i = 0; i < dr.Table.Columns.Count; i++)
        //    {
        //        switch (dr.Table.Columns[i].ToString())
        //        {
        //            case "device_id":
        //                ID = dr.Field<ushort>("device_id");
        //                break;

        //            case "name":
        //                Name = dr.Field<string>("name");
        //                break;

        //            case "station_id":
        //                StationID = dr.Field<ushort>("station_id");
        //                break;

        //            case "protocol_id":
        //                byte protocolID = dr.Field<byte>("protocol_id");
        //                string protocolName = dr.Field<string>("protocol_name");
        //                communicationProtocol = new CommunicationProtocol() { ID = protocolID, Name = protocolName };
        //                break;
        //            case "is_active":
        //                isActive = dr.Field<bool>("is_active");
        //                break;
        //            case "connected":
        //                Connected = dr.Field<bool>("connected");
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}

        #endregion Constructor

        public override string ToString()
        {
            return Name;
        }

        public virtual void GetPropertyValuesFromDataRow(DataRow dr)
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
                        if (communicationProtocol == null)
                            communicationProtocol = new CommunicationProtocol() { ID = protocolID };
                        else
                            communicationProtocol.ID = protocolID;
                        break;
                    case "protocol_name":
                        string protocolName = dr.Field<string>("protocol_name");
                        ;
                        if (communicationProtocol == null)
                            communicationProtocol = new CommunicationProtocol() {Name = protocolName};
                        else
                            communicationProtocol.Name = protocolName;
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