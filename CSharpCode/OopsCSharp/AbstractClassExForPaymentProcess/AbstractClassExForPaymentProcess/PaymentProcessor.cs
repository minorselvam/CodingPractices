using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassExForPaymentProcess
{
    // Abstract class defining the contract
    public abstract class PaymentProcessor
    {
        public abstract void ProcessPayment(double amount);

        public void PrintMessage()
        {
            Console.WriteLine("test message");
        }
    }
}
