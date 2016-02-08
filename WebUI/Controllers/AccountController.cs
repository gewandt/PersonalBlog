using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AccountController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.Contains(model.Name) == null)
                {
                    _userService.Create(model.Name, model.Password, _roleService.GetByName("User"));
                    return View("RegistrationSuccessful");
                }
                ModelState.AddModelError("", "username are denied");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(string login, string password, bool remember = true)
        {
            if (ModelState.IsValid && _userService.Contains(login, password))
            {
                FormsAuthentication.SetAuthCookie(login, remember);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Wrong login or password");
            return View();
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "Home");
        }
    }
}
