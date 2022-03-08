using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Inheritence.Animals
{
    public class Caterpillar : Animal
    {
        public Caterpillar()
        {
            Console.WriteLine("A caterpillar is born");
            NumberOfLegs = 20;
            IsMammal = false;
            Diet = DietType.Herbivore;
            HasFur = false;
            CanCrawl = true;
        }

        public bool CanCrawl { get; set; }
        public bool CanFly
        {
            get
            {
                return false;
            }
        }

        public virtual void PukeSilk()
        {
            PukeSilkBase();
        }

        protected void PukeSilkBase()
        {
            Console.WriteLine($"The {GetType().Name} pukes silk");
        }
    }

    public class Cacoon : Caterpillar
    {
        public Cacoon()
        {
            Console.WriteLine("It wraps itself in silk");
            NumberOfLegs = 0;
        }
        public bool CanCrawl
        {
            get
            {
                return false;
            }
        }

        public override void PukeSilk()
        {
            Console.WriteLine("It can't, it's just chilling");
        }

    }

    public class Butterfly : Cacoon
    {
        public Butterfly()
        {
            Console.WriteLine("It's reborn a buttefly");
            NumberOfLegs = 12;
            CanFly = true;
            CanCrawl = true;
        }
        
        public bool CanFly { get; set; }
        public bool CanCrawl { get; set; }
        public void Fly()
        {
            Console.WriteLine("The butterfly flies!!!");
        }
        public override void PukeSilk()
        { // I want to use the grandparent version of puke silk
            // By making a second method call that's protect it's only available to derived classes like this one.
            PukeSilkBase();
        }
    }
}
