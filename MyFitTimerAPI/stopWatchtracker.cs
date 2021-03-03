using System;
using System.Collections.Generic;
using System.Text;

namespace MyFitTimerAPI
{
    class stopWatchtracker
    {

        public DateTime startTime { get; private set; }

        public Run LastRun{ get; set; }

        public void start()
        {
            if (startTime == null)
                startTime = DateTime.Now;
        }
        public void stop()
         {
            if (startTime != null)
            {

                LastRun = new Run(DateTime.Now);

            }
            else
                throw new InvalidOperationException("Timer`sSs running");

        }
        public long elapsedMilliseconds { get; }
        public TimeSpan elapsed { get; }
        public long elapsedTicks { get; }
        public bool IsRunning { get; }

    }

    public class Run
    {
        private DateTime dateTime;

        public Run(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }
    }
}
