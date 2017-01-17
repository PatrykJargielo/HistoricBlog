using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Users
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(HistoricBlogDbContext historicBlogDbContext) : base(historicBlogDbContext)
        {
        }
    }
}
