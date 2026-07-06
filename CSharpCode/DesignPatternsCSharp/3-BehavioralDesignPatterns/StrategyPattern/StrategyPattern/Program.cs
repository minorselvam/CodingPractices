using StrategyPattern.Context;
using StrategyPattern.StrategyClasses;

namespace StrategyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Create the context object
            var context = new PaymentContext();

            // Choose CreditCard strategy at runtime
            context.SetStrategy(new CreditCardStrategy()); // Client decides strategy
            context.ExecutePayment(300); // Executes using CreditCardStrategy

            // Switch to PayPal strategy at runtime
            context.SetStrategy(new PayPalStrategy()); // Client switches strategy
            context.ExecutePayment(435); // Executes using PayPalStrategy
        }
    }
}
