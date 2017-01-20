using System.Collections.Generic;
using HistoricBlog.BLL.Base;
using HistoricBlog.BLL.Logger;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Ratings;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.BLL.Users
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public override GenericResult<User> Create(User entity)
        {
            entity.Comments=new List<Comment>();
            entity.Roles=new List<Role>();
            entity.Ratings=new List<Rating>();
            return base.Create(entity);
        }
    }
}
