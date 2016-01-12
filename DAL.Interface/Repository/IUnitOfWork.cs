using System;
using BlogEntity.Interfaces;

namespace DAL.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : IDalEntity;
        void Commit();
    }
}
