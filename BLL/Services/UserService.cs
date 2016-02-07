using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BLL.Helpers;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Entities;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<DalUserEntity> _userRepository;
        private readonly IRepository<DalBlogEntity> _blogRepository;
        private readonly IRepository<DalArticleEntity> _articleRepository;
        private readonly IRepository<DalTagEntity> _tagRepository;

        #region Ctor

        public UserService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<DalUserEntity>();
            _blogRepository = _unitOfWork.GetRepository<DalBlogEntity>();
            _articleRepository = _unitOfWork.GetRepository<DalArticleEntity>();
            _tagRepository = _unitOfWork.GetRepository<DalTagEntity>();
        }

        #endregion
        public void Create(string name, string password, BllRoleEntity role)
        {
            Create(new BllUserEntity
            {
                Name = name,
                Password = password,
                BllRole = role
            });
        }

        private void Create(BllUserEntity user)
        {
            _userRepository.Create(user.ToDal());
            _unitOfWork.Commit();
        }

        public bool Update(BllUserEntity item)
        {
            var user = _userRepository.GetById(item.Id);
            if (user == null)
                return false;
            _userRepository.Update(item.ToDal());
            _unitOfWork.Commit();
            return true;
        }

        public void Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                return;
            Helper.DeleteBlogs(_blogRepository, _articleRepository, _tagRepository, id);
            _userRepository.Delete(user);
            _unitOfWork.Commit();
        }

        public IEnumerable<BllUserEntity> GetAll()
        {
            return _userRepository.GetAll().Select(c => c.ToBal());
        }

        public string GetRole(string login)
        {
            var user = _userRepository.GetByPredicate(c => c.Name == login);
            if (user == null)
                return string.Empty;
            return user.ToBal()
                .BllRole
                .Name;
        }

        public BllUserEntity Contains(string login)
        {
            return _userRepository.GetByPredicate(c => c.Name == login).ToBal();
        }

        public bool Contains(string login, string password)
        {
            var user = Contains(login);
            if (user == null) return false;
            return user.Password == password;
        }
    }
}
