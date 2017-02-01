using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoricBlog.WebApi.Models.Post
{
    public class PostInputViewModel: BaseViewModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }

        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        public virtual List<string> Categories{ get; set; }

        public virtual List<string> Tags { get; set; }

    }
}