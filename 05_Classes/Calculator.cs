using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Classes
{
    public class Calculator
    {
        // Addition
        public int Add(int numOne, int numTwo)
        {
            int sum = numOne + numTwo;
            return sum;
        }
        public double Add(double numOne, double numTwo)
        {
            double sum = numOne + numTwo;
            return sum;
        }
        // Challenge: You write these till 1:22p
        // Subtraction
        public int Subtract(int numOne, int numTwo)
        {
            int difference = numOne - numTwo;
            return difference;
        }


        // Multiplication
        public int Multiply(int numOne, int numTwo)
        {
            return numOne * numTwo;
        }

        // Division
        public int Divide(int numOne, int numTwo)
        {
            return numOne / numTwo;
        }
        // Casted overload
        public double Divide(int numOne, double numTwo)
        {
            return (double)numOne / numTwo;
        }
        public double Divide(double numOne, double numTwo)
        {
            return numOne / numTwo;
        }
        
        // Finding the remainder
        public int Remainder(int numOne, int numTwo)
        {
            return numOne % numTwo;
        }

        public int CalculateAge(DateTime birthDate)
        {
            TimeSpan age = DateTime.Now - birthDate;
            double totalAgeInYears = age.TotalDays / 365.25;
            double rounded = Math.Floor(totalAgeInYears);
            int years = Convert.ToInt32(rounded);
            return years;
        }
        // Just because you can do it one line doesn't mean you should.
        public int CalculateAgeOneLine(DateTime birthDate)
        {
            return Convert.ToInt32(Math.Floor((DateTime.Now - birthDate).TotalDays / 365.25)); 
        }

    }
}
