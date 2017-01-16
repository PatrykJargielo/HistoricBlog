using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.BLL.Base
{
    public abstract class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _genericRepository;

        protected GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public GenericResult<IEnumerable<T>> GetAll()
        {
            var result = _genericRepository.GetAll();
            return result;
        }

        public abstract GenericResult<T> Create(T entity);

        private void Assign(T entity, GenericResult<T> result)
        {
            if (result.IsVaild) result.Result = entity;
        }

        protected GenericResult<T> Create(T entity,GenericResult<T> result)
        {
            Assign(entity,result);
            return Create(result);
        }

        private GenericResult<T> Create(GenericResult<T> result)
        {
            if (result.IsVaild)
            {
                _genericRepository.Add(result.Result);
                _genericRepository.Save();
            }

            return result;
        }

        public abstract GenericResult<T> Update(T entity);

        protected GenericResult<T> Update(T entity, GenericResult<T> result)
        {
            Assign(entity, result);
            return Update(result);
        }
       
        private GenericResult<T> Update(GenericResult<T> result)
        {
            if (result.IsVaild)
            {
                _genericRepository.Edit(result.Result);
                _genericRepository.Save();
                
            }
            return result;
        }


        public abstract GenericResult<T> Delete(T entity);

        protected GenericResult<T> Delete(T entity, GenericResult<T> result)
        {
            Assign(entity,result);
            return Delete(result);
        }

        public GenericResult<T> Delete(GenericResult<T> result)
        {
            if (result.IsVaild)
            {
                _genericRepository.Delete(result.Result);
                _genericRepository.Save();
                
            }
            return result;
        }

       
    }
}
