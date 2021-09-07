using BBG.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG.Core.Entity
{
    public class EmailCount
    {
        public int EmailNumber { get; set; }
        public Status[] StatusInfo { get; set; }
    }
}
