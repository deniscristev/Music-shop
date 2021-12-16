using MusicInShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.Domain.Contexts
{
    public class DataContext : DbContext
    {
        static DataContext()
        {
            Database.SetInitializer(new AdminInitializer());
        }
        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
    }

    class AdminInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
            context.Users.Add(new User { Email = "admin@mail.ru", NickName = "admin", Password = "admin", Role = "admin" });
            context.SaveChanges();
        }
    }
}