using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Employee
    {
        public String EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Position { get; set; }
        public String Department { get; set; }
        public List<Employee> DirectReports { get; set; }

        public static explicit operator EmployeeResponse(Employee employee)
        {
            EmployeeResponse employeeResponse = new EmployeeResponse();
            employeeResponse.EmployeeId = employee.EmployeeId;
            employeeResponse.FirstName = employee.FirstName;
            employeeResponse.LastName = employee.LastName;
            employeeResponse.Position = employee.Position;
            employeeResponse.Department = employee.Department;
            employeeResponse.DirectReports = employee.DirectReports.Select(dr => dr.EmployeeId).ToList();
            return employeeResponse;
        }
    }

    public class EmployeeResponse
    {
        public String EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Position { get; set; }
        public String Department { get; set; }
        public List<String> DirectReports { get; set; }
    }
}
