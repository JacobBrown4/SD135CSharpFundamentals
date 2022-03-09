using _08_Interfaces.Fruits;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _08_Interfaces
{
    [TestClass]
    public class IFruitTests
    {
        [TestMethod]
        public void CallingInterfaceMethods_ShouldReturnCorrectString()
        {
            IFruit banana = new Banana();

            string output = banana.Peel();
            Console.WriteLine(output);
            Console.WriteLine("The banana is peeled: " + banana.IsPeeled);

            Assert.IsTrue(banana.IsPeeled);
        }

        [TestMethod]
        public void InterfacesInCollections_ShouldDemonstratePoint()
        {
            var orange = new Orange();
            var fruitSalad = new List<IFruit>
            {
                orange,
                new Banana(),
                new Grape()
            };

            foreach(var fruit in fruitSalad)
            {
                Console.WriteLine(fruit.Name);
                Console.WriteLine(fruit.Peel());

                Assert.IsInstanceOfType(fruit, typeof(IFruit));
                if(fruit is Orange)
                {
                    Console.WriteLine( ((Orange)fruit).Squeeze() );
                }
            }
        }

        private string GetFruitName(IFruit fruit)
        { // This is a method to give me a string of the name back
            return $"This fruit is called {fruit.Name}";
        }

        [TestMethod]
        public void InterfacesInMethods()
        {
            var grape = new Grape();

            var output = GetFruitName(grape);
            Console.WriteLine(output);
            Assert.IsTrue(output.Contains("This fruit is called Grape"));
        }
    }
}
