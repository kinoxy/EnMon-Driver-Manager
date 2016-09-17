using System;
using System.Collections.Generic;

namespace EnMon_Driver_Manager
{
    public class Station
    {
        private ushort id;
        private String name;
        private string ipAddress;
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