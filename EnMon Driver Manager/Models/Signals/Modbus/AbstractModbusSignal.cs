using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models
{
    public class AbstractModbusSignal : Signal
    {
        public ushort Address { get; set; }
        public byte FunctionCode { get; set; }
        public byte WordCount { get; set; }
    }
}
