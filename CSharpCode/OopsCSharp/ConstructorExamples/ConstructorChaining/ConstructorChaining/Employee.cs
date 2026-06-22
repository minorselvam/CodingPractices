using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorChaining
{
    public class Employee
    {
        public Employee(string empName)
        {
            Console.WriteLine("Employee class called for the employee " + empName);
        }
    }
}
