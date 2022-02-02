using System;
using System.Data;
using GHPRS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GHPRS.Persistence
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        private BaseContext _context;
        private bool disposed;

        public BaseUnitOfWork(BaseContext context)
        {
            _context = context;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;
            if (disposing)
            {
                // Free any other managed objects here
                _context.Dispose();
            }

            // Free any unmanaged objects here
            this.disposed = true;
        }
        
        public DbContext Context { get { return _context; } }

        public IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return Context.Database.BeginTransaction(isolationLevel);
        }
    }
}