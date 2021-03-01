using BBGCombination.Core.DAL;
using BBGCombination.Core.Entity;
using BBGCombination.Core.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BBGCombination.Domain.Service
{
    
    public class EmailService
    {
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
                    if (-newSpan >= 0)
                    {
                        // Logger.Info("The concession has expired:" + newSpan);
                    }

                    else if (newSpan <= 28 && newSpan <= 31)
                    {
                        stringPath = path;
                        // Logger.Info("Path for one month:" + path);
                    }
                    else if (newSpan >= 31 && newSpan >= 33)
                    {
                        stringPath = path2;
                        //  Logger.Info("Path for Two months or more:" + path2);
                    }
                    else
                    {
                        stringPath = path2;
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

        // Send mail Term Loan Method
        public  static string GetTermLoan()
        {
            TermLoan termLoan = new TermLoan();
            LoanCustomerDB db = new LoanCustomerDB();
            CustomerDetails details = new CustomerDetails();

            DateTime todayDate = new DateTime();
            todayDate = DateTime.Now;
            DateTime date = DateTime.Parse(details.DueDate);
            var noOfDays = (date - DateTime.Now).Days;
            int TermLoanNo = 0;

            // Determine noOfDays ie Overdue.. call send mail
            if(noOfDays <= 0 && TermLoanNo == 1)
            {
                // Call send mail
                // SendEmail()
                string path = ConfigurationManager.AppSettings["EmailTemplatePath1"]; 
                 var result = SendEmail(db.GetTermLoanCustomerDetail());
            }
            // Determine noOfDays ie 30days
            if (noOfDays == 30)
            {
                string path = ConfigurationManager.AppSettings["EmailTemplatePath2"];
                // Call send mail mtd
                // var result = SendEmail(db.GetTermLoanCustomerDetail());
            }
            // Determine noOfDays ie 14days
            if (noOfDays == 14)
            {
                string path = ConfigurationManager.AppSettings["EmailTemplatePath1"];
                // var result = SendEmail(db.GetTermLoanCustomerDetail());
            }
            // Determine noOfDays ie 7days
            if (noOfDays == 7)
            {
                // var result = SendEmail(db.GetTermLoanCustomerDetail());
            }
            // Determine noOfDays ie Expired Days.
            if (noOfDays == 0)
            {
                // var result = SendEmail(db.GetTermLoanCustomerDetail());
            }
            // var result = SendEmail(db.GetTermLoanCustomerDetail());

            return null;
        }
        // Send mail Leae Finance Loan Method
        public static string GetLeaseLoan()
        {
            LoanCustomerDB db = new LoanCustomerDB();
            CustomerDetails details = new CustomerDetails();

            DateTime todayDate = new DateTime();
            todayDate = DateTime.Now;
            DateTime date = DateTime.Parse(details.DueDate);
            var noOfDays = (date - DateTime.Now).Days;
            if (noOfDays <= 0)
            {
                // Call send mail
                // SendEmail()
                // var result = SendEmail(db.GetTermLoanCustomerDetail());
            }
            // Determine noOfDays ie 30days
            if (noOfDays == 30)
            {
                // Call send mail mtd
                // var result = SendEmail(db.GetTermLoanCustomerDetail());
            }
            // Determine noOfDays ie 14days
            if (noOfDays == 14)
            {
                // var result = SendEmail(db.GetTermLoanCustomerDetail());
            }
            // Determine noOfDays ie 7days
            if (noOfDays == 7)
            {
                // var result = SendEmail(db.GetTermLoanCustomerDetail());
            }
            // Determine noOfDays ie Expired Days.
            if (noOfDays == 0)
            {
                // var result = SendEmail(db.GetTermLoanCustomerDetail());
            }
            return null;
        }
        // Send mail Overdraft Loan Method
        public static string GetOverdraftLoan()
        {
            LoanCustomerDB db = new LoanCustomerDB();
            CustomerDetails details = new CustomerDetails();

            DateTime todayDate = new DateTime();
            todayDate = DateTime.Now;
            DateTime date = DateTime.Parse(details.DueDate);
            var noOfDays = (date - DateTime.Now).Days;

            // Determine noOfDays ie Expired Days.
            if (noOfDays == 0)
            {
                // var result = SendEmail(db.GetTermLoanCustomerDetail());
            }

            // Determine noOfDays ie Overdue
            if(noOfDays >= 0)
            {
                // var result = SendEmail(db.GetTermLoanCustomerDetail());
            }
            return null;
        }
    }
}
