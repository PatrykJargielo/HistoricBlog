using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Posts;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.BLL.Posts
{
    class PostService : IPostService
    {
        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }



        public IEnumerable<Post> GetPosts()
        {
            // _postRepository.GetAll().ToList();
            //Automaper --- > List Postów

            List<Post> postOfDoom = new List<Post>();

            Post test = new Post();
            test.Id = 1;
            test.Modified = DateTime.Today;
            test.PostedOn = DateTime.Today;
            test.ShortDescription = "dd";
            test.Tag = new List<Tag> { new Tag { Name = "dd" }, new Tag { Name = "bb" } };
            test.Title = "testitle";
            test.User = new User() { Id = 1, Name = "bop", Surname = "dd" };
            postOfDoom.Add(test);

            return postOfDoom;
        }
    }
}
