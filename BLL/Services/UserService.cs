using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        public bool CreateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public bool EditUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public UserEntity GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
