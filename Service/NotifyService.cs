using BBGCombination.Core.Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBGCombination.Domain.Service
{
    public class NotifyService
    {
        CustomerDetails details = new CustomerDetails();
        public System.Timers.Timer thisTimer;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public void Start()
        {
           
            thisTimer = new System.Timers.Timer();
            thisTimer.Enabled = true;
            int timerInterval = 0;
            timerInterval = 1000;
            thisTimer.Interval = timerInterval;
            thisTimer.AutoReset = true;
            thisTimer.Elapsed += thistTimer_Tick;
            thisTimer.Start();
        }
        public void Stop()
        {
            logger.Info("Service Stopped!!");
        }
        private void thistTimer_Tick(System.Object sender, System.EventArgs e)
        {
            // call Email Sevice
            var result = EmailService.GetTermLoan();
            var result2 = EmailService.GetLeaseLoan();
            var result3 = EmailService.GetOverdraftLoan();
            logger.Info("Service running!!");

        }
    }
}
