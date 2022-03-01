using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _03_Conditionals
{
    [TestClass]
    public class IfElse
    {
        [TestMethod]
        public void IfStatements()
        {

            bool userIsHungry = true;

            // if keyword
            if (userIsHungry) // Condition in parenthesis
            {
                // Body
                Console.WriteLine("Eat something");
            }

            string name = "Jacob";

            if (name == "Jacob")
            {
                Console.WriteLine("You must be so cool!");
            }

            if (name != "Jacob")
            {
                Console.WriteLine("You must not be very cool.");
            }

        }

        [TestMethod]
        public void IfElseStatements()
        {
            bool choresAreDone = false;

            if (choresAreDone)
            {
                Console.WriteLine("Have fun at the movies!");
            }
            else
            {
                Console.WriteLine("Stay home and do your chores");
            }

            string input = "9";
            int totalHours = int.Parse(input);
            // Nested conditionals
            if (totalHours >= 8)
            {
                Console.WriteLine("You should be well rested");
            }
            else
            {
                Console.WriteLine("You might be tired today");
                if (totalHours < 4)
                {
                    Console.WriteLine("You should get more sleep");
                }

            }
        }

        [TestMethod]
        public void IfElseIfStatements()
        {
            Random rng = new Random();
           
            int roll = rng.Next(1,7);

            if (roll == 6)
            {
                Console.WriteLine("you rolled six! Good job");
            }
            else if(roll == 5)
            {
                Console.WriteLine("You rolled five, not bad");
            }
            else if(roll < 5 && roll > 3)
            {
                Console.WriteLine("You rolled not a six or five");
            }
            else if(roll == 3)
            {
                Console.WriteLine("THREEE");
            }
            else if(roll > 1)
            {
                Console.WriteLine("Tooooo Wars?!");
            }
            else
            {
                Console.WriteLine("Uno");
            }
        }

    }
}
