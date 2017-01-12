using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace HistoricBlog.DAL
{
    public abstract class GenericRepository<T> : IRepositories<T> where T : class 
    {
        private HistoricBlogDbContext db = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this.db = new HistoricBlogDbContext();
            table = db.Set<T>();
        }
        public GenericRepository(HistoricBlogDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate !=null)
            {
                return table.Where(predicate);
            }
            else
            {
                return table.AsEnumerable();
            }
        }
        public IEnumerable<T> FindBy(Expression<Func<T,bool>> predicate)
        {
            IEnumerable<T> query = db.Set<T>().Where(predicate);
            return query;
        }
        public virtual void Add(T obj)
        {
            table.Add(obj);

        }
        public T Delete(T obj)
        {
            table.Remove(obj);
            return obj;
        }
        public T Delete(Expression<Func<T, bool>> predicate)
        {
            T entityToDelete = table.First(predicate);
            table.Remove(entityToDelete);
            return entityToDelete;
        }

        public virtual void Edit(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            db.SaveChanges();
        }
    }
}
