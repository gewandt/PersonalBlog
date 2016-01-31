using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                if (_userService.Find(model.Name) == null)
                {
                    _userService.Create(model.Name, model.Password);
                    return View("RegistrationSuccessful");
                }
                ModelState.AddModelError("", "username are denied");
            }
            return View(model);
        }
    }
}
