using System;

namespace EnMon_Driver_Manager
{

    public static class Constants

    {

        public static string DatabaseConfigFileLocation

        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "/Config/DatabaseConfig.ini"; }
        }


        public static string MailClientConfigFileLocation

        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "Config/MailClientConfig.ini"; }
        }

        public static string ModbusTCPDriverConfigFileLocation

        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "Config/ModbusTCPConfig.ini"; }
        }


        public static string MessageBoxHeader

        {
            get { return "EnMon Sürücü Yöneticisi"; }
        }
    }
}
