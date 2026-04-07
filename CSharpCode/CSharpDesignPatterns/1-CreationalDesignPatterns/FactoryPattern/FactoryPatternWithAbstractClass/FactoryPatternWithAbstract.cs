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
    // 1. Abstract Base Class — contains BOTH shared logic and abstract methods
    public abstract class ReportGenerator
    {
        // Abstract method — must be overridden by each concrete report
        public abstract void GenerateContent();

        //Shared logic methods
        protected void PrintHeader()
        {
            Console.WriteLine("=== ACME Global Shipping & Logistics ===");
            Console.WriteLine("Report Generated On: " + DateTime.Now);
            Console.WriteLine("------------------------------------------");
        }

        protected void PrintFooter()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("© 2025 ACME Logistics - Confidential");
        }

        protected void LogReport()
        {
            Console.WriteLine("[LOG]: Report was successfully generated at " + DateTime.Now);
        }

        // Shared logic — common to all reports
        public void GenerateReport()
        {
            PrintHeader(); // shared header
            GenerateContent(); // custom report content (from derived class)
            PrintFooter(); // shared footer
            LogReport(); // shared logging
        }
    }

    public class SalesReport: ReportGenerator
    {
        public override void GenerateContent()
        {
            Console.WriteLine("Generating Sales Report...");
        }
    }

    public class InventoryReport:ReportGenerator
    {
        public override void GenerateContent()
        {
            Console.WriteLine("Generating Inventory Report...");
        }
    }

    public class HRReport:ReportGenerator
    {
        public override void GenerateContent()
        {
            Console.WriteLine("Generating HR Report...");
        }
    }

    public class LoanReport:ReportGenerator
    {
        public override void GenerateContent()
        {
            Console.WriteLine("Generating Loan Report...");
        }
    }

    // 3. Factory Class to Produce the Products
    public static class FactoryPatternWithAbstractExample
    {
        public static ReportGenerator CreateReport(string reportType)
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
