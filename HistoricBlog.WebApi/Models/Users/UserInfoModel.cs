using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoricBlog.WebApi.Models.Users
{
    public class UserInfoModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        
    }
}