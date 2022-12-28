using BigOn.Domain.Models.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BigOn.Domain.AppCode.Infrastructure
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T GetById(int id);
        T Add(T entity);
        T Edit(T entity);
        bool Remove(T entity);
    }

    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        private readonly BigOnDbContext db;

        public GenericRepository(BigOnDbContext db)
        {
            this.db = db;
        }

        public T Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();

            return entity;
        }

        public T Edit(T entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            var set = db.Set<T>().AsQueryable();

            if (predicate != null)
            {
                set = set.Where(predicate);
            }

            return set;
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T entity)
        {
            throw new System.NotImplementedException();
        }
    }


}
