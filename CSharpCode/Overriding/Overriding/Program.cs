
namespace Overriding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //Calling CalculateBonus from Employee class 
            Employee emp = new Employee("test@yahoo.com");
            emp.CalculateBonus();

            // Calling CalculateBonus from SeniorEngineer class
            SeniorEngineer empSenior = new SeniorEngineer("test@yahoo.com");
            empSenior.CalculateBonus();

            // Polymorphism: base class reference to derived class object
            Employee emp1 = new SeniorEngineer("test@yahoo.com");
            emp1.CalculateBonus(); // Which method is called?... Calls overridden version in SeniorEngineer

            /*
             What Happens?
                At compile time, the type of emp1 is Employee, so the compiler checks that CalculateBonus exists in 
                Employee (which it does, as a virtual method).

                At runtime, the actual object that emp1 refers to is a SeniorEngineer.

                Because CalculateBonus is marked as virtual in the base class and override in the derived class, 
                the overridden method in SeniorEngineer is called.

                The derived class provides a new implementation of this method using the override keyword.

                At runtime, when a method is called on an object, the CLR checks the actual runtime type of 
                the object (not just the compile-time type).

                The most derived implementation of that method available on the runtime type of the object is executed.

                This mechanism is known as dynamic dispatch or late binding, enabling polymorphic behavior.
            */

            /*
              Why Is This Important?
                This is called runtime polymorphism or dynamic method dispatch.

                It allows you to write code that works with the base class (Employee) but automatically uses the correct 
                overridden behavior for any derived class (like SeniorEngineer), making your code flexible and extensible.
            */

            /*
                Benefits
                    Extensibility: You can add new employee types with their own bonus logic without changing existing code.
                    Maintainability: You avoid complex if-else or switch statements to check the type of employee.
                    Code Reuse: Shared logic can be placed in the base class, while specific logic is in derived classes.
            */

            /*
              In summary:
                When calling CalculateBonus on a base class reference that refers to a derived class object, 
                the overridden method in the derived class is executed. This is the core effect of polymorphism in C#, 
                enabling flexible and dynamic method invocation based on the actual object type at runtime.
            */


            //Calling new employee type CalculateBonus
            Employee emp2 = new Consultant("test1@msn.com");
            emp2.CalculateBonus(); //This will call the Consultant class CalculateBonus method.
        }
    }
}
