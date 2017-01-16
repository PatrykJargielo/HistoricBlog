using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.BLL.Posts
{
    public interface IPostService : IGenericService<Post>
    {
        IEnumerable<Post> GetPosts();
    }
}
