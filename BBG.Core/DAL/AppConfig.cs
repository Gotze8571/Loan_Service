using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG.Core.DAL
{
    public class AppConfig
    {
        public bool GetEnvironment()
        {
            var activeData = ConfigurationManager.AppSettings["LiveData"].ToString();
            try
            {
                if (activeData == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;
           
        } 
    }
}
