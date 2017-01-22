﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
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

        public virtual GenericResult<IEnumerable<T>> GetAll()
        {
            var result = _genericRepository.GetAll();
            result.IsVaild = true;
            return result;
        }
        
        public virtual GenericResult<T> Create(T entity)
        {
            GenericResult<T> result = new GenericResult<T>();
            List<string> errors = entity.Validation();
            bool hasErrors = errors.Any();
            if (hasErrors)
            {
                result.IsVaild = false;
                result.Messages = errors;
            }
            else
            {
                result = _genericRepository.Add(entity);
                _genericRepository.Save();
                result.IsVaild = true;
            }

            return result;
        }

      

        public virtual GenericResult<T> Update(T entity)
        {
            GenericResult<T> result = new GenericResult<T>();
            List<string> errors = entity.Validation();
            bool hasErrors = errors.Any();
            if (hasErrors)
            {
                result.IsVaild = false;
                result.Messages = errors;
            }
            else
            {
                
                result = _genericRepository.Edit(entity);
                _genericRepository.Save();
                result.IsVaild = true;
            }

            return result;
        }



        public virtual GenericResult<T> Delete(T entity)
        {
            GenericResult<T> result = new GenericResult<T>();
            List<string> errors = entity.Validation();
            bool hasErrors = errors.Any();
            if (hasErrors)
            {
                result.IsVaild = false;
                result.Messages = errors;
            }
            else
            {
                
                result = _genericRepository.Delete(entity);
                _genericRepository.Save();
                result.IsVaild = true;
            }

            return result;
        }

        public GenericResult<T> DeleteById(int id)
        {
            var result = new GenericResult<T>();
            result.Result = _genericRepository.FindBy(x => x.Id == id).Result.SingleOrDefault();
            if (result.Result == null) return result; 
            result = _genericRepository.Delete(result.Result);
            result.IsVaild = true;
            return result;
        }

        public GenericResult<T> GetById(int id)
        {
            var result = _genericRepository.FindBy(x => x.Id == id);
            GenericResult<T> genericResult = new GenericResult<T>();
            genericResult.Result = result.Result.FirstOrDefault();
            if (genericResult.Result == null) return genericResult;
            genericResult.IsVaild = true;
            
            return genericResult;
        }
    }
}
