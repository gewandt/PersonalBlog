﻿using System;
using System.Collections;
using System.Collections.Generic;
using BlogEntity.Entities;
using DAL.Context;
using DAL.Interface.Repository;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext unit)
        {
            _context = unit;
        }
        public bool Create(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public UserEntity GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}