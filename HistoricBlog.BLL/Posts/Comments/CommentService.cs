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

        public GenericResult<Comment> DeleteCommentWithId(int id)
        {
            var result = new GenericResult<Comment>();
            var comment = GetById(id);
            if (comment.IsVaild)
            {
                result = base.Delete(result.Result);
            }
            return result;
        }

        public GenericResult<IEnumerable<Comment>> GetCommentsByPostId(int postId)
        {
            var result = _commentRepository.FindBy(comment => comment.Post.Id == postId);
            result.IsVaild = true;
            return result;
        }

        public GenericResult<IEnumerable<Comment>> GetCommentByPostIdAndByCommentId(int postId, int commentId)
        {
            var result = _commentRepository.FindBy(comment => comment.Post.Id == postId && comment.Id == commentId);
            result.IsVaild = true;
            return result;
        }

        public GenericResult<IEnumerable<Comment>> GetCommentsByUserId(int userId)
        {
            var result = _commentRepository.FindBy(comment => comment.User.Id == userId);
            result.IsVaild = true;
            return result;
        }

        public GenericResult<IEnumerable<Comment>> GetCommentByUserIdAndByCommentId(int userId, int commentId)
        {
            var result = _commentRepository.FindBy(comment => comment.User.Id == userId && comment.Id == commentId);
            result.IsVaild = true;
            return result;
        }
    }
}
