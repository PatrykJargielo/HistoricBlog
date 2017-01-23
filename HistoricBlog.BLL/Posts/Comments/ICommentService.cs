
using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Posts.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts;

namespace HistoricBlog.BLL.Posts.Comments
{
    public interface ICommentService : IGenericService<Comment>
    {
        GenericResult<Comment> AddCommentToPost(Post post, string commentText);
        GenericResult<IEnumerable<Comment>> GetCommentsByUserId(int userId);
        GenericResult<Comment> Update(Comment comment,string text);
    }
}
