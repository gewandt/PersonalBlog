using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ITagService
    {
        bool Create(string name, BllArticleEntity article);
        IEnumerable<BllTagEntity> GetAllForArticle(int id);
        //bool Delete(BllTagEntity item);
        //BllTagEntity GetById(int id);
    }
}
