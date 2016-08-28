using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager
{
    public class Log
    {
        public static Logger Instance { get; private set; }
        static Log()
        {
            LogManager.ReconfigExistingLoggers();
            LogManager.EnableLogging();
            Instance = LogManager.GetCurrentClassLogger();
            
        }
    }
}
