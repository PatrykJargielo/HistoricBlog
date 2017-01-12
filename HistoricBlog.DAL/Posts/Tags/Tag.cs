using System.Collections.Generic;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts;


namespace HistoricBlog.DAL.Entities
{
    public class Tag: BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Post> Posts { get; set; }
    }
}