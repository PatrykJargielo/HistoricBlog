using HistoricBlog.Web.ViewModels.Posts;
using HistoricBlog.Web.ViewModels.Users.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoricBlog.Web.ViewModels.Users
{
    public class UserViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual IList<CommentViewModel> Comments { get; set; }
      
    }
}