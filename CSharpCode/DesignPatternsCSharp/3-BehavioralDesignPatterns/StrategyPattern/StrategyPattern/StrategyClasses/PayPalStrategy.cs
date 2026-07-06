using StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.StrategyClasses
{
    // Concrete Strategy: PayPal
    public class PayPalStrategy : IPaymentStrategy
    {
        public void Pay(int amount)
        {
            // Implementation specific to PayPal payments
            Console.WriteLine($"Paid amount {amount} using the pay pal");
        }
    }
}
