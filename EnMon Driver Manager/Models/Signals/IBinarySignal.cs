using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models
{
    public interface IBinarySignal
    {
        bool CurrentValue { get; set; }

        bool IsReversed { get; set; }

        uint StatusID { get; set; }

        bool IsAlarm { get; set; }
    }
}
