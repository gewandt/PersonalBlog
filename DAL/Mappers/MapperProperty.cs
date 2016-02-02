using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entities;
using ORM;

namespace DAL.Mappers
{
    public static class MapperProperty
    {
        #region DAL to Model

        public static User ToModel(this DalUserEntity item)
        {
            if (item == null)
                return null;

            User userEntity = new User
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                RoleId = item.DalRole.Id
            };
            return userEntity;
        }

        public static Role ToModel(this DalRoleEntity item)
        {
            if (item == null)
                return null;
            Role roleEntity = new Role
            {
                Id = item.Id,
                Name = item.Name
            };
            return roleEntity;
        }

        #endregion

        #region Model to DAL

        public static DalUserEntity ToDal(this User item)
        {
            if (item == null)
                return null;

            DalUserEntity userDalEntity = new DalUserEntity
            {
                Id = item.Id,
                Name = item.Name,
                Password = item.Password,
                DalRole = item.Role.ToDal()
            };
            return userDalEntity;
        }

        public static DalRoleEntity ToDal(this Role item)
        {
            if (item == null)
                return null;

            DalRoleEntity roleDalEntity = new DalRoleEntity
            {
                Id = item.Id,
                Name = item.Name
            };
            return roleDalEntity;
        }

        #endregion
    }
}
