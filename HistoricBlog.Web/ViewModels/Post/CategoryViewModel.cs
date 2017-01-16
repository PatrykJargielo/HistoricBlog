using HistoricBlog.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoricBlog.Web.ViewModels.Posts
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public virtual IList<PostViewModel> Posts { get; set; }
    }
}