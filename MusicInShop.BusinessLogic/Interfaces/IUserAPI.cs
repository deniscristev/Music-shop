using MusicInShop.BusinessLogic.DataTransfer;
using MusicInShop.BusinessLogic.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.BusinessLogic.Interfaces
{
    public interface IUserAPI
    {
        Result Login(UserDTO userDTO);
        Result Register(UserDTO userDTO);
        void AddToCart(string email, int productId, int? quantity = null);
        void RemoveFromCart(string email, int productId);
        void DecrementFromCart(string email, int productId);
        UserDTO GetUser(string email);
    }
}