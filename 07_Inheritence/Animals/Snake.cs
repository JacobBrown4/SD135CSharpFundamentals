using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritence.Animals
{
    public class Snake : Animal
    {
        public Snake()
        {
            Console.WriteLine("Constructing a snake");
            HasFur = false;
            IsMammal = false;
            Diet = DietType.Carnivore;
            NumberOfLegs = 0;
        }
        public string Color { get; set; }
        public override void Move()
        {
            Console.Write("The snake slithers");
        }
        public void Slither()
        {
            Move();
        }
    }

    public class GardenSnake : Snake
    {
        public GardenSnake()
        {
            Console.WriteLine("It's from a garden");
            Color = "Green";
        }

        public override void Move()
        {
            base.Move();
            Console.WriteLine(" through the garden");

        }
    }

    public class CerastesSnake : Snake
    {
        public CerastesSnake()
        {
            Console.WriteLine("It's from the desert");
            Color = "Brown";
        }

        public override void Move()
        {
            base.Move();
            Console.WriteLine(" throught the desert.");
        }
    }
}
