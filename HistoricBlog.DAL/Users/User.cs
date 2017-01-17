using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net.Mail;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Ratings;
using System.Text.RegularExpressions;

namespace HistoricBlog.DAL.Users
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<Rating> Ratings { get; set; }
        public virtual IList<Role> Roles { get; set; }
       

        public override List<string> Validation()
        {
            var errorMessage = new List<string>();

            ValidatePropertyExist(this.Name, errorMessage);
            ValidatePropertyExist(this.Surname, errorMessage);
            ValidatePropertyExist(this.Login, errorMessage);

            ValidatePropertyLength(this.Name, errorMessage);
            ValidatePropertyLength(this.Surname, errorMessage);
            ValidatePropertyLength(this.Login, errorMessage);

            ValidateRegExCredentials(this.Name, errorMessage);
            ValidateRegExCredentials(this.Surname, errorMessage);

            ValidateRegExLogIn(this.Login, errorMessage);
            ValidateRegPassword(this.Password, errorMessage);

            ValidateEmail(errorMessage);
      
            return errorMessage;
        }

        private void ValidateEmail(List<string> errorMessage)
        {
            try
            {
                var mailAddress = new MailAddress(this.Email);
            }
            catch (Exception)
            {

                errorMessage.Add("Your e-mail is not correct");
            }
        }

        private void ValidatePropertyLength(string valueValidate, List<string> errorMessage)
        {
            const int minimumLength = 3;
            const int maximumLength = 50;

            if (valueValidate.Length < minimumLength && valueValidate.Length > maximumLength)
            {
                errorMessage.Add($"The value should be between {minimumLength} and {maximumLength}");
            }
        }

        private void ValidatePropertyExist(string valueValidate, List<string> errorMessage)
        {
            if (String.IsNullOrEmpty(valueValidate))
            {
                errorMessage.Add($"Please provide {valueValidate}");
            }
        }

        private void ValidateRegExCredentials(string valueValidate, List<string> errorMessage)
        {
            Match match = Regex.Match(valueValidate, @"[A-Za-z]");
            if (!match.Success)
            {
                errorMessage.Add($"Your {valueValidate} is invalid");
            }
        }

        private void ValidateRegExLogIn(string valueValidate, List<string> errorMessage)
        {
            Match match = Regex.Match(valueValidate, @"^[a-zA-Z0-9]([._](?![._])|[a-zA-Z0-9]){6,18}[a-zA-Z0-9]$");
            if (!match.Success)
            {
                errorMessage.Add($"Your {valueValidate} is invalid");
            }
        }
        private void ValidateRegPassword(string valueValidate, List<string> errorMessage)
        {
            Match match = Regex.Match(valueValidate, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$");
            if (!match.Success)
            {
                errorMessage.Add($"Your {valueValidate} is invalid");
            }
        }
    }
}

    

