using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using BlogEntity.Entities;
using BlogEntity.Interfaces;
using DAL.Context;
using DAL.Interface.Repository;

namespace DAL.Repository
{
    public class UserRepository<TEntity, TDal> : IRepository<TDal> 
        where TEntity : class 
        where TDal : IDalEntity
    {
        private readonly DbContext _context;


        public bool Create(TDal entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TDal entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(TDal entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TDal> GetAll()
        {
            throw new NotImplementedException();
        }

        public TDal GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
