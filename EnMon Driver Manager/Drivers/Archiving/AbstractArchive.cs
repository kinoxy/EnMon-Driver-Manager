using EnMon_Driver_Manager.DataBase;
using EnMon_Driver_Manager.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using EnMon_Driver_Manager.Models.ArchivePeriods;

namespace EnMon_Driver_Manager.Drivers.Archiving
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving'
    public abstract class AbstractArchiving
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving.DBHelper_Archive'
        protected AbstractDBHelper DBHelper_Archive { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving.DBHelper_Archive'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving.periods'
        protected List<ArchivePeriod> periods;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving.periods'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving.archiveTimers'
        protected List<PollingTimer> archiveTimers;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving.archiveTimers'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving.ArchivingStarted'
        public bool ArchivingStarted;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving.ArchivingStarted'

#pragma warning disable CS1572 // XML comment has a param tag for '_databasetype', but there is no parameter by that name
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractArchiving"/> class.
        /// </summary>
        /// <param name="_databasetype">The databasetype.</param>
        public AbstractArchiving()
#pragma warning restore CS1572 // XML comment has a param tag for '_databasetype', but there is no parameter by that name
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving.StartArchiving()'
        protected bool StartArchiving()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving.StartArchiving()'
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving.ArchiveValues(uint)'
        protected abstract void ArchiveValues(uint _periodID);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AbstractArchiving.ArchiveValues(uint)'

        /// <summary>
        /// Gets the archive periods.
        /// </summary>
        /// <returns>Return null if there is no period</returns>
        protected abstract List<ArchivePeriod> getArchivePeriods();
    }
}