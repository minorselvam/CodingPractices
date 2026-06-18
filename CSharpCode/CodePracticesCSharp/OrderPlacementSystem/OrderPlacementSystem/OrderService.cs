using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderPlacementSystem
{
    public class OrderService
    {
        private InventoryService inventoryService;
        private NotificationService notificationService;
        private List<Order> lstOrders = new List<Order>();

        public OrderService(InventoryService inventoryService, NotificationService notificationService)
        {
            this.inventoryService = inventoryService;
            this.notificationService = notificationService;
        }

        public void PlaceOrder(int orderID, string productName, int quantity)
        {
            //Starts the order
            Console.WriteLine("Starting to place the order");

            //Check stock
            if(!inventoryService.CheckStock(productName, quantity))
            {
                notificationService.SendNotification("No stock available for this quantity in this product");
                return;
            }

            //Deduct Stock
            inventoryService.DeductStock(productName, quantity);

            //Place Order
            Order newOrder = new Order(1, productName, quantity);
            lstOrders.Add(newOrder);

            notificationService.SendNotification("Order Placed successfully for the product " + productName + " with the quantity " + quantity);

        }
    }
}
