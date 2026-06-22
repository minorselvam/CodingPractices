using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorChaining
{
    public class Consultant:Employee
    {
        public Consultant(string name):base(name) // Must chain to base
        {
            Console.WriteLine("Consultant class called for the employee " + name);
        }
    }
}
