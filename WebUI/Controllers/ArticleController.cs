using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IArticleService _articleService;
        private readonly ITagService _tagService;
        private readonly ICommentService _commentService;

        public ArticleController(IBlogService blogService, IArticleService articleService, ITagService tagService, ICommentService commentService)
        {
            _blogService = blogService;
            _articleService = articleService;
            _tagService = tagService;
            _commentService = commentService;
        }
        [HttpGet]
        public ActionResult Articles(int id, string user)
        {
            try
            {
                var articles = _articleService.GetAllByBlog(id);
                if (articles != null)
                {
                    var articlesModel = GetListOfArticles(articles);
                    var blogName = _blogService.GetById(id).Name;
                    ViewBag.BlogName = blogName ?? string.Empty;
                    ViewBag.UserName = user;
                    return View("Articles", articlesModel);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return RedirectToAction("Main", "Blog");
        }

        public ActionResult Search()
        {
            var listArticles = _articleService.GetAll().ToList();
            return PartialView("Search", listArticles);
        }

        [HttpPost]
        public ActionResult Search(string searchParam)
        {
            List<BllArticleEntity> list = new List<BllArticleEntity>();
            if (string.IsNullOrEmpty(searchParam))
            {
                list = _articleService.GetAll().ToList();
            }
            else
            {
                list = _articleService.GetAll()
                    .Where(item => item.Name.StartsWith(searchParam))
                    .ToList();
            }
            return PartialView("Search", list);
        }



        [HttpGet]
        public ActionResult Create(string blog, string username)
        {
            var item = _blogService.GetByNameAndUser(username, blog);
            if (item != null)
            {
                ArticleModel model = new ArticleModel
                {
                    BlogName = blog,
                    Author = username,
                    Date = DateTime.Now
                };
                return PartialView("Create", model);
            }
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleModel itemArticle)
        {
            if (itemArticle != null)
            {
                if (!ModelState.IsValid) return PartialView("Create", itemArticle);
                var blogname = itemArticle.BlogName;
                var username = itemArticle.Author;
                var itemBlog = _blogService.GetByNameAndUser(username, blogname);
                var item = new BllArticleEntity
                {
                    Name = itemArticle.Name,
                    Text = itemArticle.Text,
                    Date = itemArticle.Date,
                    Blog = itemBlog
                };
                _articleService.Create(item);
                var article = _articleService.GetAll()
                    .Where(art => art.Blog != null)
                    .Where(art => art.Blog.User.Name == item.Blog.User.Name)
                    .FirstOrDefault(art => art.Name == item.Name);
                if (itemArticle.CurrentTag != null)
                {
                    var listTags = GetListOfTags(itemArticle, article);
                    _tagService.Create(listTags);
                }
                return RedirectToAction("Main", "Blog");
            }
            return RedirectToAction("Articles");
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var itemArticle = _articleService.GetById(id);
            if (itemArticle != null)
            {
                var tags = GetStringOfTags(itemArticle);
                ArticleModel model = new ArticleModel
                {
                    Name = itemArticle.Name,
                    Text = itemArticle.Text,
                    CurrentTag = tags.ToString(),
                    Author = itemArticle.Blog.User.Name
                };
                return PartialView("Edit", model);
            }
            return View("Error");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleModel itemArticle)
        {
            if (itemArticle != null)
            {
                if (!ModelState.IsValid) return PartialView("Edit", itemArticle);
                var updArticle = _articleService.GetById(itemArticle.Id);
                updArticle.Name = itemArticle.Name;
                updArticle.Text = itemArticle.Text;
                _articleService.Update(updArticle);
                if (itemArticle.CurrentTag != null)
                {
                    var listTags = GetListOfTags(itemArticle, updArticle);
                    _tagService.Update(listTags, itemArticle.Id);
                }
            }
            return RedirectToAction("Main", "Blog");
        }
        public ActionResult Delete(int id)
        {
            if (_articleService.GetById(id) != null)
                _articleService.Delete(id);
            return RedirectToAction("Main", "Blog");
        }

        public ActionResult Comments(int id)
        {
            var comments = _commentService.GetAllForArticle(id).ToList();
            TempData["articleId"] = id;
            return View(comments);
        }

        [HttpPost]
        public ActionResult Comments(string textComment)
        {
            try
            {
                var articleId = (int)TempData["articleId"];
                if (textComment != string.Empty)
                    _commentService.Create(HttpContext.User.Identity.Name, textComment, articleId);
                return RedirectToAction("Comments", articleId);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        #region Private members

        private IEnumerable<ArticleModel> GetListOfArticles(IEnumerable<BllArticleEntity> articles)
        {
            return articles.Select(item => new ArticleModel
            {
                Id = item.Id,
                Name = item.Name,
                Text = item.Text,
                Tags = _tagService.GetAllForArticle(item.Id).ToList(),
                Author = item.Blog.User.Name,
                Date = item.Date
            }).ToList();
        }

        private List<BllTagEntity> GetListOfTags(ArticleModel itemArticle, BllArticleEntity item)
        {
            string[] substrings = Regex.Split(itemArticle.CurrentTag, ";");
            return (from match in substrings
                    where match != string.Empty
                    select new BllTagEntity
                    {
                        Name = match,
                        Article = item
                    }).ToList();
        }

        private StringBuilder GetStringOfTags(BllArticleEntity itemArticle)
        {
            var tags = _tagService.GetAllForArticle(itemArticle.Id);
            StringBuilder sb = new StringBuilder();
            foreach (var item in tags)
            {
                sb.AppendFormat("{0};", item.Name);
            }
            return sb;
        }

        #endregion
    }
}
