using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using EnMon_Driver_Manager.Models.ArchivePeriods;

namespace EnMon_Driver_Manager.Drivers.Archiving
{
    public abstract class AbstractArchiving
    {
        protected AbstractDBHelper DBHelper_Archive { get; set; }

        protected List<ArchivePeriod> periods;

        protected List<PollingTimer> archiveTimers;

        public bool ArchivingStarted;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractArchiving"/> class.
        /// </summary>
        /// <param name="_databasetype">The databasetype.</param>
        public AbstractArchiving()
        {
        }

        protected bool StartArchiving()
        {
            try
            {
                periods = getArchivePeriods();
                if (periods != null)
                {
                    archiveTimers = new List<PollingTimer>();
                    foreach (ArchivePeriod period in periods)
                    {
                        PollingTimer timer = new PollingTimer();
                        timer.PeriodID = period.ID;
                        timer.Interval = period.Period * 1000;
                        timer.AutoReset = true;
                        timer.Enabled = true;
                        timer.Elapsed += timer_Archive;
                        timer.Start();
                        archiveTimers.Add(timer);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Instance.Error("{0}: Archiving sürücü hatası. Sürücü başlatılamıyor => {1}", this.GetType().Name, ex.Message);
                return false;
            }
        }

        private void timer_Archive(object sender, ElapsedEventArgs e)
        {
            Task t1 = Task.Factory.StartNew(() =>
                {
                    uint _periodID = ((PollingTimer)sender).PeriodID;
                    Log.Instance.Trace("{0} nolu archive periyodundaki sinyallerin degerleri kaydediliyor", _periodID.ToString());
                    ArchiveValues(_periodID);
                }
            );
        }

        protected abstract void ArchiveValues(uint _periodID);

        /// <summary>
        /// Gets the archive periods.
        /// </summary>
        /// <returns>Return null if there is no period</returns>
        protected abstract List<ArchivePeriod> getArchivePeriods();
    }
}