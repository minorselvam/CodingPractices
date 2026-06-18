/*
The Factory pattern in C# is a creational design pattern that provides a way to create objects without specifying the 
exact class of the object that will be created. Instead, a factory class or method handles the instantiation, often based 
on input parameters, returning objects that implement a common interface or inherit from a common base class. 
This promotes loose coupling and makes it easy to introduce new types without changing existing client code.

----------------How the Factory Pattern Works-------------------
Define a common interface or abstract class for the product.

Implement concrete classes for each product type.

Create a factory class with a method that takes input (such as a string or enum) and returns the appropriate product instance.

Real-World Example in C#: Report Generation
Suppose you are building a reporting system that can generate different types of reports (Sales, Inventory, HR). 
The Factory pattern allows you to encapsulate the logic for creating the correct report generator based on user input
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    // 1. Define the Common Product Interface
    public interface IReportGenerator
    {
        void GenerateReport();
    }

    // 2. Implement concrete classes for each product type
    public class SalesReport : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating Sales Report...");
        }
    }

    public class InventoryReport : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating Inventory Report...");
        }
    }

    public class HRReport : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating HR Report...");
        }
    }

    public class LoanReport : IReportGenerator
    {
        public void GenerateReport() 
        {
            Console.WriteLine("Generating Loan Report...");
        }
    }

    // 3. Factory Class to Produce the Products
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
                case "hr":
                    return new HRReport();
                case "loan":
                    return new LoanReport();
                default:
                    throw new ArgumentException("Invalid report type");
            }
        }
    }
}
