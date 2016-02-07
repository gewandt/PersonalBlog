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
        public bool Create(string name, BllArticleEntity article)
        {
            Create(new BllTagEntity
            {
                Name = name,
                Article = article
            });
            return true;
        }

        public IEnumerable<BllTagEntity> GetAllForArticle(int id)
        {
            return _tagRepository.GetAll()
                .Where(c => c.Article != null)
                .Where(c => c.Article.Id == id)
                .Select(c => c.ToBal());
        }

        private void Create(BllTagEntity tag)
        {
            _tagRepository.Create(tag.ToDal());
            _unitOfWork.Commit();
        }

        public bool Delete(BllTagEntity item)
        {
            throw new NotImplementedException();
        }

        public BllTagEntity GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
