using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Posts.Comments;
using HistoricBlog.DAL.Posts;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Users;
using HistoricBlog.WebApi.Models.Post;
using HistoricBlog.WebApi.Models.Users;

namespace HistoricBlog.WebApi.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentService _commentService;
        public ILoggerService LoggerService { get; set; }

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        // GET: api/Comment/5
        public HttpResponseMessage Get(int id)
        {
            var result = _commentService.GetCommentsById(id);
            Mapper.Initialize(
                cfg => cfg.CreateMap<Comment,CommentViewModel>()
            );

            var comments = Mapper.Map<IEnumerable<CommentViewModel>>(result.Result);
            return Request.CreateResponse(HttpStatusCode.OK,comments);
        }

        // POST: api/Comment
        public HttpResponseMessage Post([FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/Comment/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Comment/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
