using System.ComponentModel;

namespace EnMon_Driver_Manager.Models.Signals.Modbus
{
    public interface IModbusSignal
    {
        [Browsable(true)]
        ushort Address { get; set; }
        byte FunctionCode { get; set; }
        byte WordCount { get; set; }

    }
}
