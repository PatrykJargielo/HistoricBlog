using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts.Comments
{
    class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
    }
}
