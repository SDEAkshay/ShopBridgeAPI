using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name of the Category of product must contains at least 3 characters")]
        public string CategoryName { get; set; }
    }
}
