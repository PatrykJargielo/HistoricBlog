using System.Collections.Generic;
using System.Linq;
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
            entity.Comments = new List<Comment>();
            entity.Roles = new List<Role>();
            entity.Ratings = new List<Rating>();
            return base.Create(entity);
        }

        public override GenericResult<User> Update(User entity)
        {
            var dbUserResult = _userRepository.FindBy(user => user.Id == entity.Id);
            var dbUser = dbUserResult.Result.FirstOrDefault();
            if (dbUser == null)
            {
                return new GenericResult<User>();
            }
            dbUser.Email = entity.Email;
            dbUser.Login = entity.Login;
            dbUser.Name = entity.Name;
            dbUser.Surname = entity.Surname;
            dbUser.Password = entity.Password;
            return base.Update(dbUser);
        }
    }
}
