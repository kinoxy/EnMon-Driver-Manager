using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager
{
    public static class Constants
    {
        public static string DatabaseConfigFileLocation
        {
            get { return "Config/DatabaseConfig.ini"; }
        }

        public static string MailclientConfigFileLocation
        {
            get { return "Config/MailClientConfig.ini"; }
        }

        public static string MessageBoxHeader
        {
            get { return "EnMon Sürücü Yöneticisi"; }
        }
    }
}
