using HistoricBlog.BLL.Base;
using HistoricBlog.BLL.Logger;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Users;
using HistoricBlog.DAL.Users.Roles;

namespace HistoricBlog.BLL.Users
{
    public class UserService : GenericService<User>,IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoggerService _loggerService;

        public UserService(IUserRepository userRepository, ILoggerService loggerService) : base(userRepository)
        {
            _userRepository = userRepository;
            _loggerService = loggerService;
        }

        public override GenericResult<User> Create(User user)
        {
           
            var result = new GenericResult<User>();
            Create(user, result);
            return result;
        }

        private static GenericResult<User> ValidateUser(User user)
        {
            var result = new GenericResult<User>();
            return result;
        }


        //    if (user.Email is not valid)
        //    {
        //        result.Message = "E-mail sie nie zgadza";
        //        return result;
        //    }


        //    return result;
        //}

        public override GenericResult<User> Update(User userUpdate)
        {
            var genericResult = new GenericResult<User>();
            return Update(userUpdate, genericResult);
        }

        public override GenericResult<User> Delete(User userDelete)
        {
            var genericResult = new GenericResult<User>();
            return Update(userDelete, genericResult);
        }
    }
}
