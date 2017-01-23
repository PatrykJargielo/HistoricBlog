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
    [RoutePrefix("api/user")]
    public class UserCommentsController : ApiController
    {
        private readonly ICommentService _commentService;

        public UserCommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Route("{userId}/comments/")]
        public HttpResponseMessage Get(int userId)
        {
            var result = _commentService.GetCommentsByUserId(userId);

            if (!result.Result.Any())
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (!result.IsVaild)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, result.Messages);
            }

            var comments = Mapper.Map<IEnumerable<CommentViewModel>>(result.Result);
            return Request.CreateResponse(HttpStatusCode.OK, comments);
        }

    }
}
