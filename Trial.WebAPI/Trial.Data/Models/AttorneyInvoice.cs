using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Data.Models
{
    public class AttorneyInvoice
    {
        public int AttorneyId { get; set; }
        public Attorney Attorney { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public bool IsActive { get; set; }
    }
}
