using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Services
{
    public interface IService<TEntity>
        where TEntity : IBllEntity
    {
        bool Create(TEntity bllItem);
        bool Delete(TEntity item);
        bool Update(TEntity item);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
