using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace WebUI.Controllers
{
    public class ManagementController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public ManagementController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Control()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Control");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(BllUserEntity itemUser)
        {
            _userService.Update(itemUser);
            return RedirectToAction("Control");
        }
    }
}
