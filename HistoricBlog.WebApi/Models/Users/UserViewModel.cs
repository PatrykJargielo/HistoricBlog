using System.Collections.Generic;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Ratings;
using HistoricBlog.DAL.Users;
using HistoricBlog.WebApi.Models.Post;
using HistoricBlog.WebApi.Models.Users.Roles;

namespace HistoricBlog.WebApi.Models.Users
{
    public class UserViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}