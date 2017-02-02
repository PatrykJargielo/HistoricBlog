using Autofac;
using HistoricBlog.BLL.Config;
using HistoricBlog.BLL.Logger;
using HistoricBlog.BLL.Posts;
using HistoricBlog.BLL.Posts.Categories;
using HistoricBlog.BLL.Posts.Comments;
using HistoricBlog.BLL.Posts.Ratings;
using HistoricBlog.BLL.Posts.Tags;
using HistoricBlog.BLL.Users;
using HistoricBlog.BLL.Users.Identity;
using HistoricBlog.DAL.Users;
using Microsoft.AspNet.Identity;

namespace HistoricBlog.WebApi.AutofacModule
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationUserManager>().As<UserManager<User, int>>();
            builder.RegisterType<UserService>().As<IUserService>().PropertiesAutowired();
            builder.RegisterType<PostService>().As<IPostService>().PropertiesAutowired();
            builder.RegisterType<CommentService>().As<ICommentService>().PropertiesAutowired();
            builder.RegisterType<TagService>().As<ITagService>().PropertiesAutowired();
            builder.RegisterType<CategoryService>().As<ICategoryService>().PropertiesAutowired();
            builder.RegisterType<RatingService>().As<IRatingService>().PropertiesAutowired();
            builder.RegisterType<LoggerService>().As<ILoggerService>();
            builder.RegisterType<ConfigurationManager>().As<IConfigurationManager>();
            builder.RegisterType<ConfigurationService>().As<IConfigurationService>().PropertiesAutowired();
        }
    }
}