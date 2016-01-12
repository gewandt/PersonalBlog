using System;
using System.Data.Entity;
using BlogEntity.Interfaces;
using DAL.Interface.Repository;
using Ninject;

namespace DAL.Context
{
    public class CustomDbContext : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKernel _kernel;

        public CustomDbContext(DbContext context, IKernel kernel)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (kernel == null) throw new ArgumentNullException("kernel");
            _context = context;
            _kernel = kernel;
        }

        public IRepository<T> GetRepository<T>() where T : IDalEntity
        {
            var repository = _kernel.Get<IRepository<T>>();
            return repository;
        }

        public void Commit()
        {
            if (_context != null)
            {
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
