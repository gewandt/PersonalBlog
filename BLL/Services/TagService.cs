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
    public class TagService : ITagService
    {
        private readonly IRepository<DalTagEntity> _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tagRepository = _unitOfWork.GetRepository<DalTagEntity>();
        }
        public bool Create(IEnumerable<BllTagEntity> listTags)
        {
            if (listTags == null)
                return false;
            foreach (var tag in listTags)
            {
                _tagRepository.Create(tag.ToDal());
            }
            _unitOfWork.Commit();
            return true;
        }

        public IEnumerable<BllTagEntity> GetAllForArticle(int id)
        {
            return _tagRepository.GetAll()
                .Where(c => c.Article != null)
                .Where(c => c.Article.Id == id)
                .Select(c => c.ToBal());
        }

        public bool Update(IEnumerable<BllTagEntity> listTags, int articleId)
        {
            if (listTags == null)
                return false;
            var tags = GetAll()
                .Where(item => item.Article != null)
                .Where(item => item.Article.Id == articleId);
            foreach (var item in tags)
            {
                _tagRepository.Delete(item.ToDal());
            }
            List<BllTagEntity> listUpd = listTags.ToList();
            Create(listUpd);
            _unitOfWork.Commit();
            return true;
        }

        public IEnumerable<BllTagEntity> GetAll()
        {
            return _tagRepository.GetAll().Select(c => c.ToBal());
        }

        public bool Delete(BllTagEntity item)
        {
            var tag = _tagRepository.GetById(item.Id);
            if (tag == null)
                return false;
            _tagRepository.Delete(tag);
            _unitOfWork.Commit();
            return true;
        }

        public BllTagEntity GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
