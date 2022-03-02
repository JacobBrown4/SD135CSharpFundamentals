using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_Classes
{
    [TestClass]
    public class VehicleTests
    {
        [TestMethod]
        public void PropertiesTest()
        {
            Vehicle firstVehicle = new Vehicle();
            firstVehicle.Make = "Nissan";
            Console.WriteLine(firstVehicle.Make);
            firstVehicle.Model = "Skyline GT-R";
            firstVehicle.Mileage = 50000;
            firstVehicle.VehicleType = VehicleType.Car;

            Console.WriteLine($"I own a {firstVehicle.Make} {firstVehicle.Model}, it has {firstVehicle.Mileage} miles on it. It is a {firstVehicle.VehicleType}");
        }

        [TestMethod]
        public void EngineTests()
        {
            Vehicle transport = new Vehicle();

            transport.TurnOn();
            Console.WriteLine(transport.IsRunning);
            transport.TurnOff();
            transport.Drive();

            transport.RightIndicator = new Indicator();
            transport.LeftIndicator = new Indicator();

            transport.IndicateLeft();
            Console.WriteLine("Indicating left");
            CheckIndicators(transport);

            transport.IndicateRight();
            Console.WriteLine("Turning right");
            CheckIndicators(transport);

            transport.TurnOnHazards();
            Console.WriteLine("Oh no an accident");
            CheckIndicators(transport);
        }

        [TestMethod]
        public void Constructors()
        {
            Vehicle car = new Vehicle();
            car.Make = "Toyota";
            car.Model = "Corolla";
            car.Mileage = 21300;
            car.VehicleType = VehicleType.Car;

            Console.WriteLine($"{car.Make} {car.Model}");

            Vehicle rocket = new Vehicle("SpaceX", "Falcon Heavy", 30000, VehicleType.Spaceship);
            Console.WriteLine($"{rocket.Make} {rocket.Model} is a {rocket.VehicleType}");
        }

        // Helper method
        private void CheckIndicators(Vehicle vehicle)
        {
            Console.WriteLine($"Right indicator: {vehicle.RightIndicator.IsFlashing}");
            Console.WriteLine($"Left indicator: {vehicle.LeftIndicator.IsFlashing}");
        }
    }
}
