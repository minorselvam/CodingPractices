using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassExForPaymentProcess
{
    // Derived class for Insurance payments
    //🧩 Syntax Rule for Derived Class
    //<access-modifier> class <DerivedClassName> : <AbstractClassName>
    public class InsurancePayment : PaymentProcessor
    {
        //Syntax- for overriden method
        //// Rule: Use 'override' keyword to implement abstract method.
        //<access-modifier> override <return-type> <MethodName>(<parameters>)
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing insurance claim for ${amount}");
            // Logic: connect to insurance provider, verify policy, etc. }  
        }
    }
}
