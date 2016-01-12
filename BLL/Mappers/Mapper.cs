using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntity.Interfaces;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Entities;

namespace BLL.Mappers
{
    public static class Mapper
    {
        #region BLL to DAL

        public static IDalEntity ToDal(this IBllEntity itemEntity)
        {
            if (itemEntity == null)
                return null;

            if (itemEntity is BllUserEntity)
            {
                var itemUserEntity = (BllUserEntity)itemEntity;
                DalUserEntity dalUserEntity = new DalUserEntity();
                dalUserEntity.Id = itemUserEntity.Id;
                dalUserEntity.Name = itemUserEntity.Name;
                dalUserEntity.Password = itemUserEntity.Password;
                dalUserEntity.DalRole = itemUserEntity.BllRole.ToDal();
                return dalUserEntity;
            }
            
        }

        public static DalRoleEntity ToDal(this BllRoleEntity itemRoleEntity)
        {
            if (itemRoleEntity == null)
                return null;

            DalRoleEntity dalRoleEntity = new DalRoleEntity();
            dalRoleEntity.Id = itemRoleEntity.Id;
            dalRoleEntity.Name = itemRoleEntity.Name;
            return dalRoleEntity;
        }

        #endregion
    }
}
