using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Async
{
    public class Potato
    {
        public Potato() { }
        public Potato(bool isPeeled)
        {
            IsPeeled = isPeeled;
        }

        public bool IsPeeled { get; set; }
        public bool Peel()
        {
            Console.WriteLine("Started peeling the potato");

            Task.Delay(2000).Wait();
            IsPeeled = true;
            Console.WriteLine("You peel the potato");
            return true;
        }
    }

    public class Fries
    {
        public Fries(Potato potato) { }
    }

    public class Hamburger
    {

    }
}
