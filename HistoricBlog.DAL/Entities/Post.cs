using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HistoricBlog.DAL.Entities.BaseEntity;


namespace HistoricBlog.DAL.Entities
{
    public class Post : BaseId
    {
        [MaxLength(500), Required]
        public virtual string Title { get; set; }
        [MaxLength(5000), Required]
        public virtual string ShortDescription { get; set; }
        [MaxLength(5000), Required]
        public virtual string Description { get; set; }
        [Required]
        public virtual string UrlSlug { get; set; }
        [MaxLength(100), Required]
        public virtual bool Published { get; set; }
        [Required]
        public virtual DateTime PostedOn { get; set; }
        [Required]
        public virtual DateTime? Modified { get; set; }
        [ForeignKey("CategoryId"), Required]
        public virtual Category Category { get; set; }
        [ForeignKey("TagId"), Required]
        public virtual IList<Tag> Tags { get; set; }
    }
}
