using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;
using ORM;

namespace DAL.Mappers
{
    public class ArticleMapper : IMapper<Article, DalArticleEntity>
    {
        public Article ToEntity(DalArticleEntity item)
        {
            if (item == null)
                return null;
            return item.ToModel();
        }

        public DalArticleEntity ToDal(Article item)
        {
            if (item == null)
                return null;
            return item.ToDal();
        }

        public IEnumerable<DalArticleEntity> ToDalCollection(IEnumerable<Article> entity)
        {
            throw new NotImplementedException();
        }

        public void CopyFields(DalArticleEntity dalFrom, Article entityTo)
        {
            if (dalFrom == null || entityTo == null)
                return;
            entityTo.Id = (dalFrom.Id == 0) ? entityTo.Id : dalFrom.Id;
            entityTo.Name = dalFrom.Name ?? entityTo.Name;
            entityTo.BlogId = (dalFrom.Blog.Id == 0) ? entityTo.BlogId : dalFrom.Blog.Id;
            entityTo.Text = dalFrom.Text ?? entityTo.Text;
            entityTo.Date = dalFrom.Date;
        }
    }
}
