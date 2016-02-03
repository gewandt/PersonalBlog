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
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<DalRoleEntity> _repository;

        #region Ctor
        public RoleService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<DalRoleEntity>();
        }
        #endregion
        public void Create(string name)
        {
            Create(new BllRoleEntity { Name = name });
        }

        public void Create(BllRoleEntity role)
        {
            _repository.Create(role.ToDal());
            _unitOfWork.Commit();
        }

        public bool ResetToDefault(int id)
        {
            throw new NotImplementedException();
        }

        public BllRoleEntity GetById(int id)
        {
            return _repository.GetById(id).ToBal();
        }

        public BllRoleEntity GetByName(string name)
        {
            if (name == null) 
                return null;
            return _repository.GetByPredicate(x => x.Name == name).ToBal();
        }

        public IEnumerable<BllRoleEntity> GetAll()
        {
            return _repository.GetAll().Select(c => c.ToBal());
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
