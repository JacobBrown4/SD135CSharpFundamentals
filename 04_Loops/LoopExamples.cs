using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _04_Loops
{
    [TestClass]
    public class LoopEamples
    {
        [TestMethod]
        public void WhileLoops()
        { 
            int total = 1;

            // while(condition) Body

            while(total != 10)
            {
                Console.WriteLine(total);
                total = total + 1;
            }

            total = 0;
            // "Inifinte" loop, condition will never be false
            while (true)
            {
                if(total == 10)
                {
                    Console.WriteLine("Goal reached");
                    // break will "break" the loop
                    break;
                }
                total++;
            }

            int someCount;
            bool keepLooping = true;
            Random randy = new Random();

            while (keepLooping)
            {
                someCount = randy.Next(0, 20);

                // Skip iterations
                if(someCount == 0 || someCount == 10)
                {
                    continue;
                }

                Console.WriteLine(someCount);

                if (someCount == 15)
                {
                    keepLooping = false;
                }
            }
        }


        [TestMethod]
        public void ForLoops()
        {
            int studentCount = 12;

            // 1 Starting point, local variable
            // 2 Condition, loop while true
            // 3 What we do after each loop
            // 4 Code to execute each loop
                    //1        //2            //3
            for (int i = 0; i < studentCount; i++)
            {
                //4
                Console.WriteLine(i);
            }

            string[] students = { "Clay", "Stephen", "Ethan", "Victor", "Chirs", "Cyrus", "Hayden" };

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"Welcome to class {students[i]}!");
            }
        }

        [TestMethod]
        public void ForeachLoops()
        {
            string[] students = { "Clay", "Stephen", "Ethan", "Victor", "Chirs", "Cyrus", "Hayden" };
    
            //1 Type in collection
            //2 local variable
            //3 in keyword to signify going into collection
            //4 the collection
                    //1     //2    //3   //4
            foreach(string student in students)
            {
                Console.WriteLine(student+" is a student in class.");
            }

            string myName = "Henry Allen Venture";
            foreach (char letter in myName)
            {
                if(letter != ' ')
                {
                    Console.WriteLine(letter);
                }
            }
        }

        [TestMethod]
        public void DoWhileLoops()
        {
            int iterator = 4;

            // Do runs at least once before the condition is checked.

            do
            {
                Console.WriteLine("Hello!");
                iterator++; // iterator = iterator + 1; iterator += 1;
            }
            while (iterator < 5);

            do
            {
                Console.WriteLine("My condition is false");
            }
            while (false);

            while(false)
            {
                Console.WriteLine("My condition is false");
            }

        }

    }
}
