using Autofac;
using HistoricBlog.DAL;

namespace HistoricBlog.Web.AutofacModule
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HistoricBlogDbContext>().AsSelf();
        }
    }
}