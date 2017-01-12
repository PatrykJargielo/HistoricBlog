using System.Collections.Generic;
using System.Data.Entity.Migrations;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HistoricBlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HistoricBlog";
        }

        protected override void Seed(HistoricBlogDbContext context)
        {
            List<User> Users = new List<User>();
            Users.Add(new User()
            {
                Id = 1,
                Name = "Admin",
                Surname = "Admin",
                Login ="admin",
                Password = "admin",
                Role = null,
                Email = "admin@admin.pl",
                Comment = null,
                Rating = null
            });
            
            context.Users.AddOrUpdate(Users.ToArray());
        }
    }
}
