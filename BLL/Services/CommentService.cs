using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Entities;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<DalCommentEntity> _commentRepository;
        private readonly IRepository<DalArticleEntity> _articleRepository;
        private readonly IRepository<DalUserEntity> _userRepository;

        #region Ctor

        public CommentService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            _commentRepository = _unitOfWork.GetRepository<DalCommentEntity>();
            _articleRepository = _unitOfWork.GetRepository<DalArticleEntity>();
            _userRepository = _unitOfWork.GetRepository<DalUserEntity>();
        }

        #endregion
        public bool Create(string author, string text, int articleId)
        {
            _commentRepository.Create(new BllCommentEntity
            {
                Article = _articleRepository.GetById(articleId).ToBal(),
                Text = text,
                User = _userRepository.GetByPredicate(c => c.Name == author).ToBal(),
                Date = DateTime.Now
            }.ToDal());
            _unitOfWork.Commit();
            return true;
        }

        public IEnumerable<BllCommentEntity> GetAllForArticle(int id)
        {
            return _commentRepository.GetAll()
                 .Where(c => c.Article != null)
                 .Where(c => c.Article.Id == id)
                 .Select(c => c.ToBal());
        }
    }
}
