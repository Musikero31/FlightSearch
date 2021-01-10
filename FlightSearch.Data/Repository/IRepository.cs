using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FlightSearch.Data.Repository
{
    public interface IRepository<T> where T : class, new()
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        T Add(T entity);
    }
}
