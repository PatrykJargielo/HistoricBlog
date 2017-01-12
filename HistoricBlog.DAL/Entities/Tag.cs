using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HistoricBlog.DAL.Entities.BaseEntity;


namespace HistoricBlog.DAL.Entities
{
    public class Tag: BaseId
    {

        public string Name { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}