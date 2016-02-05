using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IArticleService _articleService;

        public BlogController(IBlogService blogService, IArticleService articleService)
        {
            _blogService = blogService;
            _articleService = articleService;
        }
        [HttpGet]
        public ActionResult Main()
        {
            var blogs = _blogService.GetAll();
            return View(blogs);
        }

        [HttpGet]
        public ActionResult Articles(int id)
        {
            var articles = _articleService.GetAllByBlog(id);
            if (articles != null)
            {
                var blogName = _blogService.GetById(id).Name;
                ViewBag.BlogName = blogName ?? string.Empty;
                return View("Articles", articles);
            }
            return View("Main");
        }
    }
}
