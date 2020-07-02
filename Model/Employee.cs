using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpPatchExe.Model
{
    public class Employee
    {
        public int EmpUId { get; set; }
        public DateTime DateofBirth { get; set; }
        public EmployeeName EmployeeName { get; set; }
        public EmployeeEmail EmployeeEmail { get; set; }
        public EmployeePhone EmployeePhone { get; set; }
    }
    public class EmployeeName
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int EmpUId { get; set; }
    }
    public class EmployeeEmail
    {
        public int EmailId { get; set; }
        public string Email { get; set; }
        public string EmailType { get; set; }
        public int EmpUId { get; set; }

    }
    public class EmployeePhone
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; } 
        public int EmpUId { get; set; }
    }
}
