namespace InMemoryCrudOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            EmployeeManager employeeManager  = new EmployeeManager();
            employeeManager.AddEmployee(new Employee(1, "Selvam", "Selvam@yahoo.com"));
            employeeManager.AddEmployee(new Employee(2, "Kumar", "Kumar@msn.com"));

            var employee = employeeManager.GetEmployeeWithoutUsingLinq(18);
            if(employee != null)
            {
                Console.WriteLine("Employee Name: " + employee.EmployeeName + Environment.NewLine);
                Console.WriteLine("Employee E-Mail: " + employee.EmployeeEmail + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("No employee details found");
            }

            var employeeResult = employeeManager.GetEmployeeWithUsingLinq(1);
            if (employeeResult != null)
            {
                Console.WriteLine("Employee Name: " + employeeResult.EmployeeName + Environment.NewLine);
                Console.WriteLine("Employee E-Mail: " + employeeResult.EmployeeEmail + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("No employee details found");
            }
        }
    }
}
