using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG.Core.Entity
{
    public class LeaseFinance
    {
        public int LeaseId { get; set; }
        public string LeaseType { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime DueDate { get; set; }
        public decimal OutstandingAmt { get; set; }
        public decimal TotalOustandingAmt { get; set; }
    }
}
