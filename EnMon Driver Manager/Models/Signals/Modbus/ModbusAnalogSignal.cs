using EnMon_Driver_Manager.Models;
using System;

namespace EnMon_Driver_Manager
{
    public class ModbusAnalogSignal : AbstractModbusSignal, IAnalogSignal
    {
        public ModbusAnalogSignal()
        {
            dataType = new DataType();
            archivePeriod = new ArchivePeriod();
        }

        public ArchivePeriod archivePeriod { get; set; }

        public uint CurrentValue { get; set; }

        public DataType dataType { get; set; }

        public bool HasMaxAlarm { get; set; } 

        public bool HasMinAlarm { get; set; }

        public bool IsArchive { get; set; }

        public uint MaxAlarmStatusID { get; set; }

        public float MaxAlarmValue { get; set; }

        public uint MinAlarmStatusID { get; set; }

        public float MinAlarmValue { get; set; }

        public float ScaleValue { get; set; }

        public string Unit { get; set; }
    }
}