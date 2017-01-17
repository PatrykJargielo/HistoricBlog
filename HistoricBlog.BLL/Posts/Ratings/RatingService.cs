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

        public override GenericResult<Rating> Update(Rating entity)
        {
            var result = new GenericResult<Rating>();
            return Update(entity, result);

        }

        public override GenericResult<Rating> Delete(Rating entity)
        {
            var result = new GenericResult<Rating>();
            return Delete(entity, result);
        }

        public override GenericResult<Rating> Create(Rating entity)
        {
            var result = new GenericResult<Rating>();

            return Create(entity, result);
        }
    }
}
