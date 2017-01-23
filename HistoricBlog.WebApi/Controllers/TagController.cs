using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HistoricBlog.BLL.Posts.Tags;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.WebApi.Models.Post;

namespace HistoricBlog.WebApi.Controllers
{
    public class TagController : ApiController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        // GET: api/Tag
        public HttpResponseMessage Get()
        {
            var result = _tagService.GetAll();
            var tags = Mapper.Map<IEnumerable<TagViewModel>>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, tags);
        }

        [HttpGet]
        // GET: api/Tag/5
        public HttpResponseMessage Get(int id)
        {
            var result = _tagService.GetById(id);

            if (result.Result == null) return Request.CreateResponse(HttpStatusCode.BadRequest, "Tag not found!");

            var tag = Mapper.Map<TagViewModel>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, tag);

        }

        [HttpPut]
        [HttpPost]
        // POST: api/Tag
        public HttpResponseMessage Post([FromBody] string tagName)
        {
            var result = _tagService.GetTagByName(tagName);

            if (result.Result == null)
            {
                var newTag = new Tag()
                {
                    Name = tagName
                };
                result = _tagService.Create(newTag);

                if(result.IsVaild) return Request.CreateResponse(HttpStatusCode.Created, result.Result);
            }

            var updateTag = _tagService.Update(result.Result);

            if (!result.IsVaild)
            {
                var errorMessage = result;
                return Request.CreateResponse(HttpStatusCode.BadRequest, errorMessage);
            }


            var tags = Mapper.Map<TagViewModel>(updateTag.Result);

            return Request.CreateResponse(HttpStatusCode.OK, tags);


        }

        // DELETE: api/Tag/5
        public HttpResponseMessage Delete(int id)
        {
            var result = _tagService.DeleteById(id);

            if (result.Result == null) return Request.CreateResponse(HttpStatusCode.BadRequest, "Post not found!");

            var tagToDelete = Mapper.Map<TagViewModel>(result.Result);

            return Request.CreateResponse(HttpStatusCode.OK, tagToDelete);

        }
    }
}
