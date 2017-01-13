using System.Linq;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts.Categories
{
    public class CategoriesRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoriesRepository(HistoricBlogDbContext historicBlogDbContext) : base(historicBlogDbContext)
        {
        }

    }
}

