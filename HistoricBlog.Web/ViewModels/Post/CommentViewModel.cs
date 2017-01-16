using HistoricBlog.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoricBlog.Web.ViewModels.Posts
{
    public class CommentViewModel : BaseViewModel
    {
        public virtual PostViewModel Post { get; set; }
        public virtual UserViewModel User { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentedOn { get; set; }
    }
}