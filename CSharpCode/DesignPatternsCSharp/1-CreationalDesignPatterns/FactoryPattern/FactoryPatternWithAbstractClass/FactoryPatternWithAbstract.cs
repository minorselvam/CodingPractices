using FactoryPatternWithAbstractClass.ReportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    We can place shared logic (like headers, footers, logging) in the abstract base class when implementing the Factory Pattern 
    with Abstract Class, so that all derived products get this shared behavior without duplicating it.

    This is actually one of the main advantages of using an abstract class over an interface — 
    we can have abstract methods (force override) and common implemented methods (shared across all subclasses).
*/

namespace FactoryPatternWithAbstractClass
{
    // 3. Factory Class to Produce the Products
    public static class FactoryPatternWithAbstractExample
    {
        public static ReportGenerator.ReportGenerator CreateReport(string reportType)
        {
            switch(reportType.ToLower())
            {
                case "sales":
                    return new SalesReport();
                case "inventory":
                    return new InventoryReport();
                case "hr":
                    return new HRReport();
                case "loan":
                    return new LoanReport();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
