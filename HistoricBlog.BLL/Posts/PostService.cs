using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.BLL.Base;
using HistoricBlog.BLL.Logger;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.BLL.Posts
{
    public class PostService : GenericService<Post>,IPostService
    {
        private readonly IPostRepository _postRepository;

        public ILoggerService LoggerService { get; set; }

        public PostService(IPostRepository postRepository) : base(postRepository)
        {
            _postRepository = postRepository;
        }

      

        public override GenericResult<Post> Update(Post entity)
        {
            entity.Modified = DateTime.Now;
            return base.Update(entity);

        }

     

        public override GenericResult<Post> Create(Post entity)
        {
            entity.PostedOn = DateTime.Now;
            entity.Modified = entity.PostedOn;
            return base.Create(entity);
        }

        public GenericResult<IEnumerable<Post>> GetPostById(int postId)
        {
            
            return _postRepository.GetAll(p => p.Id == postId);
        }
    }
}
