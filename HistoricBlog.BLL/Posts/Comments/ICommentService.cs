
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
        GenericResult<IEnumerable<Comment>> GetCommentsByPostId(int postId);

        GenericResult<IEnumerable<Comment>> GetCommentsById(int commentId);
    }
}
