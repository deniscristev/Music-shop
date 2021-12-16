using MusicInShop.BusinessLogic.DataTransfer;
using MusicInShop.BusinessLogic.Infrastructure;
using MusicInShop.BusinessLogic.Interfaces;
using MusicInShop.Domain.Entities;
using MusicInShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.BusinessLogic.API
{
    public class UserAPI : API, IUserAPI
    {
        public UserAPI(IUnitOfWork database) : base(database)
        {
        }
        public Result Login(UserDTO userDTO)
        {
            var user = Database.Users.FindFirst(u => u.Email == userDTO.Email && u.Password == userDTO.Password);
            if (user == null)
            {
                return new Result { Succeeded = false, Message = "Неправильные данные для входа" };
            }
            return new Result { Succeeded = true };
        }

        public Result Register(UserDTO userDTO)
        {
            var user = Database.Users.FindFirst(u => u.Email == userDTO.Email);
            if (user != null)
            {
                return new Result { Succeeded = false, Message = "Почта уже занята" };
            }
            user = new User
            {
                NickName = userDTO.NickName,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Role = userDTO.Role
            };
            Database.Users.Create(user);
            Database.Save();
            return new Result { Succeeded = true };
        }

        public void AddToCart(string email, int productId, int? quantity = null)
        {
            var user = Database.Users.FindFirst(u => u.Email == email);
            var product = Database.Products.Get(productId);
            if (user == null || product == null)
                return;
            var cartProduct = user.CartProducts.FirstOrDefault(p => p.Product.Id == productId);
            if (cartProduct == null)
            {
                cartProduct = new CartProduct { Product = product, Quantity = quantity ?? 1 };
                user.CartProducts.Add(cartProduct);
            }
            else
            {
                cartProduct.Quantity += quantity ?? 1;
            }
            Database.Save();
        }
        public void RemoveFromCart(string email, int productId)
        {
            var user = Database.Users.FindFirst(u => u.Email == email);
            var product = Database.Products.Get(productId);
            if (user == null || product == null)
                return;
            var cartProduct = user.CartProducts.FirstOrDefault(p => p.Product.Id == productId);
            if (cartProduct != null)
            {
                user.CartProducts.Remove(cartProduct);
                Database.Save();
            }
        }
        public void DecrementFromCart(string email, int productId)
        {
            var user = Database.Users.FindFirst(u => u.Email == email);
            var product = Database.Products.Get(productId);
            if (user == null || product == null)
                return;
            var cartProduct = user.CartProducts.FirstOrDefault(p => p.Product.Id == productId);
            if (cartProduct != null)
            {
                if (--cartProduct.Quantity == 0)
                {
                    product.CartProducts.Remove(cartProduct);
                    user.CartProducts.Remove(cartProduct);
                    Database.CartProducts.Delete(cartProduct);
                }
                Database.Save();
            }
        }

        private UserDTO ConvertToDTO(User user)
        {
            if (user == null)
                return null;
            var userDTO = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                NickName = user.NickName,
                Password = user.Password,
                Role = user.Role,
                CartProducts = new Dictionary<ProductDTO, int>()
            };
            foreach (var cartProduct in user.CartProducts)
            {
                userDTO.CartProducts.Add(ProductAPI.ConvertToDTO(cartProduct.Product), cartProduct.Quantity);
            }
            return userDTO;
        }

        public UserDTO GetUser(string email)
        {
            var user = Database.Users.FindFirst(u => u.Email == email);
            return ConvertToDTO(user);
        }
    }
}