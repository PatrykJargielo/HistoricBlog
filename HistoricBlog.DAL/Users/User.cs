using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Ratings;
using HistoricBlog.DAL.Users.Roles;

namespace HistoricBlog.DAL.Users
{
    public class User : BaseEntity
    {
        [MinLength(5,ErrorMessage = "Za krotki")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public virtual IList<Comment> Comment { get; set; }
        public virtual IList<Rating> Rating { get; set; }
        public virtual IList<Role> Role { get; set; }

        public override List<string> Validation()
        {
            var erroMessage =  new List<string>();

            if (string.IsNullOrEmpty(Name))
            {
                erroMessage.Add("Zły name");
            }

            return erroMessage;

        }
    }
}
