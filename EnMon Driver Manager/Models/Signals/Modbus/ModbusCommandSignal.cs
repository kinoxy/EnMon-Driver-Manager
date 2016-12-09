using System;

namespace EnMon_Driver_Manager.Models
{
    public class ModbusCommandSignal : AbstractModbusSignal, ICommandSignal

    {
        public enum CommandType

        {
            /// <summary>
            /// The binary
            /// </summary>
            Binary,

            /// <summary>
            /// The analog
            /// </summary>
            Analog
        }

        public CommandType commandType { get; set; }

        public byte BitNumber { get; set; }

        public float CommandValue { get; set; }

    }
}