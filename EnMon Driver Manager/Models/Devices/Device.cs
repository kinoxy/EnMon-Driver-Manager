using EnMon_Driver_Manager.Extensions;
using EnMon_Driver_Manager.Models.Converters;
using EnMon_Driver_Manager.Models.DataTypes;
using EnMon_Driver_Manager.Models.DeviceTypes;
using EnMon_Driver_Manager.Models.Signals;
using EnMon_Driver_Manager.Models.Stations;
using System;
using System.ComponentModel;
using System.Data;

namespace EnMon_Driver_Manager.Models.Devices
{
    /// <summary>
    ///
    /// </summary>
    public class Device
    {
        #region Public Properties

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Yazılım tarafından verilen bir değerdir. Değiştirilemez")]
        [CustomSortedCategory("Cihaz ID", 1)]
        [DisplayName("ID")]
        public ushort ID { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Cihaz ismi")]
        [CustomSortedCategory("Genel Ayarlar", 2)]
        [CustomSortedDisplayName("Cihaz İsmi", 2)]
        public String Name { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Cihazın yer aldığı istasyon ismi")]
        [TypeConverter(typeof(StationConverter))]
        [CustomSortedCategory("Genel Ayarlar", 2)]
        [CustomSortedDisplayName("İstasyon İsmi", 1)]
        public ushort StationID { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Cihazın haberleşme protokolü")]
        [TypeConverter(typeof(ProtocolConverter))]
        [CustomSortedCategory("Genel Ayarlar", 2)]
        [CustomSortedDisplayName("Haberleşme Protokolü", 3)]
        public CommunicationProtocol Protocol
        {
            get;

            set;
            
        }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Cihazın haberleşme protokolü")]
        [TypeConverter(typeof(DeviceTypeConverter))]
        [CustomSortedCategory("Genel Ayarlar", 2)]
        [CustomSortedDisplayName("Cihaz Tipi", 4)]
        public byte TypeID
        {
            get;

            set;

        }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Evet: Yazılım cihaz ile haberleşir.\r\nHayır: Yazılım cihaz ile haberleşmez. Mevcut bağlantı durdurulur.")]
        [TypeConverter(typeof(TrueFalseTextConverter))]
        [CustomSortedCategory("Haberleşme Ayarları", 2)]
        [CustomSortedDisplayName("Aktif", 10)]
        public bool isActive { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Cihazın o anki bağlantı durumunu gösterir")]
        [TypeConverter(typeof(CommunicationStatusTextConverter))]
        [CustomSortedCategory("Haberleşme Ayarları", 2)]
        [CustomSortedDisplayName("Haberleşme Durumu", 11)]
        public bool Connected { get; set; }

        [Browsable(false)]
        public int disconnectionCounter { get; set; }

        #endregion Public Properties

        #region Constructor

        public Device()
        {
        }

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
                        if (Protocol == null)
                            Protocol = new CommunicationProtocol() { ID = protocolID };
                        else
                            Protocol.ID = protocolID;
                        break;
                    case "protocol_name":
                        string protocolName = dr.Field<string>("protocol_name");
                        
                        if (Protocol == null)
                            Protocol = new CommunicationProtocol() {Name = protocolName};
                        else
                            Protocol.Name = protocolName;
                        break;
                    case "is_active":
                        isActive = dr.Field<bool>("is_active");
                        break;
                    case "connected":
                        Connected = dr.Field<bool>("connected");
                        break;
                    case "device_type":
                        TypeID = dr.Field<byte>("device_type");
                        //if (TypeID == null)
                        //    TypeID = new DeviceType() { ID = id };
                        //else
                        //    TypeID.ID = id;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}