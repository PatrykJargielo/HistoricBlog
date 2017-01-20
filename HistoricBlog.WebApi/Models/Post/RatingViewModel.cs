
using HistoricBlog.WebApi.Models.Users;

namespace HistoricBlog.WebApi.Models.Post
{
    public class RatingViewModel : BaseViewModel
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int RatingValue { get; set; }
    }
}