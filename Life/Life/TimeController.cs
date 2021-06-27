using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Life
{
    public class TimeController
    {
        private static TimeController time;
        public Timer timer = new Timer(1000);
        public int generation = 1;
        public bool isPaused = false;
        public void Run()
        {
            ;
        }
    }
}
