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
        private readonly ICommentService _commentService; 

        public PostCommentsController(IPostService postService,ICommentService commentService)
        {
            _commentService = commentService;
            _postService = postService;
        }

        [Route("{postId}/comment")]
        public HttpResponseMessage Post(int postId, [FromBody]string commentText)
        {
            var post = _postService.GetById(postId);
            if (post.Result == null) return Request.CreateResponse(HttpStatusCode.NotFound,"Post not found!");

            var result = _commentService.AddCommentToPost(post.Result, commentText);
            if (result.Result == null) return Request.CreateResponse(HttpStatusCode.Unauthorized,"You need to be logged!");
            
            if (!result.IsVaild) return Request.CreateResponse(HttpStatusCode.BadRequest, result.Messages);
            
            var createdComment = Mapper.Map<CommentViewModel>(result.Result);

            return Request.CreateResponse(HttpStatusCode.Created, createdComment);
        }

   
    }
}
