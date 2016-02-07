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
    public class TagMapper : IMapper<Tag, DalTagEntity>
    {
        public Tag ToEntity(DalTagEntity item)
        {
            if (item == null)
                return null;
            return item.ToModel();
        }

        public DalTagEntity ToDal(Tag entity)
        {
            if (entity == null)
                return null;
            return entity.ToDal();
        }

        public Tag ToDal(DalTagEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTagEntity> ToDalCollection(IEnumerable<Tag> entity)
        {
            throw new NotImplementedException();
        }

        public void CopyFields(DalTagEntity dalFrom, Tag entityTo)
        {
            if (dalFrom == null || entityTo == null)
                return;
            entityTo.Id = (dalFrom.Id == 0) ? entityTo.Id : dalFrom.Id;
            entityTo.Name = dalFrom.Name ?? entityTo.Name;
            entityTo.ArticleId = (dalFrom.Article.Id == 0) ? entityTo.ArticleId : dalFrom.Article.Id;
        }
    }
}
