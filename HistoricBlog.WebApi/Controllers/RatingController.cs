using AutoMapper;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Posts;
using HistoricBlog.BLL.Posts.Ratings;
using HistoricBlog.BLL.Users;
using HistoricBlog.DAL.Posts.Ratings;
using HistoricBlog.WebApi.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HistoricBlog.WebApi.Controllers
{
    [RoutePrefix("api/rating")]
    public class RatingController : ApiController
    {
        private readonly IRatingService _ratingService;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        public ILoggerService LoggerService { get; set; }



        public RatingController(IRatingService ratingService, IPostService postService, IUserService userService)
        {
            _ratingService = ratingService;
            _postService = postService;
            _userService = userService;
        }

        // GET: api/Rating/postId
        [Route("{postId}")]
        [HttpGet]
        public HttpResponseMessage Get(int postId)
        {
            var result = _ratingService.GetPostRatings(postId);
            

            if (!result.IsVaild)
                return Request.CreateResponse(HttpStatusCode.BadRequest, result.Messages);



            var ratings = Mapper.Map<IEnumerable<RatingViewModel>>(result.Result);
           
            return Request.CreateResponse(HttpStatusCode.OK, ratings);
        }


        // POST: api/Rating
        [Route("{userId}/{postId}/")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]int ratingValue, int userId, int postId)
        {
            var getRatingResult = _ratingService.GetUserRatingForPost(postId, userId);
            if (!getRatingResult.IsVaild) return Request.CreateResponse(HttpStatusCode.BadRequest, getRatingResult.Messages);        

            if (getRatingResult.Result == null)//add new rating
            {
                var getPostResult = _postService.GetById(postId);
                if (!getPostResult.IsVaild) return Request.CreateResponse(HttpStatusCode.BadRequest, getPostResult.Messages);

                var getUserResult = _userService.GetById(userId);
                if (!getUserResult.IsVaild) return Request.CreateResponse(HttpStatusCode.BadRequest, getUserResult.Messages);

                Rating category = new Rating() { UserId=getUserResult.Result, PostId=getPostResult.Result, RatingValue = ratingValue };
                var createResult = _ratingService.Create(category);
                if (createResult.IsVaild) return Request.CreateResponse(HttpStatusCode.OK, "Your rating has been added");
                return Request.CreateResponse(HttpStatusCode.BadRequest, createResult.Messages);
            }
            //update existing rating
            
                var ratingToUpdate = getRatingResult.Result;
                ratingToUpdate.RatingValue = ratingValue;
                var updateResult = _ratingService.Update(getRatingResult.Result);

                if (updateResult.IsVaild) return Request.CreateResponse(HttpStatusCode.OK, "Your rating has been updated");
                return Request.CreateResponse(HttpStatusCode.BadRequest, updateResult.Messages);
        }
    }
}
