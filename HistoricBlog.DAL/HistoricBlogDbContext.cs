using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Entities;

namespace HistoricBlog.DAL
{
    class HistoricBlogDbContext : DbContext
    {
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        public HistoricBlogDbContext()
            : base("HistoricBlog")
        {

        }
        public HistoricBlogDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
