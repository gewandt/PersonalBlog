using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<DalUserEntity> _repository;

        #region Ctor
        public UserService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<DalUserEntity>();
        }
        #endregion
        public void Create(string name, string password)
        {
            Create(new DalUserEntity
            {
                Name = name,
                Password = password,
                DalRole = new DalRoleEntity
                {
                    Name = "user"
                }
            });
        }

        private void Create(DalUserEntity user)
        {
            _repository.Create(user);
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
    }
}
