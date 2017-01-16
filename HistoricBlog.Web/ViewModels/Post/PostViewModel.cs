﻿using HistoricBlog.BLL.Posts.Tags;
using HistoricBlog.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoricBlog.Web.ViewModels.Posts
{
    public class PostViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
 
        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        public virtual IList<CategoryViewModel> Category { get; set; }

        public virtual IList<TagViewModel> Tag { get; set; }

        public virtual UserViewModel User { get; set; }
    }
}