using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Data.Models
{
    public class Jurisdiction
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AttorneyId { get; set; }

        public Attorney Attorney { get; set; }

        public ICollection<Matter> Matters { get; set; }
    }
}
