using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class UserService : IService<BllUserEntity>
    {
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
