using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Configs
{
    public class ConfigRepository : GenericRepository<Config>, IConfigRepository
    {
        public ConfigRepository(HistoricBlogDbContext historicBlogDbContext) : base(historicBlogDbContext)
        {
        }
    }
}
