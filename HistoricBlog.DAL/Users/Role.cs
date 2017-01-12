using System.Collections.Generic;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Users
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public IList<Permission> Permission { get; set; }
    }
}
