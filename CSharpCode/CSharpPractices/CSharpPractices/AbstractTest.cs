using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{
    public abstract class AbstractTest
    {
        public int amount {  get; set; }
        public abstract void TestAmount();

        public void SaveTotalSalary()
        {
            Console.WriteLine("test");
        }
    }

    public class ChildClass:AbstractTest {
        public override void TestAmount()
        {
            throw new NotImplementedException();
        }
    }
}
