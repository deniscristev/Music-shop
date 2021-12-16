using MusicInShop.BusinessLogic.DataTransfer;
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
    public class ProductAPI : API, IProductAPI
    {
        public ProductAPI(IUnitOfWork database) : base(database)
        {
        }

        static internal ProductDTO ConvertToDTO(Product product)
        {
            if (product == null)
                return null;
            return new ProductDTO
            {
                Id = product.Id,
                Category = product.Category,
                Description = product.Description,
                Discount = product.Discount,
                Name = product.Name,
                Price = product.Price
            };
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return Database.Products.GetAll().ToList().ConvertAll(ConvertToDTO);
        }

        public ProductDTO GetProduct(int productId)
        {
            return ConvertToDTO(Database.Products.Get(productId));
        }
    }
}