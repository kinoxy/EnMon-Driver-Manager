using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models
{
    public class AnalogSignal : Signal
    {
        public uint CurrentValue { get; set; }

        public DataType dataType { get; set; }

        public float MaxAlarmValue { get; set; }

        public float MinAlarmValue { get; set; }

        public float ScaleValue { get; set; }

        public bool HasMaxAlarm { get; set; }

        public bool HasMinAlarm { get; set; }

        public uint MaxAlarmStatusID { get; set; }

        public uint MinAlarmStatusID { get; set; }

        public string Unit { get; set; }

        public bool IsArchive { get; set; }

        public ArchivePeriod archivePeriod { get; set; }
    }
}
