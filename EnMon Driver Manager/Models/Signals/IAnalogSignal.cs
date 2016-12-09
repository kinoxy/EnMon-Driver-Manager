using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models
{
    public interface IAnalogSignal
    {
        UInt32 CurrentValue { get; set; }

        DataType dataType { get; set; }

        float MaxAlarmValue { get; set; }

        float MinAlarmValue { get; set; }

        float ScaleValue { get; set; }

        bool HasMaxAlarm { get; set; }

        bool HasMinAlarm { get; set; }

        uint MaxAlarmStatusID { get; set; }

        uint MinAlarmStatusID { get; set; }

        string Unit { get; set; }

        bool IsArchive { get; set; }

        ArchivePeriod archivePeriod { get; set; }
    }
}
