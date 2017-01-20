using System;

namespace HistoricBlog.WebApi.Models.Post
{
    public class CommentViewModel : BaseViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentedOn { get; set; }
    }
}