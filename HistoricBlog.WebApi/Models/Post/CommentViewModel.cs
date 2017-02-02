using System;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.WebApi.Models.Post
{
    public class CommentViewModel : BaseViewModel
    {
        public virtual string UserName { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentedOn { get; set; }
    }
}