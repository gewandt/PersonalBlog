using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly IRepository<DalRoleEntity> _roleRepository; 

        #region Ctor

        public UserService(IUnitOfWork unitOfWork)
        {
            MapperProperty.Configure();
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<DalUserEntity>();
            _roleRepository = _unitOfWork.GetRepository<DalRoleEntity>();
        }

        #endregion
        public void Create(string name, string password)
        {
            var role = _roleRepository.GetByPredicate(c => c.Name == "User");
            Create(new BllUserEntity
            {
                Name = name,
                Password = password,
                BllRole = role.ToBal()
            });
        }

        private void Create(BllUserEntity user)
        {
            _userRepository.Create(user.ToDal());
            _unitOfWork.Commit();
        }

        public bool Update(BllUserEntity item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BllUserEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public BllUserEntity Find(string name)
        {
            return null;
        }
    }
}
