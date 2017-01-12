using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HistoricBlog.DAL.Base
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HistoricBlogDbContext _db = null;
        private readonly DbSet<T> _table = null;

        public GenericRepository()
        {
            this._db = new HistoricBlogDbContext();
            _table = _db.Set<T>();
        }
        //public GenericRepository(HistoricBlogDbContext db)
        //{
        //    this._db = db;
        //    _table = db.Set<T>();
        //}

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate !=null)
            {
                return _table.Where(predicate);
            }
            else
            {
                return _table.AsEnumerable();
            }
        }
        public IEnumerable<T> FindBy(Expression<Func<T,bool>> predicate)
        {
            IEnumerable<T> query = _db.Set<T>().Where(predicate);
            return query;
        }
        public virtual void Add(T obj)
        {
            _table.Add(obj);

        }
        public T Delete(T obj)
        {
            _table.Remove(obj);
            return obj;
        }
        public T Delete(Expression<Func<T, bool>> predicate)
        {
            T entityToDelete = _table.First(predicate);
            _table.Remove(entityToDelete);
            return entityToDelete;
        }

        public virtual void Edit(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _db.SaveChanges();
        }
    }
}
