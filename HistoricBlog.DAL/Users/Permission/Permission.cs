using System.Collections.Generic;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Users.Roles;

namespace HistoricBlog.DAL.Users.Permission
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public IList<Role> Role { get; set; }
    }
}