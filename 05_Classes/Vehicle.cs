using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Classes
{
    public enum VehicleType { Car, Truck, Van, Motorcycle, Spaceship, Plane, Boat }

    // Accessor types:
    // Public: availble throughout the full assembly
    // Private: only available in the same class or struct
    // Protected: like private but also accessible by derived classes.
    // Internal: Accessible in this assembly only
    // Protected Internal: Accessible in this assembly only and derived classes in other assemblies
    // Private Protected: Only in this class, by code in the same class, and derived

    public class Vehicle // (Noun)
    {
        // Constructor
        public Vehicle() // Implicit, goes away when another constructor is added
        {
            LeftIndicator = new Indicator();
            RightIndicator = new Indicator();
        }

        public Vehicle(string make, string model, double mileage, VehicleType type)
        {
            Make = make;
            Model = model;
            Mileage = mileage;
            VehicleType = type;
            LeftIndicator = new Indicator();
            RightIndicator = new Indicator();
        }

        // Fields, Constructors, Properties (Adjectives), and Methods (Verbs)

        // 1 Access modifer = Where can this be seen?
        // 2 Type = what type of property is it?
        // 3 Name = What's it called?
        // 4 Getters and Setters = How do I set it? How do I get it?

        // 1      2     3       4
        public string Make { get; set; }
        public string Model { get; set; }
        public double Mileage { get; set; }
        public VehicleType VehicleType { get; set; }
        public bool IsRunning { get; private set; }

        public Indicator RightIndicator { get; set; }
        public Indicator LeftIndicator { get; set; }

        public void TurnOn()
        {
            IsRunning = true;
            Console.WriteLine("You turn on the vehicle");
        }
        public void TurnOff()
        {
            IsRunning = false;
            Console.WriteLine("You turned off the vehicle");
        }

        public void Drive()
        {
            if (IsRunning)
            {
                Console.WriteLine("You start driving the vehicle");
            }
            else
            {
                Console.WriteLine("You need to turn on the vehicle");
            }
        }

        public void IndicateRight()
        {
            RightIndicator.TurnOn();
            LeftIndicator.TurnOff();
        }
        public void IndicateLeft()
        {
            RightIndicator.TurnOff();
            LeftIndicator.TurnOn();
        }
        public void ClearIndicators()
        {
            RightIndicator.TurnOff();
            LeftIndicator.TurnOff();
        }
        public void TurnOnHazards()
        {
            RightIndicator.TurnOn();
            LeftIndicator.TurnOn();
        }
    }

    public class Indicator
    {
        public bool IsFlashing { get; private set; }
        public void TurnOn()
        {
            IsFlashing = true;
        }
        public void TurnOff()
        {
            IsFlashing = false;
        }
    }
}
