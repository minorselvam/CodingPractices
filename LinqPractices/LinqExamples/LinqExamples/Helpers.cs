using LinqExamples.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace LinqExamples
{
    public static class Helpers
    {
        public static void LoadData()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    CustomerId = 1,
                    Name = "Alice",
                    InsurancePolicies = new List<InsurancePolicy>()
                },
                new Customer
                {
                    CustomerId = 2,
                    Name = "Bob",
                    InsurancePolicies = new List<InsurancePolicy>()
                },
                new Customer
                {
                    CustomerId = 3,
                    Name = "Charlie",
                    InsurancePolicies = new List<InsurancePolicy>()
                }
            };

            var policies = new List<InsurancePolicy>
            {
                new InsurancePolicy { InsurancePolicyId = 1, PolicyNumber = "P1001", InsuredAmount = 50000, CustomerId = 1 },
                new InsurancePolicy { InsurancePolicyId = 2, PolicyNumber = "P1002", InsuredAmount = 150000, CustomerId = 1 },
                new InsurancePolicy { InsurancePolicyId = 3, PolicyNumber = "P1003", InsuredAmount = 200000, CustomerId = 2 },
                new InsurancePolicy { InsurancePolicyId = 4, PolicyNumber = "P1004", InsuredAmount = 300000, CustomerId = 2 },
                new InsurancePolicy { InsurancePolicyId = 5, PolicyNumber = "P1005", InsuredAmount = 75000, CustomerId = 3 }
            };

            // Link policies to customers for navigation property
            foreach (var customer in customers)
            {
                customer.InsurancePolicies = policies.Where(p => p.CustomerId == customer.CustomerId).ToList();
            }
            foreach (var policy in policies)
            {
                policy.Customer = customers.FirstOrDefault(c => c.CustomerId == policy.CustomerId);
            }

            //Get the list of insurances by a customer (e.g., Alice)
            var policiesByCustomer = policies.Where(p => p.CustomerId == 2).ToList();

            //Get total insured amount by a customer
            var totalInsuredAmountByCustomer = policies.Where(p => p.CustomerId == 2).Sum(p => p.InsuredAmount);

            //Group insurances by customer
            var policiesGroupByCustomer = policies
                .GroupBy(p => p.CustomerId)
                .Select(g => new
                {
                    CustomerName = g.Key,
                    TotalInsured = g.Sum(p=> p.InsuredAmount),
                    Policies = g.ToList()
                }).ToList();

            var groupByCustomerPolicies = policies.GroupBy(p => p.CustomerId)
                .Select(g => new
                {
                    CustomerName = customers.First(c=> c.CustomerId==g.Key).Name,
                    TotalInsured = g.Sum(p => p.InsuredAmount),
                    Policies = g.ToList()
                }).ToList();

            //Select only specific columns from a collection
            var data = policies.Select(p => new {
                InsurancePolicyId = p.InsurancePolicyId,
                PolicyNumber = p.PolicyNumber
            }).ToList();

            //Get the 3rd largest insurance amount

            var amount = policies.OrderByDescending(p=> p.InsuredAmount).Skip(2).Select(p => p.InsuredAmount).FirstOrDefault();
        }

        public static void GetInnerListCount()
        {
            List<List<string>> outerList = new List<List<string>>()
            {
                new List<string> { "Apple", "Banana", "Cherry" },
                new List<string> { "Dog", "Elephant" },
                new List<string> { "Fish", "Goat", "Horse", "Iguana" }
            };

            var counts = outerList.Select(innerList => innerList.Count).ToList();

            foreach (var count in counts)
            {
                Console.WriteLine(count);
            }
        }
    }
}
