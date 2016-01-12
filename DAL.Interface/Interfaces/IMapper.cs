using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IMapper<TEntity, TDal>
    {
        TEntity ToEntity(TDal item);
        TDal ToDal(TEntity entity);
        void CopyFields(TDal item, TEntity entity);
    }
}
