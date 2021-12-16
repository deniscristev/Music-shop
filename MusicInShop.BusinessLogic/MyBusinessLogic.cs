using MusicInShop.BusinessLogic.API;
using MusicInShop.BusinessLogic.Interfaces;
using MusicInShop.Domain;
using MusicInShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInshop.BusinessLogic
{
    public class MyBusinessLogic
    {
        public MyBusinessLogic()
        {
            Database = new UnitOfWork("MusicInShop");
        }

        IUnitOfWork Database { get; }

        IUserAPI userAPI;
        IProductAPI productAPI;
        IAdminAPI adminAPI;

        public IUserAPI UserAPI
        {
            get
            {
                if (userAPI == null)
                    userAPI = new UserAPI(Database);
                return userAPI;
            }
        }
        public IProductAPI ProductAPI
        {
            get
            {
                if (productAPI == null)
                    productAPI = new ProductAPI(Database);
                return productAPI;
            }
        }
        public IAdminAPI AdminAPI
        {
            get
            {
                if (adminAPI == null)
                    adminAPI = new AdminAPI(Database);
                return adminAPI;
            }
        }
    }
}