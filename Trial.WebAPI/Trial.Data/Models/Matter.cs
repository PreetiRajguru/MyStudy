using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Data.Models
{
    public class Matter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime RegisteredDate { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int JuridictionId { get; set; }
        public Jurisdiction Jurisdiction { get; set; }

        public int BillingAttorneyId { get; set; }

        public int ResponsibleAttorneyId { get; set; }

        public Attorney BillingAttorney { get; set; }

        public Attorney ResponsibleAttorney { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        public bool IsActive { get; set; }
    }
}
