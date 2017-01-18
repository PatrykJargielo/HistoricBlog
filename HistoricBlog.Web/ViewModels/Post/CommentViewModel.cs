using HistoricBlog.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HistoricBlog.Web.ViewModels.Post;

namespace HistoricBlog.Web.ViewModels.Posts
{
    public class CommentViewModel : BaseViewModel
    {
        public string CommentText { get; set; }
        public DateTime CommentedOn { get; set; }
    }
}