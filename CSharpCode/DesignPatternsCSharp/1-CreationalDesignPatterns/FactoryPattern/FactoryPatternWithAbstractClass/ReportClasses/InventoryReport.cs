using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternWithAbstractClass.ReportClasses
{
    public class InventoryReport : ReportGenerator.ReportGenerator
    {
        public override void GenerateContent()
        {
            Console.WriteLine("Generating Inventory Report...");
        }
    }
}
