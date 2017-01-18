using HistoricBlog.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HistoricBlog.Web.ViewModels.Post;

namespace HistoricBlog.Web.ViewModels.Posts
{
    public class RatingViewModel : BaseViewModel
    {
        public int RatingValue { get; set; }
        public virtual UserViewModel UserId { get; set; }
        public virtual PostViewModel PostId { get; set; }
    }
}