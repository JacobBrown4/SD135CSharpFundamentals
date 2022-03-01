using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _03_Conditionals
{
    [TestClass]
    public class Switch
    {
        [TestMethod]
        public void SwitchCases()
        {
            int input = 1;

            switch (input)
            {
                case 1:
                    Console.WriteLine("Hello");
                    break;
                case 2:
                case 8:
                case 3:
                case 9:
                case 200:
                case 5:
                    Console.WriteLine("What's up");
                    break;
                default:
                    Console.WriteLine("This is the default, it will execute if not case matches the value");
                    break;
            }

            string name = "jacob";
            switch (name)
            {
                case "jacob":
                case "Cyrus":
                    Console.WriteLine("What's up cool guy?");
                    break;
                case "Hello":
                    Console.WriteLine("Hello!");
                    break;
                default:
                    Console.WriteLine("Hi?");
                    break;
            }
        }
    }
}
