using BBG.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG.Core.DAL
{
    public class LoanOfferDb
    {
        public List<TermLoan> GetTermLoans()
        {

            try
            {
                if (AppConfig == "Y")
                {

                }
                else
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
           
            return null;
        }

        public List<LeaseFinance> GetLeaseFinances()
        {
            return null;
        }
        public List<Overdraft> GetOverdraft()
        {
            return null;
        }
    }
}
