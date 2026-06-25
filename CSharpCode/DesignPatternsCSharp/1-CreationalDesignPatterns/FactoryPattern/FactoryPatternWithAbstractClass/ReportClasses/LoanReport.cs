using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternWithAbstractClass.ReportClasses
{
    public class LoanReport : ReportGenerator.ReportGenerator
    {
        public override void GenerateContent()
        {
            Console.WriteLine("Generating Loan Report...");
        }
    }
}
