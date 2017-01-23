using System.Collections.Generic;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Posts.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }  

        public virtual IList<Post> Posts { get; set; }
        public override List<string> Validation()
        {
            List<string> errorsList = new List<string>();
            ValidateCategoryName(errorsList);
            return errorsList;
        }

        private void ValidateCategoryName(List<string> errorsList)
        {
            if (string.IsNullOrEmpty(Name)) errorsList.Add("There is no name in category!");

            const int maximumNameLength = 20;
            const int minimumNameLength = 3;

            bool isValidNameLength = Name.Length >= minimumNameLength && Name.Length <= maximumNameLength;
            if (!isValidNameLength)
            {
                errorsList.Add($"Name length must be between {minimumNameLength} and {maximumNameLength} characters !");
            }
        }
    }
}