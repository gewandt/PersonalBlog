using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IBlogService : IDisposable
    {
        void Create(BllBlogEntity item);
        bool Update(BllBlogEntity item);
        bool Delete(int id);
        BllBlogEntity GetByNameAndUser(string user, string blog);
        BllBlogEntity GetById(int id);
        IEnumerable<BllBlogEntity> GetByUserName(string name);
        IEnumerable<BllBlogEntity> GetAll();
    }
}
