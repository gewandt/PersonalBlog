using System;
using System.Collections.Generic;
using BlogEntity.Interfaces;

namespace DAL.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : IDalEntity
    {
        bool Create(TEntity entity);
        bool Delete(TEntity entity);
        bool Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
