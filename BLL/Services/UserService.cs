using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class UserService : IService<BllUserEntity>
    {
        private static readonly Exception NullProviderError;
        private readonly IUserRepository _userRepository;

        #region Static ctor
        static UserService()
        {
            NullProviderError = new Exception("UserService: data provider not initialized.");
        }
        #endregion

        public bool Create(BllUserEntity bllUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(BllUserEntity bllUser)
        {
            throw new NotImplementedException();
        }

        public BllUserEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BllUserEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
