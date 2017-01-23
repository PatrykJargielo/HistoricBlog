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
    public class CommentController : ApiController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
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
                return Request.CreateResponse(HttpStatusCode.BadRequest,"Comment not found!");
            }

            var comments = Mapper.Map<CommentViewModel>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, comments);
        }


        [HttpPatch]
        [HttpPost]
        [HttpPut]
        public HttpResponseMessage Put(int id,[FromBody] string text)
        {
            var result = _commentService.GetById(id);
            if (result.Result == null)      
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,"Comment not found!");
            }

            result = _commentService.Update(result.Result,text);

            if (!result.IsVaild)
            {
                var messages = result.Messages;
                return Request.CreateResponse(HttpStatusCode.BadRequest, messages);
            }

            var comments = Mapper.Map<CommentViewModel>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK , comments);
        }

        [HttpDelete]
        // DELETE: api/Comment/5
        public HttpResponseMessage Delete(int id)
        {
            var result = _commentService.DeleteById(id);
            if (result.Result == null) return Request.CreateResponse(HttpStatusCode.BadRequest, "Comment not found!");

            var commentDeleted = Mapper.Map<CommentViewModel>(result.Result);
         
            return Request.CreateResponse(HttpStatusCode.OK, commentDeleted);
           
        }
    }
}
