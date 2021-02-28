using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBGCombination.Domain.Service
{
    public class NotifyService
    {
        public System.Timers.Timer thisTimer;
        public void Start()
        {
            // call Email Sevice
            thisTimer = new System.Timers.Timer();
            thisTimer.Enabled = true;
            int timerInterval = 0;
            timerInterval = 10800;
            thisTimer.Interval = timerInterval;
            thisTimer.AutoReset = true;
            thisTimer.Elapsed += thistTimer_Tick;
            thisTimer.Start();
        }
        public void Stop()
        {

        }
        private void thistTimer_Tick(System.Object sender, System.EventArgs e)
        {

        }
    }
}
