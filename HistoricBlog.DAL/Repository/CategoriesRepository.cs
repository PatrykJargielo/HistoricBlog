using HistoricBlog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.DAL
{
    public class CategoriesRepository : GenericRepository<Category>, ICategoryRepository
    {
        public Category GetSingle(int categoryId)
        {
            var query = GetAll().FirstOrDefault(x => x.Id == categoryId);
            return query;
        }
    }
}

