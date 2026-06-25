using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternWithAbstractClass.ReportClasses
{
    public class SalesReport : ReportGenerator.ReportGenerator
    {
        public override void GenerateContent()
        {
            Console.WriteLine("Generating Sales Report...");
        }
    }
}
