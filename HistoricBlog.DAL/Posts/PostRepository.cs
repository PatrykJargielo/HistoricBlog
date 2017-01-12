using System.Linq;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public Post GetSingle(int postId)
        {
            var query = GetAll().FirstOrDefault(x => x.Id == postId);
            return query;
        }
    }
}
