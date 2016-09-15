using System;
using System.Collections.Generic;

namespace EnMon_Driver_Manager
{
    public class Device
    {
        private ushort id;
        private String name;
        private ushort stationID;
        private Protocol protocolID;
        private String ipAddress;
        private byte slaveID;
        private List<BinarySignal> binarySignals;
        private List<AnalogSignal> analogSignals;

        public enum Protocol
        {
            ModbusRTU,
            ModbusTCP,
            ModbusASCII
        }

        public ushort ID
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public ushort StationID
        {
            get { return stationID; }
            set { stationID = value; }
        }


        public Protocol ProtocolID
        {
            get { return protocolID; }
            set { protocolID = value; }
        }

        public String IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        public byte SlaveID
        {
            get { return slaveID; }
            set { slaveID = value; }
        }

        public List<BinarySignal> BinarySignals
        {
            get { return binarySignals; }
            set { binarySignals = value; }
        }

        public List<AnalogSignal> AnalogSignals
        {
            get { return analogSignals; }
            set { analogSignals = value; }
        }


    }
}