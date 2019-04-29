using MKDRI.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Extensions;
using System.Threading.Tasks;

namespace MKDRI.Models.UnitOfWork
{
    public class BaseRepository<T>: IBaseRepository<T>, IDisposable where T: class
    {
        protected IMKDRIContext context;
        protected DbSet<T> set { get; }

        public BaseRepository(IMKDRIContext dbContext)
        {
            context = dbContext;
            set = context.Set<T>();
        }

        public void SaveAsync()
        {
            context.SaveChangesAsync();
        }
        public IQueryable<T> All()
        {
            return set;
        }

        public Task<T> GetByIdAsync(int id)
        {
            return set.FindAsync(id);
        }


        public void Insert(T newEntry)
        {
            context.Set<T>().AddAsync(newEntry);
        }

        public void Delete(int id)
        {
            T entry = context.Set<T>().Find(id);
            context.Remove(entry);
        }

        public void Update(T entry)
        {
            context.Entry(entry).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
