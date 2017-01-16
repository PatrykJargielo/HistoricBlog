
using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Posts.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.BLL.Posts.Comments
{
    public interface ICommentService : IGenericService<Comment>
    {
        IEnumerable<Comment> GetPostComments(int postId);
    }
}
