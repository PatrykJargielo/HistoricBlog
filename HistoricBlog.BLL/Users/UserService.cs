using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Users;

namespace HistoricBlog.BLL.Users
{
    public class UserService : GenericService<User>,IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public override GenericResult<User> Create(User entity)
        {
            throw new System.NotImplementedException();
        }

        public override GenericResult<User> Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public override GenericResult<User> Delete(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
