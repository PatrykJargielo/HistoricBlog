using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HistoricBlog.BLL.Posts.Comments;
using HistoricBlog.WebApi.Models.Post;
using HistoricBlog.BLL.Posts;

namespace HistoricBlog.WebApi.Controllers
{
    [RoutePrefix("api/post")]
    public class PostCommentsController : ApiController
    {
        private readonly IPostService _postService;

        public PostCommentsController(IPostService postService)
        {
            _postService = postService;
        }

        [Route("{postId}/comment")]
        public HttpResponseMessage Post(int postId, [FromBody]string commentText)
        {
            var post = _postService.GetById(postId);
            if (post.Result == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            var result = _postService.AddCommentToPost(post.Result, commentText);
            if (result.Result == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            

            if (!result.IsVaild) return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Messages);
            

            var comments = Mapper.Map<CommentViewModel>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, comments);
        }

   
    }
}
