using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCrudOperations
{
    public class EmployeeManager
    {
        private List<Employee> lstEmployees= new List<Employee>();

        //Add Employee Details
        public void AddEmployee(Employee employee)
        {
            lstEmployees.Add(employee);
        }

        //Find Employee Details Without using LINQ
        public Employee? GetEmployeeWithoutUsingLinq(int empID)
        {
           foreach(Employee emp in lstEmployees)
            {
                if(emp.EmployeeID == empID)
                {
                    return emp;
                }
            }
            return null;
        }

        //Find Employee Details with using LINQ
        public Employee? GetEmployeeWithUsingLinq(int empID)
        {
            var result = lstEmployees.Where(e=> e.EmployeeID == empID).FirstOrDefault();
            if(result != null)
            {
                return result;
            }

            return null;
        }
    }
}
