using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.MysqlHelper
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConnectionString'
    public class ConnectionString
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConnectionString'
    {
        #region Variables

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConnectionString.connectionAttemps'
        public int connectionAttemps = 3;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConnectionString.connectionAttemps'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConnectionString.allowUserVariables'
        public bool allowUserVariables = true;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConnectionString.allowUserVariables'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConnectionString.connectionSleep'
        public int connectionSleep = 50;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConnectionString.connectionSleep'

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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ConnectionString.pooling'
        public bool pooling = false;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ConnectionString.pooling'

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
