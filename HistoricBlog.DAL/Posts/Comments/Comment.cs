using System;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Users;
using System.Collections.Generic;

namespace HistoricBlog.DAL.Posts.Comments
{
    public class Comment : BaseEntity
    {
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentedOn { get; set; }
        public override List<string> Validation()
        {
            return Validation();
        }
    }
}