using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.BLL.Posts.Ratings
{
    public interface IRatingService : IGenericService<Rating>
    {
        GenericResult<IEnumerable<Rating>> GetPostRatings(int postId);
        GenericResult<Rating> GetUserRatingForPost(int postId, int userId);
    }
}
