using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicInShop.Web.Models
{
    public class ProductModel : NavbarModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}