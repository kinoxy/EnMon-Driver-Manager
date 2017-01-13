using EnMon_Driver_Manager.Extensions;
using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Models.Stations;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;

namespace EnMon_Driver_Manager.Models.Signals
{
    public class Signal
    {
        #region Public Fields

        public ushort deviceID;

        #endregion Public Fields

        #region Private Fields

        private string name;
        private string stationName;
        private string deviceName;
        private string identification;

        #endregion Private Fields

        #region Public Properties

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Yazılım tarafından verilen bir değerdir. Değiştirilemez")]
        [CustomSortedCategory("Sinyal ID", 1)]
        [DisplayName("ID")]
        public uint ID { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Sinyale ait kısa isim")]
        [TypeConverter(typeof(StationConverter))]
        [CustomSortedCategory("Genel Ayarlar", 2)]
        [CustomSortedDisplayName("İstasyon İsmi", 1)]
        public string StationName
        {
            get { return stationName; }
            set
            {
                stationName = value;
                DeviceName = string.Empty;
                TemporaryValues.devices = TemporaryValues.stations.First(s => s.Name == value).Devices;
                identification = stationName + " " + deviceName + " " + name;
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Sinyale ait kısa isim")]
        [CustomSortedCategory("Genel Ayarlar", 2)]
        [TypeConverter(typeof(DeviceConverter))]
        [CustomSortedDisplayName("Cihaz İsmi", 2)]
        public string DeviceName
        {
            get { return deviceName; }
            set
            {
                deviceName = value;
                //deviceID = TemporaryValues.devices.First((d) => d.Name == deviceName).ID;
                identification = stationName + " " + deviceName + " " + name;
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Sinyale ait kısa isim")]
        [CustomSortedCategory("Genel Ayarlar", 2)]
        [CustomSortedDisplayName("Sinyal İsmi", 3)]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                identification = stationName + " " + deviceName + " " + name;
            }
        }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Sinyale ait uzun isim/tanım bilgisi")]
        [CustomSortedCategory("Genel Ayarlar", 2)]
        [CustomSortedDisplayName("Sinyal Tanımı", 4)]
        public string Identification
        {
            get { return identification; }
            set { identification = value; }
        }

        [Browsable(false)]
        public bool IsEvent { get; set; }

        [Browsable(false)]
        public string TimeTag { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Evet: Sinyalin değeri cihaz detay sayfasında gösterilir \r\nHayır: Sinyalin değeri cihaz detay sayfasında gösterilmez")]
        [CustomSortedCategory("Sayfa Gösterimi", 3)]
        [CustomSortedDisplayName("Detay Sayfası Gösterimi", 2)]
        [TypeConverter(typeof(PageShownConverter))]
        public bool DisplayAtDeviceDetailPage { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Evet: Sinyalin değeri istasyon detay sayfasında gösterilir \r\n Hayır: Sinyalin değeri istasyon detay sayfasında gösterilmez")]
        [CustomSortedCategory("Sayfa Gösterimi", 3)]
        [CustomSortedDisplayName("İstasyon Sayfası Gösterimi", 1)]
        [TypeConverter(typeof(PageShownConverter))]
        public bool DisplayAtStationDetailPage { get; set; }

        public virtual void GetPropertyValuesFromDataRow(DataRow dr)
        {
        }

        #endregion Public Properties



        #region Protected Methods

        protected void SetPropertyBoolAttributeValue(string _propertyName, bool value)
        {
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())[_propertyName];
            if (descriptor != null)
            {
                ReadOnlyAttribute attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
                FieldInfo isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
                isReadOnly.SetValue(attrib, value);
            }
        }

        #endregion Protected Methods
    }
}