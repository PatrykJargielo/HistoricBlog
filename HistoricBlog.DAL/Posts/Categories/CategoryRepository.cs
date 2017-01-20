using System.Linq;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts.Categories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(HistoricBlogDbContext historicBlogDbContext) : base(historicBlogDbContext)
        {
        }

    }
}

