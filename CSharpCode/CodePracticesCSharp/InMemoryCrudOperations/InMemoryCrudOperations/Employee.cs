using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCrudOperations
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }

        public Employee(int empId, string empName, string empEmail) 
        {
            EmployeeID = empId;
            EmployeeName = empName;
            EmployeeEmail = empEmail;
        }
    }
}
