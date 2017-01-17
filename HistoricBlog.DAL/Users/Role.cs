using System.Collections.Generic;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Users
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Permission> Permission { get; set; }

        public override List<string> Validation()
        {
            List<string> errorList = new List<string>();
            return errorList;
        }
    }
}
