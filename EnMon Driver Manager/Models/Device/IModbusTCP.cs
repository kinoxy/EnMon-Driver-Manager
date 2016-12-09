using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models.Device
{
    public interface IModbusTCP
    {
        List<ModbusBinarySignal> BinarySignals { get; set; }

        List<ModbusAnalogSignal> AnalogSignals { get; set; }

        List<ModbusCommandSignal> CommandSignals { get; set; }



        byte SlaveID { get; set; }
    }
}
