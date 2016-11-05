using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Log'
    public class Log
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Log'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Log.Instance'
        public static Logger Instance { get; private set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Log.Instance'
        static Log()
        {
            LogManager.ReconfigExistingLoggers();
            LogManager.EnableLogging();
            Instance = LogManager.GetCurrentClassLogger();
            
        }
    }
}
