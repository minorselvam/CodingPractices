using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overriding
{
    public class Employee
    {
        public Employee(string eMail) 
        { 
            Console.WriteLine("Employee class constructor called");
        }

        public virtual double CalculateBonus()
        {
            Console.WriteLine("Employee class CalculateBonus called");
            return 100 * 0.25;
        }
    }
}
