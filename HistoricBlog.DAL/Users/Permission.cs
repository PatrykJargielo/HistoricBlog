using System.Collections.Generic;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Users
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public IList<Role> Role { get; set; }
    }
}