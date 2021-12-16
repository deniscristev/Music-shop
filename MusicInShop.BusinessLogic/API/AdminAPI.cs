using MusicInShop.BusinessLogic.DataTransfer;
using MusicInShop.BusinessLogic.Interfaces;
using MusicInShop.Domain.Entities;
using MusicInShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.BusinessLogic.API
{
    public class AdminAPI : API, IAdminAPI
    {
        public AdminAPI(IUnitOfWork database) : base(database)
        {
        }
        public void AddProduct(ProductDTO productDTO, string imageUrl, string directory)
        {
            var product = new Product { Name = productDTO.Name, Category = productDTO.Category, Description= productDTO.Description, Price = productDTO.Price, Discount = productDTO.Discount };
            Database.Products.Create(product);
            Database.Save();
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(imageUrl), directory + "/" + product.Id + ".jpg");
            }
        }
        public void DeleteProduct(int productId, string directory)
        {
            var product = Database.Products.Get(productId);
            var path = directory + "/" + product.Id + ".jpg";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Database.Products.Delete(product);
            Database.Save();
        }
    }
}