using BBGCombination.Core.DAL;
using BBGCombination.Core.Entity;
using BBGCombination.Core.Model;
using BBGCombination.Domain.Data.DAL;
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

namespace BBGCombination.Domain.Service
{
  
    public class EmailService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        LoanCustomerDB database = new LoanCustomerDB();
        private readonly DataConnectorContext context;
        /// <summary>
        ///  Calling all Loan Types
        /// </summary>
        public EmailService()
        {
            GetTermLoan();
            GetLeaseLoan();
            GetOverdraftLoan();
        }
        // Send mail for Term Loan
        public static string SendTermLoanEmail(List<CustomerDetails> emailDetail)
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

                   
                    DateTime sampleDate = DateTime.Parse(thisEmailDetail.DueDate);
                  
                    DateTime todayDate = new DateTime();
                    todayDate = DateTime.Now;
                    // var newSpan = (sampleDate - todayDate).Days;
                    var newSpan = 0;
                    logger.Info("No of days to send mail: " + newSpan);

                    //var preConc = (newSpan.TotalDays) / 30;
                    //var calCon = Math.Round(preConc, 0);

                    var stringPath = "";
                    if (newSpan >= 0)
                    {
                        stringPath = path;
                        logger.Info("The No of days and path: ");
                    }
                    else if (newSpan <= 7 && newSpan >= 8)
                    {
                        stringPath = path2;
                        // Logger.Info("Path for one month:" + path);
                    }
                    else if (newSpan <= 14 && newSpan >= 15)
                    {
                        stringPath = path3;
                        //  Logger.Info("Path for Two months or more:" + path2);
                    }
                    else if(newSpan <= 30 && newSpan >= 31)
                    {
                        stringPath = path4;
                    }
                    else if (newSpan <= -1 && newSpan >= -2)
                    {
                        stringPath = path5;
                    }
                    else
                    {
                        ActivityLog ac = new ActivityLog
                        {
                            Activity = "less days or more days",
                            ActivityDate = DateTime.Now
                        };
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
                    MailText = MailText.Replace("{PastDueObligationAmt}", thisEmailDetail.PastDueObligationAmt);
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
       //Send mail - Lease Finance Loan
        public string SendLeaseFinanceLoanEmail(List<CustomerDetails> emailDetail)
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


                    DateTime sampleDate = DateTime.Parse(thisEmailDetail.DueDate);

                    DateTime todayDate = new DateTime();
                    todayDate = DateTime.Now;
                    // var newSpan = (sampleDate - todayDate).Days;
                    var newSpan = 0;
                    logger.Info("No of days to send mail: " + newSpan);
                    var stringPath = "";
                    if (newSpan == 0)
                    {
                        stringPath = path;
                        logger.Info("The No of days equal to zero:" + path);
                        ActivityLog logPath = new ActivityLog
                        {
                            Activity = "",
                            ActivityDate = DateTime.Now
                        };
                        context.Activitylogs.Add(logPath);
                        context.SaveChanges();

                    }
                    else if (newSpan <= 7 && newSpan >= 8)
                    {
                        stringPath = path2;
                        ActivityLog logPath2 = new ActivityLog
                        {
                            Activity = "",
                            ActivityDate = DateTime.Now
                        };
                        context.Activitylogs.Add(logPath2);
                        context.SaveChanges();
                        logger.Info("Path for one month:" + path);
                    }
                    else if (newSpan <= 14 && newSpan >= 15)
                    {
                        stringPath = path3;
                        ActivityLog logPath3 = new ActivityLog
                        {
                            Activity = "",
                            ActivityDate = DateTime.Now
                        };
                        context.Activitylogs.Add(logPath3);
                        context.SaveChanges();
                        logger.Info("Path for one month:" + path);
                    }
                    else if (newSpan <= 30 && newSpan >= 31)
                    {
                        stringPath = path4;
                        ActivityLog logPath4 = new ActivityLog
                        {
                            Activity = "",
                            ActivityDate = DateTime.Now
                        };
                        context.Activitylogs.Add(logPath4);
                        context.SaveChanges();
                    }
                    else if (newSpan <= -1 && newSpan >= -2)
                    {
                        stringPath = path5;
                        ActivityLog logPath5 = new ActivityLog
                        {
                            Activity = "",
                            ActivityDate = DateTime.Now
                        };
                        context.Activitylogs.Add(logPath5);
                        context.SaveChanges();
                    }
                    else
                    {
                        ActivityLog log1 = new ActivityLog
                        {
                            Activity = "",
                            ActivityDate = DateTime.Now
                        };
                        context.Activitylogs.Add(log1);
                        context.SaveChanges();
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

                    ActivityLog log = new ActivityLog
                    {
                        Activity = "",
                        ActivityDate = DateTime.Now
                    };
                    context.Activitylogs.Add(log);
                    context.SaveChanges();
                    logger.Info("");
                }
                catch (Exception ex)
                {
                    Result = "failed" + ex.Message;
                    ErrorLog error = new ErrorLog
                    {
                        ErrorName = "",
                        ErrorDate = DateTime.Now
                    };
                    context.ErrorLogs.Add(error);
                    context.SaveChanges();
                    logger.Info("");
                }
            }
            return null;
        }
        // Send mail - Overdraft Loian
        public static string SendOverdraftLoanEmail(List<CustomerDetails> emailDetail)
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

                    string path = ConfigurationManager.AppSettings["ExpiredTermLoanTemplatePath"]; 
                    string path2 = ConfigurationManager.AppSettings["7daysTermLoanTemplatePath"]; 
                    string path3 = ConfigurationManager.AppSettings["14daysTermLoanTemplatePath"];
                    string path4 = ConfigurationManager.AppSettings["30daysTermLoanTemplatePath"];
                    string path5 = ConfigurationManager.AppSettings["OverdueTermLoanTemplatePath"];
                    string rootPath = Directory.GetCurrentDirectory();


                    DateTime sampleDate = DateTime.Parse(thisEmailDetail.DueDate);

                    DateTime todayDate = new DateTime();
                    todayDate = DateTime.Now;
                    // var newSpan = (sampleDate - todayDate).Days;
                    var newSpan = 0;
                    logger.Info("No of days to send mail: " + newSpan);

                    //var preConc = (newSpan.TotalDays) / 30;
                    //var calCon = Math.Round(preConc, 0);

                    var stringPath = "";
                    if (-newSpan >= 0)
                    {
                        stringPath = path;
                        logger.Info("The No of days and path: ");
                    }
                    else if (newSpan <= 7 && newSpan >= 8)
                    {
                        stringPath = path2;
                        // Logger.Info("Path for one month:" + path);
                    }
                    else if (newSpan <= 14 && newSpan >= 15)
                    {
                        stringPath = path3;
                        //  Logger.Info("Path for Two months or more:" + path2);
                    }
                    else if (newSpan <= 30 && newSpan >= 31)
                    {
                        stringPath = path4;
                    }
                    else if (newSpan <= -1 && newSpan >= -2)
                    {
                        stringPath = path5;
                    }
                    else
                    {
                        ActivityLog ac = new ActivityLog
                        {
                            Activity = "less days or more days",
                            ActivityDate = DateTime.Now
                        };
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
        public string GetTermLoan()
        {
            var result = SendTermLoanEmail(database.GetTermLoanCustomerDetail());
            return result;
        }
        // Send mail Leae Finance Loan Method
        public  string GetLeaseLoan()
        {
            var result2 = SendLeaseFinanceLoanEmail(database.GetLeaseLoanCustomerDetail());
            return result2;
        }
        // Send mail Overdraft Loan Method
        public string GetOverdraftLoan()
        {
            var result3 = SendOverdraftLoanEmail(database.GetOverdraftLoanCustomerDetail());
            return null;
        }
    }
}
