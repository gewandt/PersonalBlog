using System;
using System.Collections.Generic;
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

            User userEntity = item.ToModel();
            return userEntity;
        }

        public DalUserEntity ToDal(User entity)
        {
            if (entity == null)
                return null;

            DalUserEntity userEntity = entity.ToDal();
            return userEntity;
        }

        public User ToDal(DalUserEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalUserEntity> ToDalCollection(IEnumerable<User> entity)
        {
            throw new NotImplementedException();
        }
    }
}
