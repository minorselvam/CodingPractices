using StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyClasses
{
    // Concrete Strategy: Credit Card
    public class CreditCardStrategy : IPaymentStrategy
    {
        public void Pay(int amount)
        {
            // Implementation specific to credit card payments
            Console.WriteLine($"Paid amount {amount} using credit card");
        }
    }
}
