using System;

namespace EnMon_Driver_Manager
{
    internal class Event
    {
        private int id;
        private String eventText;
        private String statusText;
        private DateTime eventTime;


        
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        
        public String EventText
        {
            get { return eventText; }
            set { eventText = value; }
        }
        public String StatusText
        {
            get { return statusText; }
            set { statusText = value; }
            
        }

        public DateTime EventTime
        {
            get { return eventTime; }
            set { eventTime = value; }
        }

    }
}