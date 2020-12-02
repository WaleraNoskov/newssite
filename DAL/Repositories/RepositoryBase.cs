using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using newsSite.Models;
using newsSite.DAL;

namespace newsSite.DAL.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : EntityBase
    {
        protected NewsSiteContext newsSiteContext {get; set;}
        protected DbSet<T> dbSet {get; set;}

        public RepositoryBase(NewsSiteContext newsSiteContext)
        {
            this.newsSiteContext = newsSiteContext;
            this.dbSet = newsSiteContext.Set<T>();
        }

        public void delete(T entity)
        {
            dbSet.Remove(entity);
            newsSiteContext.SaveChanges();
        }

        public T Find(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
            newsSiteContext.SaveChanges();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            return query.Where(filter);
        }

        public void Update(int id, Action<T> updateAction)
        {
            var entity = Find(id);
            updateAction(entity);
            Update(entity);
        }

        public void Update(T entity)
        {
            if(newsSiteContext.Entry(entity).State == EntityState.Detached)
            {
                newsSiteContext.Attach(entity);
                newsSiteContext.Entry(entity).State = EntityState.Modified;
            }
            newsSiteContext.SaveChanges();
        }
    }
}