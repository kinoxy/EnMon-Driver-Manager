using System;
using System.Data;
using System.Timers;

namespace EnMon_Driver_Manager.Modbus
{
    class ModbusRTU : AbstractModbusDriver
    {

        protected override void InitializeDriver()
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

        protected override void Communicate()
        {
            throw new NotImplementedException();
        }

        public override void SetDriverAllDevicesDisconnected()
        {
            throw new NotImplementedException();
        }

        protected override void GetStationDevicesAndSignalsInfo()
        {
            throw new NotImplementedException();
        }

        protected override void SendCommand(DataRow dr)
        {
            throw new NotImplementedException();
        }

        protected override void CycleForCommands_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void SetAllDevicesDisconnected()
        {
            throw new NotImplementedException();
        }
    }
}
