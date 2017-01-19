using System.Collections.Generic;
using HistoricBlog.BLL.Base;
using HistoricBlog.BLL.Logger;
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
        public GenericResult<IEnumerable<User>> GetUsersByName(string userName)
        {
            return _userRepository.FindBy(user => user.Name == userName);
        }
    }
}
