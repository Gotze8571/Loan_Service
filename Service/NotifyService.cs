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
           
            thisTimer = new System.Timers.Timer();
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
          //  var result = new EmailService();
            //var result2 = EmailService.GetLeaseLoan();
            //var result3 = EmailService.GetOverdraftLoan();

            logger.Info("Service running!!");

        }
        public static string SendEmail(List<CustomerDetails> emailDetail)
        {
            var CcAddress = "";
            var MailSubject = ConfigurationManager.AppSettings["MailSubject"].ToString();
            var IsBodyHtml = true;
            var Result = "";
            SmtpClient obj = new SmtpClient();
            MailMessage msg = new MailMessage();

            foreach (var thisEmailDetail in emailDetail)
            {
                try
                {
                    string DisplayName = ConfigurationManager.AppSettings["DisplayName"].ToString();
                    MailAddress FromAddress = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"], DisplayName);
                    msg.From = FromAddress;

                    string[] temp = null;
                    if (string.IsNullOrEmpty(thisEmailDetail.CustomerEmail))
                    {
                        // Get Customer email to send mail To...
                    }
                    else
                    {
                        // Send mail to the Customer.
                        // msg.To.Add(thisEmailDetail.CustomerEmail);
                        msg.To.Add(ConfigurationManager.AppSettings["EmailRecepient"].ToString());
                        msg.Bcc.Add(ConfigurationManager.AppSettings["EmailBcc"]);
                    }
                    // Email Address to be in the Copy of the mail
                    if (string.IsNullOrEmpty(CcAddress))
                    {
                    }
                    else
                    {
                    }
                    msg.Subject = MailSubject;

                    dynamic emailServer = ConfigurationManager.AppSettings["EmailServer"];

                    string path = ConfigurationManager.AppSettings["EmailTemplatePath1"]; // Directory.GetCurrentDirectory() + "\\EmailTemplate\\ConcessTemp.html";// 
                    string path2 = ConfigurationManager.AppSettings["EmailTemplatePath2"]; //Directory.GetCurrentDirectory() + "\\EmailTemplate\\TwoMonthsConcess.html"; //
                    string path3 = ConfigurationManager.AppSettings["EmailTemplatePath3"];
                    string path4 = ConfigurationManager.AppSettings["EmailTemplatePath4"];
                    string path5 = ConfigurationManager.AppSettings["EmailTemplatePath5"];
                    string rootPath = Directory.GetCurrentDirectory();

                    //calculate duration
                    // DateTime sampleDate = new DateTime(2020, 11, 1);// 9/23/2019
                    DateTime sampleDate = DateTime.Parse(thisEmailDetail.DueDate);
                    // DateTime sampleDate = new DateTime(currentDate);// 9/23/2019\

                    // Console.WriteLine(int.Parse(thisEmailDetail.ExpirationDate));
                    DateTime todayDate = new DateTime();
                    todayDate = DateTime.Now;
                    var newSpan = (sampleDate - todayDate).Days;

                    //var preConc = (newSpan.TotalDays) / 30;
                    //var calCon = Math.Round(preConc, 0);

                    var stringPath = "";
                    if (newSpan == 0)
                    {
                        stringPath = path;
                        // Logger.Info("The concession has expired:" + newSpan);
                    }
                    else if (newSpan == 7)
                    {
                        stringPath = path2;
                        // Logger.Info("Path for one month:" + path);
                    }
                    else if (newSpan == 14)
                    {
                        stringPath = path3;
                        //  Logger.Info("Path for Two months or more:" + path2);
                    }
                    else if (newSpan == 30)
                    {
                        stringPath = path4;
                    }
                    else if (newSpan >= -1)
                    {
                        stringPath = path5;
                    }
                    else
                    {

                    }

                    StreamReader str = new StreamReader(stringPath);
                    string MailText = str.ReadToEnd();
                    str.Close();
                    MailText = MailText.Replace("{CustomerName}", thisEmailDetail.AccountName);
                    MailText = MailText.Replace("{AccountNumber}", thisEmailDetail.AccountNumber);
                    MailText = MailText.Replace("{DueDate}", thisEmailDetail.DueDate);
                    //MailText = MailText.Replace("{DueAmt}", Double.Parse(thisEmailDetail.DueAmt).ToString());
                    //MailText = MailText.Replace("{DueInDays}", thisEmailDetail.DueInDays);
                    //MailText = MailText.Replace("{OutstandingAmt}", Double.Parse(thisEmailDetail.OutstandingAmt).ToString());
                    // MailText = MailText.Replace("{PastDueObligationAmt}", thisEmailDetail.PastDueObligationAmt);
                    MailText = MailText.Replace("{CustomerEmail}", thisEmailDetail.CustomerEmail);
                    MailText = MailText.Replace("{ExcessAmt}", thisEmailDetail.ExcessAmt);
                    MailText = MailText.Replace("{AgreeMonthlyVol}", thisEmailDetail.AgreeMonthlyVol);

                    AlternateView plainView = AlternateView.CreateAlternateViewFromString(MailText, null, "text/html");

                    var fileName = stringPath;
                    if (IsBodyHtml == true)
                    {
                        msg.AlternateViews.Add(plainView);
                    }

                    msg.IsBodyHtml = IsBodyHtml;
                    obj.Host = emailServer;
                    obj.Send(msg);
                    Result = "Successful";
                    //Logger.Info("The mail is: " + Result);
                }
                catch (Exception ex)
                {
                    Result = "failed" + ex.Message;
                }
            }
            return null;
        }
        public static bool ValidateEmail(string email)
        {
            bool emailValidated = false;
            if (Regex.IsMatch(email, "^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$"))
            {
                emailValidated = true;
            }
            return emailValidated;
        }
    }
}
