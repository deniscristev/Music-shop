using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.Domain.Entities
{
    public class CartProduct
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
