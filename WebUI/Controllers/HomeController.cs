using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Hour = hour > 12 ? "p.m." : "a.m.";
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}
