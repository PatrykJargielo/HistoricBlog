using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using HistoricBlog.DAL.Posts;
using AutoMapper;
using HistoricBlog.BLL.Posts;
using HistoricBlog.BLL.Posts.Comments;
using HistoricBlog.BLL.Posts.Tags;
using HistoricBlog.BLL.Posts.Ratings;
using HistoricBlog.Web.ViewModels.Posts;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.DAL.Users;
using HistoricBlog.Web.ViewModels.Users;

namespace HistoricBlog.Web.Controllers
{
   
  

    public class DataController : Controller
    {
        private IPostService _postService;


        public DataController(IPostService postService)
        {
            _postService = postService;
           
        }

        [HttpGet()] //for test purposes only
        public IEnumerable<PostViewModel> GetPosts()
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<Post, PostViewModel>();
                                       cfg.CreateMap<Category, CategoryViewModel>();
                                       cfg.CreateMap<Tag, TagViewModel>();
                                       cfg.CreateMap<User, UserViewModel>();

                               });

            

            IEnumerable<Post> posts = _postService.GetPosts();
            IEnumerable<PostViewModel> postsView = Mapper.Map<IEnumerable<PostViewModel>>(posts);

            return Mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

       


    }
}