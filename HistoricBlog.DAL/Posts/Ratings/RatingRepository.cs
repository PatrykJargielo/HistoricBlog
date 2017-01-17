using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts.Ratings

{
    public class RatingRepository: GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(HistoricBlogDbContext historicBlogDbContext) : base(historicBlogDbContext)
        {

        }
    }
}
