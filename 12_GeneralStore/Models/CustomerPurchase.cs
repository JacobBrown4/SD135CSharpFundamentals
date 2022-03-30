using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _12_GeneralStore.Models
{
    public class CustomerPurchase
    { // View model
        public string CustomerName { get; set; }
        public List<string> Products { get; set; } = new List<string>();

        public double TotalSpent { get; set; }
    }
}