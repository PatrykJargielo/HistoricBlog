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

            var posts = Mapper.Map<IEnumerable<PostViewModel>>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, posts);

        }

        [HttpGet]
        // GET: api/Post/5
        public HttpResponseMessage Get(int id)
        {
            var result = _postService.GetById(id);

            if (result.Result == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Post not found!");

            var posts = Mapper.Map<PostViewModel> (result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, posts);

        }

        [HttpPut]
        [HttpPost]
        [HttpPatch]
        public HttpResponseMessage Post([FromBody]PostViewModel post)
        {
            var postEntity = new Post()
            {
                Title = post.Title,
                ShortDescription = post.ShortDescription,
                Content = post.Content
            };
            var result = new GenericResult<Post>();
            if (post.Id == 0)
            {
                result.IsVaild = true;
                result = _postService.Create(postEntity);
                return Request.CreateResponse(HttpStatusCode.Created, result.Result);
            }

            var editPost = _postService.Update(postEntity);

            if (!result.IsVaild)
            {
                var messages = string.Concat(result.Messages.ToArray());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, messages);
            }

            var updatePosts = Mapper.Map<IEnumerable<PostViewModel>>(editPost.Result);

            return Request.CreateResponse(HttpStatusCode.OK, updatePosts);
        }


        [HttpDelete]
        // DELETE: api/Post/5
        public HttpResponseMessage Delete(int id)
        {
            var result = _postService.DeleteById(id);
            if (result.Result == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Post not found!");
            
            var posts = Mapper.Map<PostViewModel>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, posts);

        }
    }
}
