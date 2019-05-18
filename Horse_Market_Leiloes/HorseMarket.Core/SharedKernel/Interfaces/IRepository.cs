using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HorseMarket.Core.SharedKernel.Entitites;

namespace HorseMarket.Core.SharedKernel.Interfaces
{
    public interface IRepository<T> where T : BaseEntity<T>
    {
        T GetById(int id);
        T Add(T entity);
        void Update(T entity);
        T Update(T objDb, T obj);
        void Delete(T entity);
        void Delete(int id);
        IEnumerable<T> FindAsNoTracking(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> All();
        void Commit();
    }
}
