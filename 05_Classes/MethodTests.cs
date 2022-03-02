using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_Classes
{
    [TestClass]
    public class MethodTests
    {
        [TestMethod]
        public void GreeterMethodExecute()
        {
            Greeter greeter = new Greeter();
            // Semantic satiation: Words no longer are words

            greeter.SayHello("Jacob");
            greeter.SayHello();
            greeter.SayHello(3,true);
            greeter.SayHello(3,"William");


            greeter.GetRandomGreeting();
            greeter.GetRandomGreeting();
            greeter.GetRandomGreeting();
            greeter.GetRandomGreeting();

            Console.WriteLine(greeter.RandomGreeting());
        }

        [TestMethod]
        public void CalculatorTests()
        {
            Calculator calculator = new Calculator();
            int sum = calculator.Add(8, 3);
            Console.WriteLine(sum);

            int quotient = calculator.Divide(12, 4);
            Console.WriteLine(quotient);

            Console.WriteLine(calculator.Multiply(4,3));

            int result = calculator.Divide(calculator.Multiply(sum, 6),quotient);

            Console.WriteLine(result);
            DateTime dob = new DateTime(1995, 11, 24);
            int age = calculator.CalculateAge(dob);
            Console.WriteLine(age);

        }

        [TestMethod]
        public void PersonProperty()
        {
            Person person = new Person("Jacob","Brown",new DateTime(2002,02,02));
            Console.WriteLine($"My name is {person.FullName} and I am {person.Age} years old.");
            person.Transport = new Vehicle("Nissan", "Skyline", 100, VehicleType.Car);

            Assert.AreEqual("Jacob B", person.FullName);
            Assert.AreEqual("Jacob", person.FirstName);
            person.SayHello();

            Person luke = new Person("Luke", "Skywalker", new DateTime(1970, 02, 02));
            luke.SayHello();

            person.Brag();

            person.Transport.TurnOnHazards();
        }
    }
}
