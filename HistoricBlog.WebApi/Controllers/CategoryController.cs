using AutoMapper;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Posts.Categories;
using HistoricBlog.DAL.Posts.Categories;
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

    [RoutePrefix("api/category/{id}")]
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
        public HttpResponseMessage Post([FromBody]string name)
        {
            var getResult = _categoryService.GetCategoryByName(name);
            if (getResult.Result == null)
            {
                Category category = new Category() { Name = name };
                List<string> validationOutput = category.Validation();
                if (validationOutput.Any()) return Request.CreateResponse(HttpStatusCode.OK, validationOutput);

                var createResult = _categoryService.Create(category);
                if (createResult.IsVaild) return Request.CreateResponse(HttpStatusCode.OK);
      
                return Request.CreateResponse(HttpStatusCode.InternalServerError,"There was an error with your request");
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        

        // DELETE: api/Category/5
        public HttpResponseMessage Delete(int id)
        {
            var deleteResult = _categoryService.DeleteById(id);
            if (!deleteResult.IsVaild)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, deleteResult.Messages);

            return Request.CreateResponse(HttpStatusCode.OK);
        }



    }
}