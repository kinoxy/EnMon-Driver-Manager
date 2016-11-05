using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Constants'
    public static class Constants
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Constants'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Constants.DatabaseConfigFileLocation'
        public static string DatabaseConfigFileLocation
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Constants.DatabaseConfigFileLocation'
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "/Config/DatabaseConfig.ini"; }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Constants.MailClientConfigFileLocation'
        public static string MailClientConfigFileLocation
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Constants.MailClientConfigFileLocation'
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "Config/MailClientConfig.ini"; }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Constants.ModbusTCPDriverConfigFileLocation'
        public static string ModbusTCPDriverConfigFileLocation
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Constants.ModbusTCPDriverConfigFileLocation'
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "Config/ModbusTCPConfig.ini"; }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Constants.MessageBoxHeader'
        public static string MessageBoxHeader
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Constants.MessageBoxHeader'
        {
            get { return "EnMon Sürücü Yöneticisi"; }
        }
    }
}
