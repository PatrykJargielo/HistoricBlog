using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Users;
using Microsoft.AspNet.Identity;

namespace HistoricBlog.BLL.Users.Identity
{
    public class ApplicationRoleManager : RoleManager<Role,int>
    {
        public ApplicationRoleManager(IRoleStore<Role, int> store) : base(store)
        {
        }
    }
}
