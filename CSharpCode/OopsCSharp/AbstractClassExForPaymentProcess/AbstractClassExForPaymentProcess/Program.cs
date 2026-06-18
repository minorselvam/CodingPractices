using System.Data;
using System.Runtime.Intrinsics.X86;

namespace AbstractClassExForPaymentProcess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Staff only interacts with abstract class reference
            PaymentProcessor payment; // Rule: Abstract classes cannot be instantiated directly.

            // Rule: Use abstract reference pointing to derived object.
            //abstract reference here is payment
            //derived object is new CreditCardPayment(); 
            payment = new CreditCardPayment();

            //Call the derived class method i.e CreditCardPayment.ProcessPayment()
            payment.ProcessPayment(500.00); 

            payment = new InsurancePayment(); 
            payment.ProcessPayment(1200.00);
        }
    }

    /*
     Abstraction in C# Object-Oriented Programming (OOP) is the concept of hiding implementation details and exposing only the necessary 
     features of an object. 
     It helps in reducing complexity and increasing efficiency by allowing users to focus on what an object 
     does rather than how it does it.
    */

    /*     
    🔍 Explanation
        Abstract Class (PaymentProcessor)  
        Defines the contract for processing payments. It doesn’t care about the details of credit card, insurance, or wallet systems.

        Derived Classes (CreditCardPayment, InsurancePayment)  
        Each provides its own implementation of ProcessPayment().

        Credit card → Bank API

        Insurance → Insurance provider system 
    */

    /*
     Client Code (Program)  
        Uses the abstract class reference. This means the hospital system can easily switch between 
        payment methods without changing the core logic.
    */

    /*
     *🏥 Real-World Application
        In a hospital management system:

        Doctors and staff don’t need to know the technical details of how payments are processed.

        Abstraction ensures security, modularity, and flexibility.

        If a new payment method (e.g., UPI in India) is added, you just create a new derived class without touching existing code.
     */

    /*
     🧩 What Counts as Existing Code?
        Base Class (PaymentProcessor)  
        This is part of the existing code. It defines the abstract contract (ProcessPayment) that all payment methods must follow.
        You don’t need to change this when adding a new payment method, unless you want to add new behaviors that apply to all processors.

        Derived Classes (CreditCardPayment, InsurancePayment, DigitalWalletPayment)  
        These are also existing code. They already implement the contract. You don’t touch them when adding UPI.

        Program Class (Client Code)  
        This is where you use the payment processors. If you want to actually call the new UPI payment method, you’ll add a 
        line here to instantiate and use it.
        Technically, this is the only place you’d “touch” when integrating the new class into your workflow.    
     
    */

    /*
    🔍 Key Insight
        Existing code = Base class + already implemented derived classes.
        Minimal change = Only the Program class (client code) needs a new line to use the new derived class.
        The beauty of abstraction: you don’t rewrite or modify existing payment classes, you just extend the system with a new one.
    */
}
