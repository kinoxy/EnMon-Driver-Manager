using System;

namespace EnMon_Driver_Manager
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Signal'
    public abstract class Signal
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Signal'
    {
        private uint id;
        private ushort deviceId;
        private String name;
        private String identification;
        private ushort address;
        private bool is_event;


        public uint ID
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Signal.ID'
        {
            get { return id; }
            set { id = value; }
        }
        
        public ushort DeviceID
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Signal.DeviceID'
        {
            get { return deviceId; }
            set { deviceId = value; }
        }

        public String Name
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Signal.Name'
        {
            get { return name; }
            set { name = value; }
        }

        public String Identification
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Signal.Identification'
        {
            get { return identification; }
            set { identification = value; }
        }


        public ushort Address
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Signal.Address'
        {
            get { return address; }
            set { address = value; }
        }

        public byte FunctionCode { get; set; }

        public byte WordCount { get; set; }

        


        public bool IsEvent
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Signal.IsEvent'
        {
            get { return is_event; }
            set { is_event = value; }
        }

    }
}