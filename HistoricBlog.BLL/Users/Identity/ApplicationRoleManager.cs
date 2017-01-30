using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL;
using HistoricBlog.DAL.Users;
using HistoricBlog.DAL.Users.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace HistoricBlog.BLL.Users.Identity
{
    public class ApplicationRoleManager : RoleManager<Role,int>
    {
        public ApplicationRoleManager(IRoleStore<Role, int> store) : base(store)
        {
        }

        public static ApplicationRoleManager Create(
            IdentityFactoryOptions<ApplicationRoleManager> options,
            IOwinContext context)
        {
            return new ApplicationRoleManager(new ApplicationRoleStore(context.Get<HistoricBlogDbContext>()));
        }
    }
}
