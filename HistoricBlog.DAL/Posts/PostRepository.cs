using System.Linq;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(HistoricBlogDbContext historicBlogDbContext) : base(historicBlogDbContext)
        {

        }

    }
}
