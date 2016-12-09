using EnMon_Driver_Manager.Models.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Drivers
{
    public class TCPClientEventArgs : EventArgs
    {
            /// <summary>
            /// The analog signals
            /// </summary>
            public List<ModbusAnalogSignal> AnalogSignals { get; internal set; }

            /// <summary>
            /// Gets or sets the binary signals.
            /// </summary>
            /// <value>
            /// The binary signals.
            /// </value>
            public List<ModbusBinarySignal> BinarySignals { get; internal set; }

            public string ipAddress { get; internal set; }

            public List<AbstractTCPDevice> Devices { get; internal set; }

            public AbstractDevice Device { get; internal set; }
    }

    public delegate void TCPClientEventHandler(object source, TCPClientEventArgs e);

}
