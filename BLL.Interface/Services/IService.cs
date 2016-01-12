using System;
using System.Collections.Generic;

namespace BLL.Interface.Services
{
    public interface IService<TEntity>
    {
        bool Create(TEntity item);
        bool Delete(TEntity item);
        bool Update(TEntity item);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
