using System.Collections.Generic;
using System.Data.Entity.Migrations;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Ratings;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HistoricBlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HistoricBlog";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HistoricBlogDbContext context)
        {
            List<User> users = new List<User>();
            users.Add(new User()
            {
                Id = 1,
                Name = "Admin",
                Surname = "Admin",
                Login ="admin",
                Password = "admin",
                Roles = new List<Role>(),
                Email = "admin@admin.pl",
                Comments = new List<Comment>(),
                Ratings = new List<Rating>()
            });
            
            context.Users.AddOrUpdate(users.ToArray());
        }
    }
}
