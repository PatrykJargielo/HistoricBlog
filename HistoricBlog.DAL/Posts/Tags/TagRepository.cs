using System.Linq;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts.Tags
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(HistoricBlogDbContext historicBlogDbContext) : base(historicBlogDbContext)
        {
        }
    }
}
