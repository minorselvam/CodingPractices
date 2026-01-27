/*
 Façade Pattern in C#.NET Core with Real-World Example
The Façade pattern is a structural design pattern that provides a simplified interface to a set of complex subsystems. 
It hides the complexity of the system by exposing a single entry point, making the system easier to use and maintain.

Real-World Example: E-Commerce Order Placement
Scenario:
In an e-commerce application, placing an order involves several subsystems: inventory checking, payment processing, and shipping. 
Each subsystem may have complex logic and interfaces. The Façade pattern can be used to provide a simple method for clients to place orders, 
hiding all underlying complexity.
 */

namespace FaçadePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var product = new Product { Name = "Laptop", Price = 1500m };
            var user = new User { Name = "Alice", Address = "123 Main St" };

            var facade = new ECommerceFacade();
            facade.PlaceOrder(product, user);
        }
    }
}
