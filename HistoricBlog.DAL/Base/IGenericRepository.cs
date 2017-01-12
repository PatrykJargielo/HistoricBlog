using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HistoricBlog.DAL.Base
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T obj);
        T Delete(T obj);
        T Delete(Expression<Func<T, bool>> predicate);
        void Edit(T obj);
        void Save();
    }

}
