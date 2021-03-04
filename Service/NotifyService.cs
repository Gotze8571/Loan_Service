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
        public void Start()
        {
            logger.Info("Service Start!!");
            thisTimer = new System.Timers.Timer(1000);
            thisTimer.Enabled = true;
            int timerInterval = 0;
            timerInterval = 1000;
            thisTimer.Interval = timerInterval;
            thisTimer.AutoReset = true;
            thisTimer.Elapsed += thistTimer_Tick;
            thisTimer.Start();
            var result = new EmailService();
        }
        public void Stop()
        {
            logger.Info("Service Stopped!!");
        }
        private void thistTimer_Tick(object sender, ElapsedEventArgs e)
        {
            // call Email Sevice
           // var result = SendEmail(db.GetTermLoanCustomerDetail());
             // var result = new EmailService();
            //var result2 = EmailService.GetLeaseLoan();
            //var result3 = EmailService.GetOverdraftLoan();
            logger.Info("Service running!!");

        }
        
    }
}
