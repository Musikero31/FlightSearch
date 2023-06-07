using FlightSearch.Data.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FlightSearch.Data.Repository
{
    public class FlightRepository<T> where T : class
    {
        protected FlightSearchContext _context;
        protected DbSet<T> _dbSet;

        public FlightRepository(FlightSearchContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetByID(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity) 
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity) 
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity) 
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public void DeleteByID(int id)
        {
            T entity = _dbSet.Find(id);
            Delete(entity);
        }

        
    }
}
