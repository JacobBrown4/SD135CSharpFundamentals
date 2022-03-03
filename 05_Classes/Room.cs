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
        -Create a Room class that has three properties: one each for the length, width, and height.
        -Create a method that calculates total square footage.
        -We also would like to include some constants that the define a minimum and maximum length, width, and height.
        -When setting the properties, make sure to compare the values to the min/max and only set them if the value is valid.

        -Create constructors
        -Create a method that calculates total lateral surface area.
        -Only allow the properties to be set from inside the class itself (Make all set's private, set only in constructor)
        -Throw an exception if the given value is outside the permitted range.
        -Test the code like we did with the Vehicle tests.
        */
        // > CFCPM
        // Constants
        private const double MaxLength = 30;
        private const double MinLength = 6;
        private const double MaxHeight = 20;
        private const double MinHeight = 8;
        private const double MaxWidth = 30;
        private const double MinWidth = 6;

        // Fields
        private double _length;
        private double _height;
        private double _width;

        // Constructor
        // Room(){} Implicit, but inaccessible when another constructor exists
        public Room(double l, double w, double h)
        {
            Length = l;
            Width = w;
            Height = h;
        }

        // Properties
        public double Length
        {
            get { return _length; }
            private set
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
            private set
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
            private set
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

        // Methods
        public double CalculateSquareFootage()
        {
            return Length * Width;
        }

        public double CalculateTotalLateralSurfaceArea()
        {
            double lengthLSA = _length * _height * 2;
            double widthLSA = _width * _height * 2;
            return lengthLSA + widthLSA; 
            // 2 * (height * length * width)
        }

        public double Calculate2()
        {
            return ((2 * Length) + (2 * Width)) * Height;
        }

        public double Calculate3()
        {
           return 2 * (Height * (Length + Width));

        }
    }
}
