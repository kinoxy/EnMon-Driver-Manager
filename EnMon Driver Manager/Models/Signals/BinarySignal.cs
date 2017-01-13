namespace EnMon_Driver_Manager.Models.Signals
{
    public class BinarySignal : Signal
    {
        public bool CurrentValue { get; set; }

        public bool IsReversed { get; set; }

        public uint StatusID { get; set; }

        public bool IsAlarm { get; set; }
    }
}
