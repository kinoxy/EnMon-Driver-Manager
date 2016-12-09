using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models.Device
{
    public class SNMPDevice : AbstractTCPDevice
    {
        public List<SNMPAnalogSignal> AnalogSignals { get; set; }

        public List<SNMPBinarySignal> BinarySignals { get; set; }

        public List<SNMPCommandSignal> CommandSignals { get; set; }
    }
}
