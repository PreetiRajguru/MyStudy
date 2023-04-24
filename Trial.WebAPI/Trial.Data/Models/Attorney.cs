using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Data.Models
{
    public class Attorney
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Role> Roles { get; set; }

        public int RateId { get; set; }

        public Rate Rate { get; set; }

        public ICollection<Matter> Matters { get; set; }

        public ICollection<Jurisdiction> Jurisdictions { get; set; }

        public ICollection<AttorneyInvoice> AttorneyInvoices { get; set; }

        public bool IsActive { get; set; }

    }
}
