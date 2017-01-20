using System;

namespace HistoricBlog.WebApi.Models.Post
{
    public class CommentViewModel : BaseViewModel
    {
        public string CommentText { get; set; }
        public DateTime CommentedOn { get; set; }
    }
}