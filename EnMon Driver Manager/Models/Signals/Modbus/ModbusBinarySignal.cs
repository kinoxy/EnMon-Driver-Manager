using EnMon_Driver_Manager.Models;

namespace EnMon_Driver_Manager
{
    public class ModbusBinarySignal : AbstractModbusSignal, IBinarySignal
    {
        public bool CurrentValue { get; set; }

        public bool IsReversed { get; set; }

        public uint StatusID { get; set; }

        public bool IsAlarm { get; set; }

    }
}