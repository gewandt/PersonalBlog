using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;

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
            if (itemEntity is BllRoleEntity)
            {
                var itemRoleEntity = (BllRoleEntity)itemEntity;
                DalRoleEntity dalRoleEntity = new DalRoleEntity();
                dalRoleEntity.Id = itemRoleEntity.Id;
                dalRoleEntity.Name = itemRoleEntity.Name;
                return dalRoleEntity;
            }
            return null;
        }

        private static DalRoleEntity ToDal(this BllRoleEntity itemRoleEntity)
        {
            if (itemRoleEntity == null)
                return null;

            return new DalRoleEntity
            {
                Id = itemRoleEntity.Id,
                Name = itemRoleEntity.Name
            };
        }

        #endregion

        #region DAL to BAL

        public static BllRoleEntity ToBal(this DalRoleEntity role)
        {
            if (role == null)
                return null;

            return new BllRoleEntity
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        #endregion
    }
}
