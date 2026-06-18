using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassExForPaymentProcess
{
    // Abstract class defining the contract
    //Syntax - Abstract class
    //<access-modifier> abstract class <AbstractClassName>

    // Rule: Abstract class must be declared with 'abstract' keyword.
    // Rule: Cannot be instantiated directly.
    public abstract class PaymentProcessor
    {
        //Syntax - Abstract method
        //<access-modifier> abstract <return-type> <AbstractMethodName>(<parameter>)
        // Rule: Abstract method has only signature, no body or function statements.
        // Rule: Must be overridden in derived classes.        
        public abstract void ProcessPayment(double amount);

        // Rule: Normal methods are allowed inside abstract classes.
        // Rule: These can have body/implementation.
        public void PrintMessage()
        {
            Console.WriteLine("Payment Processed Successfully...");
        }
    }
}
