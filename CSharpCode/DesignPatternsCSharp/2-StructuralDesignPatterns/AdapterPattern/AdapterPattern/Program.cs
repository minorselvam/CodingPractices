//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

/* 
 Adapter Pattern in C#.NET Core with Real-World Example
The Adapter pattern is a structural design pattern that allows objects with incompatible interfaces to work together 
by acting as a bridge between them. In .NET Core, it is commonly used when integrating third-party libraries or legacy systems 
with your own codebase.

------------Real-World Example: HR System Integrating with Third-Party Billing System-------
Scenario:
An existing HR system stores employee data as a string array.
A third-party billing system requires a List<Employee> to process salaries.
The two systems are incompatible due to different data structures.
The Adapter pattern is used to convert the HR system's data format to what the billing system expects, allowing seamless integration.

Key Components
Target Interface (ITarget): Defines the domain-specific interface used by the client (HR system).
Adaptee (ThirdPartyBillingSystem): The existing class with an incompatible interface (expects List<Employee>).
Adapter (EmployeeAdapter): Converts the interface of the adaptee into the target interface (string[,] to List<Employee>).

 */

using AdapterPattern;
using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] employees = new string[2, 4]
             {
                { "1001", "John", "SE", "10000" },
                { "1002", "Smith", "Manager", "20000" }
             };

            ITarget adapter = new EmployeeAdapter();
            adapter.ProcessCompanySalary(employees);
        }
    }
}
