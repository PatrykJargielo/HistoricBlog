using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Users;
using HistoricBlog.DAL.Base;
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
            if (result.Result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var users = Mapper.Map<UserViewModel>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        // POST: api/User
        [HttpPost]
        [HttpPut]
        public HttpResponseMessage Post([FromBody]UserViewModel user)
        {
            var newUserFields= new User
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.Login,
                Password = user.Password,
                Id = user.Id
            };
            var result=new GenericResult<User>();
            if (user.Id==0)
            {

                result = _userService.Create(newUserFields);
                if (!result.IsVaild)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Result is invalid");
                }
                var newUser = Mapper.Map<UserViewModel>(result.Result);
                return Request.CreateResponse(HttpStatusCode.OK, newUser);
            }

            result = _userService.Update(newUserFields);
            if (result.Result == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User not found!");
            }

            if (!result.IsVaild)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Result is invalid");
            }
            var updatedUser = Mapper.Map<UserViewModel>(result.Result);
            return Request.CreateResponse(HttpStatusCode.OK, updatedUser);


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
