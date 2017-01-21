﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.BLL.Base;
using HistoricBlog.BLL.Logger;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.BLL.Posts
{
    public class PostService : GenericService<Post>,IPostService
    {
        private readonly IPostRepository _postRepository;

        public ILoggerService LoggerService { get; set; }

        public PostService(IPostRepository postRepository) : base(postRepository)
        {
            _postRepository = postRepository;
        }

      

        public override GenericResult<Post> Update(Post entity)
        {
            entity.Modified = DateTime.Now;
            return base.Update(entity);
        }

     

        public override GenericResult<Post> Create(Post entity)
        {
            entity.PostedOn = DateTime.Now;
            entity.Modified = entity.PostedOn;
            entity.Categories = new List<Category>();
            entity.Comments = new List<Comment>();
            entity.Tags = new List<Tag>();
            entity.PostedOn = DateTime.Now;
            entity.Modified = entity.PostedOn;
            return base.Create(entity);
        }

        public GenericResult<Comment> AddCommentToPost(Post post, string commentText)
        {
            Comment comment = new Comment();
            var result = new GenericResult<Comment>();
            result.Messages = new List<string>();

            if (post == null)
            {
                result.Messages.Add("No posts attatched to this comment");
                result.IsVaild = false;
                return result;
            }

            if (post.Comments == null)
            {
                post.Comments = new List<Comment>();
            }

            //Add
            comment.CommentText = commentText;
            comment.User = new User(); //CommentedUser get logged user
            comment.CommentedOn = DateTime.Now;
            post.Comments.Add(comment);
            _postRepository.Save();


            result.Result = comment; 
            result.IsVaild = true;
            return result;
        }
    }
}
