using System;
using System.Collections.Generic;
using System.Text;


namespace MyFitTimerAPI
{
    public class StopWatchTracker
    {

        public DateTime? StartTime { get; private set; }

        public TimeSpan LastRun{ get; set; }

        public void Start()
        {
            if (StartTime == null)
                StartTime = DateTime.Now;
			else
				throw new InvalidOperationException("Timer already started");
		}
        public void Stop()
         {
            if (StartTime != null)
            {
                LastRun = DateTime.Now - StartTime.Value;
				StartTime = null;
            }
            else
                throw new InvalidOperationException("Timer not started");

        }
        public long ElapsedMilliseconds { get { return StartTime == null ? 0 : (long)(DateTime.Now - StartTime.Value).TotalMilliseconds; } }

        public TimeSpan Elapsed { get { return StartTime == null ? TimeSpan.Zero : DateTime.Now - StartTime.Value; } }
        public bool IsRunning {	get	{ return StartTime != null;	} }

    }
}
