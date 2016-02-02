using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interface.Interfaces
{
    public interface IMapper<TEntity, TDal>
    {
        TEntity ToEntity(TDal item);
        TDal ToDal(TEntity item);
        IEnumerable<TDal> ToDalCollection(IEnumerable<TEntity> entity);
        void CopyFields(TDal dalEntity, TEntity entity);
    }
}
