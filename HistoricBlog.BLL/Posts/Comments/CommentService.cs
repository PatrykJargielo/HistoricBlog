using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Posts.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.BLL.Posts.Comments
{
    public class CommentService : GenericService<Comment>, ICommentService
    {

        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;

        public CommentService(ICommentRepository commentRepository,IUserRepository userRepository) : base(commentRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
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

        public GenericResult<Comment> AddCommentToPost(Post post, string commentText)
        {
            var result = new GenericResult<Comment>();
            Comment comment = new Comment();          
            result.Messages = new List<string>();

            if (post.Comments == null)
            {
                post.Comments = new List<Comment>();
            }

            //Add
            comment.CommentText = commentText;
            comment.CommentedOn = DateTime.Now;
            comment.User = _userRepository.FindBy(user => user.Id == 1).Result.FirstOrDefault();
            if (comment.User == null)
            {
                result.IsVaild = false;
                return result;
            }

            comment.Post = post;
            return base.Create(comment);
        }

        public GenericResult<Comment> Update(Comment comment, string text)
        {
            comment.CommentText = text;
            return base.Update(comment);
        }
    }
}
