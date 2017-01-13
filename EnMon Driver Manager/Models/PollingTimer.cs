using System.Timers;

namespace EnMon_Driver_Manager.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PollingTimer'
    public class PollingTimer : Timer
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PollingTimer'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PollingTimer.hostAddress'
        public string hostAddress { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PollingTimer.hostAddress'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PollingTimer.PeriodID'
        public uint PeriodID { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PollingTimer.PeriodID'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PollingTimer.PollingTimer()'
        public PollingTimer() : base()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PollingTimer.PollingTimer()'
        {

        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PollingTimer.PollingTimer(double)'
        public PollingTimer(double i) : base(i)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PollingTimer.PollingTimer(double)'
        {
            
        }
    }
}
