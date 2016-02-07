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
        bool Create(IEnumerable<BllTagEntity> listTags);
        IEnumerable<BllTagEntity> GetAllForArticle(int id);
        bool Update(IEnumerable<BllTagEntity> listTags, int articleId);
        IEnumerable<BllTagEntity> GetAll();
    }
}
