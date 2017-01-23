using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Dynamic;
using System.Net.Mail;
using System.Reflection;
using System.Security.Claims;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Ratings;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using static System.Configuration.ConfigurationManager;

namespace HistoricBlog.DAL.Users
{
    public class User : BaseEntity,IUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<Rating> Ratings { get; set; }
        public virtual IList<Role> Roles { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User,int> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public override List<string> Validation()
        {
            string emailRegex = AppSettings["emailexp"];
            string loginRegex = AppSettings["loginexp"];
            string passwordRegex = AppSettings["passwordexp"];
            string credentialsRegex = AppSettings["credentialsexp"];

            var errorMessage = new List<string>();


            ValidateStringProperty(this.Name, errorMessage);
            ValidateStringProperty(this.Surname, errorMessage);
            ValidateStringProperty(this.UserName, errorMessage);

            ValidateStringWithRegex(Email, errorMessage, emailRegex);
            ValidateStringWithRegex(UserName, errorMessage, loginRegex);
            ValidateStringWithRegex(Password, errorMessage, passwordRegex);
            ValidateStringWithRegex(Name, errorMessage, credentialsRegex);
            ValidateStringWithRegex(Surname, errorMessage, credentialsRegex);
            return errorMessage;
        }

        private void ValidateStringWithRegex(string valueValidate, List<string> errorMessage, string regex)
        {
            if (string.IsNullOrEmpty(valueValidate))
            {
                errorMessage.Add($"Please provide {valueValidate}");
                return;
            }

            Match match = Regex.Match(valueValidate, regex);
            if (!match.Success)
            {
                errorMessage.Add($"Your {valueValidate} is invalid");
            }

        }

        private void ValidateStringProperty(string valueValidate, List<string> errorMessage)
        {
            
            if (string.IsNullOrEmpty(valueValidate))
            {
                errorMessage.Add($"Please provide {valueValidate}");
                return;
            }

            const int minimumLength = 3;
            const int maximumLength = 50;

            bool isInRange = valueValidate.Length >= minimumLength && valueValidate.Length <= maximumLength;
            if (!isInRange)
            {
                errorMessage.Add($"The value should be between {minimumLength} and {maximumLength}");
            }


        }


    }
}



