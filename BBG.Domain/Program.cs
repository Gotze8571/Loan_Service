using BBGCombination.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace BBGCombination.Domain
{
    public class Program
    {
        static void Main(string[] args)
        {
            //HostFactory.Run(hostConfig =>
            //{
            //    hostConfig.Service<NotifyService>(serviceConfig =>
            //    {
            //        serviceConfig.ConstructUsing(() => new NotifyService());
            //        serviceConfig.WhenStarted(s => s.Start());
            //        serviceConfig.WhenStopped(s => s.Stop());
            //    });
            //});
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<EmailService>(s =>
                {
                    s.ConstructUsing(v => new EmailService());
                    s.WhenStarted(v => v.Start());
                    s.WhenStopped(v => v.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("BBGLoanCombinationService");
                x.SetDisplayName("BBGLoan Service");
                x.SetDescription("This is the BBG Loan Combination Service used to notify Customers.");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode =  exitCodeValue;

            Console.WriteLine("The Service is Working!!");
            Console.ReadLine();
        }
    }
}