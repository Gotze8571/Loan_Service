using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG.Core.Entity
{
    public class Overdraft
    {
        public int OverdraftId { get; set; }
        public string OverdraftType { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime DueDate { get; set; }
        public decimal CurrentOustandingAmount { get; set; }
        public decimal TotalOustandingAmount { get; set; }
    }
}
