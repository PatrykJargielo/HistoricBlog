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

            if (!result.IsVaild)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Result is invalid");

            }
            if (!result.Result.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var users = Mapper.Map<IEnumerable<UserViewModel>>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, users.FirstOrDefault());
        }

        // POST: api/User
        [HttpPost]
        public HttpResponseMessage Post([FromBody]UserViewModel user)
        {
            var newUserFields= new User
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password
            };

            var result = _userService.Create(newUserFields);
            if (!result.IsVaild)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Result is invalid");

            }
            var newUser = Mapper.Map<IEnumerable<UserViewModel>>(result.Result);
            return Request.CreateResponse(HttpStatusCode.OK, newUser);
        }

        // PUT: api/User/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
            //var result = _userService.GetById(id);

            //var newUserFields = new User()
            //{
            //    Name = user.Name,
            //    Surname = user.Surname,
            //    Email = user.Email,
            //    Login = user.Login,
            //    Password = user.Password
            //};

            ////result = _userService.Create(newUserFields);
            //if (!result.IsVaild)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Result is invalid");

            //}
            //var newUser = Mapper.Map<IEnumerable<UserViewModel>>(result.Result);
            //return Request.CreateResponse(HttpStatusCode.OK, newUser);
        }

        // DELETE: api/User/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var result = _userService.DeleteById(id);

            if (result.IsVaild)
            {
                var userDeleted = Mapper.Map<IEnumerable<UserViewModel>>(result.Result);
                return Request.CreateResponse(HttpStatusCode.OK, userDeleted);
            }

            var messages = string.Concat(result.Messages.ToArray());
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, messages);
        }
    }
}
