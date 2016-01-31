﻿using AutoMapper;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;

namespace BLL.Mappers
{
    public static class MapperProperty
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

        public static DalUserEntity ToDal(this BllUserEntity itemUserEntity)
        {
            if (itemUserEntity == null)
                return null;

            DalUserEntity dalUserEntity = new DalUserEntity
            {
                Id = itemUserEntity.Id,
                Name = itemUserEntity.Name,
                Password = itemUserEntity.Password,
                DalRole = itemUserEntity.BllRole.ToDal()
            };
            return dalUserEntity;
        }
        public static DalRoleEntity ToDal(this BllRoleEntity itemRoleEntity)
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

        public static BllUserEntity ToBal(this DalUserEntity user)
        {
            if (user == null)
                return null;

            return new BllUserEntity
            {
                Id = user.Id,
                Name = user.Name,
                BllRole = user.DalRole.ToBal(),
                Password = user.Password
            };
        }

        #endregion
    }
}