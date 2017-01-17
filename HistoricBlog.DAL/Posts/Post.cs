using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.DAL.Posts
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        
        public string ShortDescription { get; set; }
        [MaxLength(500)]
        [MinLength(10,ErrorMessage = "Minimal Lenght should be atleast 10")]
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public virtual IList<Category> Category { get; set; }
        public virtual IList<Tag> Tag { get; set; }
        public virtual User User { get; set; }

        public override List<string> Validation()
        {
            List<string> errorList = new List<string>();
            const int maximumShortDescriptionLength = 50;
            const int minimumShortDescriptionLength = 10;
            if(ShortDescription.Length > maximumShortDescriptionLength) errorList.Add("Your short description length is too long!");
            if(ShortDescription.Length < minimumShortDescriptionLength) errorList.Add("Your short description length is too short!");

            const int maximumDescriptionLength = 500;
            const int minimumDescriptionLength = minimumShortDescriptionLength;

            if(Description.Length > maximumDescriptionLength) errorList.Add("Your description length is too long!");
            if(Description.Length < minimumDescriptionLength) errorList.Add("Your description length is too short!");

            if (User == null) errorList.Add("There is no user assagined to this post!");
            
            if(Tag == null) errorList.Add("There is no list of tags assagined to this post!");
            
            if(Category == null) errorList.Add("There is no list of categories assagined to this post!");           

            return errorList;
        }
    }
}
