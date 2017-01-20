
using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Posts.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.BLL.Posts.Comments
{
    public interface ICommentService : IGenericService<Comment>
    {

        GenericResult<IEnumerable<Comment>> GetCommentsByUserId(int userId);

        GenericResult<Comment> UpadteCommentById(int commentId,string text);
        GenericResult<Comment> AddCommentToPostByPostId(int postId, string commentText);
    }
}
