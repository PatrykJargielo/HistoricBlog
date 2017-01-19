using System.Collections.Generic;
using HistoricBlog.WebApi.Models.Users.Roles;

namespace HistoricBlog.WebApi.Models.Users.Permissions
{
    public class PermissionViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public IList<RoleViewModel> Role { get; set; }
    }
}