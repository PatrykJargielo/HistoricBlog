using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace HistoricBlog.DAL.Users.Identity
{
    public class ApplicationRoleStore : IRoleStore<Role,int>
    {
        private readonly HistoricBlogDbContext _historicBlogDbContext;

        public ApplicationRoleStore(HistoricBlogDbContext historicBlogDbContext)
        {
            _historicBlogDbContext = historicBlogDbContext;
        }

        public ApplicationRoleStore()
        {
            _historicBlogDbContext = new HistoricBlogDbContext();
        }


        public void Dispose()
        {
            _historicBlogDbContext.Dispose();
        }

        public Task CreateAsync(Role role)
        {
            _historicBlogDbContext.Roles.Add(role);
            Task task = _historicBlogDbContext.SaveChangesAsync();
            return task;
        }

        public Task UpdateAsync(Role role)
        {
            _historicBlogDbContext.Roles.Attach(role);
            Task task = _historicBlogDbContext.SaveChangesAsync();
            return task;
        }

        public Task DeleteAsync(Role role)
        {
            _historicBlogDbContext.Roles.Attach(role);
            Task task = _historicBlogDbContext.SaveChangesAsync();
            return task;
        }

        public Task<Role> FindByIdAsync(int roleId)
        {
            Task<Role> task = _historicBlogDbContext.Roles.Where(role => role.Id == roleId).FirstOrDefaultAsync();
            return task;
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            Task<Role> task = _historicBlogDbContext.Roles.Where(role => role.Name == roleName).FirstOrDefaultAsync();
            return task;
        }
    }
}
