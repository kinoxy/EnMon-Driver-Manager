using EnMon_Driver_Manager.DataBase;
using IniParser;
using IniParser.Model;
using System.IO;
using System.Reflection;
using System.Text;
using System;
using EnMon_Driver_Manager.Drivers.Mail;

namespace EnMon_Driver_Manager
{
    public class StaticHelper
    {
        public static AbstractDBHelper InitializeDatabase(string _fileName)
        {
            if (File.Exists(_fileName))
            {
                string _databaseType = string.Empty;
                string _serverAddress = string.Empty;
                string _databaseName = string.Empty;
                string _userName = string.Empty;
                string _password = string.Empty;
                var parser = new FileIniDataParser();

                IniData data = parser.ReadFile(_fileName, Encoding.UTF8);

                var _parameters = data["DataBase Parameters"];

                foreach (KeyData kd in _parameters)
                {
                    switch (kd.KeyName.Trim())
                    {
                        case "DatabaseType":
                            _databaseType = kd.Value.Trim();
                            break;

                        case "ServerAddress":
                            _serverAddress = kd.Value.Trim();
                            break;

                        case "DatabaseName":
                            _databaseName = kd.Value.Trim();
                            break;

                        case "UserName":
                            _userName = kd.Value.Trim();
                            break;

                        case "Password":
                            _password = kd.Value.Trim();
                            break;

                        default:
                            break;
                    }
                }
                if (_databaseType != string.Empty & _serverAddress != string.Empty & _databaseType != string.Empty & _userName != string.Empty & _password !=  string.Empty)
                {
                    switch (_databaseType)
                    {
                        case "MySQL":
                            return new MySqlDBHelper(_serverAddress, _databaseName, _userName, _password);

                        default:
                            Log.Instance.Error("{0} database tipi için driver bulunamadı.", _databaseType);
                            return null;
                    } 
                }
                else
                {
                    Log.Instance.Trace("{0}",MethodBase.GetCurrentMethod().Name);
                    Log.Instance.Error("Database baglantısı olusturulamadı");
                    return null;
                }
                
            }
            else
            {
                Log.Instance.Error("MailClient config dosyası okunamadı");
                return null;
            }
        }

        public static MailClient InitializeMailClient(string _fileName)
        {
            if (File.Exists(_fileName))
            {
                string _mailServerName = string.Empty;
                string _mailServerPort = string.Empty;
                string _userName = string.Empty;
                string _password = string.Empty;

                var parser = new FileIniDataParser();

                IniData data = parser.ReadFile(_fileName, Encoding.UTF8);

                var _parameters = data["MailClient Parameters"];

                foreach (KeyData kd in _parameters)
                {
                    switch (kd.KeyName.Trim())
                    {
                        case "MailServerName":
                            _mailServerName = kd.Value.Trim();
                            break;

                        case "MailServerPort":
                            _mailServerPort = kd.Value.Trim();
                            break;

                        case "UserName":
                            _userName = kd.Value.Trim();
                            break;

                        case "Password":
                            _password = kd.Value.Trim();
                            break;

                        case "MaxRegisterInOnePoll":
                            _password = kd.Value.Trim();
                            break;

                        default:
                            break;
                    }
                }
                if (_mailServerName != string.Empty & _mailServerPort!= string.Empty & _userName!= string.Empty & _password!= string.Empty)
                {
                    return new MailClient(_mailServerName, _mailServerPort, _userName, _password);
                }
                else
                {
                    Log.Instance.Trace("{0}", MethodBase.GetCurrentMethod().Name);
                    Log.Instance.Error("Eksik parametre hatası. MailClient config dosyasını kontrol ediniz.");
                    return null;
                }

            }
            else
            {
                Log.Instance.Error("MailClient config dosyası okunamadı");
                return null;
            }
        }

    }
}
