using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            Users = new HashSet<User>();
            CartProducts = new HashSet<CartProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}