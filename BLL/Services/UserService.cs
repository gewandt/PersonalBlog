using System;
using System.Collections.Generic;
using BlogEntity.Entities;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class UserService : IService<UserEntity>
    {
        public bool Create(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public UserEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
