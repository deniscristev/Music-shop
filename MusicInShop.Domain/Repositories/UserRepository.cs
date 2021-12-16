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
    class UserRepository : IRepository<User>
    {
        DataContext db;

        public UserRepository(DataContext db)
        {
            this.db = db;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(User item)
        {
            if (item != null)
            {

                db.CartProducts.RemoveRange(item.CartProducts);
                db.Users.Remove(item);
            }
        }

        public void DeleteById(int id)
        {
            Delete(Get(id));
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.Users.Where(predicate);
        }

        public User FindFirst(Func<User, bool> predicate)
        {
            return db.Users.FirstOrDefault(predicate);
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public void Update(User item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}