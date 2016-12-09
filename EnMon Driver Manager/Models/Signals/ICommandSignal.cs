using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models
{
    public interface ICommandSignal
    {
        float CommandValue { get; set; }
    }
}
