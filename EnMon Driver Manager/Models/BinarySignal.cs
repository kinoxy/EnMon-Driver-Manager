using System;

namespace EnMon_Driver_Manager
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'BinarySignal'
    public class BinarySignal : Signal
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'BinarySignal'
    {
        private bool currentValue;
        private bool is_reversed;
        private string timetag;

        /// <summary>
        /// Gets or sets the bit number.
        /// </summary>
        /// <value>
        /// The bit number.
        /// </value>
        public byte BitNumber { get;  set;}

        /// <summary>
        /// Gets or sets a value indicating whether [current value].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [current value]; otherwise, <c>false</c>.
        /// </value>
        public bool CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is reversed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is reversed; otherwise, <c>false</c>.
        /// </value>
        public bool IsReversed
        {
            get { return is_reversed; }
            set { is_reversed = value; }
        }

        /// <summary>
        /// Gets or sets the time tag.
        /// </summary>
        /// <value>
        /// The time tag.
        /// </value>
        public string TimeTag
        {
            get { return timetag; }
            set { timetag = value; }
        }


        public uint StatusID { get; set; }

        public bool IsAlarm { get; set; }


    }
}