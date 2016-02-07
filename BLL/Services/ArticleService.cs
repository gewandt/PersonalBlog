using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Helpers;
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
        private readonly IRepository<DalTagEntity> _tagRepository;

        #region Ctor

        public ArticleService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            _articleRepository = _unitOfWork.GetRepository<DalArticleEntity>();
            _tagRepository = _unitOfWork.GetRepository<DalTagEntity>();
        }

        #endregion

        public void Create(BllArticleEntity item)
        {
            _articleRepository.Create(item.ToDal());
            _unitOfWork.Commit();
        }

        public bool Update(BllArticleEntity item)
        {
            var article = _articleRepository.GetById(item.Id);
            if (article == null)
                return false;
            _articleRepository.Update(item.ToDal());
            _unitOfWork.Commit();
            return true;
        }

        public bool Delete(int id)
        {
            var article = _articleRepository.GetById(id);
            if (article == null)
                return false;
            Helper.DeleteTags(_tagRepository, id);
            _articleRepository.Delete(article);
            _unitOfWork.Commit();
            return true;
        }

        public BllArticleEntity GetById(int id)
        {
            return _articleRepository.GetById(id).ToBal();
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
