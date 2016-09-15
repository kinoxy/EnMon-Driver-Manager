using System;

namespace EnMon_Driver_Manager
{
    public abstract class Signal
    {
        private uint id;
        private ushort deviceId;
        private String name;
        private String identification;
        private ushort address;
        private bool is_alarm;
        private bool is_event;

        public uint ID
        {
            get { return id; }
            set { id = value; }
        }

        public ushort DeviceID
        {
            get { return deviceId; }
            set { deviceId = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Identification
        {
            get { return identification; }
            set { identification = value; }
        }

        public ushort Address
        {
            get { return address; }
            set { address = value; }
        }

        public byte FunctionCode { get; set; }

        public byte WordCount { get; set; }

        public bool IsAlarm
        {
            get { return is_alarm; }
            set { is_alarm = value; }
        }

        public bool IsEvent
        {
            get { return is_event; }
            set { is_event = value; }
        }

    }
}