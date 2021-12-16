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
    public class CartProductRepository : IRepository<CartProduct>
    {
        DataContext db;

        public CartProductRepository(DataContext db)
        {
            this.db = db;
        }

        public void Create(CartProduct item)
        {
            db.CartProducts.Add(item);
        }

        public void Delete(CartProduct item)
        {
            if (item != null)
                db.CartProducts.Remove(item);
        }

        public void DeleteById(int id)
        {
            Delete(Get(id));
        }

        public IEnumerable<CartProduct> Find(Func<CartProduct, bool> predicate)
        {
            return db.CartProducts.Where(predicate);
        }

        public CartProduct FindFirst(Func<CartProduct, bool> predicate)
        {
            return db.CartProducts.FirstOrDefault(predicate);
        }

        public CartProduct Get(int id)
        {
            return db.CartProducts.Find(id);
        }

        public IEnumerable<CartProduct> GetAll()
        {
            return db.CartProducts.ToList();
        }

        public void Update(CartProduct item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}