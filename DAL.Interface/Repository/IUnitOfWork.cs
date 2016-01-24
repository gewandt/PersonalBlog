using System;
using DAL.Interface.Interfaces;

namespace DAL.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IDalEntity;
        void Commit();
    }
}
