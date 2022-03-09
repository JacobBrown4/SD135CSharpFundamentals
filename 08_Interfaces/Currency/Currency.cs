using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Interfaces.Currency
{
    public class Penny : ICurrency
    {
        public string Name
        {
            get
            {
                return "Penny";
            }
        }

        public decimal Value
        {
            get
            {
                return 0.01m;
            }
        }
    }

    public class Dime : ICurrency
    {
        public string Name => "Dime";
        public decimal Value => 0.10m;
    }

    public class Dollar : ICurrency
    {
        public string Name => "Dollar";

        public decimal Value => 1m;
    }

    public class ElectronicPayment : ICurrency
    {
        // Without a set or private set on value,
        // we can only set value making the object in a constructor
        public ElectronicPayment(decimal value)
        {
            Value = value;
        }
        public string Name => "Electronic Payment";
        public decimal Value { get; }
    }
}
