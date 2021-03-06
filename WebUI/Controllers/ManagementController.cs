﻿using System.Linq;
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
        public ActionResult Edit(string login)
        {
            var roles = _roleService.GetAll().ToList();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            if (login != null)
            {
                var itemUser = _userService.Contains(login);
                return PartialView("Edit", itemUser);
            }
            return RedirectToAction("Control");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BllUserEntity itemUser, int role)
        {
            if (itemUser != null)
            {
                itemUser.BllRole = _roleService.GetById(role);
                _userService.Update(itemUser);
            }
            return RedirectToAction("Control");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var user = new BllUserEntity();
            var roles = _roleService.GetAll().ToList();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");
            return PartialView("Create", user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BllUserEntity itemUser, int role)
        {
            itemUser.BllRole = _roleService.GetById(role);
            if (itemUser.Name == null || itemUser.Password == null)
                return View("Error");
            if (_userService.Contains(itemUser.Name) == null)
                _userService.Create(itemUser.Name, itemUser.Password, itemUser.BllRole);
            return RedirectToAction("Control");
        }
    }
}
