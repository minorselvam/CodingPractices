using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternWithAbstractClass.ReportGenerator
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
}
