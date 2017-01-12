using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Post GetSingle(int postId);
    }
}
