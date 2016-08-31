using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EnMon_Driver_Manager.Models
{
    public class PollingTimer : Timer
    {
        public string hostAddress { get; set; }

        public PollingTimer() : base()
        {

        }

        public PollingTimer(double i) : base(i)
        {
            
        }
    }
}
