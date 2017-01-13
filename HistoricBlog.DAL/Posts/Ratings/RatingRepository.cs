using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts.Ratings

{
    class RatingRepository: GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(HistoricBlogDbContext historicBlogDbContext) : base(historicBlogDbContext)
        {

        }
    }
}
