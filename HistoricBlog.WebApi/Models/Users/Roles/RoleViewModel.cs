using System.Collections.Generic;
using HistoricBlog.WebApi.Models.Users.Permissions;

namespace HistoricBlog.WebApi.Models.Users.Roles
{
    public class RoleViewModel : BaseViewModel
    {

        public string Name { get; set; }
        public IList<PermissionViewModel> Permission { get; set; }
        }
}