using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Interfaces.Fruits
{
    public class Banana : IFruit // Minimums, not limits
    {
        public Banana() { }
        public Banana(bool isPeeled)
        {
            IsPeeled = isPeeled;
        }
        public string Name
        {
            get
            {
                return "Banana";
            }
        }
        public bool IsPeeled { get; private set; }
        public string Peel()
        {
            IsPeeled = true;
            return "You peel the banana";
        }

    }
}
