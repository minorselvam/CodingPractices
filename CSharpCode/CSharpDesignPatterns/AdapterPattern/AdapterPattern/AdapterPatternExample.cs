using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class AdapterPatternExample
    {
    }

    // Employee class (used by ThirdPartyBillingSystem)
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }

        public Employee(int id, string name, string designation, decimal salary)
        {
            ID = id;
            Name = name;
            Designation = designation;
            Salary = salary;
        }
    }

    // Adaptee: Third-party billing system
    public class ThirdPartyBillingSystem
    {
        public void ProcessSalary(List<Employee> employees)
        {
            // Process each employee's salary
            foreach (var emp in employees)
            {
                Console.WriteLine($"Salary processed for {emp.Name}");
            }
        }
    }

    // Target interface
    public interface ITarget
    {
        void ProcessCompanySalary(string[,] employeesArray);
    }

    // Adapter: Converts string[,] to List<Employee> and delegates to ThirdPartyBillingSystem
    public class EmployeeAdapter : ITarget
    {
        private readonly ThirdPartyBillingSystem _thirdPartyBillingSystem = new ThirdPartyBillingSystem();
        public void ProcessCompanySalary(string[,] employeesArray)
        {
            var listEmployee = new List<Employee>();
            for (int i = 0; i < employeesArray.GetLength(0); i++)
            {
                int id = Convert.ToInt32(employeesArray[i, 0]);
                string name = employeesArray[i, 1];
                string designation = employeesArray[i, 2];
                decimal salary = Convert.ToDecimal(employeesArray[i, 3]);
                listEmployee.Add(new Employee(id, name, designation, salary));
            }

            Console.WriteLine("Adapter converted Array of Employee to List of Employee");
            _thirdPartyBillingSystem.ProcessSalary(listEmployee);
        }
    }
}
