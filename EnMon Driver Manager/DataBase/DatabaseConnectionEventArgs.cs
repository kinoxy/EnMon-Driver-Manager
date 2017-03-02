using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.DataBase
{
    public class DatabaseConnectionEventArgs : EventArgs
    {

    }

    public delegate void DatabaseConnectionEventHandler(object source, DatabaseConnectionEventArgs args);
}
