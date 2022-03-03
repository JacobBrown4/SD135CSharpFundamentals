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
            Room room = new Room();
            room.Length = 800;
            room.Width = 10;

            Assert.AreEqual(80, room.CalculateSquareFootage());

        }
    }
}
