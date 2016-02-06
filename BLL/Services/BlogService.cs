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
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<DalBlogEntity> _blogRepository;

        #region Ctor

        public BlogService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            _blogRepository = _unitOfWork.GetRepository<DalBlogEntity>();
        }

        #endregion

        public void Create(BllBlogEntity user)
        {
            _blogRepository.Create(user.ToDal());
            _unitOfWork.Commit();
        }

        public bool Update(BllBlogEntity item)
        {
            var blog = _blogRepository.GetById(item.Id);
            if (blog == null)
                return false;
            _blogRepository.Update(item.ToDal());
            _unitOfWork.Commit();
            return true;
        }

        public BllBlogEntity GetById(int id)
        {
            return _blogRepository.GetById(id).ToBal();
        }

        public IEnumerable<BllBlogEntity> GetByName(string name)
        {
            var list = _blogRepository.GetAll();
            return from c in list 
                   where c.User.Name == name
                   select c.ToBal();
        }

        public IEnumerable<BllBlogEntity> GetAll()
        {
            return _blogRepository.GetAll().Select(c => c.ToBal());
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
