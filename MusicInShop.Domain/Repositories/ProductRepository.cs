using MusicInShop.Domain.Contexts;
using MusicInShop.Domain.Entities;
using MusicInShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.Domain.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        DataContext db;

        public ProductRepository(DataContext db)
        {
            this.db = db;
        }

        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Delete(Product item)
        {
            if (item != null)
            {
                db.CartProducts.RemoveRange(item.CartProducts);
                db.Products.Remove(item);
            }
        }

        public void DeleteById(int id)
        {
            Delete(Get(id));
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return db.Products.Where(predicate);
        }

        public Product FindFirst(Func<Product, bool> predicate)
        {
            return db.Products.FirstOrDefault(predicate);
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public void Update(Product item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}