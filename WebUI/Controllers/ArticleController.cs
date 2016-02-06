using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;

namespace WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IArticleService _articleService;

        public ArticleController(IBlogService blogService, IArticleService articleService)
        {
            _blogService = blogService;
            _articleService = articleService;
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
            return RedirectToAction("Main", "Blog");
        }

    }
}
