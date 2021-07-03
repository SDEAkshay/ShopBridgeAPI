using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name of the product must contains at least 3 characters")]
        public string ProductName { get; set; }
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string PhotoPath { get; set; }
        public Category Category { get; set; }
    }
}
