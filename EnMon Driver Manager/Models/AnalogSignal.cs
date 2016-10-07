using System;

namespace EnMon_Driver_Manager
{
    public class AnalogSignal : Signal
    {
        private UInt32 currentValue;
        private byte dataTypeID;
        private int maxValue;
        private int minValue;
        private float scaleValue;
        public string TimeTag { get; set; }
        
        public UInt32 CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; }
        }

        /// <summary>
        /// Gets or sets the datatype identifier.
        /// </summary>
        /// <value>
        /// The datatype identifier.
        /// </value>
        public byte DatatypeID
        {
            get { return dataTypeID; }
            set { dataTypeID = value; }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>
        /// The minimum value.
        /// </value>
        public int MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        /// <summary>
        /// Gets or sets the scale value.
        /// </summary>
        /// <value>
        /// The scale value.
        /// </value>
        public float ScaleValue
        {
            get { return scaleValue; }
            set { scaleValue = value; }
        }

    }
}