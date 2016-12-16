using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models
{
    public interface IModbusSignal
    {
        ushort Address { get; set; }
        byte FunctionCode { get; set; }
        byte WordCount { get; set; }

        void GetInfosFromDataRow(DataRow dr);
    }
}
