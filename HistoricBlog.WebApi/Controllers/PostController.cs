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
using HistoricBlog.DAL.Base;

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

            if (!result.IsVaild)
            {
                var messages = string.Concat(result.Messages.ToArray());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, messages);
            }

            var posts = Mapper.Map<IEnumerable<PostViewModel>>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, posts);

        }

        [HttpGet]
        // GET: api/Post/5
        public HttpResponseMessage Get(int id)
        {
            var result = _postService.GetById(id);

            if (!result.IsVaild)
            {
                var messages = string.Concat(result.Messages.ToArray());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, messages);
            }

            var posts = Mapper.Map<IEnumerable<PostViewModel>>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, posts);

        }

        //[HttpPost]
        //// POST: api/Post
        //public HttpResponseMessage Post(Post post)
        //{
        //    var result = _postService.Create(post);

        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<Post, PostViewModel>();
        //        cfg.CreateMap<Category, CategoryViewModel>();
        //        cfg.CreateMap<Tag, TagViewModel>();
        //        cfg.CreateMap<User, UserViewModel>();
        //        cfg.CreateMap<Comment, CommentViewModel>();
        //    });

        //    if (!result.IsVaild)
        //    {
        //        var messages = string.Concat(result.Messages.ToArray());
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, messages);
        //    }

        //    var posts = Mapper.Map<IEnumerable<PostViewModel>>(result.Result);

        //    return Request.CreateResponse(HttpStatusCode.OK, posts);

        //}
        //[HttpPost]
        //public HttpResponseMessage Post(int id, [FromBody]string commentText)
        //{
        //    var result = new GenericResult<Post>();
        //    var post = new Post()
        //    {
        //        Id = id,
        //    };

        //    if (id == 0)
        //    {

        //        result = _postService.Create(post);

        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    if (!result.IsVaild)
        //    {
        //        var messages = string.Concat(result.Messages.ToArray());
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, messages);
        //    }


        //    result = _postService.Update(post);

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //[HttpDelete]
        //// DELETE: api/Post/5
        //public HttpResponseMessage Delete(int id)
        //{
        //    //var result = _postService.d

        //    //if (!result.IsVaild)
        //    //{
        //    //    var messages = string.Concat(result.Messages.ToArray());
        //    //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, messages);
        //    //}

        //    //var posts = Mapper.Map<IEnumerable<PostViewModel>>(result.Result);

        //    return Request.CreateResponse(HttpStatusCode.OK, posts);

        //}
    }
}
