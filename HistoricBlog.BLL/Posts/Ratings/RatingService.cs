using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts.Ratings;

namespace HistoricBlog.BLL.Posts.Ratings
{
    public class RatingService : GenericService<Rating>, IRatingService
    {
        private IRatingRepository _ratingRepository;


        public RatingService(IRatingRepository ratingRepository) : base(ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public GenericResult<IEnumerable<Rating>> GetPostRatings(int postId)
        {
            var result = _ratingRepository.GetAll(rating => rating.PostId.Id == postId);
            result.IsVaild = true;
            return result;
        }

        public GenericResult<Rating> GetUserRatingForPost(int postId, int userId)
        {
            GenericResult<Rating> result = new GenericResult<Rating>();

            var queryResult = _ratingRepository.GetAll(rating => (rating.PostId.Id == postId) && (rating.UserId.Id == userId));
            result.Messages = result.Messages;
            result.Result = queryResult.Result.FirstOrDefault();
            result.IsVaild = true;

            return result;
        }

      
    }
}
