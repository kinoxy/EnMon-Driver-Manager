using EnMon_Driver_Manager.DataBase;
using IniParser;
using IniParser.Model;
using System.IO;
using System.Reflection;
using System.Text;
using System;
using EnMon_Driver_Manager.Drivers.Mail;
using System.Collections.Generic;
using EnMon_Driver_Manager.Forms;
using System.Windows.Forms;

namespace EnMon_Driver_Manager
{

    public static class StaticHelper
    {
        public static string DatabaseType { get; set; }
        public static string ServerAddress { get; set; }
        public static string DatabaseName { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }

        private static  AbstractDBHelper DBHelper;
        public static AbstractDBHelper InitializeDatabase(string _fileName)
       {
            InitializeDatabaseConnectionStringProperties();
            try
            {
                // Databaseconfig dosyası mevcutsa veritabanı bağlantı bilgileri dosyadan okunarak veritabanına bağlanmaya çalışılır.
                if (File.Exists(_fileName))
                {
                    ReadDatabaseConnectionStringPropertiesFromFile(_fileName);

                    // Databaseconfig dosyasından okunan bilgiler ile veritabanına bağlanılamaz ise kullanıcadan yeni bilgiler istenir.
                    if(!TryConnectToDatabase())
                    {
                        Log.Instance.Warn("Databaseconfig dosyasından okunan veriler ile database bağlantısı kurulamadı.Kullanıcıdan veritabanı bağlantısı için gerekli bilgiler isteniyor...");
                        MessageBox.Show("Veritabanı bağlantısı kurulumadı.\nBağlantı bilgilerini kontrol ederek tekrardan veritabanına bağlanmayı deneyiniz.", Constants.MessageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Kullanıcıdan veritabanı bilgileri istenir
                        if (GetDatabaseConnectionInfoFromUser(DatabaseType, DatabaseName, ServerAddress, UserName, Password))
                        {
                            // Kullanıcı veritabanı bilgilerini girdiyse tekrardan bağlantı kurma denenir.
                            TryConnectToDatabase();
                        }
                    }

                    return DBHelper;
                }
                else
                {
                    Log.Instance.Warn("Database config dosyası bulunamadı. Kullanıcıdan veritabanı bağlantısı için gerekli bilgiler isteniyor...");
                    if(GetDatabaseConnectionInfoFromUser())
                    {
                        TryConnectToDatabase();
                    }
                    
                    return DBHelper;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Veritabanı bağlantısı oluşturulamadı => {1}", "StaticHelper", ex.Message);
                return null;
            }
        }

        private static bool GetDatabaseConnectionInfoFromUser(string databaseType, string databaseName, string serverAddress, string userName, string password)
        {
            frm_GetDatabaseConnectionProperties form = new frm_GetDatabaseConnectionProperties(databaseType, databaseName, serverAddress, userName, password);
            form.FormSubmitted += GetDatabaseConnectionPropertiesFromForm;
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK) return true;
            return false;
        }

        private static bool GetDatabaseConnectionInfoFromUser()
        {
            frm_GetDatabaseConnectionProperties form = new frm_GetDatabaseConnectionProperties();
            form.FormSubmitted += GetDatabaseConnectionPropertiesFromForm;
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK) return true;
            return false;
        }

        private static void GetDatabaseConnectionPropertiesFromForm(object source, frm_GetDatabaseConnectionPropertiesEventArgs e)
        {
            DatabaseName = e.DatabaseName;
            DatabaseType = e.DataBaseType;
            ServerAddress = e.ServerAddress;
            UserName = e.UserName;
            Password = e.Password;
        }

        private static bool TryConnectToDatabase()
        {
            if (DatabaseType != string.Empty & ServerAddress != string.Empty & DatabaseName != string.Empty & UserName != string.Empty & Password != string.Empty)
            {
                switch (DatabaseType)
                {
                    case "MySQL":

                        try
                        {
                            DBHelper = new MySqlDBHelper(ServerAddress, DatabaseName, UserName, Password);
                            // DBHelper null değilse veritabanı bağlantısı kurulmuştur.
                            if (DBHelper != null) return DBHelper.CheckDBConnection();
                            return false;
                        }
                        catch (Exception ex)
                        {
                            Log.Instance.Error("{0}: Veritabanı bağlantısı kurulumu esnasında hata oluştu => {1}", "StaticHelper", ex.Message);
                            return false;
                        }

                    default:
                        Log.Instance.Error("{0} database tipi için driver bulunamadı.", DatabaseType);
                        return false;
                }
            }
            return false;
        }

        private static void ReadDatabaseConnectionStringPropertiesFromFile(string _fileName)
        {
            var parser = new FileIniDataParser();

            IniData data = parser.ReadFile(_fileName, Encoding.UTF8);

            var _parameters = data["DataBase Parameters"];

            foreach (KeyData kd in _parameters)
            {
                switch (kd.KeyName.Trim())
                {
                    case "DatabaseType":
                        DatabaseType = kd.Value.Trim();
                        break;

                    case "ServerAddress":
                        ServerAddress = kd.Value.Trim();
                        break;

                    case "DatabaseName":
                        DatabaseName = kd.Value.Trim();
                        break;

                    case "UserName":
                        UserName = kd.Value.Trim();
                        break;

                    case "Password":
                        Password = kd.Value.Trim();
                        break;

                    default:
                        break;
                }
            }
        }

        private static void InitializeDatabaseConnectionStringProperties()
        {
            DatabaseType = string.Empty;
            ServerAddress = string.Empty;
            DatabaseName = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
        }

        public static MailClient InitializeMailClient(string _fileName)
        {
            if (File.Exists(_fileName))
            {
                string _mailServerName = string.Empty;
                string _mailServerPort = string.Empty;
                string _userName = string.Empty;
                string _password = string.Empty;
                string _fromMailAddress = string.Empty;
                bool _useSSL = false;

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

                        case "MailAddress":
                            _fromMailAddress = kd.Value.Trim();
                            break;
                        case "EnableSLL":
                            _useSSL = kd.Value.Trim() == "TRUE" ? true : false;
                            break;
                        default:
                            break;
                    }
                }
                if (_mailServerName != string.Empty & _mailServerPort!= string.Empty & _userName!= string.Empty & _password!= string.Empty & _fromMailAddress != string.Empty)
                {
                    return new MailClient(_mailServerName, _mailServerPort, _userName, _password, _fromMailAddress, _useSSL);
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'StaticHelper.GetStringsBetweenGivenChar(string, char)'
        public static List<string> GetStringsBetweenGivenChar(string text, char v)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'StaticHelper.GetStringsBetweenGivenChar(string, char)'
        {
            List<string> strings = new List<string>();
            int c = 0;
            while (c != text.Length)
            {
                if (text[c] == v)
                {
                    int startPosition = ++c;
                    while (text[c] != v)
                    {
                        ++c;
                    }
                    strings.Add(text.Substring(startPosition, c - startPosition));
                }
                ++c;
            }

            return strings;
        }

    }
}
