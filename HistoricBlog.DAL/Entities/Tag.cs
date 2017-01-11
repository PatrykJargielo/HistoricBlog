using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HistoricBlog.DAL.Entities.BaseEntity;


namespace HistoricBlog.DAL.Entities
{
    public class Tag: BaseId
    {
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string UrlSlug { get; set; }
        [Required]
        public virtual string Description { get; set; }
        [Required]
        public virtual IList<Post> Posts { get; set; }
    }
}