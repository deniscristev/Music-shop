using MusicInshop.BusinessLogic;
using MusicInShop.BusinessLogic.DataTransfer;
using MusicInShop.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicInShop.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private MyBusinessLogic Bl { get; }

        protected BaseController()
        {
            Bl = new MyBusinessLogic();
        }

        protected IUserAPI UserAPI => Bl.UserAPI;
        protected IProductAPI ProductAPI => Bl.ProductAPI;
        protected IAdminAPI AdminAPI => Bl.AdminAPI;
        protected UserDTO LoggedUser => UserAPI.GetUser(User.Identity.Name);

    }
}