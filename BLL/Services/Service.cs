using System;
using System.Collections.Generic;
using BlogEntity.Interfaces;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Entities;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class UserService : IService<IBllEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<IDalEntity> _repository;

        #region Ctor
        public UserService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<IDalEntity>();
        }
        #endregion

        public bool Create(IBllEntity bllUser)
        {
            _repository.Create(bllUser.ToDal());
            return true;
        }

        public bool Delete(IBllEntity bllUser)
        {
            _repository.Delete(bllUser.ToDal());
            return true;
        }

        public bool Update(IBllEntity bllUser)
        {
            _repository.Update(bllUser.ToDal());
            return true;
        }

        public IBllEntity GetById(int id)
        {
            //return _userRepository.GetById(id).ToBll();
        }

        public IEnumerable<IBllEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
