using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples.Modals
{
    public class InsurancePolicy
    {
        public int InsurancePolicyId { get; set; }
        public string PolicyNumber { get; set; }
        public decimal InsuredAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
