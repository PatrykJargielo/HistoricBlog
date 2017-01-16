using HistoricBlog.Web.ViewModels.Users.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoricBlog.Web.ViewModels.Users.Permission
{
    public class PermissionViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public IList<RoleViewModel> Role { get; set; }
    }
}