using System;
using System.Collections.Generic;
using EnMon_Driver_Manager.Models;
using EnMon_Driver_Manager.Models.ArchivePeriods;

namespace EnMon_Driver_Manager.Drivers.Archiving
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ArchiveToDatabase'
    public class ArchiveToDatabase : AbstractArchiving
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ArchiveToDatabase'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ArchiveToDatabase.ArchiveToDatabase()'
        public ArchiveToDatabase() : base()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ArchiveToDatabase.ArchiveToDatabase()'
        {
           
            try
            {
                // Database baglantısı olusturuluyor
                DBHelper_Archive = StaticHelper.InitializeDatabase(Constants.DatabaseConfigFileLocation);
                if (DBHelper_Archive != null)
                {
                    ArchivingStarted = StartArchiving();
                }
                else
                {
                    Log.Instance.Error("{0}: Archiving sürücü hatası: Database baglantısı olusturulamadı. Sürücü başlatılamıyor", this.GetType().Name);
                    ArchivingStarted = false;
                     
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Archiving sürücü hatası. Sürücü başlatılamıyor => {1}", this.GetType().Name, ex.Message);
                ArchivingStarted = false;

            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ArchiveToDatabase.ArchiveValues(uint)'
        protected override void ArchiveValues(uint _periodID)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ArchiveToDatabase.ArchiveValues(uint)'
        {
            try
            {
                DBHelper_Archive.SaveValuesToArchive(_periodID);
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Archiving sürücü hatası: {0} nolu arşiv grubu için kayıt yapılamadı => {1}", _periodID.ToString(), ex.Message);
            }
        }

        /// <summary>
        /// Gets the archive periods.
        /// </summary>
        /// <returns></returns>
        protected override List<ArchivePeriod> getArchivePeriods()
        {
            try
            {
                List<ArchivePeriod> _archivePeriods;
                _archivePeriods = DBHelper_Archive.GetArchivePeriods();
                return _archivePeriods;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("Archiving sürücü hatası => {0} ", ex.Message);
                return null;
            }
        }
    }
}
