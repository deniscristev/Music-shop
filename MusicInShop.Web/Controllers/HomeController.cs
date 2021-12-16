using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicInShop.Web.Models;

namespace MusicInShop.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new NavbarModel { User = LoggedUser };
            return View(model);
        }
        

    }
}