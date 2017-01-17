using System;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Users;
using System.Collections.Generic;

namespace HistoricBlog.DAL.Posts.Comments
{
    public class Comment : BaseEntity
    {
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentedOn { get; set; }
        public override List<string> Validation()
        {
            List<string> validationMessages = new List<string>();
           
            ValidateMaximalLength(validationMessages);
            ValidateMinimalLength(validationMessages);

            return validationMessages;
        }

        private void ValidateMaximalLength(List<string> validationMessages)
        {
            var maximalLength = 300;
            bool isValidLength = CommentText.Length < maximalLength;
            if (!isValidLength) validationMessages.Add($"Comment lenght should be less than {maximalLength}");
        }

        private void ValidateMinimalLength(List<string> validationMessages)
        {
            var minimalLength = 2;
            bool isValidLength = CommentText.Length > minimalLength;
            if (!isValidLength) validationMessages.Add($"Comment lenght should not be empty");

        }
    }
}