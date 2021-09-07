using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG.Core.Entity
{
    public class TermLoan
    {
        [Key]
        public int Id { get; set; }
        public string Loantype { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime DueDate { get; set; }
        public decimal OutstandingAmt { get; set; }
        public decimal OutstandingBalance { get; set; }
    }
}
