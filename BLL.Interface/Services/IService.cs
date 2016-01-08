using System;
using System.Collections.Generic;
using BlogEntity.Entities;
using BlogEntity.Interfaces;

namespace BLL.Interface.Services
{
    public interface IService<TEntity> where TEntity : IEntity
    {
        bool Create(TEntity user);
        bool Delete(int id);
        bool Update(TEntity user);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
