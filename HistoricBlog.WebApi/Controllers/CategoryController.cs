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

            var categories = Mapper.Map<IEnumerable<CategoryViewModel>>(result.Result);
            return Request.CreateResponse(HttpStatusCode.OK, categories);
        }

     
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string name)
        {
            var getResult = _categoryService.GetCategoryByName(name);
            if (getResult.Result == null)
            {
                Category category = new Category() { Name = name };
                var createResult = _categoryService.Create(category);
                if (createResult.IsVaild) return Request.CreateResponse(HttpStatusCode.OK);
      
                return Request.CreateResponse(HttpStatusCode.OK, createResult.Messages);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest,"There is a comment with this name!");
        }

        

        // DELETE: api/Category/5
        public HttpResponseMessage Delete(int id)
        {
            var deleteResult = _categoryService.DeleteById(id);
            if (deleteResult.Result == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Category not found");

            return Request.CreateResponse(HttpStatusCode.OK);
        }



    }
}