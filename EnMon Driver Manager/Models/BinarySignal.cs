using System;

namespace EnMon_Driver_Manager
{
    public class BinarySignal : Signal
    {
        private bool currentValue;
        private bool is_reversed;
        private string timetag;

        public bool CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; }
        }

        public bool IsReversed
        {
            get { return is_reversed; }
            set { is_reversed = value; }
        }

        public string TimeTag
        {
            get { return timetag; }
            set { timetag = value; }
        }
    }
}