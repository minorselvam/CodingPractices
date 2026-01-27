using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPattern
{
    // Facade Implementation
    public class LogisticsFacade:ILogisticsFacade
    {
        private readonly InventoryService _inventoryService;
        private readonly PaymentService _paymentService;
        private readonly ShippingService _shippingService;
        private readonly NotificationService _notificationService;
        private readonly CustomsService _customsService;

        public LogisticsFacade()
        {
            _inventoryService = new InventoryService();
            _paymentService = new PaymentService();
            _shippingService = new ShippingService();
            _notificationService = new NotificationService();
            _customsService = new CustomsService();
        }
        public bool ShipPackage(string packageId, string customerId, string destination, decimal paymentAmount)
        {
            if (!_inventoryService.IsPackageAvailable(packageId))
            {
                Console.WriteLine("Package not available.");
                return false;
            }

            if (!_customsService.ValidateDocuments(packageId))
            {
                Console.WriteLine("Customs documents invalid.");
                return false;
            }

            if (!_paymentService.ProcessPayment(customerId, paymentAmount))
            {
                Console.WriteLine("Payment processing failed.");
                return false;
            }

            _shippingService.ScheduleShipment(packageId, destination);
            _notificationService.NotifyCustomer(customerId, $"Your package {packageId} has been shipped to {destination}.");

            return true;
        }
    }
}
