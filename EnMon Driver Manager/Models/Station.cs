using System;
using System.Collections.Generic;

namespace EnMon_Driver_Manager
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Station'
    public class Station
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Station'
    {
        private ushort id;
        private String name;
#pragma warning disable CS0169 // The field 'Station.ipAddress' is never used
        private string ipAddress;
#pragma warning restore CS0169 // The field 'Station.ipAddress' is never used
        private List<Device> devices;

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
        /// Gets or sets the devices.
        /// </summary>
        /// <value>
        /// The devices.
        /// </value>
        public List<Device> Devices
        {
            get { return devices; }
            set { devices = value; }
        }

    }
}