using System.Collections.Generic;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Users.Roles
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public IList<Permission.Permission> Permission { get; set; }
        public override List<string> Validation()
        {
            return Validation();
        }
    }
}
