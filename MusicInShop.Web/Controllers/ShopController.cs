using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicInShop.Web.Models;

namespace MusicInShop.Web.Controllers
{
    public class ShopController : BaseController
    {
        public ActionResult Index()
        {
            var model = new ShopModel { User = LoggedUser, Products = ProductAPI.GetAllProducts() };
            return View(model);
        }

        public ActionResult Guitar()
        {
            var model = new ShopModel { User = LoggedUser, Products = ProductAPI.GetAllProducts() };
            return View(model);
        }

        public ActionResult Keyboard()
        {
            var model = new ShopModel { User = LoggedUser, Products = ProductAPI.GetAllProducts() };
            return View(model);
        }

        public ActionResult Violin()
        {
            var model = new ShopModel { User = LoggedUser, Products = ProductAPI.GetAllProducts() };
            return View(model);
        }
        public ActionResult Wind()
        {
            var model = new ShopModel { User = LoggedUser, Products = ProductAPI.GetAllProducts() };
            return View(model);
        }

        public ActionResult Accessories()
        {
            var model = new ShopModel { User = LoggedUser, Products = ProductAPI.GetAllProducts() };
            return View(model);
        }

        public ActionResult Search()
        {
            var model = new ShopModel { User = LoggedUser, Products = ProductAPI.GetAllProducts() };
            return View(model);
        }

        public ActionResult Product(int id)
        {
            var model = new ProductPageModel { User = LoggedUser, Product = ProductAPI.GetProduct(id) };
            return View(model);
        }
        [Authorize]
        public ActionResult Cart()
        {
            var model = new NavbarModel { User = LoggedUser };
            return View(model);
        }
        [Authorize]
        public ActionResult AddToCart(int id, int? quantity)
        {
            UserAPI.AddToCart(User.Identity.Name, id, quantity);
            return PartialView("Empty");
        }
        [Authorize]
        public ActionResult RemoveFromCart(int id)
        {
            UserAPI.RemoveFromCart(User.Identity.Name, id);
            var model = new NavbarModel { User = LoggedUser };
            return PartialView("CartPartial", model);
        }
        [Authorize]
        public ActionResult IncrementToCart(int id)
        {
            UserAPI.AddToCart(User.Identity.Name, id);
            var model = new NavbarModel { User = LoggedUser };
            return PartialView("CartPartial", model);
        }
        [Authorize]
        public ActionResult DecrementFromCart(int id)
        {
            UserAPI.DecrementFromCart(User.Identity.Name, id);
            var model = new NavbarModel { User = LoggedUser };
            return PartialView("CartPartial", model);
        }
    }
}