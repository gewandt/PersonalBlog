using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interface.Interfaces;

namespace DAL.Interface.Repository
{
    public interface IRepository<TEntity> 
        where TEntity : IDalEntity
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity GetByPredicate(Expression<Func<TEntity, bool>> predicate);
    }
}
