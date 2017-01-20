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
        private readonly IPostRepository _postRepository;

        public CommentService(ICommentRepository commentRepository,IPostRepository postRepository) : base(commentRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
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

        public GenericResult<Comment> AddCommentToPostByPostId(int postId, string commentText)
        {
            Comment comment = new Comment();
            var result = new GenericResult<Comment>();
            result.Messages = new List<string>();
            
            var postResult = _postRepository.FindBy(post => post.Id == postId);

            var postEntity = postResult.Result.FirstOrDefault();
            if (postEntity == null)
            {
                result.Messages.Add("No posts attatched to this comment");
                result.IsVaild = false;
                return result;
            }

            if (postEntity.Comments == null)
            {
                postEntity.Comments = new List<Comment>();
            }

            //Add
            comment.CommentText = commentText;
            comment.User = null; //CommentedUser get logged user
            comment.CommentedOn = DateTime.Now;
            comment.Post = postEntity;

            result = Create(comment);
            return result;
        }
    }
}
