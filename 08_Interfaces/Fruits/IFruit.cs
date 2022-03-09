using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Interfaces.Fruits
{
    // Interfaces are contracts, bare minimum derived objects
    public interface IFruit // Cannot exist as their own objects
    {
        string Name { get; }
        bool IsPeeled { get; }
        string Peel();
    }
}
