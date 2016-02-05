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
        //void Create(string name, BllUserEntity user);
        //bool Update(int id);
        //bool Delete(int id);
        BllBlogEntity GetById(int id);
        //BllBlogEntity GetByName(string name);
        IEnumerable<BllBlogEntity> GetAll();
    }
}
