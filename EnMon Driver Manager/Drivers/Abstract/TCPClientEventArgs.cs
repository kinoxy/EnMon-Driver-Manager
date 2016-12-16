using EnMon_Driver_Manager.Models;
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

            public List<AnalogSignal> AnalogSignals { get; internal set; }

            public List<BinarySignal> BinarySignals { get; internal set; }

            public string ipAddress { get; internal set; }

            public List<AbstractTCPDevice> Devices { get; internal set; }

            public AbstractDevice Device { get; internal set; }
    }

    public delegate void TCPClientEventHandler(object source, TCPClientEventArgs e);

}
