using FactoryPatternWithInterfaceEx.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternWithInterfaceEx.ReportClasses
{
    // 2. Implement concrete classes for each product type
    public class HRReport : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating HR Report...");
        }
    }
}
