using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.MysqlHelper
{
    public class ConnectionString
    {
        #region Variables

        public int connectionAttemps = 3;

        public bool allowUserVariables = true;

        public int connectionSleep = 50;

        /// <summary>
        /// Database'den cevap gelmesi için beklenen Timeout süresi
        /// </summary>
        public uint connectionTimeout = 5000;

        /// <summary>
        /// Database bağlantısı için gerekli password
        /// </summary>
        public string password;

        /// <summary>
        /// Mysql database'a login olabilmek için kullanıcı adı
        /// </summary>
        public string username;

        /// <summary>
        /// Mysql database bağlantısının gerçekleştirlecegi server adı veya ip adresi
        /// </summary>
        public string server;

        /// <summary>
        /// Database adı
        /// </summary>
        public string dbname;

        /// <summary>
        /// Mysql database bağlantısı için kullanılan port numarası
        /// </summary>
        public uint port = 3306;

        public bool pooling = false;

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_server">Server host adı ya da ip adresii</param>
        /// <param name="_dbname">Database adı</param>
        /// <param name="_username">Kullanıcı adı</param>
        /// <param name="_password">Şifre</param>
        public ConnectionString(string _server, string _dbname, string _username, string _password)
        {
            server = _server;
            dbname = _dbname;
            username = _username;
            password = _password;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Database baglantısı icin connection string dondurur</returns>
        public override string ToString()
        {
            return "Server=" + server +
            ";Port=" + port.ToString() +
            ";Uid=" + username +
            ";Pwd=" + password +
            ";ConnectionTimeout=" + connectionTimeout.ToString() +
            ";Pooling=" + pooling.ToString();
        }

    }
}
