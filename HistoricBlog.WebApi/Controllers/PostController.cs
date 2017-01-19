using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Posts;
using HistoricBlog.WebApi.Models.Post;
using HistoricBlog.DAL.Posts;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Users;
using HistoricBlog.WebApi.Models.Users;

namespace HistoricBlog.WebApi.Controllers
{
    public class PostController : ApiController
    {
        private readonly IPostService _postService;
        public ILoggerService LoggerService { get; set; }

        public PostController(IPostService PostService)
        {
            _postService = PostService;

        }
        [HttpGet]
        // GET: api/Post
        public HttpResponseMessage Get()
        {
            var result = _postService.GetAll();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<Comment, CommentViewModel>();
            });

            var posts = Mapper.Map<IEnumerable<PostViewModel>>(result.Result);
            return Request.CreateResponse(HttpStatusCode.OK, posts);
        }

        [HttpGet]
        // GET: api/Post/5
        public HttpResponseMessage Get(int id)
        {
            var result = _postService.GetPostById(id);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<Comment, CommentViewModel>();
            });

            var posts = Mapper.Map<IEnumerable<PostViewModel>>(result.Result);
            return Request.CreateResponse(HttpStatusCode.OK, posts);

        }

        [HttpPut]
        // POST: api/Post
        public HttpResponseMessage Put(Post post)
        {
            var result = _postService.Create(post);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<Comment, CommentViewModel>();
            });
            var posts = Mapper.Map<IEnumerable<PostViewModel>>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, posts);

        }

        // PUT: api/Post/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Post/5
        public void Delete(int id)
        {

        }
    }
}
