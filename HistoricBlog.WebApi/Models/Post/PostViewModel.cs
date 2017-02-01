using System;
using System.Collections.Generic;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.WebApi.Models.Users;


namespace HistoricBlog.WebApi.Models.Post
{
    public class PostViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
 
        public string Content { get; set; }      

        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        public virtual List<CategoryViewModel> Categories { get; set; }

        public virtual List<TagViewModel> Tags { get; set; }

        public virtual List<CommentViewModel> Comments { get; set; }
    }
}