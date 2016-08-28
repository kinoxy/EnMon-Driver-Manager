using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Modbus
{
    class ModbusRTU : AbstractDriver
    {
        public override void ReadValueFromDevice()
        {
            throw new NotImplementedException();
        }

        public override void VerifyProtocolofDevices()
        {
            throw new NotImplementedException();
        }

        public override void WriteAnalogValuesToDatabase(List<AnalogSignal> _analogValues)
        {
            throw new NotImplementedException();
        }

        public override void WriteValueToDevice()
        {
            throw new NotImplementedException();
        }
    }
}
