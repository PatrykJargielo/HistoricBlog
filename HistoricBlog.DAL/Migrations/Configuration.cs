using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HistoricBlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HistoricBlog";
        }
    }
}
