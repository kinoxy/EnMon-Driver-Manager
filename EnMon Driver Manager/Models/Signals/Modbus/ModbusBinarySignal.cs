using System;
using System.Data;
using EnMon_Driver_Manager.Models;

namespace EnMon_Driver_Manager
{
    public class ModbusBinarySignal : BinarySignal, IModbusSignal
    {
        public float ComparisonValue { get; set; }

        public enum ComparisonType
        {
            bit,
            value
        }

        public ComparisonType comparisonType { get; set;}

        public byte ComparisonBitNumber { get; set; }

        public ushort Address { get; set; }

        public byte FunctionCode { get; set; }

        public byte WordCount { get; set; }

        public void GetInfosFromDataRow(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}