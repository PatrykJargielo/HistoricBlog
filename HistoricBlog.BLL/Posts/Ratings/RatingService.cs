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
    class RatingService : GenericService<Rating>, IRatingService
    {
        private IGenericRepository<Rating> _ratingRepository;

        public RatingService(IGenericRepository<Rating> ratingRepository) : base(ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

   
    }
}
