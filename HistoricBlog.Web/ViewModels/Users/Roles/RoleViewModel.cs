using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoricBlog.Web.ViewModels.Users.Roles
{
    public class RoleViewModel
    {
        public class Permission : BaseViewModel
        {
            public string Name { get; set; }
            public IList<RoleViewModel> Role { get; set; }
        }
    }
}