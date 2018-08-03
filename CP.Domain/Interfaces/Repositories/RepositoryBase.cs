using CP.Domain.Interfaces.Repositories;
using CP.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CP.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

        protected IDbSet<TEntity> DbSet;
        protected readonly CPContext Context;

        public RepositoryBase(CPContext dbContext)
        {
            Context = dbContext;
            DbSet = Context.Set<TEntity>();
        }
        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
        public virtual IEnumerable<TEntity> GetAllReadOnly()
        {
            return DbSet.AsNoTracking();
        }
        public void Update(TEntity obj)
        {
            var entry = Context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
