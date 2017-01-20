using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HistoricBlog.BLL.Posts.Comments;
using HistoricBlog.WebApi.Models.Post;

namespace HistoricBlog.WebApi.Controllers
{
    [RoutePrefix("api/post")]
    public class PostCommentsController : ApiController
    {
        private readonly ICommentService _commentService;

        public PostCommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Route("{postId}/comment")]
        public HttpResponseMessage Post(int postId, [FromBody]string commentText)
        {
            var result = _commentService.AddCommentToPostByPostId(postId, commentText);
            if (result.Result == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            

            if (!result.IsVaild) return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Messages);
            

            var comments = Mapper.Map<IEnumerable<CommentViewModel>>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, comments);
        }

   
    }
}
