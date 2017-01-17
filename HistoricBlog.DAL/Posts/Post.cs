﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.DAL.Posts
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public virtual IList<Category> Categories { get; set; }
        public virtual IList<Tag> Tags { get; set; }
        public virtual User User { get; set; }
        public virtual IList<Comment> Comments { get; set; }

        public override List<string> Validation()
        {
            List<string> errorList = new List<string>();

            ValidateTitle(errorList);
            ValidateShortDescription(errorList);
            ValidateCategoryPresence(errorList);
           
            return errorList;
        }

        private void ValidateTitle(List<string> errorList)
        {
            if(string.IsNullOrEmpty(Title)) errorList.Add("There is no title in your post!");
            const int maximumTitleLength = 50;
            const int minimumTitleLength = 10;
            if (Title.Length > maximumTitleLength) errorList.Add("Your title length is too long!");
            if (Title.Length < minimumTitleLength) errorList.Add("Your title length is too short!");

        }

        private void ValidateCategoryPresence( List<string> errorList)
        {
            if (Categories == null) errorList.Add("There is no list of categories assagined to this post!");
        }

        private void ValidateShortDescription(List<string> errorList)
        {
            if(string.IsNullOrEmpty(ShortDescription)) errorList.Add("There is no short description in your post");
            const int maximumShortDescriptionLength = 500;
            const int minimumShortDescriptionLength = 10;
            if (ShortDescription.Length > maximumShortDescriptionLength) errorList.Add("Your short description length is too long!");
            if (ShortDescription.Length < minimumShortDescriptionLength) errorList.Add("Your short description length is too short!");
        }


    }
}
