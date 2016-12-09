using EnMon_Driver_Manager.Models;
using EnMon_Driver_Manager.Models.Device;
using System;
using System.Collections.Generic;

namespace EnMon_Driver_Manager
{
    /// <summary>
    /// 
    /// </summary>
    public class AbstractDevice
    {
        #region Public Properties

        public enum Protocol
        {
            ModbusRTU = 3,
            SNMP = 2,
            ModbusTCP = 1,
            ModbusASCII = 4
        }

        public ushort ID { get; set; }

        public String Name { get; set; }

        public ushort StationID { get; set; }

        public Protocol ProtocolID { get; set; }

        public bool isActive { get; set; }

        public bool Connected { get; set; }

        public int disconnectionCounter { get; set; }

        #endregion

        #region Constructor

        #endregion

    }
}