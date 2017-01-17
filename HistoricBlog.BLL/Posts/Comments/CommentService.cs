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

        public override DAL.Base.GenericResult<Comment> Create(Comment entity)
        {
            var result = new GenericResult<Comment>();
            return Create(entity, result);
        }

        public override DAL.Base.GenericResult<Comment> Delete(Comment entity)
        {
            var result = new GenericResult<Comment>();
            return Delete(entity, result);
        } 

        public override DAL.Base.GenericResult<Comment> Update(Comment entity)
        {
            var result = new GenericResult<Comment>();
            return Update(entity, result);
        }

        public GenericResult<IEnumerable<Comment>> GetAllPostComments(int postId)
        {
            return _commentRepository.GetAll(x => x.Post.Id == postId);
        }
    }
}
