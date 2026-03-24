using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPattern
{
    // Facade Interface
    public interface ILogisticsFacade
    {
        bool ShipPackage(string packageId, string customerId, string destination, decimal paymentAmount);
    }
}
