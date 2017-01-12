using System.Collections.Generic;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }  

        public virtual IList<Post> Posts { get; set; }
    }
}