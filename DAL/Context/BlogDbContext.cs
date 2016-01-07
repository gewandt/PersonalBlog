using System;
using System.Data.Entity;
using DAL.Interface.Repository;

namespace DAL.Context
{
    public class BlogDbContext : IUnitOfWork
    {
        public DbContext Context { get; private set; }

        public BlogDbContext(DbContext context)
        {
            Context = context;
            //Debug.WriteLine("unit of work create!");
        }

        public void Commit()
        {
            if (Context != null)
            {
                Context.SaveChanges();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            //Debug.WriteLine("Context dispose!");
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
