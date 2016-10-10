//using EnMon_Driver_Manager.DataBase;
//using IniParser;
//using IniParser.Model;
//using System;
//using System.IO;
//using System.Text;

//namespace EnMon_Driver_Manager
//{
//    internal class StaticHelper
//    {
//        public static AbstractDBHelper initializeDatabase()
//        {
//            if (File.Exists("/Config/DatabaseConfig.ini"))
//            {
//                string _databaseType;
//                string _serverAddress;
//                string _databaseName;
//                string _userName;
//                string _password;
//                var parser = new FileIniDataParser();

//                IniData data = parser.ReadFile("/Config/DatabaseConfig.ini", Encoding.UTF8);

//                var _parameters = data["DataBase Parameters"];

//                foreach (KeyData kd in _parameters)
//                {
//                    switch (kd.KeyName.Trim())
//                    {
//                        case "DatabaseType":
//                            _databaseType = kd.Value.Trim();
//                            break;

//                        case "_serverAddress":
//                            _serverAddress = kd.Value.Trim();
//                            break;

//                        case "PollingTime":
//                            _databaseName = kd.Value.Trim();
//                            break;

//                        case "PortNumber":
//                            _userName = kd.Value.Trim();
//                            break;

//                        case "MaxRegisterInOnePoll":
//                            _password = kd.Value.Trim();
//                            break;

//                        default:
//                            break;
//                            switch (_dbType)
//                            {
//                                case "MySQL":
//                                    return new MySqlDBHelper(_serverAddres, _databaseName, _username, _password);

//                                default:
//                                    Log.Instance.Error("{0} database tipi için driver bulunamadı.", _dbType);
//                                    return null;
//                            }
//                    }
//                } 
//            }
//        }
//    }
//}