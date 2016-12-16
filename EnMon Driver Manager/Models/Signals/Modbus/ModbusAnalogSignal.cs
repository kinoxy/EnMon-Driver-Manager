using EnMon_Driver_Manager.Models;
using System;
using System.Data;

namespace EnMon_Driver_Manager
{
    public class ModbusAnalogSignal : AnalogSignal, IModbusSignal
    {
        public ModbusAnalogSignal()
        {
            dataType = new DataType();
            archivePeriod = new ArchivePeriod();
        }

        public ushort Address { get; set; }

        public ArchivePeriod archivePeriod { get; set; }

        public byte FunctionCode { get; set; }

        public byte WordCount { get; set; }

        public void GetInfosFromDataRow(DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}