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
            return item.ToModel();
        }

        public DalUserEntity ToDal(User entity)
        {
            if (entity == null)
                return null;
            return entity.ToDal();
        }

        public User ToDal(DalUserEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalUserEntity> ToDalCollection(IEnumerable<User> entity)
        {
            throw new NotImplementedException();
        }

        public void CopyFields(DalUserEntity dalFrom, User entityTo)
        {
            if (dalFrom == null || entityTo == null)
                return;
            entityTo.Id = (dalFrom.Id == 0) ? entityTo.Id : dalFrom.Id;
            entityTo.Name = dalFrom.Name ?? entityTo.Name;
            entityTo.Password = dalFrom.Password ?? entityTo.Password;
            entityTo.RoleId = (dalFrom.DalRole.Id == 0) ? entityTo.RoleId : dalFrom.DalRole.Id;
        }
    }
}
