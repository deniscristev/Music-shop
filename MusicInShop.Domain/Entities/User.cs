using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.Domain.Entities
{
    public class User
    {
        public User()
        {
            CartProducts = new HashSet<CartProduct>();
        }

        public int Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}