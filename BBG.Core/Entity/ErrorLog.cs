using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG.Core.Entity
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string IPAddress { get; set; }
        public string CustomerName { get; set; }
        public string LoanType { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public decimal OutstandingAmt { get; set; }
        public DateTime ActivityDate { get; set; }
    }
}
