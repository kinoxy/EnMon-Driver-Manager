using EnMon_Driver_Manager.Models.Device;
using System;
using System.Collections.Generic;

namespace EnMon_Driver_Manager
{
    public class Station

    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public ushort ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the devices.
        /// </summary>
        /// <value>
        /// The devices.
        /// </value>
        public List<ModbusTCPDevice> ModbusTCPDevices { get; set; }

        public List<SNMPDevice> SNMPDevices {get; set; }

    }
}