using CP.Data.Context;
using CP.Data.Interfaces;
using System;

namespace CP.Data.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly CPContext _dbContext;
        private bool _disposed;

        public EFUnitOfWork(CPContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
