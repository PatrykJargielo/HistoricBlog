using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Posts;
using HistoricBlog.BLL.Users;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Ratings;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Users;
using HistoricBlog.Web.ViewModels.Posts;
using HistoricBlog.Web.ViewModels.Users;
using HistoricBlog.Web.ViewModels.Users.Roles;

namespace HistoricBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        public ILoggerService LoggerService { get; set; }

        public HomeController(IPostService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }
     

        public ActionResult Index()
        {
            GetUsers();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }


        //public IEnumerable<PostViewModel> GetPosts()
        //{
        //    Mapper.Initialize(cfg => {
        //        cfg.CreateMap<Post, PostViewModel>();
        //        cfg.CreateMap<Category, CategoryViewModel>();
        //        cfg.CreateMap<Tag, TagViewModel>();
        //        cfg.CreateMap<User, UserViewModel>();

        //    });



        //    GenericResult<IEnumerable<Post>> posts = _postService.GetAll();
        //    IEnumerable<PostViewModel> postsView = Mapper.Map<IEnumerable<PostViewModel>>(posts.Result);

        //    return Mapper.Map<IEnumerable<PostViewModel>>(posts);
        //}

        public IEnumerable<UserViewModel> GetUsers()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<Comment, CommentViewModel>();
                cfg.CreateMap<Rating, RatingViewModel>();
                cfg.CreateMap<Role, RoleViewModel>();
            });

            GenericResult<IEnumerable<User>> users = _userService.GetAll();
            return Mapper.Map<IEnumerable<UserViewModel>>(users.Result);
        }


    }
}