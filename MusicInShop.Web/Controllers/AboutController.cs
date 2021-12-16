using MusicInShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicInShop.Web.Controllers
{
    public class AboutController : BaseController
    {
        // GET: About
        public ActionResult Abouts()
        {
            var model = new NavbarModel { User = LoggedUser };
            return View(model);
        }
    }
}