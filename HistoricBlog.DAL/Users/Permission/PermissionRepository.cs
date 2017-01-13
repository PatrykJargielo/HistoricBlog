using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Users.Permission;

namespace HistoricBlog.DAL.Users
{
    class PermissionRepository : GenericRepository<Permission.Permission>, IPermissionRepository
    {
        public PermissionRepository(HistoricBlogDbContext historicBlogDbContext) : base(historicBlogDbContext)
        {
        }
    }
}
