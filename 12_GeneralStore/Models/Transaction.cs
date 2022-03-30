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
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfTransaction { get; set; }

    }
}