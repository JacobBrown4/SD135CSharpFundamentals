using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _12_GeneralStore.Models
{
    public class Transaction
    {
        // Joining Table (SQL) or Junction Table (MSFT)
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))] // Either annotation style works
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        public int Quantity { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfTransaction { get; set; }
        public double Total
        {
            get
            {
                if (Product == null)
                    return 0;

                double totalCost = Quantity * Product.Price; // Get cost price times amount purchased
                double discount = totalCost * Discount(totalCost); // Figure out what the discount is
                double tax = (totalCost - discount) * 0.07; // Add sales tax
                return Math.Round(totalCost + tax,2); // Round it to the nearest .00 place
            }
        }

        public double BulkSavings
        {
            get
            {
                if (Product == null)
                    return 0;
                
                double total = Quantity * Product.Price;
                return Math.Round((total * Discount(total)),2);
            }
        }

        public double Discount(double totalCost)
        {
            double discount;
            // We'll offer a discount for bulk orders
            if (Quantity > 100)
                discount = 0.05;
            else if (Quantity > 20 && Quantity <= 100)
                discount = 0.04;
            else if (Quantity > 5 && Quantity <= 20)
                discount = 0.025;
            else
                discount = 0;
            return discount;
        }

    }
}