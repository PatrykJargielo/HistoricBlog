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
       
        
        protected GenericResult<T> Create(T entity,GenericResult<T> result)
        {
            List<string> errors = entity.Validation();
            bool hasErrors = errors.Any();
            if (hasErrors)
            {
                result.IsVaild = false;
                result.Messages = errors;
            }
            else
            {
                result.IsVaild = true;
                result = _genericRepository.Add(entity);
                _genericRepository.Save();
            }

            return result;;
        }

        public abstract GenericResult<T> Update(T entity);

        protected GenericResult<T> Update(T entity, GenericResult<T> result)
        {
            List<string> errors = entity.Validation();
            bool hasErrors = errors.Any();
            if (hasErrors)
            {
                result.IsVaild = false;
                result.Messages = errors;
            }
            else
            {
                result.IsVaild = true;
                result = _genericRepository.Edit(result.Result);
                _genericRepository.Save();
            }

            return result;
        }

        public abstract GenericResult<T> Delete(T entity);

        protected GenericResult<T> Delete(T entity, GenericResult<T> result)
        {
            List<string> errors = entity.Validation();
            bool hasErrors = errors.Any();
            if (hasErrors)
            {
                result.IsVaild = false;
                result.Messages = errors;
            }
            else
            {
                result.IsVaild = true;
                result = _genericRepository.Delete(result.Result);
                _genericRepository.Save();
            }

            return result;
        }

       
    }
}
