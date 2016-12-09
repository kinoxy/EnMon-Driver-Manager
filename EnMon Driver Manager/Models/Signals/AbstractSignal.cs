
using System;

namespace EnMon_Driver_Manager
{

    public class Signal
    {
        #region Public Properties
        public uint ID { get; set; }

        public ushort DeviceID { get; set; }

        public String Name { get; set; }

        public String Identification { get; set; }
        
        public bool IsEvent { get; set; }

        public string TimeTag { get; set; }

        #endregion

        #region Constructors

        #endregion


    }
}