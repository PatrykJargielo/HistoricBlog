using System.Collections.Generic;
using HistoricBlog.DAL.Base;
using Microsoft.AspNet.Identity;

namespace HistoricBlog.DAL.Users
{
    public class Role : BaseEntity, IRole<int>
    {
        public string Name { get; set; }

        public override List<string> Validation()
        {
            List<string> errorList = new List<string>();
            return errorList;
        }

    }
}
