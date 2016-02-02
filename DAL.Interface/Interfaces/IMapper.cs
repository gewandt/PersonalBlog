using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interface.Interfaces
{
    public interface IMapper<TEntity, TDal>
    {
        TEntity ToEntity(TDal item);
        TDal ToDal(TEntity entity);
        IEnumerable<TDal> ToDalCollection(IEnumerable<TEntity> entity);
    }
}
