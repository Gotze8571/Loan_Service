using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG.Core.Entity
{
    public class EmailNotificationLog
    {
        public int EnailId { get; set; }
        public string EmailName { get; set; }
        public DateTime EmailSent { get; set; }
        public EmailCount NoOfEmail { get; set; }


    }
}
