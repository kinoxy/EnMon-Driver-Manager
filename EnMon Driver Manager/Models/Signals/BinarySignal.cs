using EnMon_Driver_Manager.Extensions;
using EnMon_Driver_Manager.Models.StatusTexts;
using System.ComponentModel;

namespace EnMon_Driver_Manager.Models.Signals
{
    public class BinarySignal : Signal
    {
        private bool isalarm;
        private bool isevent;

        public BinarySignal() : base()
        {
            StatusID = 1;
        }

        [Browsable(true)]
        [ReadOnly(true)]
        [CustomSortedDisplayName("Anlık Değer", 1)]
        [Description("Sinyale ait okunan son değeri gösterir. Güncel değer değişmiş olabilir.")]
        [TypeConverter(typeof(TrueFalseValueConverter))]
        public bool CurrentValue { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description(
            "Evet: Digital sinyal değer değişimleri alarm listesine kaydedilir.\r\nHayır: Digital sinyal değerdeğişimleri alarm listesine kaydedilmez."
        )]
        [CustomSortedCategory("Alarm/Olay Listesi Ayarları", 5)]
        [CustomSortedDisplayName("Alarm", 2)]
        [TypeConverter(typeof(TrueFalseTextConverter))]
        public bool IsAlarm
        {
            get { return isalarm; }
            set
            {
                isalarm = value;
                if (isalarm == false & isevent == false)
                {
                    SetPropertyReadOnlyAttributeValue("StatusID", true);
                }
                else
                {
                    SetPropertyReadOnlyAttributeValue("StatusID", false);
                }
                
            }
        }

        [Browsable(true)]
        [ReadOnly(false)]
        [Description(
            "Evet: Digital sinyal değer değişimleri olay listesine kaydedilir.\r\nHayır: Digital sinyal değer değişimleri olay listesine kaydedilmez."
        )]
        [CustomSortedCategory("Alarm/Olay Listesi Ayarları", 5)]
        [CustomSortedDisplayName("Olay", 1)]
        [TypeConverter(typeof(TrueFalseTextConverter))]
        public new bool IsEvent
        {
            get { return isevent; }
            set
            {
                isevent = value;
                if (isevent == false) IsAlarm = false;
                SetPropertyReadOnlyAttributeValue("IsAlarm", !value);
                SetPropertyReadOnlyAttributeValue("StatusID", !value);
            }
        }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Alarm veya olay durumunda listede gözücek metin.")]
        [CustomSortedCategory("Alarm/Olay Listesi Ayarları", 5)]
        [CustomSortedDisplayName("Durum Yazısı", 3)]
        [TypeConverter(typeof(StatusTextTypeConverter))]
        public uint StatusID { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [Description("Okunan değer işlenmeden önce terslenir.")]
        [CustomSortedCategory("Alarm/Olay Listesi Ayarları", 5)]
        [CustomSortedDisplayName("Tersle", 4)]
        [TypeConverter(typeof(StatusTextTypeConverter))]
        public bool IsReversed { get; set; }

    }
}
