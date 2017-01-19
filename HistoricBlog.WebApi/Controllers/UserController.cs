using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Users;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Users;
using HistoricBlog.WebApi.Models.Post;
using HistoricBlog.WebApi.Models.Users;

namespace HistoricBlog.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private IUserService _userService;
        public ILoggerService LoggerService { get; set; }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/User
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var result = _userService.GetById(id);
            Mapper.Initialize(x => x.CreateMap<User, UserViewModel>());

      
            if (!result.IsVaild)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Result is invalid");

            }
            if (!result.Result.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            var users = Mapper.Map<IEnumerable<UserViewModel>>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
            Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
            Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
