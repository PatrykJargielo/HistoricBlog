using AutoMapper;
using HistoricBlog.DAL.Posts;
using HistoricBlog.DAL.Posts.Categories;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Ratings;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.DAL.Users;
using HistoricBlog.WebApi.Models.Post;
using HistoricBlog.WebApi.Models.Users;
using HistoricBlog.WebApi.Models.Users.Permissions;
using HistoricBlog.WebApi.Models.Users.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HistoricBlog.AutoMapper.App_Start
{
    public class AutoMapperConfig
    {
        public static void SetUpAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostViewModel,Post >();
                cfg.CreateMap<Comment, CommentViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<Rating, RatingViewModel>();
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<Role, RoleViewModel>();
                cfg.CreateMap<Permission, PermissionViewModel>();
            });
        }
    }
}