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
        private readonly IUserRepository _userRepository;

        public ILoggerService LoggerService { get; set; }

        public PostService(IPostRepository postRepository,IUserRepository userRepository) : base(postRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
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

        public GenericResult<IEnumerable<Post>> GetPostsByTitle(string Name)
        {
            var result = _postRepository.FindBy(post => post.Title.Contains(Name));
            result.IsVaild = true;
            return result;
        }
    }
}
