using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicInShop.BusinessLogic.DataTransfer
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public IDictionary<ProductDTO, int> CartProducts { get; set; }
    }
}