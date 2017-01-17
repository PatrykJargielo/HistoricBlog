using System.Collections.Generic;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts.Tags
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Post> Posts { get; set; }

        public override List<string> Validation()
        {
            var errorMessage = new List<string>();
            ValidateTagName(errorMessage);
            ValidateTagNameLength(errorMessage);

            return errorMessage;
        }

        private void ValidateTagName(List<string> errorMessage)
        {
            if (string.IsNullOrEmpty(Name))
            {
                errorMessage.Add("Tag name cannot be empty");
            }

        }

        private void ValidateTagNameLength(List<string> errorMessage)
        {
            const int maximumNameLength = 20;
            const int minimumNameLength = 3;

            bool isValidNameLength = Name.Length >= minimumNameLength && Name.Length <= maximumNameLength;
            if (!isValidNameLength)
            {
                errorMessage.Add($"Name length must be between {minimumNameLength} and {maximumNameLength} characters ");
            }
        }
    }
}