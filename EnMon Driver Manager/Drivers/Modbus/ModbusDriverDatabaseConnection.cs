using EnMon_Driver_Manager.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Drivers.Modbus
{
    class ModbusDriverDatabaseConnection
    {
        private AbstractDBHelper DBHelper;

        public ModbusDriverDatabaseConnection(string _configFileLocation)
        {
            DBHelper = StaticHelper.InitializeDatabase(_configFileLocation);
        }

    }
}
