using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HistoricBlog.BLL.Posts.Comments;

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
        // GET: api/Comment
        public IEnumerable<string> Get()
        {
            
            var result = _commentService.GetAll().Result.FirstOrDefault();
           
            return new string[] { "value1", "value2" };
        }

        // GET: api/Comment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Comment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Comment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comment/5
        public void Delete(int id)
        {
        }
    }
}
