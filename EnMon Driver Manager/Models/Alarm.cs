using System;

namespace EnMon_Driver_Manager
{
    internal class Alarm
    {
        private int id;
        private String alarmText;
        private String statusText;
        private String comment;
        private bool isActive;
        private bool isAcknowloedge;
        private DateTime activeTime;
        private DateTime clearedTime;
        private DateTime acknowledgeTime;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public String AlarmText
        {
            get { return alarmText; }
            set { alarmText = value; }
        }

        public String StatusText
        {
            get { return statusText; }
            set { statusText = value; }
        }

        public String Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public bool IsAcknowledge
        {
            get { return isAcknowloedge; }
            set { isAcknowloedge = value; }
        }

        public DateTime ActiveTime
        {
            get { return activeTime; }
            set { activeTime = value; }
        }

        public DateTime ClearedTime
        {
            get { return clearedTime; }
            set { clearedTime = value; }
        }

        public DateTime AcknowledgeTime
        {
            get { return acknowledgeTime; }
            set { acknowledgeTime = value; }
        }

    }
}