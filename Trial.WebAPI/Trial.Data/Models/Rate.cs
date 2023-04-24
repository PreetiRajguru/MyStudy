using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Data.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public decimal HourlyRate { get; set; }
        public Attorney Attorney { get; set; }
        public Invoice Invoice { get; set; }
    }
}
