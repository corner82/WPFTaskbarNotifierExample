using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utill
{
    public class ThreadHelper
    {
        public ThreadHelper()
        {

        }

        public static void Wait(double seconds, Action action)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = (int)(seconds * 1000.0);
            timer.Elapsed += (s, o) => {
                timer.Enabled = false;
                timer.Dispose();
                action();
            };
            timer.Enabled = true;
        }
    }
}
