using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Modbus
{
    class ModbusRTU : AbstractDriver
    {

        protected override void InitializeDriver()
        {
            throw new NotImplementedException();
        }

        protected override void ConnectToModbusDevices()
        {
            throw new NotImplementedException();
        }

        protected override List<Device> VerifyProtocolofDevices(List<Device> _devices)
        {
            throw new NotImplementedException();
        }

        protected override void GetCommunicationParametersFromConfigFile(string _configFile)
        {
            throw new NotImplementedException();
        }

        protected override void SetDefaultCommunicationParameters()
        {
            throw new NotImplementedException();
        }
    }
}
