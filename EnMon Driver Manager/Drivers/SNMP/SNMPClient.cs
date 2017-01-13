using System;
using System.Collections.Generic;
using System.Linq;
using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Models.Signals;
using EnMon_Driver_Manager.Models.Signals.SNMP;

namespace EnMon_Driver_Manager.Drivers.SNMP
{
    public class SNMPClient : AbstractTCPClient
    {
        #region Public Properties

        public new List<SNMPDevice> Devices { get; set; }

        public enum SNMPVersion
        {
            V1 = 0,
            V2 = 1,
            V3 = 2
        }

        public SNMPVersion Version;
        #endregion

        #region Constructors
        public SNMPClient(string _ipAddress, int _readTimeOut, int _retryNumber, double _pollingtime, SNMPVersion Version = SNMPVersion.V1) : base(_ipAddress, _readTimeOut, _retryNumber, _pollingtime)
        {
            
        }

        #endregion

        public override void ReadValues()
        {
            throw new NotImplementedException();
        }

        public override bool WriteValue(Device d, CommandSignal c)
        {
            SNMPDevice _d = Devices.Where(device => device.ID == d.ID).FirstOrDefault();
            SNMPCommandSignal _commandSignal = _d.CommandSignals.Where(command => command.ID == c.ID).FirstOrDefault();

            if (_d.Connected && _d.isActive)
            {
                // TODO: Devamını getir.
                //switch (_commandSignal.FunctionCode)
                //{
                //    case 5:
                //        WriteSingleCoil(_d, _commandSignal);
                //        return true;

                //    case 6:
                //        WriteSingleRegister(_d, _commandSignal);
                //        return true;

                //    case 15:
                //        WriteMultipleCoils(_d, _commandSignal);
                //        return true;

                //    case 16:
                //        WriteValueMultipleRegisters(_d, _commandSignal);
                //        return true;

                //    default:
                //        Log.Instance.Error("Yanlış function code : {0} sinyaline değer yazılamadı", _commandSignal.Identification);
                //        return false;
                //}
                return false;
            }
            else
            {
                Log.Instance.Warn("{0}: {1} adlı komut cihaz ile haberleşme olmadığı için gönderilemedi", this.GetType().Name, _commandSignal.Identification);
                return false;
            }
        }

        protected override bool AnyActiveDeviceAvaliable()
        {
            throw new NotImplementedException();
        }

        protected override void DoProtocolSpecificWorksWhenCommunicationEstablished()
        {
            throw new NotImplementedException();
        }

        protected override void InitializeClientProperties()
        {
            throw new NotImplementedException();
        }

        protected override void InitializeDefaultCommunicationSettings()
        {
            throw new NotImplementedException();
        }

        protected override void OrderSignalsByAddress()
        {
            throw new NotImplementedException();
        }
    }
}

