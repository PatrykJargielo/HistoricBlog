﻿using System.Data.Entity;
using HistoricBlog.DAL.Posts;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Ratings;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.DAL
{
    public class HistoricBlogDbContext : DbContext
    {
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission>Permissions { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Comment>Comments { get; set; }

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
