using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Interfaces
{
    // Strategy Interface (defines the contract that all payment strategies must follow)
    public interface IPaymentStrategy
    {
        public void Pay(int amount); // Every strategy must implement this method
    }
}
