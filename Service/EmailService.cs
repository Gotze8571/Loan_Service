using BBGCombination.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBGCombination.Domain.Service
{
    
    public class EmailService
    {
        // Send mail Term Loan Method
        public static string GetTermLoan()
        {
            TermLoan termLoan = new TermLoan();
            //Determine Term Loan of noOfDays = ExpiredDate(finacle) - Date.Now(presentDay).
           // DateTime noOfDays = termLoan.DueDate - DateTime.Now;
          // var ExpiredDate = "";// from Finacle.
           

            return null;
        }
        // Send mail Leae Finance Loan Method

        // Send mail Overdraft Loan Method
    }
}
