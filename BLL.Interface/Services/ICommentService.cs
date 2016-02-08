using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ICommentService
    {
        bool Create(string author, string text, int articleId);
        IEnumerable<BllCommentEntity> GetAllForArticle(int id);
    }
}
