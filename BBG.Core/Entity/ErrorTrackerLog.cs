using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG.Core.Entity
{
    public class ErrorTrackerLog
    {
        [Key]
        public int Id { get; set; }
        public string ErrorMesage { get; set; }
        public string CustomerError{ get; set; }
    }
}
