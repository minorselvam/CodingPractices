using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassExForPaymentProcess
{
    // Derived class for Insurance payments
    public class InsurancePayment : PaymentProcessor
    {
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing insurance claim for ${amount}");
            // Logic: connect to insurance provider, verify policy, etc. }  
        }
    }
}
