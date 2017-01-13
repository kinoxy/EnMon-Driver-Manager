using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Models.Signals;
using System;
using System.Collections.Generic;

namespace EnMon_Driver_Manager.Drivers
{
    public class TCPClientEventArgs : EventArgs
    {

            public List<AnalogSignal> AnalogSignals { get; internal set; }

            public List<BinarySignal> BinarySignals { get; internal set; }

            public string ipAddress { get; internal set; }

            public List<Device> Devices { get; internal set; }

            public Device Device { get; internal set; }
    }

    public delegate void TCPClientEventHandler(object source, TCPClientEventArgs e);

}
