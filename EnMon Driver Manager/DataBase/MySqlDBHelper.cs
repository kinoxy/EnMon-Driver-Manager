using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace EnMon_Driver_Manager.DataBase
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="EnMon_Driver_Manager.DataBase.AbstractDBHelper" />
    public class MySqlDBHelper : AbstractDBHelper
    {
        #region Private Properties

        private MySqlConnection conn { get; set; }

        private Object thisLock = new Object();

        #endregion Private Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlDBHelper"/> class.
        /// </summary>
        public MySqlDBHelper() : base()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlDBHelper"/> class.
        /// </summary>
        /// <param name="_serverAddres">The server addres.</param>
        /// <param name="_databaseName">Name of the database.</param>
        /// <param name="_username">The username.</param>
        /// <param name="_password">The password.</param>
        public MySqlDBHelper(string _serverAddres, string _databaseName, string _username, string _password) : this()
        {

            str_serverAddress = _serverAddres;
            str_databaseName = _databaseName;
            str_userName = _username;
            str_password = _password;

            if (conn == null)
            {
                conn = new MySqlConnection(ConnectionString);
            }
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Databases the test connection.
        /// </summary>
        /// <returns></returns>
        public bool DatabaseTestConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(MySqlDBHelper.ConnectionString);
                connection.Open();
                Log.Instance.Info("Database'e baglanıldı.");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Database baglantı hatası: {0}", ex.Message);
                return false;
            }
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Checks and opens the databse connection if it is not already opened.
        /// </summary>
        /// <returns></returns>
        protected override bool OpenConnection()
        {
            // conn olusturulmamıs ise conn'u tanımla
            if (conn == null)
            {
                conn = new MySqlConnection(ConnectionString);
            }

            // database'e baglan
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    
                    IsConnected = true;
                    Log.Instance.Info("Database'e baglanıldı");
                    OnDatabaseConnected();
                }

                if (conn.State == ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    OnDatabaseDisconnected();
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (IsConnected)
                {
                    
                    Log.Instance.Error("Database baglantısı sorunu: {0}", ex.Message);
                    IsConnected = false;
                    OnDatabaseDisconnected();
                }
                return false;
            }
        }

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        /// <returns></returns>
        protected override bool CloseConnection()
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                    Log.Instance.Info("Database baglantısı kesildi.");
                    OnDatabaseDisconnected();
                }

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Fatal("Database baglantısı kesilirken hata olustu: {0}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="_query">The query.</param>
        /// <returns></returns>
        public override int ExecuteNonQuery(string _query)
        {
            try
            {
                if(OpenConnection())
                {

                    lock (thisLock)
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = _query;
                            cmd.Prepare();
                            return cmd.ExecuteNonQuery();
                        } 
                    }
                }
                else
                {
                    throw new Exception("Database baglantısı kurulumadı");
                }
                
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="_query">The query.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override DataTable ExecuteQuery(string _query)
        {
            DataSet ds = new DataSet();
            try
            {
                if (OpenConnection())
                {
                    lock (thisLock)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(_query, conn))
                        {
                            MySqlDataAdapter da = new MySqlDataAdapter();
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            return ds.Tables[0];
                        }  
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Checks the database connection.
        /// </summary>
        /// <returns></returns>
        public override bool CheckDBConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    IsConnected = true;
                    OnDatabaseConnected();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Database Bağlantı Hatası => {0}", ex.Message);
                IsConnected = false;
                OnDatabaseDisconnected();
                return false;
            }
        }

        #endregion Protected Methods

        
    }
}