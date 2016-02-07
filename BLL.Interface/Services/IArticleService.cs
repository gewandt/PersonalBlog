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
        void Create(BllArticleEntity item);
        bool Update(BllArticleEntity item);
        bool Delete(int id);
        BllArticleEntity GetById(int id);
        IEnumerable<BllArticleEntity> GetAllByBlog(int id);
        IEnumerable<BllArticleEntity> GetAll();
    }
}
