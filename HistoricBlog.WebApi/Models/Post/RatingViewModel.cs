
using HistoricBlog.WebApi.Models.Users;

namespace HistoricBlog.WebApi.Models.Post
{
    public class RatingViewModel : BaseViewModel
    {
        public int RatingValue { get; set; }
        public virtual UserViewModel UserId { get; set; }
        public virtual PostViewModel PostId { get; set; }
    }
}