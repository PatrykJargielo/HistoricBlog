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
    public class CommentService : GenericService<Comment>, ICommentService
    {

        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository) : base(commentRepository)
        {
            _commentRepository = commentRepository;
        }


        public GenericResult<IEnumerable<Comment>> GetCommentsByPostId(int postId)
        {
            return _commentRepository.GetAll(x => x.Post.Id == postId);
        }

        public GenericResult<IEnumerable<Comment>> GetCommentsById(int commentId)
        {
            return _commentRepository.FindBy(comment => comment.Id == commentId);
        }

        public override GenericResult<Comment> Create(Comment entity)
        {
            //TO DO : GetLoggedUser!!!
            return base.Create(entity);
        }
    }
}
