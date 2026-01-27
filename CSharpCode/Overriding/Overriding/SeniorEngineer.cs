/*
Method overriding in C# allows a derived (child) class to provide a specific implementation of a method that is already defined 
in its base (parent) class. The base class method must be marked with the virtual keyword, and the derived class overrides it 
using the override keyword. This enables runtime polymorphism, where the method that gets called depends on the actual object type, 
not the reference type
 */

/*
 Real-Time Example: Employee Bonus Calculation
Suppose you have a system to calculate employee bonuses, and the calculation varies by designation (Manager, Developer, etc.). 
The base class provides a general method, and each derived class overrides it for specific logic.
*/

/*
 Effect of Polymorphism When Calling CalculateBonus on a Base Class Reference
    In your code example, polymorphism is demonstrated when you call the CalculateBonus method on a base class reference (Employee) that 
    actually points to a derived class object (SeniorEngineer):
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overriding
{
    public class SeniorEngineer : Employee
    {
        public SeniorEngineer(string eMail) : base(eMail)
        {
            Console.WriteLine("SeniorEngineer class constructor called");
        }

        public override double CalculateBonus()
        {
            Console.WriteLine("SeniorEngineer class CalculateBonus called");
            return 100 * 0.3;
        }
    }
}
