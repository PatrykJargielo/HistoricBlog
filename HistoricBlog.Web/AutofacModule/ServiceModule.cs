
using Autofac;
using HistoricBlog.BLL.Posts;
using HistoricBlog.BLL.Posts.Categories;
using HistoricBlog.BLL.Posts.Comments;
using HistoricBlog.BLL.Posts.Ratings;
using HistoricBlog.BLL.Posts.Tags;
using HistoricBlog.BLL.Users;

namespace HistoricBlog.Web.AutofacModule
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<PostService>().As<IPostService>();
            builder.RegisterType<CommentService>().As<ICommentService>();
         
            builder.RegisterType<TagService>().As<ITagService>().InstancePerRequest();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerRequest();
            builder.RegisterType<RatingService>().As<IRatingService>().InstancePerRequest();
        }
    }
}