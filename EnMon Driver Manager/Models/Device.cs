using System;
using System.Collections.Generic;

namespace EnMon_Driver_Manager
{
    /// <summary>
    /// 
    /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        public enum Protocol
        {
            /// <summary>
            /// The modbus rtu
            /// </summary>
            ModbusRTU,

            /// <summary>
            /// The modbus TCP
            /// </summary>
            ModbusTCP,

            /// <summary>
            /// The modbus ASCII
            /// </summary>
            ModbusASCII
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public ushort ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the station identifier.
        /// </summary>
        /// <value>
        /// The station identifier.
        /// </value>
        public ushort StationID
        {
            get { return stationID; }
            set { stationID = value; }
        }

        /// <summary>
        /// Gets or sets the protocol identifier.
        /// </summary>
        /// <value>
        /// The protocol identifier.
        /// </value>
        public Protocol ProtocolID
        {
            get { return protocolID; }
            set { protocolID = value; }
        }

        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>
        /// The ip address.
        /// </value>
        public String IpAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        /// <summary>
        /// Gets or sets the slave identifier.
        /// </summary>
        /// <value>
        /// The slave identifier.
        /// </value>
        public byte SlaveID
        {
            get { return slaveID; }
            set { slaveID = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Device"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool isActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Device"/> is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if connected; otherwise, <c>false</c>.
        /// </value>
        public bool Connected { get; set; }

        /// <summary>
        /// Gets or sets list of binary signals.
        /// </summary>
        /// <value>
        /// The binary signals.
        /// </value>
        public List<BinarySignal> BinarySignals
        {
            get { return binarySignals; }
            set { binarySignals = value; }
        }

        /// <summary>
        /// Gets or sets list of analog signals.
        /// </summary>
        /// <value>
        /// The analog signals.
        /// </value>
        public List<AnalogSignal> AnalogSignals
        {
            get { return analogSignals; }
            set { analogSignals = value; }
        }


    }
}