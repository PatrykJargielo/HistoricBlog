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
    public class CommentService : GenericService<Comment>, ICommentService
    {

        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository) : base(commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public override GenericResult<Comment> Create(Comment entity)
        {
            //TO DO : GetLoggedUser!!!
            return base.Create(entity);
        }

        public GenericResult<IEnumerable<Comment>> GetCommentsByUserId(int userId)
        {
            var result = _commentRepository.FindBy(comment => comment.User.Id == userId);
            result.IsVaild = true;
            return result;
        }

        public GenericResult<Comment> UpadteCommentById(int commentId, string text)
        {
            var result = base.GetById(commentId);
            if (result.IsVaild && result.Result !=null)
            {
                Comment comment = result.Result;
                comment.CommentText = text;
                return base.Update(comment);
            }

            return result;
        }
    }
}
