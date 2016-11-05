using EnMon_Driver_Manager.Models;
using System;

namespace EnMon_Driver_Manager
{
    public class AnalogSignal : Signal
    {
        private UInt32 currentValue;

        private uint maxValue;
        private uint minValue;
        private float scaleValue;

        public AnalogSignal()
        {
            dataType = new DataType();
            archivePeriod = new ArchivePeriod();
        }
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
        public DataType dataType { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public uint MaxAlarmValue
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
        public uint MinAlarmValue
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

        public bool HasMaxAlarm { get; set; }

        public bool HasMinAlarm { get; set; }



        public uint MaxAlarmStatusID { get; set; }

        public uint MinAlarmStatusID { get; set; }

        public string Unit { get; set; }

        public bool isArchive { get; set; }

        public ArchivePeriod archivePeriod { get; set; }

    }
}