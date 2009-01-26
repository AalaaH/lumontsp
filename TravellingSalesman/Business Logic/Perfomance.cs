using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TravellingSalesman.Business_Logic
{
    public sealed class Timer
    {
        Stopwatch stopWatch = new Stopwatch();
        private static Timer _timer = null;


        public static Timer instance
        {
            get
            {
                if (_timer == null) return _timer = new Timer();
                return _timer;
            }
        }

        private Timer()
        {
        }

        public void Start() 
        {
        stopWatch.Reset();    
        stopWatch.Start();
        }

        public void Stop() 
        {
            stopWatch.Stop();
        }
        public void Pause()
        {
            if (stopWatch.IsRunning)
                stopWatch.Stop();
            else
                stopWatch.Start();
        }

        public string elapsedTime()
        {
            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            return (elapsedTime);
        }
        

        
        
    }
}
