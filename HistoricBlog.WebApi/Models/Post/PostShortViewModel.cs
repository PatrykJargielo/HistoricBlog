using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoricBlog.WebApi.Models.Post
{
    public class PostShortViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        public virtual List<CategoryViewModel> Categories { get; set; }

        public virtual List<TagViewModel> Tags { get; set; }
    }
}