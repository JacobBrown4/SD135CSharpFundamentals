using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_Classes
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        public void SettingValues()
        {
            Room room = new Room(10, 12, 15);

            Assert.AreEqual(120, room.CalculateSquareFootage());

            Assert.AreEqual(room.CalculateTotalLateralSurfaceArea(), room.Calculate2());
            Assert.AreEqual(room.CalculateTotalLateralSurfaceArea(), room.Calculate3());

            Room room2 = new Room(10, 12, 20);
            Assert.AreEqual(120, room2.CalculateSquareFootage());
        }

        // Unit Test Naming: Functionality_Goal
        // Checking constructor is setting values
        [TestMethod]
        public void ConstructRoom_ShouldSetProperties()
        {
            Room room = new Room(8, 8, 10);

            Assert.AreEqual(8, room.Length);
            Assert.AreEqual(8, room.Width);
            Assert.AreEqual(10, room.Height);

        }

        // Checking square footage output
        [TestMethod]
        public void CheckSquareFootage_ShouldReturnCorrectDouble()
        {
            Room room = new Room(10, 7, 10);
            double expected = 70; // 10* 7
            double actual = room.CalculateSquareFootage();

            Assert.AreEqual(expected, actual);
        }
        // Checking lateral area output
        [TestMethod]
        public void CheckLateralSurfaceArea_ShouldReturnCorrectDouble()
        {
            Room room = new Room(10, 7, 10);
            Assert.AreEqual(340, room.CalculateTotalLateralSurfaceArea());
        }
        // Check invalid length
        [DataTestMethod]
        [DataRow(4, 8, 12)] // Checking minimum length failure
        [DataRow(40, 30, 11)] // Checking maximum length failure
        public void CreateInvalidLength_ShouldThrowException(double l, double w, double h)
        {
            Exception thrownException = null;
            try
            {
                // attempt this
                Room room = new Room(l, w, h);
            }
            // Grab the exception
            catch (Exception err)
            {
                // run this code
                thrownException = err;
            }
            Assert.IsNotNull(thrownException);
            Assert.IsInstanceOfType(thrownException, typeof(ArgumentException));
        }
        // Check invalid width
        [DataTestMethod]
        [DataRow(9, 4, 12)] // Checking minimum width failure
        [DataRow(10, 31, 11)] // Checking maximum width failure
        public void CreateInvalidWidth_ShouldThrowException(double l, double w, double h)
        {
            Exception thrownException = null;
            try
            {
                // attempt this
                Room room = new Room(l, w, h);
            }
            // Grab the exception
            catch (Exception err)
            {
                // run this code
                thrownException = err;
            }
            finally // Will always run regardless of exception thrown or not
            {
                Console.WriteLine("I cannot be stopped");
                Assert.IsNotNull(thrownException);
                Assert.IsInstanceOfType(thrownException, typeof(ArgumentException));
            }
            Console.WriteLine("I can be");
        }
        // Check invalid height
        [DataTestMethod]
        [DataRow(12,8,7)] // Under min
        [DataRow(8,12,21)] // Over max
        [ExpectedException(typeof(ArgumentException))] // I am expecting an exception and this test to fail, so it passes
        public void CreateInvalidHeight_ShouldThrowException(double l, double w, double h)
        {
            Room room = new Room(l, w, h);
        }
    }
}
