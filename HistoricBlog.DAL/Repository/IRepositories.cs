using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.DAL
{
    public interface IRepositories<T> where T : class
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
