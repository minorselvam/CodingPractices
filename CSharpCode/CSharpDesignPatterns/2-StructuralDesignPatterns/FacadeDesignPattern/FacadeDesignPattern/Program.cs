namespace FacadeDesignPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ILogisticsFacade logisticsFacade = new LogisticsFacade();
            bool result = logisticsFacade.ShipPackage("PKG-2", "CUST-323", "Bangalore", 345);
            Console.WriteLine(result ? "Shipping process completed successfully." : "Shipping process failed.");
        }
    }
}

/*
 Explanation:
The InventoryService, PaymentService, ShippingService, NotificationService, and CustomsService are complex subsystems 
in the logistics domain.

The LogisticsFacade provides a simple method ShipPackage which internally coordinates these subsystems.

Clients call only the facade's ShipPackage method, without worrying about how inventory check, customs validation, payment, 
shipment scheduling, and notification are done separately.

This improves code maintainability and keeps client code decoupled from intricate subsystem details.

This design aligns with the Facade pattern principles
*/
