using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HistoricBlog.DAL.Base
{
    public interface IGenericRepository<T> where T : IBaseEntity
    {
        GenericResult<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null);
        GenericResult<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);
        GenericResult<T> Add(T obj);
        GenericResult<T> Delete(T obj);
        GenericResult<T> Delete(Expression<Func<T, bool>> predicate);
        GenericResult<T>Edit(T obj);
        void Save();

    }

}
