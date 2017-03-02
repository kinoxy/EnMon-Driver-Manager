using EnMon_Driver_Manager.Extensions;
using System.ComponentModel;
using EnMon_Driver_Manager.Models.ArchivePeriods;
using EnMon_Driver_Manager.Models.DataTypes;
using EnMon_Driver_Manager.Models.StatusTexts;
using System.Reflection;

namespace EnMon_Driver_Manager.Models.Signals
{
    public class AnalogSignal : Signal
    {
        #region Protected Fields

        public DataType dataType;
        public ArchivePeriod archivePeriod;
        private string archivePeriodName;
        private string dataTypeName;
        private bool isArchive;
        private string maxAlarmStatusText;
        private uint maxAlarmStatusTextID;
        private string minAlarmStatusText;
        private uint minAlarmStatusTextID;
        private bool hasMaxAlarm;
        private bool hasMinAlarm;
        private byte dataTypeID;
        private StatusText MaxAlarmStatus;
        private StatusText MinAlarmStatus;

        #endregion Protected Fields

        #region Constructors

        public AnalogSignal() : base()
        {
            dataType = new DataType() {ID=1};
            archivePeriod = new ArchivePeriod() { ID = 1 };
            maxAlarmStatusTextID = 1;
            minAlarmStatusTextID = 1;
        }

        #endregion Constructors

        #region Public Properties

        [Browsable(true)]
        public uint CurrentValue { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description(
            "Evet: Yazılım analog sinyalin girilen maksimum değeri aşması durumunda alarm üretir.\r\nHayır: Analog sinyal maksimum değer için alarm üretilmez."
        )]
        [CustomSortedCategory("Maksimum Değer Alarm Ayarları", 6)]
        [CustomSortedDisplayName("Maksimum Alarm", 1)]
        [TypeConverter(typeof(TrueFalseTextConverter))]
        public bool HasMaxAlarm
        {
            get { return hasMaxAlarm; }
            set
            {
                hasMaxAlarm = value;
                SetPropertyReadOnlyAttributeValue("MaxAlarmValue", !value);
                SetPropertyReadOnlyAttributeValue("MaxAlarmStatusTextID", !value);

            }
        }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Maksimum alarm için alarm eşik değeri")]
        [CustomSortedCategory("Maksimum Değer Alarm Ayarları", 6)]
        [CustomSortedDisplayName("Alarm değeri", 2)]
        public float MaxAlarmValue { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Minimum alarm için alarm eşik değeri")]
        [CustomSortedCategory("Minimum Değer Alarm Ayarları", 7)]
        [CustomSortedDisplayName("Alarm değeri", 2)]
        public float MinAlarmValue { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Skala")]
        [CustomSortedCategory("Haberleşme Ayarları", 4)]
        [CustomSortedDisplayName("Skala", 19)]
        public float ScaleValue { get; set; }

        

        [Browsable(true)]
        [ReadOnly(false)]
        [Description(
            "Evet: Yazılım analog sinyalin girilen minimum değeri aşması durumunda alarm üretir.\r\nHayır: Analog sinyal minimum değer için alarm üretilmez."
        )]
        [CustomSortedCategory("Minimum Değer Alarm Ayarları", 7)]
        [CustomSortedDisplayName("Minimum Alarm", 1)]
        [TypeConverter(typeof(TrueFalseTextConverter))]
        public bool HasMinAlarm
        {
            get { return hasMinAlarm; }
            set
            {
                hasMinAlarm = value;
                SetPropertyReadOnlyAttributeValue("MinAlarmStatusTextID", !value);
                SetPropertyReadOnlyAttributeValue("MinAlarmValue", !value);    
            }
        }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Alarm durumunda alarm listesinde gözücek metin.")]
        [CustomSortedCategory("Maksimum Değer Alarm Ayarları", 6)]
        [CustomSortedDisplayName("Durum Yazısı", 3)]
        [TypeConverter(typeof(StatusTextTypeConverter))]
        public uint MaxAlarmStatusTextID
        {

            get { return maxAlarmStatusTextID; }
            set { maxAlarmStatusTextID = value; }
        }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Alarm durumunda alarm listesinde gözücek metin.")]
        [CustomSortedCategory("Minimum Değer Alarm Ayarları", 7)]
        [CustomSortedDisplayName("Durum Yazısı", 3)]
        [TypeConverter(typeof(StatusTextTypeConverter))]
        public uint MinAlarmStatusTextID
        {
            get { return minAlarmStatusTextID; }
            set { minAlarmStatusTextID = value; }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Analog sinyale ait birim bilgisi.")]
        [CustomSortedCategory("Genel Ayarlar", 2)]
        [CustomSortedDisplayName("Birim", 5)]
        public string Unit { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Evet: Analog sinyalin değeri seçilen periyod aralıklarında kaydedilir.\r\nHayır: Analog sinyalin değeri kaydedilmez")]
        [CustomSortedCategory("Arşivleme", 5)]
        [CustomSortedDisplayName("Arşivleme", 19)]
        [TypeConverter(typeof(TrueFalseTextConverter))]
        public bool IsArchive
        {
            get { return isArchive; }
            set
            {
                isArchive = value;
                SetPropertyReadOnlyAttributeValue("ArchivePeriodName", !value);
            }
        }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Evet: Analog sinyalin değeri belirtilen aralıklarda kaydedilir.\r\nHayır: Analog sinyalin değeri kaydedilmez")]
        [CustomSortedCategory("Arşivleme", 5)]
        [CustomSortedDisplayName("Arşivleme Periyodu", 20)]
        [TypeConverter(typeof(ArchivePeriodConverter))]
        public string ArchivePeriodName
        {
            get
            {
                if (archivePeriod == null) archivePeriod = new ArchivePeriod() { Description = string.Empty};
                return archivePeriod.ToString();
            }
            set { archivePeriod.Description = value; }
        }

        [Browsable(false)]
        public string DataTypeName
        {
            get
            {
                if (dataType == null) dataType = new DataType() { Name = string.Empty };
                return dataType.Name;
            }
            set { dataType.Name = value; }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description("Data Tipi")]
        [CustomSortedCategory("Haberleşme Ayarları", 4)]
        [CustomSortedDisplayName("Data Tipi", 20)]
        [TypeConverter(typeof(DataTypeConverter))]
        public byte DataTypeID
        {
            get { return dataTypeID; }
            set { dataTypeID = value; }
        }

        #endregion Public Properties
    }
}