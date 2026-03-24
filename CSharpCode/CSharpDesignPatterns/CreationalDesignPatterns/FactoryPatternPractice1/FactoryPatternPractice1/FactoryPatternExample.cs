using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternPractice1
{
    //Define products
    public interface IReportGenerator
    {
        void GenerateReport();
    }

    //Define class and methods with products
    public class SalesReport:IReportGenerator
    {
        public void GenerateReport() 
        {
            Console.WriteLine("Sales Report called");
        }
    }

    public class InventoryReport : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Inventory Report called");
        }
    }

    //Define factory class to get the right class objects
    public static class FactoryPatternExample
    {
        public static IReportGenerator CreateReport(string reportType)
        {
            switch (reportType.ToLower())
            {
                case "sales":
                    return new SalesReport();
               case "inventory":
                    return new InventoryReport();
                default:
                    throw new ArgumentException("Invalid Report");
            }
        }
    }
}
