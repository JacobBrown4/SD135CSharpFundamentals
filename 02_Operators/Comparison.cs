using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_Operators
{
    [TestClass]
    public class Comparison
    {
        [TestMethod]
        public void Comparisons()
        {
            int age = 25;
            string username = "Adam";

            bool equals = age == 45;
            bool userIsAdam = username == "Adam";
            Console.WriteLine("User is 45: " + equals);
            Console.WriteLine($"User is Adam: {userIsAdam}");

            bool notEqual = age != 112;
            bool userIsNotJustin = username != "Justin";
            Console.WriteLine($"User is not 112: {notEqual}");
            Console.WriteLine("User is not Justin: " + userIsNotJustin);

            // Comparisons on reference types work different
            // Equals checks the address which is different for two objects
            List<string> firstList = new List<string>();
            firstList.Add(username);

            List<string> secondList = new List<string>();
            secondList.Add(username);

            bool areSame = firstList == secondList;

            // More comparison operations
            bool greaterThan = age > 12;
            bool lessThan = age < 75;

            bool greaThanOrEqual = age >= 66;
            bool lessThanOrEqual = age <= 23;

            bool trueValue = true;
            bool falseValue = false;

            // Or
            bool tOrT = trueValue || trueValue;
            bool tOrF = trueValue || falseValue;
            bool fOrT = falseValue || trueValue;
            bool fOrF = falseValue || falseValue;

            // And
            bool tAndT = trueValue && trueValue;
            bool tAndF = trueValue && falseValue;
            bool fAndT = falseValue && trueValue;
            bool fAndF = falseValue && falseValue;

        }
    }
}
