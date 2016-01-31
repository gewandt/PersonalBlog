using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;
using ORM;

namespace DAL.Mappers
{
    public class UserMapper : IMapper<User, DalUserEntity>
    {
        public User ToEntity(DalUserEntity item)
        {
            if (item == null)
                return null;
            User userEntity = new User();
            userEntity.Id = item.Id;
            userEntity.Name = item.Name;
            userEntity.Password = item.Password;
            userEntity.Role = new Role
            {
                Id = item.DalRole.Id,
                Name = item.DalRole.Name
            };
            return userEntity;
        }

        public DalUserEntity ToDal(User entity)
        {
            throw new NotImplementedException();
        }

        public void CopyFields(DalUserEntity item, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
