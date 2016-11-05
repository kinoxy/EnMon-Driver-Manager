using EnMon_Driver_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EnMon_Driver_Manager.Drivers.Mail
{
    class MailClientTimer : IDisposable
    {
        private Timer timer { get; set; }
        private AlarmMail alarmMail { get; set; }
        
        public MailClientTimer(AlarmMail alarmMail)
        {
            this.alarmMail = alarmMail;
            timer = new Timer();
            timer.Interval = alarmMail.Delaytime * 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnTimerElapsed();
        }

        public event TimerElapsedEventHandler TimerElapsed;

        private void OnTimerElapsed()
        {
            MailClientTimerEventArgs args = new MailClientTimerEventArgs();
            args.alarmMail = alarmMail;
            if(TimerElapsed != null)
            {
                TimerElapsed(this, args);
            }
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Dispose()
        {
            ((IDisposable)timer).Dispose();
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TimerElapsedEventHandler'
    public delegate void TimerElapsedEventHandler(object source, MailClientTimerEventArgs args);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TimerElapsedEventHandler'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClientTimerEventArgs'
    public class MailClientTimerEventArgs : EventArgs
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClientTimerEventArgs'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'MailClientTimerEventArgs.alarmMail'
        public AlarmMail alarmMail { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'MailClientTimerEventArgs.alarmMail'
    } 
}
