using System;

namespace EnMon_Driver_Manager
{
    internal class Event
    {
       
        public int ID { get; set; }
        
        public String EventText { get; set; }
        public String StatusText { get; set; }

        public DateTime EventTime { get; set; }

    }
}