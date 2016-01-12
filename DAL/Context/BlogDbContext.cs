using System;
using System.Data.Entity;
using DAL.Interface.Repository;

namespace DAL.Context
{
    public class BlogDbContext : IUnitOfWork
    {
        private readonly DbContext context;
        private IUnitOfWork uow;

        public BlogDbContext(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            if (context != null)
            {
                context.SaveChanges();
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
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
