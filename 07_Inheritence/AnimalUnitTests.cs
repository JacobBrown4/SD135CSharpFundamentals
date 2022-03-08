using _07_Inheritence.Animals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _07_Inheritence
{
    [TestClass]
    public class AnimalUnitTests
    {
        [TestMethod]
        public void Animal()
        {
            Snake snake = new Snake();
            snake.Move();
            Console.WriteLine(snake.NumberOfLegs);

            GardenSnake gSnake = new GardenSnake();
            gSnake.Move();
            Console.WriteLine(gSnake.Color);

            CerastesSnake cSnake = new CerastesSnake();
            cSnake.Move();
            Console.WriteLine(cSnake.IsMammal);
        }

        [TestMethod]
        public void Bears()
        {
            Bear bear = new Bear();
            bear.Roar();
            bear.Move();


            PolarBear pBear = new PolarBear();
            pBear.Roar();
            pBear.Run();
        }

        [TestMethod]
        public void Caterpillars()
        {
            Caterpillar caterpillar = new Caterpillar();
            Console.WriteLine(caterpillar.CanCrawl);
            caterpillar.PukeSilk();


            Cacoon cacoon = new Cacoon();
            Console.WriteLine(cacoon.CanCrawl);

            Butterfly butterfly = new Butterfly();
            Console.WriteLine(butterfly.CanCrawl);
            butterfly.PukeSilk();
        }
    }
}
