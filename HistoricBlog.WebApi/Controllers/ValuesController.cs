﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using HistoricBlog.BLL.Users;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.WebApi.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        public IUserService _IUserService { get; set; }
        public ValuesController(IUserService iUserService)
        {
            
        }
        // GET api/values
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var Hasrole = User.IsInRole("Admin");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
