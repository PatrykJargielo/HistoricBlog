using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HistoricBlog.DAL.Entities.BaseEntity;


namespace HistoricBlog.DAL.Entities
{
    public class Post : BaseId
    {
        [MaxLength(500)]
        public string Title { get; set; }
        [MaxLength(5000)]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        public int CategoryId { get; set; }

        public virtual IList<Tag> Tags { get; set; }
    }
}
