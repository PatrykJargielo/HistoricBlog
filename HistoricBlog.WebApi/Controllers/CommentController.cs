using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.XPath;
using AutoMapper;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Posts.Comments;
using HistoricBlog.BLL.Users;
using HistoricBlog.DAL.Base;
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
            var result = _commentService.GetById(id);
            Mapper.Initialize(
                cfg => { cfg.CreateMap<Comment, CommentViewModel>();
                    cfg.CreateMap<User, UserInfoModel>();
                });
   
            if (!result.IsVaild)
            {
                var messages = string.Concat(result.Messages.ToArray());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, messages);
            }

            var comments = Mapper.Map<IEnumerable<CommentViewModel>>(result.Result);
            
            return Request.CreateResponse(HttpStatusCode.OK,comments);
        }

        [HttpPost]
        // POST: api/Comment
        public HttpResponseMessage Post(int id,[FromBody]string commentText)
        {
            var result = new GenericResult<Comment>();
            var comment = new Comment()
            {
                Id = id,
                CommentText = commentText
            };

            Mapper.Initialize(
               cfg => { cfg.CreateMap<Comment, CommentViewModel>();
                   cfg.CreateMap<User, UserInfoModel>();
               }
           );

            if (id == 0)
            {
                
                result = _commentService.Update(comment);
              
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            if (!result.IsVaild)
            {
                var messages = string.Concat(result.Messages.ToArray());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, messages);
            }

            
            result = _commentService.Create(comment);
          
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        // DELETE: api/Comment/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
