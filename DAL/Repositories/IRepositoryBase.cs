using System;
using System.Linq;
using System.Linq.Expressions;
using newsSite.Models;

namespace newsSite.DAL.Repositories
{
    public interface IRepositoryBase<T>
        where T : EntityBase
    {
        void Update(int id, Action<T> updateAction);
        void Update(T entity);
        void Insert(T entity);
        void delete(T entity);
        T Find(int id);
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
    }
}