using System;
using System.Collections.Generic;
using HistoricBlog.Web.ViewModels.Posts;
using HistoricBlog.Web.ViewModels.Users;

namespace HistoricBlog.Web.ViewModels.Post
{
    public class PostViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
 
        public string Content { get; set; }      

        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

       public virtual IList<CategoryViewModel> Categories { get; set; }

        public virtual IList<TagViewModel> Tags { get; set; }

        public virtual UserViewModel User { get; set; }
    }
}