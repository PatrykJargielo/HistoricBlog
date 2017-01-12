using System;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.DAL.Posts.Comments
{
    public class Comment : BaseEntity
    {
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentedOn { get; set; }
    }
}