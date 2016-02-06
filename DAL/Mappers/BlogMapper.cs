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
    public class BlogMapper : IMapper<Blog, DalBlogEntity>
    {
        public Blog ToEntity(DalBlogEntity item)
        {
            if (item == null)
                return null;
            return item.ToModel();
        }

        public DalBlogEntity ToDal(Blog item)
        {
            if (item == null)
                return null;
            return item.ToDal();
        }

        public IEnumerable<DalBlogEntity> ToDalCollection(IEnumerable<Blog> entity)
        {
            throw new NotImplementedException();
        }

        public void CopyFields(DalBlogEntity dalFrom, Blog entityTo)
        {
            if (dalFrom == null || entityTo == null)
                return;
            entityTo.Id = (dalFrom.Id == 0) ? entityTo.Id : dalFrom.Id;
            entityTo.Name = dalFrom.Name ?? entityTo.Name;
            entityTo.UserId = (dalFrom.User.Id == 0) ?  entityTo.UserId : dalFrom.User.Id;
        }
    }
}
