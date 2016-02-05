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

        public void CopyFields(DalBlogEntity dalEntity, Blog entity)
        {
            throw new NotImplementedException();
        }
    }
}
