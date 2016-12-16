using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models
{
    public class BinarySignal : Signal
    {
        public bool CurrentValue { get; set; }

        public bool IsReversed { get; set; }

        public uint StatusID { get; set; }

        public bool IsAlarm { get; set; }
    }
}
