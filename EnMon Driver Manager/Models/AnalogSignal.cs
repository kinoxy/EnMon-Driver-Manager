using System;

namespace EnMon_Driver_Manager
{
    public class AnalogSignal : Signal
    {
        private int currentValue;
        private int dataTypeID;
        private int maxValue;
        private int minValue;
        private int scaleValue;

        
        public int CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; }
        }

        public int DatatypeID
        {
            get { return dataTypeID; }
            set { dataTypeID = value; }
        }

        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        public int MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        public int ScaleValue
        {
            get { return scaleValue; }
            set { scaleValue = value; }
        }

    }
}