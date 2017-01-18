using HistoricBlog.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HistoricBlog.Web.ViewModels.Post;

namespace HistoricBlog.Web.ViewModels.Posts
{
    public class TagViewModel : BaseViewModel
    {
        public string Name { get; set; }
     //   public virtual IList<PostViewModel> Posts { get; set; }
    }
}