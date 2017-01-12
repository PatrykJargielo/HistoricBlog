using System.Linq;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts.Categories
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

