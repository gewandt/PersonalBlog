using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
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
        public ActionResult Articles(int id, string user)
        {
            var articles = _articleService.GetAllByBlog(id);
            if (articles != null)
            {
                var blogName = _blogService.GetById(id).Name;
                ViewBag.BlogName = blogName ?? string.Empty;
                ViewBag.UserName = user;
                return View("Articles", articles);
            }
            return RedirectToAction("Main", "Blog");
        }
        [HttpGet]
        public ActionResult Create(string blog, string username)
        {
            var item = _blogService.GetByNameAndUser(username, blog);
            if (item != null)
            {
                BllArticleEntity article = new BllArticleEntity{Date = DateTime.Now};
                TempData["blogname"] = blog;
                TempData["username"] = username;
                return PartialView("Create", article);
            }
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BllArticleEntity itemArticle)
        {
            if (itemArticle != null)
            {
                var blogname = TempData["blogname"].ToString();
                var username = Request["username"];
                var itemBlog = _blogService.GetByNameAndUser(username, blogname);
                var item = new BllArticleEntity
                {
                    Name = itemArticle.Name,
                    Text = itemArticle.Text,
                    Date = DateTime.UtcNow,
                    Blog = itemBlog
                };
                _articleService.Create(item);
                return RedirectToAction("Main", "Blog");
            }
            return RedirectToAction("Articles");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var itemArticle = _articleService.GetById(id);
            return PartialView("Edit", itemArticle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BllArticleEntity itemArticle)
        {
            if (itemArticle != null)
            {
                var updArticle = _articleService.GetById(itemArticle.Id);
                updArticle.Name = itemArticle.Name;
                updArticle.Text = itemArticle.Text;
                _articleService.Update(updArticle);
            }
            return RedirectToAction("Main", "Blog");
        }
        public ActionResult Delete(int id)
        {
            if (_articleService.GetById(id) != null)
                _articleService.Delete(id);
            return RedirectToAction("Main", "Blog");
        }
    }
}
