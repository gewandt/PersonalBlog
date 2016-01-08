using System;
using System.Collections.Generic;

namespace BLL.Interface.Services
{
    public interface IService<TEntity>
    {
        bool Create(TEntity user);
        bool Delete(int id);
        bool Update(TEntity user);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
