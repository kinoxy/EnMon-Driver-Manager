using EnMon_Driver_Manager.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Drivers.Archiving
{
    abstract class AbstractArchive
    {
        protected AbstractDBHelper dbHelper { get; set; }

        protected List<int> periods;

        public enum DataBaseTypes
        {
            MySql,
            Mssql,
            Oracle
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractArchive"/> class.
        /// </summary>
        /// <param name="_databasetype">The databasetype.</param>
        public AbstractArchive(DataBaseTypes db)
        {
            switch(db)
            {
                case DataBaseTypes.MySql:
                    dbHelper = new MySqlDBHelper();
                    break;
                default:
                    break;
            }
                
            periods = getArchivePeriods();
        }

        protected abstract List<int> getArchivePeriods();


    }
}
