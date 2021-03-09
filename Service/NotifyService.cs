using BBGCombination.Core.DAL;
using BBGCombination.Core.Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace BBGCombination.Domain.Service
{
    public class NotifyService
    {
        CustomerDetails details = new CustomerDetails();
        LoanCustomerDB db = new LoanCustomerDB();
        public System.Timers.Timer thisTimer;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public NotifyService()
        {
            thisTimer = new Timer(1000)
            {
                AutoReset = true
            };
            thisTimer.Elapsed += thistTimer_Tick;
        }
        public void Start()
        {
            logger.Info("Service Start!!");
            //thisTimer = new System.Timers.Timer(1000);
            //thisTimer.Enabled = true;
            //int timerInterval = 0;
            //timerInterval = 1000;
            //thisTimer.Interval = timerInterval;
            //thisTimer.AutoReset = true;
            //thisTimer.Elapsed += thistTimer_Tick;
            thisTimer.Start();
           
        }
        public void Stop()
        {
            //thisTimer.AutoReset = false;
            //thisTimer.Enabled = false;
            thisTimer.Stop();
            logger.Info("Service Stopped!!");
        }
        private void thistTimer_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                // call Email Sevice
                logger.Info("Service running!!");
                var result = new EmailService();
                thisTimer.Stop();
                thisTimer.Dispose();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
