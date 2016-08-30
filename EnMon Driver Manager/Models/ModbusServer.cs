using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models
{
    public class ModbusServer
    {
        private TcpClient client;
        private string ipAddress;
        private int portNumber;

        public ModbusServer(string _ipAddress, int _portNumber)
        {
            ipAddress = _ipAddress;
            portNumber = _portNumber;
            client = new TcpClient(_ipAddress, portNumber);
        }

        public ModbusServer(string _ipAddress)
        {
            ipAddress = _ipAddress;
            client = new TcpClient(_ipAddress, 502);
        }

        public TcpClient Client
        {
            get { return client; }
        }
    }
}
