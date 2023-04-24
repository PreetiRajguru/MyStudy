using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int RateId { get; set; }

        public Rate Rate { get; set; }

        public decimal HoursSpent { get; set; }

        public decimal TotalAmount => Rate?.HourlyRate * HoursSpent ?? 0;

        public int MatterId { get; set; }

        public Matter Matter { get; set; }

        public ICollection<AttorneyInvoice> AttorneyInvoices { get; set; }

        public bool IsActive { get; set; }
    }
}
