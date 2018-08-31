using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AccountTracking.DataAccess;

namespace AccountTracking.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CustomDBContext dbContext;
        protected readonly DbSet<T> dbSet; 
        public Repository()
        {
            dbContext = new CustomDBContext();
            dbSet = dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
             return dbSet.Where(expression).Select(data => data);
        }

        public T Get(object Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public void Remove(object Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
