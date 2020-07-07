using HttpPatchExe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpPatchExe
{
    public class EmployeeData
    {
        public static List<Employee> GetEmployees =>
            new List<Employee>
            {
                new Employee
                {
                    EmpUId = 10,
                    DateofBirth = new DateTime(1991,10,12),
                    EmployeeName = new EmployeeName
                    {
                        EmpId = 1,
                        FirstName = "Manam",
                        LastName = "Navaneeswar",
                        EmpUId = 10,
                    },
                    EmployeeEmails = new List<EmployeeEmail>
                    {
                        new EmployeeEmail
                        {
                            EmailId = 2,
                            Email = "naveen.kumar@gmail.com",
                            EmailType = "Personal",
                            EmpUId = 20
                        }
                    },
                    EmployeePhones = new List<EmployeePhone>
                    {
                        new EmployeePhone
                        {
                            PhoneId = 1,
                            PhoneNumber = "9966661711",
                            PhoneType = "Home",
                            EmpUId = 10,
                        }
                    }
                },new Employee
                {
                    EmpUId = 20,
                    DateofBirth = new DateTime(1992,07,30),
                    EmployeeName = new EmployeeName
                    {
                        EmpId = 2,
                        FirstName = "Naveen",
                        LastName = "Kumar",
                        EmpUId = 20,
                    },
                    EmployeeEmails = new List<EmployeeEmail>
                    {
                        new EmployeeEmail
                        {
                            EmailId = 2,
                            Email = "naveen.kumar@gmail.com",
                            EmailType = "Personal",
                            EmpUId = 20
                        }
                    },
                    EmployeePhones = new List<EmployeePhone>
                    {
                        new EmployeePhone
                        {
                            PhoneId = 1,
                            PhoneNumber = "9966661711",
                            PhoneType = "Home",
                            EmpUId = 10,
                        }
                    }
                }
            };
    }
}
