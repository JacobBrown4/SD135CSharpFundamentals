using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _07_Inheritence
{
    [TestClass]
    public class PersonUnitTests
    {
        [TestMethod]
        public void PersonTesting()
        {
            Person person = new Person("jacob", "brown");

            Customer customer = new Customer();
            customer.SetFirstName("Jacob");
            customer.SetLastName("Brown");
            Console.WriteLine(customer.Name);
            customer.IsSubscribedToEmails = true;


            Employee employee = new Employee("First", "Last", "1292010", "Employee@emp.com", 474, new DateTime(2002, 12, 12));

            Console.WriteLine(employee.Name);

            // Creating a list of person and it's derived classes
            List<Person> persons = new List<Person>();

            persons.Add(person);
            persons.Add(customer);
            persons.Add(employee);

            foreach(Person peep in persons)
            {
                if(peep.GetType() == typeof(Customer))
                {
                    Console.WriteLine(((Customer)peep).IsSubscribedToEmails);
                }
                else if (peep.GetType() == typeof(Employee))
                {
                    Console.WriteLine(((Employee)peep).EmployeeId);
                }
                
            }

            HourlyEmployee stan = new HourlyEmployee("Stan", "Stanson", "7775551828", "Stan@Stancore", 223, new DateTime(2002, 12, 12), 233.2m, 10);
            persons.Add(stan);
        }
    }
}
