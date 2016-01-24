using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class Service : IService<IBllEntity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<IDalEntity> _repository;

        #region Ctor
        public Service(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<IDalEntity>();
        }
        #endregion

        public bool Create(IBllEntity bllItem)
        {
            _repository.Create(bllItem.ToDal());
            return true;
        }

        public bool Delete(IBllEntity bllItem)
        {
            _repository.Delete(bllItem.ToDal());
            return true;
        }

        public bool Update(IBllEntity bllItem)
        {
            _repository.Update(bllItem.ToDal());
            return true;
        }

        public IBllEntity GetById(int id)
        {
            //return _repository.GetById(id).ToBll();
            throw new NotImplementedException();
        }

        public IEnumerable<IBllEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
