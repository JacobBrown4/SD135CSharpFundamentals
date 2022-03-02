using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Classes
{
    public class Greeter
    {
        Random _random = new Random();

        // Parts of method
        // 1 Access modifier
        // 2 Return type = What does this method give me?
        // 3 Method Name
        // 4 Method Parameters. Name+Parameters=Method signature name(parameters)
        // 5 body, what's being executed when called?

        //1     2       3      4
        public void SayHello(string name)
        {
            // 5
            Console.WriteLine($"{RandomGreeting()}, {name}");
        }
        public void SayHello(int highFives)
        {
            Console.WriteLine($"Hi, give me {highFives} high fives!");
        }
        // If you need another of a similar type, add a useless bool
        public void SayHello(int newNum,bool a)
        {
            Console.WriteLine($"Hi, give me {newNum} high fives!");
        }
        public void SayHello(string name, int highFives)
        {
            Console.WriteLine($"Hi {name}, give me {highFives} high fives!");
        }
        public void SayHello(int highFives, string dude)
        {
            Console.WriteLine($"Hi {dude}, give me {highFives} high fives!");
        }
        // Overloaded method
        // Same name, different parameters.
        public void SayHello()
        {
            Console.WriteLine("What's up homie?");
        }

        public void GetRandomGreeting()
        {
            string[] availableGreetings = new string[] { "Hello", "Wazzzzup", "Yo, my dude", "Hi","Salutations" };
            int randomNumber = _random.Next(0, availableGreetings.Length);
            string randomGreeting = availableGreetings.ElementAt(randomNumber);
            Console.WriteLine($"{randomGreeting}");
        }
        public string RandomGreeting()
        {
            string[] availableGreetings = new string[] { "Hello", "Wazzzzup", "Yo, my dude", "Hi", "Salutations" };
            int randomNumber = _random.Next(0, availableGreetings.Length);
            string randomGreeting = availableGreetings.ElementAt(randomNumber);
            return randomGreeting;
        }
    }
}
