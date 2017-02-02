using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using HistoricBlog.BLL.PasswordHasher.Hasher;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Ratings;
using HistoricBlog.DAL.Users;
using HistoricBlog.DAL.Posts;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.DAL.Posts.Tags;

namespace HistoricBlog.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HistoricBlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HistoricBlogDB";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HistoricBlogDbContext context)
        {
            Role[] role = new Role[3]
            {
                new Role() {Name = "Admin"},
                new Role() {Name = "Moderator" },
                new Role() { Name = "User"}
            };

            string adminPasword = "admin";
            string notAdminPassword = "notadmin";
            HashService hashService = new HashService();
            List<User> users = new List<User>();
            users.Add(new User()
            {
                Id = 1,
                Name = "Admin",
                Surname = "Admin",
                UserName = "admin",
                Password = hashService.HashPassword(adminPasword),
                Roles = role.ToList(),
                Email = "admin@admin.pl",
                Comments = new List<Comment>(),
                Ratings = new List<Rating>()
            });



            List<Role> userRoles = new List<Role>();
            userRoles.Add(role[2]);

            users.Add(new User()
            {
                Id = 2,
                Name = "NieAdmin",
                Surname = "NieAdmin",
                UserName = "nieadmin",
                Password = hashService.HashPassword(notAdminPassword),
                Roles = userRoles,
                Email = "nieadmin@admin.pl",
                Comments = new List<Comment>(),
                Ratings = new List<Rating>()
            });

            users.Add(new User()
            {
                Id = 3,
                Name = "Admin2",
                Surname = "Admin2",
                UserName = "admin",
                Password = hashService.HashPassword(adminPasword),
                Roles = role.ToList(),
                Email = "admin2@admin.pl",
                Comments = new List<Comment>(),
                Ratings = new List<Rating>()
            });


            context.Users.AddOrUpdate(users.ToArray());

            List<Post> posts = new List<Post>();
            for (int i = 1; i < 10; i++)
            {
                Post post = new Post()
                {
                    Id = i,
                    User = users[0],
                    Title = $"Generic title {i}",
                    ShortDescription = $"Generic short description {i}",
                    Content = $"Generic content {i}",
                    PostedOn = System.DateTime.Now,
                    Tags = new List<Tag>(),
                    Categories = new List<Category>(),
                    Comments = new List<Comment>(),
                    Modified = null

                };
                Category category = new Category() { Id = i, Name = $"Category{i}", Posts = new List<Post>() { post } };
                List<Category> categories = new List<Category>() { category };

                Tag tag1 = new Tag() { Id = i, Name = $"Generic tag {i}", Posts = new List<Post>() { post } };
                Tag tag2 = new Tag() { Id = i + 10, Name = $"Generic tag {i + 10}", Posts = new List<Post>() { post } };
                List<Tag> tags = new List<Tag>() { tag1, tag2 };

                Comment comment1 = new Comment()
                {
                    Id = 1,
                    User = users[1],
                    CommentedOn = System.DateTime.Now,
                    CommentText = $"Generic troll post {i}",
                    Post = post
                };
                Comment comment2 = new Comment()
                {
                    Id = 2,
                    User = users[0],
                    CommentedOn = System.DateTime.Now,
                    CommentText = $"Generic angry admin reply for troll post {i}",
                    Post = post
                };
                List<Comment> comments = new List<Comment>() { comment1, comment2 };

                post.Tags = tags;
                post.Categories = categories;
                post.Comments = comments;
                posts.Add(post);
            }

            context.Posts.AddOrUpdate(posts.ToArray());
        }


    }
}
