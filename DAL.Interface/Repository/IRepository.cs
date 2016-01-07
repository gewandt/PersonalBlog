using System;
using System.Collections.Generic;
using BlogEntity.Interfaces;

namespace DAL.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        bool Create(TEntity entity);
        bool Delete(TEntity entity);
        bool Update(TEntity entity);
        IEnumerable<TEntity> GetEntities();
        TEntity GetById(int id);
    }
}
