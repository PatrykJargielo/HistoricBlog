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

        public ILoggerService LoggerService;

        public PostService(IPostRepository postRepository) : base(postRepository)
        {
            _postRepository = postRepository;
        }

      

        public override GenericResult<Post> Update(Post entity)
        {
            var result = new GenericResult<Post>();
            return Update(entity, result);
            
        }

        public override GenericResult<Post> Delete(Post entity)
        {
            throw new NotImplementedException();
        }

        public override GenericResult<Post> Create(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
