using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts.Comments;

namespace HistoricBlog.BLL.Posts
{
    public interface IPostService : IGenericService<Post>
    {
        GenericResult<Comment> AddCommentToPost(Post post, string commentText);
    }
}
