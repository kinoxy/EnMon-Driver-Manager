using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models.Device
{
    public class ModbusTCPDevice : AbstractTCPDevice
    {
        public List<ModbusAnalogSignal> AnalogSignals { get; set; }


        public List<ModbusBinarySignal> BinarySignals { get; set; }

        public List<ModbusCommandSignal> CommandSignals { get; set; }

        public byte SlaveID { get; set; }
    }
}
