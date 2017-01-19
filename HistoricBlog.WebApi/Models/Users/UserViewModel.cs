using System.Collections.Generic;
using HistoricBlog.WebApi.Models.Post;

namespace HistoricBlog.WebApi.Models.Users
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