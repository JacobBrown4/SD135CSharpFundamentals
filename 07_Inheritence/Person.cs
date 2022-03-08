using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritence
{
    public class Person
    {
        private string _firstName;
        private string _lastName;

        public Person() { }
        public Person(string firstName, string lastName)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
        }
        // Constructor chaining
        public Person(string first, string last,string phone) : this(first, last)
        {
            PhoneNumber = phone;
        }
        public Person(string firstName, string lastName, string email, string phone) : this(firstName,lastName,phone)
        {
            Email = email;
        }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name
        {
            get
            {
                string fullName = $"{_firstName} {_lastName}"; // " "
                return (!string.IsNullOrWhiteSpace(fullName)) ? fullName : "Unnamed";
            }
        }

        public void SetFirstName(string name)
        {
            _firstName = name;
        }
        public void SetLastName(string name)
        {
            _lastName = name;
        }
    }

    public class Customer : Person // Derived from person
    {
        public bool IsPremium { get; set; }
        public bool IsSubscribedToEmails { get; set; }
    }

    public class Employee : Person
    {
        public Employee() { }
        public Employee(int id, DateTime hireDate)
        {
            EmployeeId = id;
            HireDire = hireDate;
        }
        public Employee(string first, string last, string phone, string email, int id, DateTime hireDate) : base(first,last,email,phone)
        {
            EmployeeId = id;
            HireDire = hireDate;
        }
        public int EmployeeId { get; set; }
        public DateTime HireDire { get; set; }

        public int YearsWithCompany
        {
            get
            {
                double totalTime = (DateTime.Now - HireDire).TotalDays / 365.25;
                return Convert.ToInt32(Math.Floor(totalTime));
            }
        }
    }

    public class HourlyEmployee : Employee
    {
        public HourlyEmployee() { }
        public HourlyEmployee(string first, string last, string phone, string email, int id, DateTime hireDate,decimal hourlyWage,decimal hoursWorked) : base(first, last, phone, email, id, hireDate)
        {
            HourlyWage = hourlyWage;
            HoursWorked = hoursWorked;
        }
        public decimal HourlyWage { get; set; }
        public decimal HoursWorked { get; set; }
    }

    public class SalaryEmployee : Employee
    {
        public SalaryEmployee() { }
        public SalaryEmployee(string first, string last, string phone, string email, int id, DateTime hireDate,decimal salary) : base(first, last, phone, email, id, hireDate)
        {
            Salary = salary;
        }
        public decimal Salary { get; set; }
    }

}
