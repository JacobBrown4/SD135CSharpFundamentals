using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Classes
{
    public class Room
    {
        /*
        Create a Room class that has three properties: one each for the length, width, and height.
        Create a method that calculates total square footage.
        We also would like to include some constants that the define a minimum and maximum length, width, and height.
        When setting the properties, make sure to compare the values to the min/max and only set them if the value is valid.

        Create constructors
        Create a method that calculates total lateral surface area.
        Only allow the properties to be set from inside the class itself (Make all set's private, set only in constructor)
        Throw an exception if the given value is outside the permitted range.
        Test the code like we did with the Vehicle tests.
        */

        private const double MaxLength = 30;
        private const double MinLength = 6;
        private const double MaxHeight = 20;
        private const double MinHeight = 8;
        private const double MaxWidth = 30;
        private const double MinWidth = 6;

        private double _length;
        private double _height;
        private double _width;

        public double Length
        {
            get { return _length; }
            set
            { // Compare to max and min before setting
                // Throw an exception if outside the range
                if (value < MinLength || value > MaxLength)
                {
                    throw new ArgumentException($"Outside my ranges of {MinLength} and {MaxLength}");
                }
                else
                    _length = value;
            }
        }
        public double Width
        {
            get { return _width; }
            set
            { // Compare to max and min before setting
                // Throw an exception if outside the range
                if (value >= MinWidth && value <= MaxWidth)
                {
                    _width = value;
                }
                else
                {
                    throw new ArgumentException($"Outside my ranges of {MinWidth} and {MaxWidth}");
                }

                // don't store the value
            }
        }
        public double Height
        {
            get
            {
                return
                  _height;
            }
            set
            { // Compare to max and min before setting
                // Throw an exception if outside the range
                if (value < MinHeight || value > MaxHeight)
                {
                    throw new ArgumentException($"Outside my ranges of {MinHeight} and {MaxHeight}");
                }
                else
                    _height = value;
            }
        }

        // Method for square footage
        public double CalculateSquareFootage()
        {
            return Length * Width;
        }

    }
}
