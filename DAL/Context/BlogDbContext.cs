using System;
using DAL.Interface.Repository;

namespace DAL.Context
{
    public class BlogDbContext : IUnit
    {
        public DbContext Context { get; private set; }

        public BlogDbContext(DbContext context)
        {
            Context = context;
            //Debug.WriteLine("unit of work create!");
        }

        public void Save()
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
