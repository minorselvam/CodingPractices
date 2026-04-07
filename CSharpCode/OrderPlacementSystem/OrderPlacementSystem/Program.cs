namespace OrderPlacementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            InventoryService inventoryService = new InventoryService();
            NotificationService notificationService = new NotificationService();
            OrderService orderService = new OrderService(inventoryService, notificationService);

            //Placing the order
            orderService.PlaceOrder(1, "Laptop", 6);
            orderService.PlaceOrder(2, "Laptop", 8);
        }
    }
}
