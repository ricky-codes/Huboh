using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Huboh.FolderWatcher.Main
{
    public class NotificationTimer
    {
        private System.Timers.Timer _notificationTimer;

        public NotificationTimer()
        {

        }

        public void CreateTimer(int timerInterval)
        {
            _notificationTimer = new System.Timers.Timer();
            _notificationTimer.Interval = timerInterval;

        }

        public void StopTimer()
        {
            _notificationTimer.Stop();
        }

        public void ResetTimer()
        {
            _notificationTimer.Stop();
            _notificationTimer.Start();
        }


        public event ElapsedEventHandler TimerElapsed
        {
            add
            {
                _notificationTimer.Elapsed += value;
            }
            remove
            {
                _notificationTimer.Elapsed -= value;
            }
        }
    }
}
