using Autofac;

namespace HistoricBlog.Web
{
    public class DataModule : Module
    {
        private string connectionString;

        public DataModule(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(c => new His)
        }
    }
}