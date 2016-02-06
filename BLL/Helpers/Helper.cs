using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Entities;
using DAL.Interface.Repository;

namespace BLL.Helpers
{
    public class Helper
    {
        #region Clean articles in deleting blog

        public static void DeleteArticles(IRepository<DalArticleEntity> repository, int id)
        {
            var articles = repository.GetAll()
                .Where(c => c.Blog != null)
                .Where(c => c.Blog.Id == id)
                .Select(c => c)
                .ToList();
            foreach (var item in articles)
            {
                repository.Delete(item);
            }
        }

        #endregion


        #region Clean blogs with articles in deleting user

        public static void DeleteBlogs(IRepository<DalBlogEntity> blogRepository, IRepository<DalArticleEntity> articleRepository, int id)
        {
            var blogs = blogRepository.GetAll()
                .Where(c => c.User != null)
                .Where(c => c.User.Id == id)
                .Select(c => c)
                .ToList();
            foreach (var item in blogs)
            {
                DeleteArticles(articleRepository, item.Id);
                blogRepository.Delete(item);
            }
        }

        #endregion
    }
}
