using System;
using System.Collections.Generic;

namespace EnMon_Driver_Manager
{
    public class Device
    {
        private int id;
        private String name;
        private int stationID;
        private Protocol protocolID;
        private String ipAddress;
        private int slaveID;
        private List<BinarySignal> binarySginals;
        private List<AnalogSignal> analogSignals;

        public enum Protocol
        {
            ModbusRTU,
            ModbusTCP,
            ModbusASCII
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int StationID
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

        public int SlaveID
        {
            get { return SlaveID; }
            set { slaveID = value; }
        }

        public List<BinarySignal> BinarySignals
        {
            get { return binarySginals; }
            set { binarySginals = value; }
        }

        public List<AnalogSignal> AnalogSignals
        {
            get { return analogSignals; }
            set { analogSignals = value; }
        }


    }
}