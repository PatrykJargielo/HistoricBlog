using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.DAL.Posts.Ratings
{
    public class Rating : BaseEntity
    {
        public int RatingValue { get; set; }
        public virtual User UserId { get; set; }
        public virtual Post PostId { get; set; }
    }
}