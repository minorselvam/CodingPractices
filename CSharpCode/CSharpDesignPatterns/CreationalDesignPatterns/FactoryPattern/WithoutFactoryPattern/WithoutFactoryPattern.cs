using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutFactoryPattern
{
    //internal class WithoutFactoryPattern
    //{
    //}

    // Interfaces and concrete classes would still exist
    public interface IReportGenerator
    {
        void GenerateReport();
    }

    public class SalesReport : IReportGenerator
    {
        public void GenerateReport() => Console.WriteLine("Generating Sales Report...");
    }

    public class InventoryReport : IReportGenerator
    {
        public void GenerateReport() => Console.WriteLine("Generating Inventory Report...");
    }

    public class HRReport : IReportGenerator
    {
        public void GenerateReport() => Console.WriteLine("Generating HR Report...");
    }

    public class LoanReport : IReportGenerator
    {
        public void GenerateReport() => Console.WriteLine("Generating Loan Report...");
    }
}
