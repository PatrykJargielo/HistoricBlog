using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Posts;
using HistoricBlog.WebApi.Models.Post;
using HistoricBlog.DAL.Posts;
using HistoricBlog.DAL.Base;
using System.Web.Http.Cors;
using System.Linq;
using HistoricBlog.DAL.Posts.Categories;

namespace HistoricBlog.WebApi.Controllers
{


    

    public class PostController : ApiController
    {
        private readonly IPostService _postService;
        public ILoggerService LoggerService { get; set; }

        public PostController(IPostService postService)
        {
            _postService = postService;

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

            if (result.Result == null) return Request.CreateResponse(HttpStatusCode.BadRequest, "Post not found!");

            var posts = Mapper.Map<PostViewModel> (result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, posts);

        }
        [HttpGet]
        // GET: api/Post/{page}/{quantity}/{titleFilter}
        public HttpResponseMessage GetPostsFilteredPage(int page, int quantity,string titleFilter="")
        {
            var result = _postService.GetPostsByTitle(titleFilter);
            if (!result.IsVaild) return Request.CreateResponse(HttpStatusCode.BadRequest, result.Messages);
            if (result.Result.Count() == 0) return Request.CreateResponse(HttpStatusCode.OK, $"No post found by title of {titleFilter} ");

            var totalFilteredPostCount = result.Result.Count();
            var pageStart = (page-1) * quantity;
            result.Result = result.Result.Skip(pageStart).Take(quantity);

            var posts = Mapper.Map<IEnumerable<PostViewModel>>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK,new { totalFilteredPostCount = totalFilteredPostCount, pageStart=pageStart, posts=posts });

        }

        [HttpPost]

        public HttpResponseMessage Post([FromBody]PostInputViewModel post)
        {
            var postEntity = Mapper.Map<Post>(post);
            var isPostNew = post.Id == 0;  //do test
                

            var postResult = new GenericResult<Post>();
            if (isPostNew)
                postResult = _postService.Create(postEntity);
            else
                postResult = _postService.Update(postEntity);

            if (!postResult.IsVaild)
            {
                var errorMessages = string.Concat(postResult.Messages.ToArray());
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessages);
            }

            var viewResult = Mapper.Map<PostViewModel>(postResult.Result);
            return Request.CreateResponse(HttpStatusCode.Created, viewResult);
        }


        [HttpDelete]
        // DELETE: api/Post/5
        public HttpResponseMessage Delete(int id)
        {
            var result = _postService.DeleteById(id);
            if (result.Result == null) return Request.CreateResponse(HttpStatusCode.BadRequest, "Post not found!");
            
            var posts = Mapper.Map<PostViewModel>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, posts);

        }
    }
}
