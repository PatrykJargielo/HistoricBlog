using Autofac;
using HistoricBlog.DAL.Configs;
using HistoricBlog.DAL.Posts;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Ratings;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Users;
using Microsoft.AspNet.Identity;

namespace HistoricBlog.WebApi.AutofacModule
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserStoreService>().As<IUserStore<User,int>>().InstancePerRequest();
            builder.RegisterType<ConfigRepository>().As<IConfigRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<PostRepository>().As<IPostRepository>().InstancePerRequest();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>().InstancePerRequest();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerRequest();
            builder.RegisterType<PermissionRepository>().As<IPermissionRepository>().InstancePerRequest();
            builder.RegisterType<TagRepository>().As<ITagRepository>().InstancePerRequest();
            builder.RegisterType<CategoriesRepository>().As<ICategoryRepository>().InstancePerRequest();
            builder.RegisterType<RatingRepository>().As<IRatingRepository>().InstancePerRequest();

        }
    }
}