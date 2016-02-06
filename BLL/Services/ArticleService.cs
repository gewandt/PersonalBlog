using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Entities;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<DalArticleEntity> _articleRepository;

        #region Ctor

        public ArticleService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            _articleRepository = _unitOfWork.GetRepository<DalArticleEntity>();
        }

        #endregion

        public void Create(BllArticleEntity item)
        {
            _articleRepository.Create(item.ToDal());
            _unitOfWork.Commit();
        }

        public IEnumerable<BllArticleEntity> GetAllByBlog(int id)
        {
            return _articleRepository.GetAll().Select(c => c.ToBal()).Where(c => c.Blog.Id == id);
        }

        public IEnumerable<BllArticleEntity> GetAll()
        {
            return _articleRepository.GetAll().Select(c => c.ToBal());
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

    }
}
