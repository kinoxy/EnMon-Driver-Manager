using System.Collections.Generic;
using EnMon_Driver_Manager.Models.Signals.Modbus;

namespace EnMon_Driver_Manager.Models.Devices
{
    public interface IModbus
    {
        List<ModbusBinarySignal> BinarySignals { get; set; }

        List<ModbusAnalogSignal> AnalogSignals { get; set; }

        List<ModbusCommandSignal> CommandSignals { get; set; }

        byte SlaveID { get; set; }
    }
}
