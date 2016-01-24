using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entities;
using DAL.Interface.Interfaces;
using DAL.Interface.Repository;
using Ninject;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private IKernel _kernel;
        private Dictionary<Type, object> repos;
        private bool isDisposed;

        public UnitOfWork(DbContext context, IKernel kernel)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (kernel == null) throw new ArgumentNullException("kernel");
            _context = context;
            _kernel = kernel;
            repos = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepository<T>()
            where T : class, IDalEntity
        {
            object repo;
            if (!repos.TryGetValue(typeof(T), out repo))
                repos.Add(typeof(T), repo = _kernel.Get<IRepository<T>>());
            return repo as IRepository<T>;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            isDisposed = true;
        }
    }
}
