using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IArticleService : IDisposable
    {
        //void Create(string name, BllUserEntity user);
        //bool Update(int id);
        //bool Delete(int id);
        //BllBlogEntity GetById(int id);
        IEnumerable<BllArticleEntity> GetAllByBlog(int id);
        IEnumerable<BllArticleEntity> GetAll();
    }
}
