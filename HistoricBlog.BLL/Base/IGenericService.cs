using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.BLL.Base
{
    public interface IGenericService<T> where T : IBaseEntity
    {        
        GenericResult<IEnumerable<T>> GetAll();
        GenericResult<T> Update(T entity);
        GenericResult<T> Delete(T entity);
        GenericResult<T> DeleteById(int id);
        GenericResult<T> Create(T entity);
        GenericResult<IEnumerable<T>> GetById(int id);
    }
}
