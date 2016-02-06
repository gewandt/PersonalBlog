using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IUserService _userService;

        public BlogController(IBlogService blogService, IUserService userService)
        {
            _blogService = blogService;
            _userService = userService;
        }
        [HttpGet]
        public ActionResult Main()
        {
            var user = TempData["user"];
            if (user != null)
            {
                var blogs = _blogService.GetByUserName(user.ToString());
                return View(blogs);
            }
            if (HttpContext.User.IsInRole("Admin"))
            {
                TempData["user"] = HttpContext.User.Identity.Name;
            }
            return View(_blogService.GetAll());
        }
        public ActionResult Blog(string user)
        {
            TempData["user"] = user;
            return RedirectToAction("Main", "Blog");
        }
        [HttpGet]
        public ActionResult Create(string user)
        {
            BllBlogEntity blog = new BllBlogEntity { User = new BllUserEntity { Name = user } };
            return PartialView("Create", blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BllBlogEntity itemBlog)
        {
            if (itemBlog != null && itemBlog.Name.Length > 2)
            {
                var username = Request["user"];
                itemBlog.User = _userService.Contains(username);
                _blogService.Create(itemBlog);
            }
            return RedirectToAction("Main");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var itemBlog = _blogService.GetById(id);
            return PartialView("Edit", itemBlog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BllBlogEntity itemBlog)
        {
            if (itemBlog != null)
            {
                var updBlog = _blogService.GetById(itemBlog.Id);
                updBlog.Name = itemBlog.Name;
                _blogService.Update(updBlog);
            }
            return RedirectToAction("Main");
        }

        public ActionResult Delete(int id)
        {
            if (_blogService.GetById(id) != null)
                _blogService.Delete(id);
            return RedirectToAction("Main");
        }
    }
}
