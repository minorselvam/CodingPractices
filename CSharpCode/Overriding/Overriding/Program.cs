
/*
 What is Method Overriding?
    Definition: Method overriding allows a derived class to provide a specific implementation of a method already defined in its base class.

    Requirements:
        Base class method must be marked as virtual.
        Derived class method must use the override keyword.

    Purpose: 
        Enables runtime polymorphism (dynamic dispatch), where the method executed depends on the actual object type at runtime, 
        not the reference type.

    Benefits:
        Extensibility: Add new employee roles without modifying existing code.
        Maintainability: Avoid complex if-else or switch statements.
        Code Reuse: Shared logic in base class, specialized logic in derived classes.
        Flexibility: Systems can work with Employee references but execute role-specific behavior.
*/

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


/*
 Q1: What happens if you don’t mark the base method as virtual?
Answer:
The derived class cannot override it using override. If you try, the compiler throws an error. You can still hide the base method using the new keyword, but that results in method hiding, not overriding, and does not support polymorphism.

Q2: Difference between override and new keywords?
Answer:

override: Provides a new implementation of a virtual method. Supports runtime polymorphism.

new: Hides the base class method. The method called depends on the reference type, not the runtime type.

Q3: Can constructors be overridden in C#?
Answer:
No. Constructors are not inherited, so they cannot be overridden. However, derived classes can call base constructors using base(...).

Q4: What is the role of the sealed keyword in overriding?
Answer:
If you mark an overridden method as sealed, it prevents further overriding in derived classes. Example:

csharp
public sealed override double CalculateBonus() { ... }
Q5: How does polymorphism improve maintainability in large systems?
Answer:
Instead of modifying existing code when new roles are added, you simply extend the base class. This reduces risk of breaking existing logic and makes the system more modular.

Q6: What is dynamic dispatch in C#?
Answer:
It’s the mechanism by which the CLR determines at runtime which implementation of a virtual method to call, based on the actual object type.

Q7: Can you override a static method in C#?
Answer:
No. Static methods belong to the type itself, not to instances, so they cannot participate in polymorphism.

✅ Key Takeaway
Polymorphism in C# allows you to write flexible, extensible, and maintainable code. By overriding methods in derived classes, you ensure that the correct behavior is executed at runtime, based on the actual object type.
*/
