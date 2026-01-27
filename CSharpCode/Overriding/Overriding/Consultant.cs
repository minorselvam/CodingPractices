using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    In what ways does polymorphism simplify adding new employee roles with unique bonus rules 
*/

/*
  Polymorphism simplifies adding new employee roles with unique bonus rules by allowing you to introduce new subclasses that 
    override shared methods—such as CalculateBonus—without changing existing code or logic that processes employees. Here’s how:

    Override for Unique Rules: Each new employee role (e.g., Manager, SeniorEngineer, Contractor) can override the base class’s 
    bonus calculation method to implement its own unique logic. For example, a Manager might receive a different bonus calculation 
    than a Programmer, each defined in their respective subclasses.

    No Changes to Processing Logic: Code that processes employees—such as payroll or reporting systems—can operate on the base class 
    or interface. When it calls CalculateBonus, the correct overridden method for each specific employee type is automatically invoked 
    at runtime, thanks to dynamic dispatch.

    Extensible and Maintainable: Adding a new role does not require modifying existing classes or adding new conditionals. 
    You simply create a new subclass and provide the unique bonus calculation, keeping the codebase clean and maintainable.

    Consistent Interface: All employee types share the same method signature for calculating bonuses, so systems interacting with 
    them do not need to know the details of each role’s implementation.

    Example:
    If you later introduce a Consultant role with a special bonus rule, you just add:
*/

/*
    All existing payroll or reporting code continues to work, automatically applying the correct bonus calculation for 
    consultants without any changes.

    In summary:
    Polymorphism allows you to add new employee roles with unique bonus rules simply by extending the base class and overriding 
    the relevant method. This avoids modifying or complicating existing logic, making your system more flexible and easier to extend
*/

namespace Overriding
{
    public class Consultant : Employee
    {
        public Consultant(string eMail) :base(eMail)
        {
            Console.WriteLine("Consultant class constructor called");
        }

        public override double CalculateBonus()
        {
            Console.WriteLine("Consultant class CalculateBonus called");
            return 100 * 0.22;
        }
    }
}