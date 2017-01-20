using AutoMapper;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Posts.Categories;
using HistoricBlog.WebApi.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HistoricBlog.WebApi.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;
        public ILoggerService LoggerService { get; set; }

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //GET: api/Category
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var result = _categoryService.GetAll();

            if (!result.IsVaild)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Messages);
            if (result.Result.Count() == 0)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "No categories are present");

            var categories = Mapper.Map<IEnumerable<CategoryViewModel>>(result.Result);
            return Request.CreateResponse(HttpStatusCode.OK, categories);
        }

        // POST: api/Comment
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string categoryName)
        {
            

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        // DELETE: api/Category/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var getResult = _categoryService.DeleteById(id);
            if (!getResult.IsVaild)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, getResult.Messages);

            return Request.CreateResponse(HttpStatusCode.OK,"Category delete success");
        }



    }
}