using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Modbus.Data;
using Modbus.Device;
using Modbus.Utility;
using Modbus.IO;
using Modbus.Message;

namespace EnMon_Driver_Manager.Modbus
{
    class ModbusTCP : AbstractDriver
    {
        private List<string> ipAddresses;
        private int portNumber;
        private TcpClient client;
        public ModbusTCP(List<string> _ipAddresses)
        {
            ipAddresses = _ipAddresses;
            portNumber = 502;
        }

        public ModbusTCP(List<string> _ipAddresses, int _portNumber)
        {
            ipAddresses = _ipAddresses;
            portNumber = _portNumber;
        }

        public override void VerifyProtocolofDevices()
        {
            foreach (Device device in Devices)
            {
                if(device.ProtocolID != Device.Protocol.ModbusTCP)
                {
                    Devices.Remove(device);
                }
            }
        }



        
    }
}
