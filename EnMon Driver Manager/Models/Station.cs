using System;
using System.Collections.Generic;

namespace EnMon_Driver_Manager
{
    internal class Station
    {
        private int id;
        private String name;
        private List<Device> devices;

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

        public List<Device> Devices
        {
            get { return devices; }
            set { devices = value; }
        }

    }
}