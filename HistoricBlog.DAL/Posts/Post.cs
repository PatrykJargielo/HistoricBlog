using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.DAL.Posts
{
    public class Post : BaseEntity
    {
        [MaxLength(500)]
        public string Title { get; set; }
        [MaxLength(5000)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public virtual IList<Category> Category { get; set; }
        public virtual IList<Tag> Tag { get; set; }
        public virtual User User { get; set; }
    }
}
