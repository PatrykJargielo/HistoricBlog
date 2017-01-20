using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Posts.Comments;
using HistoricBlog.WebApi.Models.Post;

namespace HistoricBlog.WebApi.Controllers
{
    public class CommentsController : ApiController
    {
        private readonly ICommentService _commentService;


        public ILoggerService LoggerService { get; set; }

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        // GET: api/Comment/5
        public HttpResponseMessage Get(int id)
        {
            var result = _commentService.GetById(id);

            if (result.Result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            if (!result.IsVaild)
            {
                var messages = result.Messages;
                return Request.CreateResponse(HttpStatusCode.InternalServerError, messages);
            }

            var comments = Mapper.Map<IEnumerable<CommentViewModel>>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, comments);
        }

        [HttpDelete]
        // DELETE: api/Comment/5
        public HttpResponseMessage Delete(int id)
        {
            var result = _commentService.DeleteCommentWithId(id);
            var commentDeleted = Mapper.Map<IEnumerable<CommentViewModel>>(result.Result);
           
            if (!result.IsVaild)
            {
                var messages = string.Concat(result.Messages.ToArray());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, messages);
            }

            return Request.CreateResponse(HttpStatusCode.OK, commentDeleted);
           
        }
    }
}
