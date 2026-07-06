using StrategyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Context
{
    // Context class (uses a strategy object to perform the payment)
    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy; // Holds a reference to the chosen strategy

        // Method to set/change the strategy at runtime
        public void SetStrategy(IPaymentStrategy strategy) 
        {
            _paymentStrategy = strategy; // Assigns the chosen strategy object
        }

        // Executes the payment using the currently selected strategy
        public void ExecutePayment(int amount)
        {
            _paymentStrategy.Pay(amount); // Delegates the work to the strategy
        }
    }
}
