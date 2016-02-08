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

        public static void DeleteArticles(IRepository<DalArticleEntity> artRepository, IRepository<DalTagEntity> tagRepository, int id)
        {
            var articles = artRepository.GetAll()
                .Where(c => c.Blog != null)
                .Where(c => c.Blog.Id == id)
                .Select(c => c)
                .ToList();
            foreach (var item in articles)
            {
                DeleteTags(tagRepository, item.Id);
                artRepository.Delete(item);
            }
        }

        #endregion


        #region Clean blogs with articles in deleting user

        public static void DeleteBlogs(IRepository<DalBlogEntity> blogRepository, IRepository<DalArticleEntity> articleRepository, IRepository<DalTagEntity> tagRepository, int id)
        {
            var blogs = blogRepository.GetAll()
                .Where(c => c.User != null)
                .Where(c => c.User.Id == id)
                .Select(c => c)
                .ToList();
            foreach (var item in blogs)
            {
                DeleteArticles(articleRepository, tagRepository, item.Id);
                blogRepository.Delete(item);
            }
        }

        #endregion

        #region Clean tags with deleting article

        public static void DeleteTags(IRepository<DalTagEntity> repository, int idArticle)
        {
            var tags = repository.GetAll()
                .Where(c => c.Article != null)
                .Where(c => c.Article.Id == idArticle)
                .Select(c => c)
                .ToList();
            foreach (var item in tags)
            {
                repository.Delete(item);
            }
        }

        #endregion

        #region Clean comments with deleting user

        public static void DeleteComments(IRepository<DalCommentEntity> repository, int idUser)
        {
            var comments = repository.GetAll()
                .Where(c => c.User != null)
                .Where(c => c.User.Id == idUser)
                .Select(c => c)
                .ToList();
            foreach (var item in comments)
            {
                repository.Delete(item);
            }
        }

        #endregion
    }
}
