﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models.Device
{
    public class  AbstractTCPDevice : AbstractDevice
    {
        public string IpAddress { get; set; }
    }
}
