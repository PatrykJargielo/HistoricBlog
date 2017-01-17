using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Users
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(HistoricBlogDbContext historicBlogDbContext) : base(historicBlogDbContext)
        {
        }
    }
}
