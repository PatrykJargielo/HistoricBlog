using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HistoricBlog.DAL.Base
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly HistoricBlogDbContext _historicBlogDbContext;
        private readonly DbSet<T> _table;

        protected GenericRepository(HistoricBlogDbContext historicBlogDbContext)
        {
            _historicBlogDbContext = historicBlogDbContext;
            _table = historicBlogDbContext.Set<T>();
        }

        public virtual GenericResult<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            var result = new GenericResult<IEnumerable<T>>();
            if (predicate !=null) 
            {
                result.Result = _table.Where(predicate);
                return result;
            }
            else
            {
                result.Result = _table.AsEnumerable();
                return result;
            }
        }
        public virtual GenericResult<IEnumerable<T>> FindBy(Expression<Func<T,bool>> predicate)
        {
            var result = new GenericResult<IEnumerable<T>> {Result = _historicBlogDbContext.Set<T>().Where(predicate)};
            return result;
        }
        public virtual GenericResult<T>Add(T obj)
        {
            var result = new GenericResult<T> {Result = _table.Add(obj)};
            return result;
        }
        public  GenericResult<T>Delete(T obj)
        {
            var result = new GenericResult<T> {Result = _table.Remove(obj)};
            return result;
        }
        public  GenericResult<T>Delete(Expression<Func<T, bool>> predicate)
        {
            var result = new GenericResult<T> {Result = _table.First(predicate)};
            _table.Remove(result.Result);
            return result;
        }

        public virtual GenericResult<T>Edit(T obj)
        {
            var result = new GenericResult<T> {Result = _table.Attach(obj)};
            _historicBlogDbContext.Entry(obj).State = EntityState.Modified;
            return result;
        }

        public virtual void Save()
        {
            _historicBlogDbContext.SaveChanges();
        }

        public  GenericResult<T> GetById(int id)
        {

            GenericResult<IEnumerable<T>> allEntitiesById = GetAll(x => x.Id == id);
            var result = new GenericResult<T> {Result = allEntitiesById.Result.FirstOrDefault()};

            return result;
        }
    }
}
