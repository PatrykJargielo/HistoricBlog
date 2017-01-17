using System.Collections.Generic;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Users
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Role> Role { get; set; }

        public override List<string> Validation()
        {
            List<string> errorList = new List<string>();
            return errorList;
        }
    }
}