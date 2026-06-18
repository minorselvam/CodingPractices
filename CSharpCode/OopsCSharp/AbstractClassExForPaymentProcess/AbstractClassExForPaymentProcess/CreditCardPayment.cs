using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassExForPaymentProcess
{
    // Derived class for Credit Card payments
    public class CreditCardPayment : PaymentProcessor
    {
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing credit card payment of ${amount}");
            // Logic: connect to bank API, validate card, etc.
        }
    }
}
