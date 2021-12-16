using MusicInShop.BusinessLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MusicInShop.Web.Models;

namespace MusicInShop.Web.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Login()
        {
            var model = new LoginModel { User = LoggedUser };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDTO { Email = model.Email, Password = model.Password };
                var result = UserAPI.Login(user);
                if (result.Succeeded)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", result.Message);

            }
            return View(model);
        }

        public ActionResult Register()
        {
            var model = new RegisterModel { User = LoggedUser };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDTO { Email = model.Email, NickName = model.Nickname, Password = model.Password, Role = "user" };
                var result = UserAPI.Register(user);
                if (result.Succeeded)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(model);
        }
        [Authorize]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}