using System.Collections.Generic;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts.Tags
{
    public class Tag: BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Post> Posts { get; set; }
        public override List<string> Validation()
        {
            return Validation();
        }
    }
}