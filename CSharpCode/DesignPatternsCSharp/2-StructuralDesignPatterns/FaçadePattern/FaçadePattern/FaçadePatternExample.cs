using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FaçadePattern
{
    public class FaçadePatternExample
    {
    }

    // Inventory subsystem
    public class Inventory
    {
        public bool CheckStock(Product product)
        {
            Console.WriteLine("Checking stock for " + product.Name);
            return true; // Simulate always in stock
        }
    }

    // Payment subsystem
    public class Payment
    {
        public bool ProcessPayment(User user, decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} for {user.Name}");
            return true; // Simulate successful payment
        }
    }

    //Shipping subsystem
    public class Shipping
    {
        public void ScheduleDelivery(Product product, string address)
        {
            Console.WriteLine($"Scheduling delivery of {product.Name} to {address}");
        }
    }

    // Supporting classes
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class User
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    //Facade Class
    public class ECommerceFacade
    {
        private Inventory inventory= new Inventory();
        private Payment payment= new Payment();
        private Shipping shipping= new Shipping();

        public bool PlaceOrder(Product product, User user)
        {
            if (!inventory.CheckStock(product))
                return false;

            if (!payment.ProcessPayment(user, product.Price))
                return false;

            shipping.ScheduleDelivery(product, user.Address);
            return true;
        }
    }
}
