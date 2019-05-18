using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HorseMarket.Core.SharedKernel.Entitites;
using HorseMarket.Core.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HorseMarket.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity<T>
    {
        protected readonly DataContext _dbContext;

        protected DbSet<T> DbSet { get; set; }

        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<T>();
        }

        public virtual T GetById(int id)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            return query.SingleOrDefault(e => e.Id == id);
        }

        public virtual T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            return entity;
        }

        public void Delete(T entity)
        {
            var context = _dbContext.Set<T>();
            context.Attach(entity);
            context.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public T Update(T objDb, T obj)
        {
            _dbContext.Entry(objDb).CurrentValues.SetValues(obj);
            return obj;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public IEnumerable<T> FindAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<T> All()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
