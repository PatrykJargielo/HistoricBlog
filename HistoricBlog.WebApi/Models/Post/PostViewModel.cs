using System;
using System.Collections.Generic;
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

        public virtual IList<CategoryViewModel> Categories { get; set; }

        public virtual IList<TagViewModel> Tags { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserSurname { get; set; }

        
    }
}