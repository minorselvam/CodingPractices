using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples.Modals
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public ICollection<InsurancePolicy> InsurancePolicies { get; set; }
    }
}
