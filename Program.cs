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
            HostFactory.Run(hostConfig =>
            {
                hostConfig.Service<NotifyService>(serviceConfig =>
                {
                    serviceConfig.ConstructUsing(() => new NotifyService());
                    serviceConfig.WhenStarted(s => s.Start());
                    serviceConfig.WhenStopped(s => s.Stop());
                });
            });
            Console.WriteLine("The Service is Working!!");
            Console.ReadLine();
        }
    }
}